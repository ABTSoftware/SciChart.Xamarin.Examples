using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    public partial class MenuItemCell : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("MenuItemCell");
        public static readonly UINib Nib;

        public override bool Selected
        {
            set
            {
                base.Selected = value;
                AnimateSelection(value);
            }
        }

        public string TitleText
        {
            get => TitleLabel.Text;            
            set => TitleLabel.Text = value;
        }

        public string SubtitleText
        {
            get => Subtitle.Text;
            set => Subtitle.Text = value;
        }

        public UIImage IconImage
        {
            get => Icon.Image;
            set => Icon.Image = value;
        }

        private void AnimateSelection(bool isSelected)
        {
            UIView.Animate(0.4, () => {
                ContainerView.Transform = isSelected ? CGAffineTransform.MakeScale((nfloat)0.8, (nfloat)0.8) : CGAffineTransform.MakeIdentity();
            });
        }

        static MenuItemCell()
        {
            Nib = UINib.FromName("MenuItemCell", NSBundle.MainBundle);
        }

        protected MenuItemCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
