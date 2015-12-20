using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace RQsortCompet
{
    public static class SortingAlg
    {
        public delegate void AlgDelegate(ref string[] data, int start, int end);
        public static AlgDelegate FuncDelegate;

        private static Random _rand = new Random();

        private static readonly int _MAX_STACK_DEPTH = Properties.Settings.Default._MAX_STACK_DEPTH;
        private static int _stackDepth = Properties.Settings.Default._INI_STACK_DEPTH;
        private static readonly int _SWITCH_THRESHOLD = Properties.Settings.Default._SWITCH_THRESHOLD;

        #region Properties
        private static int StackDepth
        {
            get
            {
                return _stackDepth;
            }
            set
            {
                if (_stackDepth + value >= _MAX_STACK_DEPTH || _stackDepth - value <= 0)
                {
                    return;
                }
                else
                {
                    _stackDepth += value;
                }
            }
        }
        #endregion

        // TODO: write a version of passing the reference of string
        /// <summary>
        /// Find the character by a given index from a string.
        /// </summary>
        /// <param name="s">String.</param>
        /// <param name="d"></param>
        /// <returns></returns>
        private static int CharAt(string s, int d)
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

        /// <summary>
        /// Find the longest string from given string array.
        /// </summary>
        /// <param name="a">String array.</param>
        /// <param name="left">Left index of given range.</param>
        /// <param name="right">Right index of given range.</param>
        /// <returns></returns>
        private static int FindLongestString(ref string[] a, int left, int right)
        {
            int maxLen = a[left].Length;
            int tempLen = 0;
            for (int i = left; i < right; i++)
            {
                tempLen = a[i].Length;
                if (tempLen > maxLen)
                {
                    maxLen = tempLen;
                }
            }
            return maxLen;
        }

        /// <summary>
        /// Start sorting (using function delegate).
        /// </summary>
        /// <param name="data">String array.</param>
        public static void Start(ref string[] data)
        {
            try
            {
                FuncDelegate(ref data, 0, data.Length-1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Sorting algorithm
        /// <summary>
        /// Quicksort.
        /// </summary>
        /// <param name="unsorted">String array.</param>
        public static void QSort(ref string[] unsorted)
        {
            try
            {
                QSort(unsorted, 0, unsorted.Length - 1, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Quicksort.
        /// </summary>
        /// <param name="unsorted">String array.</param>
        /// <param name="start">Left index of given range.</param>
        /// <param name="end">Right inedx of given range.</param>
        public static void QSort(ref string[] unsorted, int start, int end)
        {
            if (start < 0 || end > unsorted.Length - 1)
            {
                throw new InvalidArgException("Given index of data is out of range.");
            }
            try
            {
                QSort(unsorted, start, end, _stackDepth);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Quicksort (3-way partition).
        /// </summary>
        /// <param name="unsorted">String array.</param>
        public static void QSort3(ref string[] unsorted)
        {
            try
            {
                QSort3(unsorted, 0, unsorted.Length - 1, 0, _stackDepth);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Quicksort (3-way partition).
        /// </summary>
        /// <param name="unsorted">String array.</param>
        /// <param name="start">Left index of given range.</param>
        /// <param name="end">Right index of given range.</param>
        public static void QSort3(ref string[] unsorted, int start, int end)
        {
            if (start < 0 || end > unsorted.Length - 1)
            {
                throw new InvalidArgException("Given index of data is out of range.");
            }
            try
            {
                QSort3(unsorted, start, end, 0, _stackDepth);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Randomized quicksort.
        /// </summary>
        /// <param name="unsorted">String array.</param>
        public static void RQSort(ref string[] unsorted)
        {
            try
            {
                RQSort(unsorted, 0, unsorted.Length - 1, _stackDepth);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Randomized quicksort.
        /// </summary>
        /// <param name="unsorted">String array.</param>
        /// <param name="start">Left index of given range.</param>
        /// <param name="end">Right index of given range.</param>
        public static void RQSort(ref string[] unsorted, int start, int end)
        {
            if (start < 0 || end > unsorted.Length - 1)
            {
                throw new InvalidArgException("Given index of data is out of range.");
            }

            try
            {
                RQSort(unsorted, start, end, _stackDepth);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Randomized quicksort (3-way partition).
        /// </summary>
        /// <param name="unsorted">String array.</param>
        public static void RQSort3(string[] unsorted)
        {
            RQSort3(unsorted, 0, unsorted.Length - 1, 0, _stackDepth);
        }

        /// <summary>
        /// Randomized quicksort.
        /// </summary>
        /// <param name="unsorted">String array.</param>
        public static void RQSort3(ref string[] unsorted)
        {
            try
            {
                RQSort3(unsorted, 0, unsorted.Length - 1, 0, _stackDepth);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Randomized quicksort.
        /// </summary>
        /// <param name="unsorted">String array.</param>
        /// <param name="start">Left index of given range.</param>
        /// <param name="end">Right index of given range.</param>
        public static void RQSort3(ref string[] unsorted, int start, int end)
        {
            if (start < 0 || end > unsorted.Length - 1)
            {
                throw new InvalidArgException("Given index of data is out of range.");
            }

            try
            {
                RQSort3(unsorted, start, end, 0, _stackDepth);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Combination of randomized quicksort (3-way partition) and insertion sort.
        /// </summary>
        /// <param name="unsorted">String array.</param>
        public static void RQSort3_hybrid(ref string[] unsorted)
        {
            try
            {
                RQSort3_hybrid(unsorted, 0, unsorted.Length - 1, 0, _stackDepth);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Combination of randomized quicksort (3-way partition) and insertion sort.
        /// </summary>
        /// <param name="unsorted">String array.</param>
        /// <param name="start">Left index of given range.</param>
        /// <param name="end">Right index of given range.s</param>
        public static void RQSort3_hybrid(ref string[] unsorted, int start, int end)
        {
            if (start < 0 || end > unsorted.Length - 1)
            {
                throw new InvalidArgException("Given index of data is out of range.");
            }

            try
            {
                RQSort3_hybrid(unsorted, start, end, 0, _stackDepth);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insertion sort.
        /// </summary>
        /// <param name="unsorted">String array.</param>
        public static void InsertionSort(ref string[] unsorted)
        {
            try
            {
                InsrtSort(unsorted, 0, unsorted.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insertion sort.
        /// </summary>
        /// <param name="unsorted">String array.</param>
        /// <param name="left">Left index of given range.</param>
        /// <param name="right">Right index of given range.</param>
        public static void InsertionSort(ref string[] unsorted, int left, int right)
        {
            if (left < 0 || right > unsorted.Length - 1)
            {
                throw new InvalidArgException("Given index of data is out of range.");
            }

            try
            {
                InsrtSort(unsorted, left, right);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insertion sort (multiple key comparison).
        /// </summary>
        /// <param name="unsorted">String array.</param>
        public static void InsertionSort_multikey(ref string[] unsorted)
        {
            try
            {
                InsertionSort_multikey(ref unsorted, 0, unsorted.Length - 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insertion sort (multiple key comparison).
        /// </summary>
        /// <param name="unsorted">String array.</param>
        /// <param name="left">Left index of given range.</param>
        /// <param name="right">Right index of given range.</param>
        public static void InsertionSort_multikey(ref string[] unsorted, int left, int right)
        {
            // Find legnth of the longest string.
            int maxLen = FindLongestString(ref unsorted, left, right);
            try
            {
                // Do insertion sort. Comparison starts from the rightest character.
                InsrtSort_mk(unsorted, left, right, maxLen);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Quicksort.
        /// </summary>
        /// <param name="a">String array.</param>
        /// <param name="p">Left index of given range.</param>
        /// <param name="r">Right index of given range.</param>
        /// <param name="sd">Depth of stack.</param>
        private static void QSort(string[] a, int p, int r, int sd)
        {
            if (p < r)
            {
                int q = Partition(a, p, r);
                if (--sd > 0)
                {
                    Parallel.Invoke(
                        () => QSort(a, p, q - 1, sd),
                        () => QSort(a, q + 1, r, sd)
                    );
                }
                else
                {
                    QSort(a, p, q - 1, sd);
                    QSort(a, q + 1, r, sd);
                }
            }
        }

        /// <summary>
        /// Quicksort (3-way parition).
        /// </summary>
        /// <param name="a">String array.</param>
        /// <param name="lo">Left inedx of given range.</param>
        /// <param name="hi">Right index of given range.</param>
        /// <param name="d">Depth, index of selected character in a string.</param>
        /// <param name="sd">Depth of stack.</param>
        private static void QSort3(string[] a, int lo, int hi, int d, int sd)
        {
            if (hi <= lo)
            {
                return;
            }

            int lt = lo;    // Lower threshold
            int gt = hi;    // Greater threshold
            int i = lo + 1; // Running index to select target
            int v = CharAt(a[lo], d);    // Pivot
            int t = -1;     // Preallocate space for target

            while (i <= gt)
            {
                t = CharAt(a[i], d);
                if (t < v)
                {
                    // Target is smaller than the pivot, so it has to be swaped to the left part.
                    // Lower threshold and index of pivot have to +1.
                    // (the later an element is swaped, a larger index it will get)
                    Swap(ref a[lt++], ref a[i++]);
                }
                else if (t > v)
                {
                    // Target is greater than the pivot, so it has to be swaped to the right part.
                    // Greater threshold has to -1. 
                    // (the later an element is swaped, a smaller index it will get)
                    Swap(ref a[i], ref a[gt--]);
                }
                else
                {
                    // Target equals to the pivot, so it is classfied into the middle part.
                    // Only the index of pivot has to +1.
                    i++;
                }
            }

            if (sd > 0)
            {
                sd--;
                if (v >= 0)
                {
                    Parallel.Invoke(
                        () => QSort3(a, lo, lt - 1, d, sd),
                        () => QSort3(a, lt, gt, d + 1, sd),
                        () => QSort3(a, gt + 1, hi, d, sd)
                    );
                }
                else
                {
                    Parallel.Invoke(
                        () => QSort3(a, lo, lt - 1, d, sd),
                        () => QSort3(a, gt + 1, hi, d, sd)
                    );
                }
            }
            else
            {
                // Left part
                QSort3(a, lo, lt - 1, d, 0);
                // Middle part (same prefix, so it starts handling substring)
                if (v >= 0)
                {
                    QSort3(a, lt, gt, d + 1, 0);
                }
                // Right part
                QSort3(a, gt + 1, hi, d, 0);
            }
        }

        /// <summary>
        /// Randomized quicksort.
        /// </summary>
        /// <param name="a">String array.</param>
        /// <param name="p">Left index of given range.</param>
        /// <param name="r">Right index of given range.</param>
        /// <param name="sd">Depth of stack.</param>
        private static void RQSort(string[] a, int p, int r, int sd)
        {
            if (p < r)
            {
                int q = RPartition(a, p, r);
                if (--sd > 0)
                {
                    Parallel.Invoke(
                        () => RQSort(a, p, q - 1, sd),
                        () => RQSort(a, q + 1, r, sd)
                    );
                }
                else
                {
                    RQSort(a, p, q - 1, sd);
                    RQSort(a, q + 1, r, sd);
                }
            }
        }

        /// <summary>
        /// Randomized radix quicksort with three-way partitioning.
        /// ref: http://www.informit.com/articles/article.aspx?p=2180073&seqNum=4
        /// </summary>
        /// <param name="a">String array.</param>
        /// <param name="lo">Low index pointer of a string.</param>
        /// <param name="hi">High index pointer of a string.</param>
        /// <param name="d">Depth, index of selected character in a string.</param>
        /// <param name="sd">Depth of stack.</param>
        private static void RQSort3(string[] a, int lo, int hi, int d, int sd)
        {
            // Check
            if (hi <= lo)
            {
                return;
            }

            // Select index of pivot
            //int p = _rand.Next(lo+1, hi);

            // Do three-way partition
            int lt, gt, v;
            RPartition3(a, lo, hi, d, sd, out lt, out gt, out v);

            if (--sd >= 0)
            {
                if (v >= 0)
                {
                    Parallel.Invoke(
                        () => RQSort3(a, lo, lt - 1, d, sd),    // Left part
                        () => RQSort3(a, lt, gt, d + 1, sd),    // Middle part
                        () => RQSort3(a, gt + 1, hi, d, sd)     // Right part
                    );
                }
                else
                {
                    Parallel.Invoke(
                        () => RQSort3(a, lo, lt - 1, d, sd),    // Left part
                        () => RQSort3(a, gt + 1, hi, d, sd)     // Right part
                    );
                }
                
            }
            else
            {
                // Left part
                RQSort3(a, lo, lt - 1, d, sd);
                // Middle part (with same prefix, so it starts handling substring)
                if (v >= 0)
                {
                    RQSort3(a, lt, gt, d + 1, sd);
                }
                // Right part
                RQSort3(a, gt + 1, hi, d, sd);
            }
        }

        /// <summary>
        /// Combination of randomized quicksort (3-way partition) and insertion sort.
        /// </summary>
        /// <param name="a">String array.</param>
        /// <param name="lo">Left index of given range.</param>
        /// <param name="hi">Right index of given range.</param>
        /// <param name="d">Depth, index of selected character in a string.</param>
        /// <param name="sd">Depth of stack.</param>
        private static void RQSort3_hybrid(string[] a, int lo, int hi, int d, int sd)
        {
            // Check
            if (hi <= lo)
            {
                return;
            }
            else if (hi - lo < _SWITCH_THRESHOLD)
            {
                InsertionSort_multikey(ref a, lo, hi);
            }

            // Select index of pivot
            int p = _rand.Next(lo + 1, hi);

            // Do three-way partition
            int lt, gt, v;
            RPartition3(a, lo, hi, d, sd, out lt, out gt, out v);

            if (--sd >= 0)
            {
                if (v >= 0)
                {
                    Parallel.Invoke(
                        () => RQSort3(a, lo, lt - 1, d, sd),    // Left part
                        () => RQSort3(a, lt, gt, d + 1, sd),    // Middle part
                        () => RQSort3(a, gt + 1, hi, d, sd)     // Right part
                    );
                }
                else
                {
                    Parallel.Invoke(
                        () => RQSort3(a, lo, lt - 1, d, sd),    // Left part
                        () => RQSort3(a, gt + 1, hi, d, sd)     // Right part
                    );
                }

            }
            else
            {
                // Left part
                RQSort3(a, lo, lt - 1, d, sd);
                // Middle part (with same prefix, so it starts handling substring)
                if (v >= 0)
                {
                    RQSort3(a, lt, gt, d + 1, sd);
                }
                // Right part
                RQSort3(a, gt + 1, hi, d, sd);
            }
        }

        /// <summary>
        /// Partition process for string array. Using built-in method.
        /// </summary>
        /// <param name="a">String array.</param>
        /// <param name="p">Left index of given range.</param>
        /// <param name="r">Right index of given range.</param>
        /// <returns></returns>
        private static int Partition(string[] a, int p, int r)
        {
            string v = a[r];
            int i = p - 1;
            for (int j = p; j < r; j++)
            {
                // Compare these string using ordinal(binary) sort rules.
                // See: https://msdn.microsoft.com/en-us/library/system.stringcomparison.aspx
                if (string.Compare(a[j], v, StringComparison.Ordinal) <= 0)
                {
                    i++;
                    Swap(ref a[i], ref a[j]);
                }
            }
            Swap(ref a[i + 1], ref a[r]);
            return i + 1;
        }

        /// <summary>
        /// Randomized parition processing. Using built-in method.
        /// </summary>
        /// <param name="a">String array.</param>
        /// <param name="p">Left index of given range.</param>
        /// <param name="r">Right index of given range.</param>
        /// <returns></returns>
        private static int RPartition(string[] a, int p, int r)
        {
            int i = _rand.Next(p, r);
            Swap(ref a[r], ref a[i]);
            return Partition(a, p, r);
        }

        /// <summary>
        /// Randomized 3-way partition process.
        /// </summary>
        /// <param name="a">String array.</param>
        /// <param name="lo">Lowest index pointer of a string.</param>
        /// <param name="hi">Highest inedx pointer of a string.</param>
        /// <param name="d">Depth, index of selected character in a string.</param>
        /// <param name="sd">Depth of stack.</param>
        /// <param name="lt">Index of lower threshold.</param>
        /// <param name="gt">Index of higher threshold.</param>
        /// <param name="v">Index of pivot.</param>
        private static void RPartition3(string[] a, int lo, int hi, int d, int sd, out int lt, out int gt, out int v)
        {
            int i = lo;     // Running index to select target
            int t = -1;     // Preallocate space for target
            int p = _rand.Next(lo + 1, hi); // Select index of pivot
            lt = lo;
            gt = hi;
            v = CharAt(a[p], d);   // Pivot

            while (i <= gt)
            {
                t = CharAt(a[i], d);    // Target
                if (t < v)
                {
                    // Target is smaller than the pivot, so it has to be swaped to the left part.
                    // Lower threshold and index of pivot have to +1.
                    // (the later an element is swaped, a larger index it will get)
                    Swap(ref a[lt++], ref a[i++]);
                }
                else if (t > v)
                {
                    // Target is greater than the pivot, so it has to be swaped to the right part.
                    // Greater threshold has to -1. 
                    // (the later an element is swaped, a smaller index it will get)
                    Swap(ref a[i], ref a[gt--]);
                }
                else
                {
                    // Target equals to the pivot, so it is classfied into the middle part.
                    // Only the index of pivot has to +1.
                    i++;
                }
            }
        }

        /// <summary>
        /// Insertion sort.
        /// </summary>
        /// <param name="a">String array.</param>
        /// <param name="left">Left index of given range.</param>
        /// <param name="right">Right index of given range.</param>
        private static void InsrtSort(string[] a, int left, int right)
        {
            string temp;    // pivot
            int j;
            for (int i = left + 1; i <= right; i++)
            {
                temp = a[i];
                j = i - 1;
                while (j > left - 1 && string.Compare(temp, a[j]) < 0)
                {
                    a[j + 1] = a[j];
                    j--;
                }
                a[j + 1] = temp;
            }
        }

        /// <summary>
        /// Insertion sort (multiple key comparison).
        /// Multiple key comparision: compare strings 
        /// </summary>
        /// <param name="a">String array.</param>
        /// <param name="left">Left index of given range.</param>
        /// <param name="right">Right index of given range.</param>
        /// <param name="d">Depth, index of selected character in a string.</param>
        private static void InsrtSort_mk(string[] a, int left, int right, int d)
        {
            string pivot;   
            int v = -1;     // value of the selected character of pivot
            int j;

            for (int i = left + 1; i <= right; i++)
            {
                pivot = a[i];
                v = CharAt(pivot, d);   // get value (ASCII code) of selected character 
                j = i - 1;
                while (j > left - 1 && v < CharAt(a[j], d))
                {
                    a[j + 1] = a[j];
                    j--;
                }
                a[j + 1] = pivot;
            }

            if (--d < 0)
            {
                // Depth of 
                return;
            }
            else
            {
                InsrtSort_mk(a, left, right, d);
            }
        }
        #endregion

        #region Swap functions
        public static void Swap(string[] a, int i, int j)
        {
            string temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        public static void Swap(string a, string b)
        {
            string temp = a;
            a = b;
            b = temp;
        }

        public static void Swap(ref string a, ref string b)
        {
            string temp = a;
            a = b;
            b = temp;
        }

        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        #endregion
    }
}
