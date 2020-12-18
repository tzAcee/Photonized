using System;

namespace photoniced.essentials
{
public struct MethodsHolder
{
        public MethodsHolder(Action method, string description)
        {
            _method = method;
            _description = description;
        }

        public Action _method { get; }
        public string _description { get; }
}
}
