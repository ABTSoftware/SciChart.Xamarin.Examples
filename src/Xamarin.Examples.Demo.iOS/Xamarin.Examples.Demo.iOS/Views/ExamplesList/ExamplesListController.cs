using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace Xamarin.Examples.Demo.iOS
{
    public partial class ExamplesListController : UITableViewController
    {
        public List<Example> Examples;

        protected ExamplesListController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationController.NavigationBarHidden = false;
            TableView.BackgroundColor = 0xFF232426.ToUIColor();
            TableView.SeparatorColor = 0xFF1B1B1B.ToUIColor();
            TableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
            TableView.RowHeight = 60;
        }

        public override nint RowsInSection(UITableView tableView, nint section) => Examples.Count;

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var example = Examples[indexPath.Row];

            var cell = tableView.DequeueReusableCell(ExampleTableViewCell.Key) as ExampleTableViewCell;
            if (cell == null)
            {
                cell = ExampleTableViewCell.Nib.Instantiate(tableView, null)[0] as ExampleTableViewCell;
            }
            cell.UpdateCell(example.Title, example.Description, example.Icon);

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var example = Examples[indexPath.Row];
            var exampleType = example.ExampleType;

            var exampleViewController = (UIViewController)Activator.CreateInstance(exampleType);
            exampleViewController.NavigationItem.Title = example.Title;
            NavigationController.PushViewController(exampleViewController, true);

            exampleViewController.Dispose();
        }
    }
}