using System;
using System.Collections.Generic;
using System.Text;

namespace CheckIn.Services
{    public class ConsoleInputOutput : IInputOutput
    {
        public void WriteLine(string s)
        {
            Console.WriteLine(s);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
