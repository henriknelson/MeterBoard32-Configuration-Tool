using System;
using System.Linq;
using System.Text;

namespace MeterBoard32
{
    public static class Helpers
    {
        public static bool ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
                return false;

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
                return false;

            byte tempForParsing;
            return splitValues.All(r => byte.TryParse(r, out tempForParsing));
        }

        public static byte[] TrimEnd(byte[] array)
        {
            int lastIndex = Array.FindLastIndex(array, b => b != 0);
            Array.Resize(ref array, lastIndex + 1);
            return array;
        }

        public static byte[] ToBCD(int value,int length)
        {
            if (value < 0 || value > 99999999)
                throw new ArgumentOutOfRangeException("value");

            byte[] ret = new byte[length];
            for (int i = 0; i < length; i++)
            {
                ret[i] = (byte)(value % 10);
                value /= 10;
                ret[i] |= (byte)((value % 10) << 4);
                value /= 10;
            }
            return ret;
        }

        public static string BCDDecode(this byte[] bytes, int length)
        {
            long val = 0;

            for (int i = length; i > 0; i--)
            {
                val = (val * 10) + ((bytes[i - 1] >> 4) & 0xF);
                val = (val * 10) + (bytes[i - 1] & 0xF);
            }

            return val.ToString();
        }

        public static string StripControlChars(string arg)
        {
            char[] arrForm = arg.ToCharArray();
            StringBuilder buffer = new StringBuilder(arg.Length);//This many chars at most

            foreach (char ch in arrForm)
                if (!Char.IsControl(ch)) buffer.Append(ch);//Only add to buffer if not a control char

            return buffer.ToString();
        }

        public static string StripExtended(string arg)
        {
            StringBuilder buffer = new StringBuilder(arg.Length); //Max length
            foreach (char ch in arg)
            {
                UInt16 num = Convert.ToUInt16(ch);//In .NET, chars are UTF-16
                //The basic characters have the same code points as ASCII, and the extended characters are bigger
                if ((num >= 32u) && (num <= 126u)) buffer.Append(ch);
            }
            return buffer.ToString();
        }

        public static string StringToHexString(string utfString)
        {
            return BitConverter.ToString(Encoding.UTF8.GetBytes(utfString)).Replace("-", "");
        }
    }
}
