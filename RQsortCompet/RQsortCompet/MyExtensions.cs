using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RQsortCompet
{
    public static class MyExtensions
    {
        /// <summary>
        /// Find the character by a given index from a string.
        /// </summary>
        /// <param name="s">String.</param>
        /// <param name="d">Depth(index) of desired character.</param>
        /// <returns>ASCII code of the character locating at given depth.</returns>
        public static int CharAt(this string s, int d)
        {
            if (d < s.Length)
            {
                return s[d];
            }
            else
            {
                return -1;
            }
        }
    }
}
