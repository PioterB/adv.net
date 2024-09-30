using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LevelUpCSharp.Products;
using LevelUpCSharp.Retail;

namespace LevelUpCSharp.Production
{
    internal class VendorViewModel : ViewModelBase
    {
        private static readonly Random Rand;

        private readonly Vendor _vendor;

        static VendorViewModel()
        {
            Rand = new Random((int)DateTime.Now.Ticks);
        }

        public VendorViewModel(Vendor vendor)
        {
            _vendor = vendor;
            _vendor.Produced += OnProduced;
            Stock = BuildStock(vendor.GetStock());
            Produce = new RelayCommand(OnProduce);
            Distribute = new RelayCommand(OnDistribution);
        }

        public string Name => _vendor.Name;

        public ObservableCollection<StockItemViewModel> Stock { get; private set; }

        public ICommand Produce { get; }

        public ICommand Distribute { get;  }

        private ObservableCollection<StockItemViewModel> BuildStock(IEnumerable<StockItem> stock)
        {
            var stockItems = new List<StockItemViewModel>();
            foreach (var stockItem in stock)
            {
                stockItems.Add(new StockItemViewModel(stockItem));
            }

            return new ObservableCollection<StockItemViewModel>(stockItems);
        }

        private void OnProduce()
        {
            var kind = Rand.Next(Dictionaries.SandwichKinds.Length);

            _vendor.Order(Dictionaries.SandwichKinds[kind], 1);
        }

        private void OnDistribution()
        {
            var sandwiches = _vendor.Buy();

            Stock = BuildStock(_vendor.GetStock());
            RaisePropertyChanged(nameof(Stock));

            Retailer.Instance.Pack(sandwiches, _vendor.Name);
        }

        private void OnProduced(Sandwich[] sandwiches)
        {
            Stock = BuildStock(_vendor.GetStock());
            RaisePropertyChanged(nameof(Stock));
        }
    }
}