using System.Collections.Generic;

namespace LevelUpCSharp.Linq.Utils
{
    public class Numbers : IEnumerable<int>
    {
        private int _upperLimit;
        public int[] _internalMemory;

        public Numbers(int upperLimit)
        {
            _upperLimit = upperLimit;
            _internalMemory = new int[upperLimit];
            InitCollection();
        }

        private void InitCollection()
        {

            for (var i = 0; i < _upperLimit; i++)
            {
                _internalMemory[i] = i;
            }
        }

        public int UpperLimit => _upperLimit;

        public IEnumerator<int> GetEnumerator()
        {
            return new NumbersIterator(_internalMemory);

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}