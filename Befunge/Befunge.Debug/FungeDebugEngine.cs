using System;
using System.Collections.Generic;
using System.Text;

using Befunge.VM;
using System.Windows.Forms;

namespace Befunge.Debug
{
    class FungeDebugEngine : FungeEngine
    {
        TextBox outputTextBox;

        public FungeDebugEngine(TextBox outputTextBox)
        {
            this.outputTextBox = outputTextBox;
        }

        protected override int ReadChar()
        {
            throw new NotImplementedException();
        }

        protected override int ReadInteger()
        {
            throw new NotImplementedException();
        }

        protected override void WriteChar(int c)
        {
            if (c == 10)
                outputTextBox.AppendText(Environment.NewLine);
            else
                outputTextBox.AppendText(((char)c).ToString());
        }

        protected override void WriteInt(int a)
        {
            outputTextBox.AppendText(a.ToString() + " ");
        }
    }
}
