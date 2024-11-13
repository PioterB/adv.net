using GalaSoft.MvvmLight;
using LevelUpCSharp.Consumption;
using LevelUpCSharp.Persistence;
using LevelUpCSharp.Retail;

namespace LevelUpCSharp
{
    internal class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            var consumers = new Repository<string, Consumer>();

            consumers.Add("Adam", new Consumer("Adam"));
            consumers.Add("Piotrek", new Consumer("Piotrek"));
            consumers.Add("Zbyszek", new Consumer("Zbyszek"));
            consumers.Add("Waldek", new Consumer("Waldek"));

            Consumption = new ConsumptionViewModel(new ConsumersService(consumers), consumers);
            Retail = new RetailViewModel();
        }

        public ConsumptionViewModel Consumption { get; }
        
        public RetailViewModel Retail { get; }
    }
}
