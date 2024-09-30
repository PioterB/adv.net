using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace LevelUpCSharp.Consumption
{
    internal class ConsumptionViewModel
    {
        private readonly ConsumersService _consumersService;
        private readonly ObservableCollection<ConsumerViewModel> _consumers;

        public ConsumptionViewModel(ConsumersService consumersService)
        {
            _consumersService = consumersService;
            Add = new RelayCommand<string>(NewConsumer);
            _consumers = InitializeConsumers();
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

        private ObservableCollection<ConsumerViewModel> InitializeConsumers()
        {
            var consumers = new List<ConsumerViewModel>();
            foreach (var consumer in Repositories.Consumers.GetAll())
            {
                consumers.Add(new ConsumerViewModel(consumer));
            }

            return new ObservableCollection<ConsumerViewModel>(consumers);
        }
    }
}