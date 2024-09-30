using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LevelUpCSharp.Reflection
{
    public class Reflector
    {
        public static IEnumerable<TypeInfo> FindByAttributes(Assembly assembly, params Type[] attributes)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<MethodInfo> FindByAttributes(TypeInfo assembly, params Type[] attributes)
        {
            throw new NotImplementedException();
        }
    }
}
