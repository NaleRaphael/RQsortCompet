using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RQsortCompet
{
    public class ArrayView
    {
        //public int[] View { get; set;}
        public int[] View;
        public ArrayView(string[] strAry)
        {
            View = new int[strAry.Length];
            for (int i = 0; i < strAry.Length; i++)
            {
                View[i] = i;
            }
        }

    }
}
