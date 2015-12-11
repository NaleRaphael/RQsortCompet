using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace RQsortCompet
{
    public static class AlgBenchmark
    {
        public delegate void AlgDelegate(string[] data);

        public static void Start(AlgDelegate func, string[] data, int step, string logPath)
        {
            try
            {
                func(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void WriteLog(string logPath, string log)
        {
            if (!Directory.Exists(Path.GetDirectoryName(logPath)))
            {
                return;
            }

            StreamWriter writer = new StreamWriter(logPath);

        }

    }
}
