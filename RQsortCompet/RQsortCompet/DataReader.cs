using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RQsortCompet
{
    public static class DataReader
    {
        private static long _maxDataSize = Properties.Settings.Default._MAX_DATA_SIZE;

        public static List<string> TempFiles;

        private static void CreateTempFiles()
        {
            string tempFileName;
            try
            {
                tempFileName = Path.GetTempFileName();
                if (TempFiles == null)
                {
                    TempFiles = new List<string>();
                }
                TempFiles.Add(tempFileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ReadLargeFile(string dataPath)
        {
            long fileLength = new FileInfo(dataPath).Length;
            int splitNum = 0;

            if (fileLength > _maxDataSize)
            {
                splitNum = (int)Math.Ceiling((double)fileLength / (double)_maxDataSize);
            }

            for (int i = 0; i < splitNum; i++)
            {
                CreateTempFiles();
            }

            // Add log to remove temp files
            
        }

        public static void RemoveTempFiles()
        {

        }

    }
}
