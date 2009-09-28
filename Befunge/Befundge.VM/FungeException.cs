using System;
using System.Collections.Generic;
using System.Text;

namespace Befunge.VM
{
    public class FungeException : Exception
    {
        public FungeException(string message)
            : base(message)
        {
        }

        public FungeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
