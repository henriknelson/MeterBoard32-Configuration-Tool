using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterBoard32.Classes
{
    public static class ArrayExtensions
    {
        public static T[] Slice<T>(this T[] source, int start, int end=0)
        {
            // Handles negative ends.
            if (end < 0)
            {
                end = source.Length + end;
            }
            else if(end == 0)
            {
                end = source.Length;
            }
            int len = end - start;
            if (len > source.Length)
            {
                len = source.Length;
            }
            // Return new array.

            T[] res = new T[len];
            for (int i = 0; i < len; i++)
            {
                res[i] = source[i + start];
            }
            return res;
        }
    }
}
