using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;


namespace RQsortCompet
{
    public static class AlgBenchmark
    {
        public delegate void AlgDelegate(ref string[] data, int start, int end);
        public static AlgDelegate FuncDelegate;
        private static Stopwatch _sw = new Stopwatch();

        public static void Start(ref string[] data, int stepNum, string logPath)
        {
            if (stepNum <= 0)
            {
                throw new InvalidArgException("stepNum should be greater than 0.");
            }

            if (!Directory.Exists(Path.GetDirectoryName(logPath)))
            {
                throw new InvalidArgException("logPath not found.");
            }

            Benchmark(FuncDelegate, ref data, stepNum, logPath);
        }

        private static void Benchmark(AlgDelegate func, ref string[] data, int stepNum, string logPath)
        {
            int step = data.Length / stepNum;
            string[] log = new string[stepNum];
            int i;
            string[] testData = new string[data.Length];

            try
            {
                for (i = 1; i <= stepNum; i++)
                {
                    Array.Copy(data, testData, step * i);
                    _sw.Start();
                    func(ref testData, 0, step * i - 1);
                    _sw.Stop();
                    log[i-1] = string.Format("{0}, {1}", step * i, _sw.ElapsedMilliseconds.ToString());
                }
                WriteLog(logPath, log);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void WriteLog(string logPath, string[] log)
        {
            if (!Directory.Exists(Path.GetDirectoryName(logPath)))
            {
                return;
            }

            try
            {
                StreamWriter writer = new StreamWriter(logPath);
                for (int i = 0; i < log.Length; i++)
                {
                    writer.Write(string.Format("{0}\r\n", log[i]));
                }
                writer.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
