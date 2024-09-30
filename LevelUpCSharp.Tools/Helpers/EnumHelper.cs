using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelUpCSharp.Helpers
{
    public static class EnumHelper
    {
        public static TEnum[] GetValues<TEnum>()
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToArray();
        }
    }
}
