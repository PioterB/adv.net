using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpCSharp.Networking
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CtrlAttribute : Attribute
    {
        public CtrlAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
