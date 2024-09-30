using System;

namespace LevelUpCSharp.Networking
{
    [AttributeUsage(AttributeTargets.Method)]
    public class WorkerAttribute : Attribute
    {
        public WorkerAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}