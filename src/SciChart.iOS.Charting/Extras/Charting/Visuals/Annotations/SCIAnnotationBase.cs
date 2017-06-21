using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace SciChart.iOS.Charting
{
    public interface ISCIAnnotation : ISCIAnnotationProtocol { }

    public partial class SCIAnnotationBase : ISCIAnnotation
    {
        // -(CGPoint)getCoordFromDataX:(SCIGenericType)x Y:(SCIGenericType)y;
        protected static NSString GetCoordFromDataMethod = new NSString("getCoordFromDataX:Y:");
        public CGPoint GetCoordFromData(IComparable x, IComparable y)
        {
            return SCIXamarinMessageResolver.sendMessagePointGG(this, GetCoordFromDataMethod, ComparableUtil.ToDouble(x), ComparableUtil.ToDouble(y));
        }
        
        // -(SCIGenericType)getDataXFromCoord:(double)x;
        protected static NSString GetDataXFromCoordMethod = new NSString("getDataXFromCoord:");
        public IComparable GetDataXFromCoord(double x)
        {
            return SCIXamarinMessageResolver.sendMessageGD(this, GetDataXFromCoordMethod, x);
        }

         // -(SCIGenericType)getDataYFromCoord:(double)y;
        protected static NSString GetDataYFromCoordMethod = new NSString("getDataYFromCoord:");
        public IComparable GetDataYFromCoord(double y)
        {
            return SCIXamarinMessageResolver.sendMessageGD(this, GetDataYFromCoordMethod, y);
        }
    }
}