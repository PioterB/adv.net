using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpCSharp
{
	internal interface IRepository<TKey, TItem>
    {
        void Add(TKey key, TItem item);

        //bool Exists(TKey key);

        //IEnumerable<TItem> GetAll();

        //TItem Get(TKey key);

        //void Remove(TKey key);
    }
}
