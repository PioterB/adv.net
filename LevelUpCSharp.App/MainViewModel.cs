using GalaSoft.MvvmLight;
using LevelUpCSharp.Consumption;
using LevelUpCSharp.Production;
using LevelUpCSharp.Retail;

namespace LevelUpCSharp
{
    internal class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Consumption = new ConsumptionViewModel(new ConsumersService());
            Production = new ProductionViewModel(new ProductionService());
            Retail = new RetailViewModel();
        }

        public ConsumptionViewModel Consumption { get; }
        
        public ProductionViewModel Production { get; }
        
        public RetailViewModel Retail { get; }
    }
}
