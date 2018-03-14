﻿using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIPointMarkerClusterizer : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCIPointMarkerClusterizer : INSCopying
    {
        // @property (nonatomic) CGSize area;
        [Export("area", ArgumentSemantic.Assign)]
        CGSize Area { get; set; }

        // @property (nonatomic) float spacing;
        [Export("spacing")]
        float Spacing { get; set; }

        // -(void)clear;
        [Export("clear")]
        void Clear();

        // -(void)purge;
        [Export("purge")]
        void Purge();

        // -(void)drawPointMarker:(id<SCIPointMarkerProtocol>)marker AtX:(double)X Y:(double)Y ToContext:(id<SCIRenderContext2DProtocol>)context;
        [Export("drawPointMarker:AtX:Y:ToContext:")]
        void DrawPointMarker(ISCIPointMarkerProtocol marker, double X, double Y, ISCIRenderContext2DProtocol context);

        // @property (copy, nonatomic) SCIActionBlock propertiesChanged;
        [Export("propertiesChanged", ArgumentSemantic.Copy)]
        SCIActionBlock PropertiesChanged { get; set; }

        // TODO discuss unsafe code with ANdrii
        //// -(SCIPointMarkerClusreizerInfo *)getClusterizerInfo;
        //[Export("getClusterizerInfo")]
        //[Verify(MethodToProperty)]
        //unsafe SCIPointMarkerClusreizerInfo* ClusterizerInfo { get; }
    }
}