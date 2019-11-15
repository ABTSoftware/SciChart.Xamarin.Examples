using Foundation;
using System;
using UIKit;
using CoreGraphics;
using System.Drawing;
using System.Collections.Generic;

namespace Xamarin.Examples.Demo.iOS
{
    class MenuSeparatorView : UICollectionReusableView
    {
        public MenuSeparatorView(IntPtr handle) : base(handle) { }

        public MenuSeparatorView(RectangleF frame)
        {
            Init();
            Frame = frame;
        }

        public override void ApplyLayoutAttributes(UICollectionViewLayoutAttributes layoutAttributes)
        {
            Frame = layoutAttributes.Frame;
            Alpha = layoutAttributes.Alpha;
            BackgroundColor = UIColor.White.ColorWithAlpha((System.nfloat)0.4);
        }
    }

    class MainMenuSource : UICollectionViewSource, IUICollectionViewDelegateFlowLayout
    {
        struct MenuItem
        {
            public string Title;
            public string Subtitle;
            public UIImage Image;
            public List<Example> Examples;
        }

        readonly MenuItem[] items = {
            new MenuItem { Title = "2D CHARTS", Subtitle = "SELECTION OF 2D CHARTS", Image = UIImage.FromBundle("Сharts2d"),  Examples = ExampleManager.Instance.Examples},
            new MenuItem { Title = "3D CHARTS", Subtitle = "SELECTION OF 3D CHARTS", Image = UIImage.FromBundle("Charts3d"), Examples = ExampleManager.Instance.Examples3D},
            new MenuItem { Title = "FEATURED APPS", Subtitle = "SELECTION OF FEATURED APPS", Image = UIImage.FromBundle("FeaturedApps"), Examples = ExampleManager.Instance.FeaturedExamples}
        };

        public UINavigationController RootNavigationController;

        [Export("collectionView:numberOfItemsInSection:")]
        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return items.Length;
        }

        [Export("collectionView:cellForItemAtIndexPath:")]
        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            MenuItemCell cell = (MenuItemCell)collectionView.DequeueReusableCell("MenuItemCellID", indexPath);
            cell.TitleText = items[indexPath.Item].Title;
            cell.SubtitleText = items[indexPath.Item].Subtitle;
            cell.IconImage = items[indexPath.Item].Image;

            return cell;
        }

        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            CGSize itemSize = CGSize.Empty;
            if (UIApplication.SharedApplication.StatusBarOrientation.IsPortrait())
            {
                itemSize.Width = (nfloat)collectionView.Frame.Size.Width;
                itemSize.Height = (nfloat)(collectionView.Frame.Size.Height / 3.0);
            }
            else
            {
                itemSize.Width = (nfloat)(collectionView.Frame.Size.Width / 3.0);
                itemSize.Height = (nfloat)collectionView.Frame.Size.Height;
            }
            return itemSize;
        }

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var selectedItem = items[indexPath.Item];
            var mainStoryboard = UIStoryboard.FromName("Main", null);
            var vcToShow = (ExamplesListController)mainStoryboard.InstantiateViewController("ExamplesListID");
            vcToShow.Examples = selectedItem.Examples;
            RootNavigationController.PushViewController(vcToShow, true);
        }
    }

    public partial class MainMenuViewController : UIViewController
    {
        private UICollectionViewFlowLayout FlowLayout
        {
            get => (UICollectionViewFlowLayout)CollectionView.CollectionViewLayout;
        }

        public MainMenuViewController (IntPtr handle) : base (handle) { }

        private void SetupCollectionView()
        {
            CollectionView.CollectionViewLayout = new MainMenuLayout();
            FlowLayout.SectionInset = UIEdgeInsets.Zero;
            FlowLayout.MinimumInteritemSpacing = (nfloat)0.0;
            FlowLayout.MinimumLineSpacing = (nfloat)0.0;
            FlowLayout.RegisterClassForDecorationView(typeof(MenuSeparatorView), (NSString)"Separator");

            UINib nib = UINib.FromName("MenuItemCell", null);
            CollectionView.RegisterNibForCell(nib, "MenuItemCellID");
            CollectionView.Source = new MainMenuSource { RootNavigationController = NavigationController };
            CollectionView.Frame = View.Bounds;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            UIDevice.CurrentDevice.BeginGeneratingDeviceOrientationNotifications();
            SetupCollectionView();
        }

        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();
            FlowLayout.ScrollDirection = UIApplication.SharedApplication.StatusBarOrientation.IsPortrait() ? UICollectionViewScrollDirection.Vertical : UICollectionViewScrollDirection.Horizontal;
        }

        public override void ViewWillAppear(bool animated)
        {
            NavigationController.NavigationBarHidden = true;
            base.ViewWillAppear(animated);
            DeselecCollectionView();
        }

        private void DeselecCollectionView()
        {
            if (CollectionView.GetIndexPathsForSelectedItems() != null)
            {
                foreach (NSIndexPath indexPath in CollectionView.GetIndexPathsForSelectedItems())
                {
                    CollectionView.DeselectItem(indexPath, true);
                }
            }
        }
    }
}
