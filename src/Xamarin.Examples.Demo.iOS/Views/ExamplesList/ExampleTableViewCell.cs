﻿using System;
using Foundation;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    public partial class ExampleTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("ExampleTableViewCell");
        public static readonly UINib Nib;

        static ExampleTableViewCell()
        {
            Nib = UINib.FromName("ExampleTableViewCell", NSBundle.MainBundle);
        }

        protected ExampleTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void UpdateCell(string title, string description, ExampleIcon? icon)
        {            
            TitleLabel.Text = title;
            DescriptionLabel.Text = description;
            if (icon.HasValue)
            {
                ExampleImage.Image = UIImage.FromBundle(icon.Value.ToString());
            }
        }
    }
}
