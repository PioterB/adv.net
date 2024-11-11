using GalaSoft.MvvmLight;
using LevelUpCSharp.Consumption;
using LevelUpCSharp.Retail;

namespace LevelUpCSharp
{
    internal class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Consumption = new ConsumptionViewModel(new ConsumersService());
            Retail = new RetailViewModel();
        }

        public ConsumptionViewModel Consumption { get; }
        
        public RetailViewModel Retail { get; }
    }
}
