using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using SciChart.Examples.Demo.Application;

namespace Xamarin.Examples.Demo.iOS
{
    public partial class MainViewController : UITableViewController
    {
        private List<Example> _examples = new List<Example>();
        private Type _currentChartType;

        protected MainViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableView.DataSource = this;
            TableView.Delegate = this;
            TableView.BackgroundColor = new UIColor(red:0.14f, green:0.14f, blue:0.15f, alpha:1.0f); // #232426
            TableView.SeparatorColor = new UIColor(red: 0.11f, green: 0.11f, blue: 0.11f, alpha: 1.0f); // #1B1B1B
            TableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
            TableView.RowHeight = 60;
            this.NavigationController.NavigationBar.BarTintColor = new UIColor(red: 0.35f, green: 0.78f, blue: 0.36f, alpha: 1.0f); // #5AC65B
            this.NavigationController.NavigationBar.Translucent = true;
            this.NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;

            _examples = ExampleManager.Instance.Examples;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _examples.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(ExampleTableViewCell.Key) as ExampleTableViewCell;
            var example = _examples[indexPath.Row];

            if (cell == null)
            {
                cell = ExampleTableViewCell.Nib.Instantiate(tableView, null)[0] as ExampleTableViewCell;
            }

            cell.UpdateCell(example.Title, example.Description, example.Icon);

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            _currentChartType = _examples[indexPath.Row].ExampleType;
            PerformSegue("showChartSegue", null);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var exampleViewController = (ExampleViewController) segue.DestinationViewController;
            exampleViewController.InitChartView(_currentChartType);
        }
    }
}