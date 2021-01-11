using System;
using System.Collections.Generic;
using System.Text;

namespace photoniced.essentials.ConsoleUnitWrapper
{
    class ConsoleUnitWrapper : IConsole
    {
            public void Write(string message)
            {
                Console.Write(message);
            }

            public void WriteLine(string message)
            {
                Console.WriteLine(message);
            }

            public string ReadLine()
            {
                return Console.ReadLine();
            }
    }
}
