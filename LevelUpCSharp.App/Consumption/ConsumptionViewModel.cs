using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace LevelUpCSharp.Consumption
{
    internal class ConsumptionViewModel
    {
        private readonly ConsumersService _consumersService;
		private readonly ObservableCollection<ConsumerViewModel> _consumers;

        public ConsumptionViewModel(ConsumersService consumersService, IRepository<string, Consumer> consumers)
        {
            /* 
             * sanity check guarding architecture is missing 
             * - consumetrs is not null
             * - consumersService is not null
             */

            _consumersService = consumersService;
            _consumers = InitializeConsumers(consumers);
            
            Add = new RelayCommand<string>(NewConsumer);
        }

        public ICommand Add { get; }

        public ObservableCollection<ConsumerViewModel> Consumers => _consumers;

        private void NewConsumer(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return;
            }
            
            var consumer = _consumersService.Create(name);
            if (consumer.Fail)
            {
                return;
            }

            _consumers.Add(new ConsumerViewModel(consumer));
        }

        private ObservableCollection<ConsumerViewModel> InitializeConsumers(IRepository<string, Consumer> consumers)
        {
            var models = consumers.GetAll().Select(c => new ConsumerViewModel(c));
            return new ObservableCollection<ConsumerViewModel>(models);
        }
    }
}