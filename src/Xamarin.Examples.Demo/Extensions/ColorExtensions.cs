namespace Xamarin.Examples.Demo
{
    public static class ColorExtension
    {
        public static byte A(this uint colorUInt)
        {
            return (byte)((colorUInt >> 24) & 0xff);
        }

        public static byte R(this uint colorUInt)
        {
            return (byte)((colorUInt >> 16) & 0xff);
        }

        public static byte G(this uint colorUInt)
        {
            return (byte)((colorUInt >> 8) & 0xff);
        }

        public static byte B(this uint colorUInt)
        {
            return (byte)(colorUInt & 0xff);
        }
    }
}