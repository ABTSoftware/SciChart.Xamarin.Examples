namespace SciChart.Core.Framework
{
    public partial interface IDisposable : System.IDisposable
    {
    }

    public partial class DisposableBase
    {
        void System.IDisposable.Dispose()
        {
            this.Dispose();
        }
    }
}