using System;
using System.Collections.Generic;
using System.Text;

namespace photoniced.essentials.ConsoleUnitWrapper
{
    public interface IConsole
    {
        void Write(string message);
        void WriteLine(string message);
        void Clear();
        string ReadLine();
    }
}
