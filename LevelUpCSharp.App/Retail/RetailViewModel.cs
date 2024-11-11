using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LevelUpCSharp.Helpers;
using LevelUpCSharp.Collections;
using LevelUpCSharp.Products;

namespace LevelUpCSharp.Retail
{
    internal class RetailViewModel : ViewModelBase
    {
        private readonly IDictionary<SandwichKind, LineSummaryViewModel> _lines;

        public RetailViewModel()
        {
            _lines = InitializeLines();
            Logs = new ObservableCollection<string>();
            Retailer.Instance.Packed += OnPacked;
            Retailer.Instance.Purchase += OnPurchase;

            Pickup = new RelayCommand(OnPickup);
        }

        public IEnumerable<LineSummaryViewModel> Lines => _lines.Values;
        public ObservableCollection<string> Logs { get; }

        public ICommand Pickup { get; }

        private IDictionary<SandwichKind, LineSummaryViewModel> InitializeLines()
        {
            var result = new Dictionary<SandwichKind, LineSummaryViewModel>();

            foreach (var value in EnumHelper.GetValues<SandwichKind>())
            {
                result.Add(value, new LineSummaryViewModel(value));
            }

            return result;
        }

        private void OnPurchase(DateTimeOffset time, Sandwich product)
        {
            _lines[product.Kind].Reduce();
            Logs.Add($"{time} purchase {product.Kind}");
        }

        private void OnPacked(PackingSummary summary)
        {
            /*
            foreach (var summaryPosition in summary.Positions)
            {
                _lines[summaryPosition.Kind].TopUp(summaryPosition.Added);
            }
            */

            summary.Positions.SafeForEach(summaryPosition => _lines[summaryPosition.Kind].TopUp(summaryPosition.Added));

            /* add total number of added items to log statement */
            Logs.Add($"{summary.TimeStamp} topped up, {summary.Vendor}.");
        }

        private void OnPickup()
        {
            Retailer.Instance.Pickup();
        }
    }
}