using System;
using System.Collections.Generic;
using System.Text;

namespace Befunge.VM
{
    /// <summary>
    /// Stack stack as in http://quadium.net/funge/spec98.html#Stack_Stack
    /// </summary>
    public class StackStack
    {
        const int MaxStackSize = 1024;
        Stack<int> stack = new Stack<int>();

        public int Count
        {
            get { return stack.Count; }
        }

        public int Pop()
        {
            if (stack.Count > 0)
                return stack.Pop();
            else
                return 0;
        }

        internal StackStack()
        {
        }

        public void Push(int item)
        {
            if (MaxStackSize == stack.Count)
                throw new InvalidOperationException("Stack overflow");

            stack.Push(item);
        }

        public void Clear()
        {
            stack.Clear();
        }

        public void CopyTo(int[] array, int arrayOffset)
        {
            stack.CopyTo(array, arrayOffset);
        }

        public int[] ToArray()
        {
            return stack.ToArray();
        }
    }
}
