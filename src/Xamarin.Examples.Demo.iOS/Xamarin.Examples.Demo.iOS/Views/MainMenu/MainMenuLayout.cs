using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    public class MainMenuLayout : UICollectionViewFlowLayout
    {
        private IUICollectionViewDelegateFlowLayout DelegateFlowLayout
        {
            get => CollectionView.Source as IUICollectionViewDelegateFlowLayout;
        }

        public override bool ShouldInvalidateLayoutForBoundsChange(CGRect newBounds) => true;

        private CGSize GetItemSize(NSIndexPath indexPath)
        {
            CGSize size = ItemSize;
            if (DelegateFlowLayout != null)
            {
                size = DelegateFlowLayout.GetSizeForItem(CollectionView, this, indexPath);
            }

            return size;
        }

        public override UICollectionViewLayoutAttributes[] LayoutAttributesForElementsInRect(CGRect rect)
        {
            List<UICollectionViewLayoutAttributes> attributes = new List<UICollectionViewLayoutAttributes>();
            UICollectionViewLayoutAttributes[] itemsAttributes = base.LayoutAttributesForElementsInRect(rect);

            foreach (UICollectionViewLayoutAttributes current in itemsAttributes)
            {
                attributes.Add(current);
            }

            List<UICollectionViewLayoutAttributes> decorationAttributes = new List<UICollectionViewLayoutAttributes>();
            List<NSIndexPath> visibleIndexPaths = IndexPathsOfSeparatorsInRect(rect);

            foreach (NSIndexPath indexPath in visibleIndexPaths)
            {
                UICollectionViewLayoutAttributes attr = LayoutAttributesForDecorationView((Foundation.NSString)"Separator", indexPath);
                decorationAttributes.Add(attr);
            }
            attributes.AddRange(decorationAttributes);

            return attributes.ToArray();
        }

        private List<NSIndexPath> IndexPathsOfSeparatorsInRect(CGRect rect)
        {
            List<NSIndexPath> result = new List<NSIndexPath>();
            int firstCellToShow = (int)Math.Floor(rect.Location.Y / ItemSize.Height);
            int lastIndexToShow = (int)Math.Floor((rect.Location.Y + rect.Height) / ItemSize.Height);
            int countOfItems = (int)(CollectionView.Source.GetItemsCount(CollectionView, 0) - 1);

            for (int i = Math.Max(firstCellToShow, 0); i <= lastIndexToShow; i++)
            {
                if (i < countOfItems)
                {
                    NSIndexPath indxPath = NSIndexPath.FromItemSection(i, 0);
                    result.Add(indxPath);
                }
            }
            return result;
        }

        public override UICollectionViewLayoutAttributes LayoutAttributesForDecorationView(NSString kind, NSIndexPath indexPath)
        {
            UICollectionViewLayoutAttributes layoutAttributes = UICollectionViewLayoutAttributes.CreateForDecorationView(kind, indexPath);
            CGSize currentItemSize = GetItemSize(indexPath);

            if (ScrollDirection == UICollectionViewScrollDirection.Vertical)
            {
                double separtorWidth = (currentItemSize.Width * 0.8);
                double separatorHeight = 0.5;
                double separatorOriginX = Math.Ceiling((currentItemSize.Width - separtorWidth) / 2.0);
                double decorationOffset = (indexPath.Item + 1) * currentItemSize.Height;
                layoutAttributes.Frame = new CGRect(separatorOriginX, decorationOffset, separtorWidth, separatorHeight);

            }
            else
            {
                double separtorWidth = 0.5;
                double separatorHeight = (currentItemSize.Height * 0.8); ;
                double separatorOriginY = Math.Ceiling((currentItemSize.Height - separatorHeight) / 2.0);
                double decorationOffset = (indexPath.Item + 1) * currentItemSize.Width;
                layoutAttributes.Frame = new CGRect(decorationOffset, separatorOriginY, separtorWidth, separatorHeight);
            }

            layoutAttributes.ZIndex = 1000;

            return layoutAttributes;
        }

        public override UICollectionViewLayoutAttributes InitialLayoutAttributesForAppearingDecorationElement(NSString elementKind, NSIndexPath decorationIndexPath)
        {
            UICollectionViewLayoutAttributes attributes = LayoutAttributesForDecorationView(elementKind, decorationIndexPath);
            attributes.Frame = CGRect.Empty;
            attributes.Alpha = (nfloat)0.0;
            return attributes;
        }

        public override UICollectionViewLayoutAttributes FinalLayoutAttributesForDisappearingDecorationElement(NSString elementKind, NSIndexPath decorationIndexPath)
        {
            UICollectionViewLayoutAttributes attributes = LayoutAttributesForDecorationView(elementKind, decorationIndexPath);
            attributes.Frame = CGRect.Empty;
            attributes.Alpha = (nfloat)0.0;
            return attributes;
        }
    }
}
