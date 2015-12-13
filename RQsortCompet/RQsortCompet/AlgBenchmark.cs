﻿using System;
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

        public delegate void IterationCountDownEventHandler(IterationEventArgs e);
        public static event IterationCountDownEventHandler IterationCountDownEvent;

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

            try
            {
                Benchmark(FuncDelegate, ref data, stepNum, logPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void Benchmark(AlgDelegate func, ref string[] data, int stepNum, string logPath)
        {
            int step = data.Length / stepNum;

            if (step <= 1)
            {
                throw new MyBenchmarkException("Given value of testing round makes step for each loop be too small.\nPlease re-enter an value.");
            }

            string[] log = new string[stepNum];
            string[] testData = new string[data.Length];
            IterationEventArgs iterArgs = new IterationEventArgs(stepNum);

            try
            {
                for (int i = 1; i <= stepNum; i++)
                {
                    Array.Copy(data, testData, step * i);
                    _sw.Start();
                    func(ref testData, 0, step * i - 1);
                    _sw.Stop();

                    iterArgs.IterationCount -= 1;       // Count down
                    IterationCountDownEvent(iterArgs);  // Fire event to notice host
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

    public class IterationEventArgs : EventArgs
    {
        public int IterationCount { get; set; }
        public IterationEventArgs(int num)
        {
            IterationCount = num;
        }
    }
}
