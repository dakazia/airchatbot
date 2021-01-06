using System;

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
