using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;
using System.Collections;

namespace SciChart.iOS.Charting
{
    public partial class SCIArrayController
    {
        // @required -(SCIGenericType)genericData;
        public static readonly NSString GenericDataMethod = new NSString("genericData");
        public IComparable GenericData => SCIXamarinMessageResolver.sendMessageGV(this, GenericDataMethod);

        // @required -(SCIGenericType)valueAt:(int)index;
        public static readonly NSString ValueAtMethod = new NSString("valueAt:");
        public IComparable ValueAt(int index)
        {
            return SCIXamarinMessageResolver.sendMessageGI(this, ValueAtMethod, index);
        }

        // @required -(void)removeValue:(SCIGenericType)value;
        public static readonly NSString RemoveValueMethod = new NSString("removeValue:");
        public void RemoveValue(IComparable value)
        {
            SCIXamarinMessageResolver.sendMessageVG(this, RemoveValueMethod, ComparableUtil.ToDouble(value));
        }

        // @required -(void)setValue:(SCIGenericType)value At:(int)index;
        public static readonly NSString SetValueAtMethod = new NSString("setValue:At:");
        public void SetValue(IComparable value, int index)
        {
            SCIXamarinMessageResolver.sendMessageVGI(this, SetValueAtMethod, ComparableUtil.ToDouble(value), index);
        }

        // @required -(void)setValueArray:(SCIGenericType)array atIndex:(int)index andCount:(int)count;
        public static readonly NSString SetValueArrayAtIndexAndCountMethod = new NSString("setValueArray:atIndex:andCount:");
        //TODO

        // @required -(void)insertValue:(SCIGenericType)value At:(int)index;
        public static readonly NSString InsertValueAtMethod = new NSString("insertValue:At:");
        public void InsertValue(IComparable value, int index)
        {
            SCIXamarinMessageResolver.sendMessageVGI(this, InsertValueAtMethod, ComparableUtil.ToDouble(value), index);
        }

        // @required -(void)insertRange:(SCIGenericType)array At:(int)index Count:(int)count;
        public static readonly NSString InsertRangeAtCountMethod = new NSString("insertRange:At:Count:");
        //TODO

        // @required -(int)indexOf:(SCIGenericType)value IsSorted:(BOOL)isSorted SearchMode:(SCIArraySearchMode)searchMode;
        public static readonly NSString IndexOfIsSortedSearchModeMethod = new NSString("indexOf:IsSorted:SearchMode:");
        public int IndexOf(IComparable value, bool isSorted, SCIArraySearchMode searchMode)
        {
            return SCIXamarinMessageResolver.sendMessageIGBI(this, IndexOfIsSortedSearchModeMethod, ComparableUtil.ToDouble(value), isSorted, (int)searchMode);
        }

        // @required -(void)append:(SCIGenericType)value;
        public static readonly NSString AppendMethod = new NSString("append:");
        public void Append(IComparable value)
        {
            SCIXamarinMessageResolver.sendMessageVG(this, AppendMethod, ComparableUtil.ToDouble(value));
        }

        // @required -(void)appendRange:(SCIGenericType)array Count:(int)count;
        public static readonly NSString AppendRangeCountMethod = new NSString("appendRange:Count:");
        //TODO

        // @required -(void)copyToArray:(void **)data Count:(int *)count Type:(SCIDataType)type;
    }
}