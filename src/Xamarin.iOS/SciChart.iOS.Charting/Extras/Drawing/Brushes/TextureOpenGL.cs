using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    public partial class SCITextureOpenGL
    {
        public SCITextureOpenGL(float[] coords, uint[] colors, int count)
            : this(GCHandle.Alloc(coords, GCHandleType.Pinned).AddrOfPinnedObject(), GCHandle.Alloc(colors, GCHandleType.Pinned).AddrOfPinnedObject(), count)
        {
        }
    }
}