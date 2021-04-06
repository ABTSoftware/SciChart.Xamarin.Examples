using System;

namespace Xamarin.Examples.Demo.Showcase.AudioAnalyzer
{
    /**
      * FFT implementation based on code from
      * http://stackoverflow.com/documentation/algorithm/8683/fast-fourier-transform/27088/radix-2-fft
      */
    public class Radix2FFT
    {
        private readonly int _n;
        private readonly int _m;
        private readonly int _mm1;

        public readonly int FftSize;

        private readonly Complex[] _x;
        private readonly Complex[] _dft;
        private readonly double _twoPiN;

        private readonly Complex _wn = new Complex();
        private readonly Complex _temp = new Complex();

        public Radix2FFT(int n)
        {
            this._n = n;
            this._m = (int)Math.Log(n, 2d);

            if (Math.Pow(2, _m) != n)
                throw new InvalidOperationException("n should be with power of 2");

            this.FftSize = n / 2;
            this._twoPiN = Math.PI * 2 / n;    // constant to save computational time.  = 2*PI / N
            this._mm1 = _m - 1;

            this._x = new Complex[n];
            this._dft = new Complex[n];

            for (int i = 0; i < n; i++)
            {
                _x[i] = new Complex();
                _dft[i] = new Complex();
            }
        }

        public void Run(double[] re, double[] im)
        {
            // init input values
            for (int i = 0; i < _n; i++)
            {
                var complex = _x[i];
                complex.Re = re[i];
                complex.Im = im[i];
            }

            // perform fft
            Rad2FFT(_x, _dft);

            for (int i = 0; i < _n; i++)
            {
                var complex = _dft[i];
                re[i] = complex.Re;
                im[i] = complex.Im;
            }
        }

        public void Run(short[] input, double[] output)
        {
            if (input.Length != _n) throw new InvalidOperationException();

            for (int i = 0; i < _n; i++)
            {
                _x[i].Re = input[i];
                _x[i].Im = 0;
            }

            Rad2FFT(_x, _dft);

            for (int i = 0; i < FftSize; i++)
            {
                output[i] = CalculateOutputValue(_dft[i]);
            }
        }

        private double CalculateOutputValue(Complex complex)
        {
            double magnitude = Math.Sqrt(complex.Re * complex.Re + complex.Im * complex.Im);

            // convert to magnitude to dB
            return 20 * Math.Log10(magnitude / _n);
        }

        private void Rad2FFT(Complex[] x, Complex[] DFT)
        {
            int BSep;                  // BSep is memory spacing between butterflies
            int BWidth;                // BWidth is memory spacing of opposite ends of the butterfly
            int P;                     // P is number of similar Wn's to be used in that stage
            int iaddr;                 // bitmask for bit reversal
            int ii;                    // Integer bitfield for bit reversal (Decimation in Time)

            int DFTindex = 0;          // Pointer to first elements in DFT array


            // Decimation In Time - x[n] sample sorting
            for (int i = 0; i < _n; i++, DFTindex++)
            {
                var pX = x[i];        // Calculate current x[n] from index i.
                ii = 0;                         // Reset new address for DFT[n]
                iaddr = i;                      // Copy i for manipulations
                for (int l = 0; l < _m; l++)     // Bit reverse i and store in ii...
                {
                    if ((iaddr & 0x01) != 0)    // Detemine least significant bit
                        ii += (1 << (_mm1 - l)); // Increment ii by 2^(M-1-l) if lsb was 1
                    iaddr >>= 1;                // right shift iaddr to test next bit. Use logical operations for speed increase
                    if (iaddr == 0)
                        break;
                }

                var dft = DFT[ii];    // Calculate current DFT[n] from bit reversed index ii
                dft.Re = pX.Re;                 // Update the complex array with address sorted time domain signal x[n]
                dft.Im = pX.Im;                 // NB: Imaginary is always zero
            }

            // FFT Computation by butterfly calculation
            for (int stage = 1; stage <= _m; stage++) // Loop for M stages, where 2^M = N
            {
                BSep = (int)(Math.Pow(2, stage));  // Separation between butterflies = 2^stage
                P = _n / BSep;                       // Similar Wn's in this stage = N/Bsep
                BWidth = BSep / 2;                  // Butterfly width (spacing between opposite points) = Separation / 2.

                for (int j = 0; j < BWidth; j++) // Loop for j calculations per butterfly
                {
                    if (j != 0)              // Save on calculation if R = 0, as WN^0 = (1 + j0)
                    {
                        _wn.Re = Math.Cos(_twoPiN * P * j);     // Calculate Wn (Real and Imaginary)
                        _wn.Im = -Math.Sin(_twoPiN * P * j);
                    }

                    // HiIndex is the index of the DFT array for the top value of each butterfly calc
                    for (int HiIndex = j; HiIndex < _n; HiIndex += BSep) // Loop for HiIndex Step BSep butterflies per stage
                    {
                        var pHi = DFT[HiIndex];                  // Point to higher value
                        var pLo = DFT[HiIndex + BWidth];         // Point to lower value

                        if (j != 0)                            // If exponential power is not zero...
                        {
                            // Perform complex multiplication of LoValue with Wn
                            _temp.Re = (pLo.Re * _wn.Re) - (pLo.Im * _wn.Im);
                            _temp.Im = (pLo.Re * _wn.Im) + (pLo.Im * _wn.Re);

                            // Find new LoValue (complex subtraction)
                            pLo.Re = pHi.Re - _temp.Re;
                            pLo.Im = pHi.Im - _temp.Im;

                            // Find new HiValue (complex addition)
                            pHi.Re = (pHi.Re + _temp.Re);
                            pHi.Im = (pHi.Im + _temp.Im);
                        }
                        else
                        {
                            _temp.Re = pLo.Re;
                            _temp.Im = pLo.Im;

                            // Find new LoValue (complex subtraction)
                            pLo.Re = pHi.Re - _temp.Re;
                            pLo.Im = pHi.Im - _temp.Im;

                            // Find new HiValue (complex addition)
                            pHi.Re = (pHi.Re + _temp.Re);
                            pHi.Im = (pHi.Im + _temp.Im);
                        }
                    }
                }
            }
        }

        class Complex
        {
            public double Re, Im;
        }
    }
}