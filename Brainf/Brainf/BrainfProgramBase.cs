using System;
using System.Collections.Generic;
using System.Text;

namespace Brainf
{
    public abstract class BrainfProgramBase
    {
        int ip = 0;
        Memory memory = new Memory();

        public int IP
        {
            get { return ip; }
            protected set { ip = value; }
        }

        public Memory Memory
        {
            get { return memory; }
        }

        public BrainfProgramBase()
        {
        }

        public void PutChar(byte ch)
        {
            if (ch == 10)
                Console.WriteLine();
            else
                Console.Write((char)ch);
        }

        public byte GetChar()
        {
            int ch;
            do
            {
                ch = Console.Read();
                if (ch < 0) throw new InvalidOperationException("End of stream");
            } while (ch != 13);

            return (byte)ch;
        }

        public abstract void Run();
    }
}
