using System;
using System.Collections.Generic;
using System.Text;

namespace CheckIn.Services
{
    public interface IInputOutput
    {
        void WriteLine(string s);
        string ReadLine();
    }
}
