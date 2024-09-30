using System;
using System.Security.Cryptography.Pkcs;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using LevelUpCSharp.Products;
using LevelUpCSharp.Retail;

namespace LevelUpCSharp.Consumption
{
    internal class ConsumerViewModel
    {
        private readonly Consumer _consumer;

        public ConsumerViewModel(Consumer consumer)
        {
            _consumer = consumer;
            Consume = new RelayCommand<SandwichKind>(BuyAndEat);
        }

        private async void BuyAndEat(SandwichKind kind)
        {
            var purchase = Retailer.Instance.Sell(kind);
            if (purchase.Fail)
            {
                return;
            }

            var x = await Digest();
        }

        private async Task<bool> Digest()
        {
             await Task.Delay(TimeSpan.FromSeconds(10));
             return true;
        }

        public string Name => _consumer.Name;

        public SandwichKind[] Kinds => Dictionaries.SandwichKinds;

        public ICommand Consume { get; }

        public Consumer GetModel()
        {
            return _consumer;
        }
    }
}