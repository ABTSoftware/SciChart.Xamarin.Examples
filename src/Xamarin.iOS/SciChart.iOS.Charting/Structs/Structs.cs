using System;
using System.Runtime.InteropServices;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using SciChart;

namespace SciChart.iOS.Charting
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SCIGenericType
    {
        public SCIDataType type;

        private ulong data;

        private static DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public SCIGenericType(sbyte val) : this()
        {
            data = 0;
            type = SCIDataType.None;
            charData = val;
        }

        public SCIGenericType(short val)
        {
            data = 0;
            type = SCIDataType.None;
            shortData = val;
        }

        public SCIGenericType(int val)
        {
            data = 0;
            type = SCIDataType.None;
            intData = val;
        }

        public SCIGenericType(long val)
        {
            data = 0;
            type = SCIDataType.None;
            longData = val;
        }

        public SCIGenericType(float val)
        {
            data = 0;
            type = SCIDataType.None;
            floatData = val;
        }

        public unsafe SCIGenericType(double val)
        {
            data = 0;
            type = SCIDataType.None;
            doubleData = val;
        }

        public SCIGenericType(DateTime val)
        {
            data = 0;
            type = SCIDataType.None;
            dateTimeData = val;
        }

        public unsafe SCIGenericType(IntPtr intPtr, SCIDataType arrayType)
        {
            data = 0;
            fixed (ulong* ptr = &data) {
                *(void**)ptr = (void*)intPtr;
                type = arrayType;
            }
        }

        public unsafe sbyte charData
        {
            get {
                if (type == SCIDataType.Byte) {
                    fixed (ulong* ptr = &data) {
                        return *(sbyte*)ptr;
                    }
                } else if (type == SCIDataType.Int16) {
                    fixed (ulong* ptr = &data) {
                        return (sbyte)*(short*)ptr;
                    }
                } else if (type == SCIDataType.Int32) {
                    fixed (ulong* ptr = &data) {
                        return (sbyte)*(int*)ptr;
                    }
                } else if (type == SCIDataType.Int64) {
                    fixed (ulong* ptr = &data) {
                        return (sbyte)*(long*)ptr;
                    }
                } else if (type == SCIDataType.Float) {
                    fixed (ulong* ptr = &data) {
                        return (sbyte)*(float*)ptr;
                    }
                } else if (type == SCIDataType.Double) {
                    fixed (ulong* ptr = &data) {
                        return (sbyte)*(double*)ptr;
                    }
                } else if (type == SCIDataType.DateTime) {
                    fixed (ulong* ptr = &data) {
                        double secondsSince1970 = *(double*)ptr;
                        return (sbyte)secondsSince1970;
                    }
                } else {
                    return 0;
                }
            }
            set {
                type = SCIDataType.Byte;
                fixed (ulong* ptr = &data) {
                    *(sbyte *) ptr = value;
                }
            }
        }

        public unsafe short shortData 
        {
            get {
                if (type == SCIDataType.Byte) {
                    fixed (ulong* ptr = &data) {
                        return *(sbyte*)ptr;
                    }
                } else if (type == SCIDataType.Int16) {
                    fixed (ulong* ptr = &data) {
                        return *(short*)ptr;
                    }
                } else if (type == SCIDataType.Int32) {
                    fixed (ulong* ptr = &data) {
                        return (short)*(int*)ptr;
                    }
                } else if (type == SCIDataType.Int64) {
                    fixed (ulong* ptr = &data) {
                        return (short)*(long*)ptr;
                    }
                } else if (type == SCIDataType.Float) {
                    fixed (ulong* ptr = &data) {
                        return (short)*(float*)ptr;
                    }
                } else if (type == SCIDataType.Double) {
                    fixed (ulong* ptr = &data) {
                        return (short)*(double*)ptr;
                    }
                } else if (type == SCIDataType.DateTime) {
                    fixed (ulong* ptr = &data) {
                        double secondsSince1970 = *(double*)ptr;
                        return (short)secondsSince1970;
                    }
                } else {
                    return 0;
                }
            }
            set {
                type = SCIDataType.Int16;
                fixed (ulong* ptr = &data) {
                    *(short *) ptr = value;
                }
            }
        }

        public unsafe int intData
        {
            get {
                if (type == SCIDataType.Byte) {
                    fixed (ulong* ptr = &data) {
                        return *(sbyte*)ptr;
                    }
                } else if (type == SCIDataType.Int16) {
                    fixed (ulong* ptr = &data) {
                        return *(short*)ptr;
                    }
                } else if (type == SCIDataType.Int32) {
                    fixed (ulong* ptr = &data) {
                        return *(int*)ptr;
                    }
                } else if (type == SCIDataType.Int64) {
                    fixed (ulong* ptr = &data) {
                        return (int)*(long*)ptr;
                    }
                } else if (type == SCIDataType.Float) {
                    fixed (ulong* ptr = &data) {
                        return (int)*(float*)ptr;
                    }
                } else if (type == SCIDataType.Double) {
                    fixed (ulong* ptr = &data) {
                        return (int)*(double*)ptr;
                    }
                } else if (type == SCIDataType.DateTime) {
                    fixed (ulong* ptr = &data) {
                        double secondsSince1970 = *(double*)ptr;
                        return (int)secondsSince1970;
                    }
                } else {
                    return 0;
                }
            }
            set {
                type = SCIDataType.Int32;
                fixed (ulong* ptr = &data) {
                    *(int *) ptr = value;
                }
            }
        }

        public unsafe long longData 
        {
            get 
            {
                if (type == SCIDataType.Byte) 
                {
                    fixed (ulong* ptr = &data)
                    {
                        return *(sbyte*)ptr;
                    }
                }
                else if (type == SCIDataType.Int16) 
                {
                    fixed (ulong* ptr = &data) 
                    {
                        return *(short*)ptr;
                    }
                } 
                else if (type == SCIDataType.Int32)
                {
                    fixed (ulong* ptr = &data) 
                    {
                        return *(int*)ptr;
                    }
                }
                else if (type == SCIDataType.Int64)
                {
                    fixed (ulong* ptr = &data)
                    {
                        return *(long*)ptr;
                    }
                }
                else if (type == SCIDataType.Float) 
                {
                    fixed (ulong* ptr = &data) 
                    {
                        return (long)*(float*)ptr;
                    }
                }
                else if (type == SCIDataType.Double) 
                {
                    fixed (ulong* ptr = &data) 
                    {
                        return (long)*(double*)ptr;
                    }
                }
                else if (type == SCIDataType.DateTime) 
                {
                    fixed (ulong* ptr = &data) 
                    {
                        double secondsSince1970 = *(double*)ptr;
                        return (long)secondsSince1970;
                    }
                } 
                else 
                {
                    return 0;
                }
            }
            set 
            {
                type = SCIDataType.Int64;
                fixed (ulong* ptr = &data) 
                {
                    *(long *) ptr = value;
                }
            }
        }

        public unsafe float floatData
        {
            get 
            {
                if (type == SCIDataType.Byte) 
                {
                    fixed (ulong* ptr = &data) 
                    {
                        return *(sbyte*)ptr;
                    }
                } 
                else if (type == SCIDataType.Int16) 
                {
                    fixed (ulong* ptr = &data)
                    {
                        return *(short*)ptr;
                    }
                } 
                else if (type == SCIDataType.Int32) 
                {
                    fixed (ulong* ptr = &data) 
                    {
                        return (float)*(int*)ptr;
                    }
                } 
                else if (type == SCIDataType.Int64)
                {
                    fixed (ulong* ptr = &data) 
                    {
                        return (float)*(long*)ptr;
                    }
                } 
                else if (type == SCIDataType.Float)
                {
                    fixed (ulong* ptr = &data) 
                    {
                        return *(float*)ptr;
                    }
                } 
                else if (type == SCIDataType.Double)
                {
                    fixed (ulong* ptr = &data) 
                    {
                        return (float)*(double*)ptr;
                    }
                }
                else if (type == SCIDataType.DateTime) 
                {
                    fixed (ulong* ptr = &data)
                    {
                        double secondsSince1970 = *(double*)ptr;
                        return (float)secondsSince1970;
                    }
                } 
                else 
                {
                    return float.NaN;
                }
            }
            set 
            {
                type = SCIDataType.Float;
                fixed (ulong* ptr = &data)
                {
                    *(float *) ptr = value;
                }
            }
        }

        public unsafe double doubleData 
        {
            get
            {
                if (type == SCIDataType.Byte)
                {
                    fixed (ulong* ptr = &data) 
                    {
                        return *(sbyte*)ptr;
                    }
                } 
                else if (type == SCIDataType.Int16)
                {
                    fixed (ulong* ptr = &data)
                    {
                        return *(short*)ptr;
                    }
                } 
                else if (type == SCIDataType.Int32)
                {
                    fixed (ulong* ptr = &data)
                    {
                        return *(int*)ptr;
                    }
                }
                else if (type == SCIDataType.Int64)
                {
                    fixed (ulong* ptr = &data) 
                    {
                        return (double)*(long*)ptr;
                    }
                } 
                else if (type == SCIDataType.Float)
                {
                    fixed (ulong* ptr = &data) 
                    {
                        return *(float*)ptr;
                    }
                } 
                else if (type == SCIDataType.Double) 
                {
                    fixed (ulong* ptr = &data) {
                        return *(double*)ptr;
                    }
                } 
                else if (type == SCIDataType.DateTime)
                {
                    fixed (ulong* ptr = &data) 
                    {
                        double secondsSince1970 = *(double*)ptr;
                        return secondsSince1970;
                    }
                } 
                else 
                {
                    return Double.NaN;
                }
            }
            set
            {
                type = SCIDataType.Double;
                fixed (ulong* ptr = &data) 
                {
                    *(double *) ptr = value;
                }
            }
        }

        public unsafe DateTime dateTimeData
        {
            get 
            {
                if (type == SCIDataType.Byte) 
                {
                    fixed (ulong* ptr = &data)
                    {
                        sbyte secondsSince1970 = *(sbyte*)ptr;
                        return epoch.AddSeconds(secondsSince1970);
                    }
                } 
                else if (type == SCIDataType.Int16) 
                {
                    fixed (ulong* ptr = &data) 
                    {
                        short secondsSince1970 = *(short*)ptr;
                        return epoch.AddSeconds(secondsSince1970);
                    }
                } 
                else if (type == SCIDataType.Int32)
                {
                    fixed (ulong* ptr = &data) 
                    {
                        int secondsSince1970 = *(int*)ptr;
                        return epoch.AddSeconds(secondsSince1970);
                    }
                } 
                else if (type == SCIDataType.Int64) 
                {
                    fixed (ulong* ptr = &data) 
                    {
                        long secondsSince1970 = *(long*)ptr;
                        return epoch.AddSeconds(secondsSince1970);
                    }
                } 
                else if (type == SCIDataType.Float)
                {
                    fixed (ulong* ptr = &data) 
                    {
                        float secondsSince1970 = *(float*)ptr;
                        return epoch.AddSeconds(secondsSince1970);
                    }
                } 
                else if (type == SCIDataType.Double) 
                {
                    fixed (ulong* ptr = &data) 
                    {
                        double secondsSince1970 = *(double*)ptr;
                        return epoch.AddSeconds(secondsSince1970);
                    }
                } 
                else if (type == SCIDataType.DateTime) 
                {
                    fixed (ulong* ptr = &data)
                    {
                        double secondsSince1970 = *(double*)ptr;
                        return epoch.AddSeconds(secondsSince1970);
                    }
                } 
                else
                {
                    return epoch;
                }
            }
            set
            {
                type = SCIDataType.DateTime;
                fixed (ulong* ptr = &data)
                {
                    TimeSpan diff = value.ToUniversalTime() - epoch;
                    double secondsSince1970 = Math.Floor(diff.TotalSeconds);
                    *(double *) ptr = secondsSince1970;
                }
            }
        }
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct SCIHitTestInfo
    {
        public bool match;

        public int index;

        public double x;

        public double y;

        public SCIGenericType xValue;

        public SCIGenericType yValue;

        public SCIGenericType xValueInterpolated;

        public SCIGenericType yValueInterpolated;

        public SCIGenericType y2Value;

        public SCIGenericType y2ValueInterpolated;

        public SCIGenericType zValue;

        public SCIGenericType zValueInterpolated;

        public SCIGenericType openValue;

        public SCIGenericType highValue;

        public SCIGenericType lowValue;

        public SCIGenericType closeValue;

        public double radius;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SCIPointMarkerClusreizerInfo
    {
        public unsafe byte* _data;

        public int _width;

        public int _height;

        public CGSize _area;

        public float _spacing;

        public float _spacingMultiplier;
    }

    [StructLayout (LayoutKind.Sequential)]
    internal struct NSFastEnumerationState {
        nint state;
        internal IntPtr itemsPtr;
        internal IntPtr mutationsPtr;
        nint extra1;
        nint extra2;
        nint extra3;
        nint extra4;
        nint extra5;
    }
}