using System.Collections.Generic;
using LevelUpCSharp.Linq.Model;

namespace LevelUpCSharp.Linq.Utils
{
    public class MyCompanyComparer : IEqualityComparer<Company>
    {

        public bool Equals(Company x, Company y)
        {
            return x.Name.Equals(y.Name);
        }

        public int GetHashCode(Company obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}