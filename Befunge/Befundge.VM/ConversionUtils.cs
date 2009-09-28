using System;
using System.Text;

namespace Befunge.VM
{
    static class ConversionUtils
    {
        internal static char ToChar(byte code)
        {
            char[] chars = Encoding.Default.GetChars(new byte[] { code });
            return chars[0];
        }

        internal static byte FromChar(char ch)
        {
            byte[] bytes = Encoding.Default.GetBytes(new char[] { ch });
            return bytes[0];
        }

        internal static char[] ToChars(byte[] bytes)
        {
            char[] chars = Encoding.Default.GetChars(bytes);
            return chars;
        }

        internal static byte[] FromChars(char[] chars)
        {
            byte[] bytes = Encoding.Default.GetBytes(chars);
            return bytes;
        }

    }
}
