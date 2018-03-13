using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AudioToolbox;
using System.Numerics;
using System.Linq;
using System.Diagnostics;
using scichartshowcase.iOS.DependencyServices.AudioService;
using scichartshowcase.Services.AudioService;
using AForge.Math;

[assembly: Xamarin.Forms.Dependency(typeof(AudioService))]
namespace scichartshowcase.iOS.DependencyServices.AudioService
{
    public class AudioService : IAudioService
    {
        InputAudioQueue inputQueue;
        public event EventHandler samplesUpdated;

        public void StartRecord()
        {
            var audioFormat = AudioStreamBasicDescription.CreateLinearPCM();
            inputQueue = new InputAudioQueue(audioFormat);

            inputQueue.InputCompleted += InputQueueInputCompleted;
            var bufferByteSize = 2048 * audioFormat.BytesPerPacket;

            IntPtr bufferPtr;
            for (var index = 0; index < 3; index++)
            {
                inputQueue.AllocateBufferWithPacketDescriptors(bufferByteSize, 2048, out bufferPtr);
                inputQueue.EnqueueBuffer(bufferPtr, bufferByteSize, null);
            }

            inputQueue.Start();
        }

        void InputQueueInputCompleted(object sender, InputCompletedEventArgs e)
        {
            var buffer = (AudioQueueBuffer)Marshal.PtrToStructure(e.IntPtrBuffer, typeof(AudioQueueBuffer));

            var status = inputQueue.EnqueueBuffer(e.IntPtrBuffer, e.PacketDescriptions);

            if (status == AudioQueueStatus.Ok)
            {
                samplesUpdated(this, new SamplesUpdatedEventArgs(AudioQueueBufferToDoubleArray(buffer)));
            }
        }

        int[] AudioQueueBufferToDoubleArray(AudioQueueBuffer audioQueueBuffer)
        {
            var audioData = new int[audioQueueBuffer.PacketDescriptionCount];
            Marshal.Copy(audioQueueBuffer.AudioData, audioData, 0, audioQueueBuffer.PacketDescriptionCount);

            return audioData;
        }

        public int[] FFT(int[] y)
        {
            var input = new AForge.Math.Complex[y.Length];

            for (int i = 0; i < y.Length; i++)
            {
                input[i] = new AForge.Math.Complex(y[i], 0);
            }

            FourierTransform.FFT(input, FourierTransform.Direction.Forward);

            var result = new int[y.Length / 2];

            // getting magnitude
            for (int i = 0; i < y.Length / 2 - 1; i++)
            {
                var current = Math.Sqrt(input[i].Re * input[i].Re + input[i].Im * input[i].Im);
                current = Math.Log10(current) * 10;
                result[i] = (int)current;
            }

            return result;
        }

        public void StopRecord()
        {
            inputQueue.Stop(true);
        }
    }
}