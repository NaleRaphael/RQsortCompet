using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace RQsortCompet
{
    public static class DataConverter
    {
        public enum CaseFormat
        {
            UpperCase = 0,
            LowerCase = 1
        }

        public static void FileToFile(string sourcePath, string destPath)
        {
            string data = File.ReadAllText(sourcePath);
            data = Regex.Replace(data, @"(\w+?)", c => c.ToString().ToLower());
            data = Regex.Replace(data, @"[^\w\s]", "");
            data = Regex.Replace(data, @"(\s+|\r|\n)", " ");

            StreamWriter writer = new StreamWriter(destPath);
            writer.Write(data);
            writer.Close();
        }
    }
}
