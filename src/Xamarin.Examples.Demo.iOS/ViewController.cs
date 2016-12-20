using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using SciChart.iOS.Charting;
using SciChart.Examples.Demo.Application;

namespace Xamarin.Examples.Demo.iOS
{
    public partial class ViewController : UITableViewController
    {
        private List<Example> _examples = new List<Example>();
        private Type _currentChartType;

        protected ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableView.DataSource = this;
            TableView.Delegate = this;

            _examples = ExampleManager.Instance.Examples;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _examples.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("chartCell");
            var item = _examples[indexPath.Row].Title;

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, "chartCell");
            }

            cell.TextLabel.Text = item;

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            _currentChartType = _examples[indexPath.Row].FragmentType;
            PerformSegue("showChartSegue", null);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var chartView = segue.DestinationViewController.View as ChartView;
            chartView?.InitChartView(Activator.CreateInstance(_currentChartType) as SCIChartSurfaceView);
        }
    }
}