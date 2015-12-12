using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RQsortCompet
{
    public class InvalidArgException : Exception
    {
        public InvalidArgException(string message)
            : base(message)
        {
        }
    }

    public class MyBenchmarkException : Exception
    {
        public MyBenchmarkException(string message)
            : base(message)
        {

        }
    }
}
