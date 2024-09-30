using GalaSoft.MvvmLight;
using LevelUpCSharp.Products;

namespace LevelUpCSharp.Retail
{
    internal class LineSummaryViewModel : ViewModelBase
    {
        public LineSummaryViewModel(SandwichKind type)
        {
            Type = type;
        }

        public SandwichKind Type { get; }
        public int Amount { get; private set; }

        public void TopUp(int count)
        {
            Amount += count;
            RaisePropertyChanged(nameof(Amount));
        }

        public void Reduce(int amount = 1)
        {
            if (Amount == 0)
            {
                return;
            }

            Amount--;

            RaisePropertyChanged(nameof(Amount));
        }
    }
}