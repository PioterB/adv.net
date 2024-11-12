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
            return assembly.DefinedTypes
                .Where(type =>
                    type.CustomAttributes
                        .Any(attr => attributes.Contains(attr.AttributeType)))
                .ToArray();
        }

        public static IEnumerable<MethodInfo> FindByAttributes(TypeInfo type, params Type[] attributes)
        {
            return type.DeclaredMethods
                .Where(method =>
                    method.CustomAttributes
                        .Any(attr => attributes.Contains(attr.AttributeType)))
                .ToArray();
        }
    }
}
