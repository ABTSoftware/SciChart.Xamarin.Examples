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

    	[StructLayout(LayoutKind.Explicit)]
    	public struct _
    	{
    		[FieldOffset(0)]
    		public sbyte charData;

    		[FieldOffset(0)]
            public short int16Data;

    		[FieldOffset(0)]
    		public int int32Data;

    		[FieldOffset(0)]
    		public long int64Data;

    		[FieldOffset(0)]
    		public float floatData;

    		[FieldOffset(0)]
    		public double doubleData;

    		[FieldOffset(0)]
    		public unsafe void* voidPtr;

    		[FieldOffset(0)]
    		public unsafe sbyte* charPtr;

    		[FieldOffset(0)]
    		public unsafe short* int16Ptr;

    		[FieldOffset(0)]
    		public unsafe int* int32Ptr;

    		[FieldOffset(0)]
    		public unsafe long* int64Ptr;

    		[FieldOffset(0)]
    		public unsafe float* floatPtr;

    		[FieldOffset(0)]
    		public unsafe double* doublePtr;
    	}

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