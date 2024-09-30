using System.Collections.Generic;
using System.Reflection;

namespace LevelUpCSharp.Server
{
    internal class Route
    {
        public TypeInfo Type { get; }

        public Dictionary<string, string> Methods { get; }

        public Route(TypeInfo ctrl, Dictionary<string, string> methods)
        {
            Type = ctrl;
            Methods = methods;
        }
    }
}