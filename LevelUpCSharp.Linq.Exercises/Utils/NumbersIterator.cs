using System;
using System.Collections.Generic;

namespace LevelUpCSharp.Linq.Utils
{
    public class NumbersIterator : IEnumerator<int>
    {
        private int position = -1;
        public int[] Numbers;

        public NumbersIterator(int[] numbers)
        {
            this.Numbers = numbers;
        }

        public int Current
        {
            get
            {
                if (this.position == -1 || this.position == this.Numbers.Length)
                {
                    throw new InvalidOperationException();
                }

                return this.Numbers[position];
            }
        }

        public bool MoveNext()
        {
            this.position += 1;

            if (this.position >= this.Numbers.Length)
            {
                this.position = this.Numbers.Length;
                return false;
            }

            moveNextCounter++;
            // Console.WriteLine("MoveNext " + Current);

            return true;
        }

        public void Reset()
        {
            this.position = -1;

            moveNextCounter = 0;
            Console.WriteLine("Reset");
        }

        object System.Collections.IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }


        public void Dispose()
        {
        }

        #region MoveNextCounter handling

        /// <summary>
        /// field is used for internal topics, do not use them please.
        /// </summary>
        private static int moveNextCounter = 0;

        public static int MoveNextCounter
        {
            get
            {
                return moveNextCounter;
            }
        }

        public static void ResetMoveNextCounter()
        {
            moveNextCounter = 0;
        }

        #endregion


    }
}