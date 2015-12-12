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
        private static Random _rand = new Random();

        private static readonly int _MAX_STACK_DEPTH = Properties.Settings.Default._STACK_DEPTH;
        private static int _stackDepth = 10;

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

        // Test function
        public static void ChangeSD()
        {
            MessageBox.Show(string.Format("{0}", _stackDepth));
            for (int i = 0; i < 3; i++)
            {
                _stackDepth++;
            }
            MessageBox.Show(string.Format("{0}", _stackDepth));
        }

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

        #region Sorting algorithm
        public static void QSort(ref string[] unsorted)
        {
            QSort(unsorted, 0, unsorted.Length - 1, 0);
        }

        public static void QSort(ref string[] unsorted, int start, int end)
        {
            if (start < 0 || end > unsorted.Length - 1)
            {
                throw new InvalidArgException("Given index of data is out of range.");
            }
            QSort(unsorted, start, end, _stackDepth);
        }

        public static void QSort3(ref string[] unsorted)
        {
            QSort3(unsorted, 0, unsorted.Length - 1, 0, _stackDepth);
        }

        public static void QSort3(ref string[] unsorted, int start, int end)
        {
            if (start < 0 || end > unsorted.Length - 1)
            {
                throw new InvalidArgException("Given index of data is out of range.");
            }
            QSort3(unsorted, start, end, 0, _stackDepth);
        }

        public static void RQSort(ref string[] unsorted)
        {
            RQSort(unsorted, 0, unsorted.Length - 1, _stackDepth);
        }

        public static void RQSort(ref string[] unsorted, int start, int end)
        {
            if (start < 0 || end > unsorted.Length - 1)
            {
                throw new InvalidArgException("Given index of data is out of range.");
            }
            RQSort(unsorted, start, end, _stackDepth);
        }

        public static void RQSort3(ref string[] unsorted)
        {
            RQSort3(unsorted, 0, unsorted.Length - 1, 0, _stackDepth);
        }

        public static void RQSort3(ref string[] unsorted, int start, int end)
        {
            if (start < 0 || end > unsorted.Length - 1)
            {
                throw new InvalidArgException("Given index of data is out of range.");
            }
            RQSort3(unsorted, start, end, 0, _stackDepth);
        }

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
            }
        }

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
            }
        }

        /// <summary>
        /// Randomized radix quicksort with three-way partitioning.
        /// ref: http://www.informit.com/articles/article.aspx?p=2180073&seqNum=4
        /// </summary>
        /// <param name="a">String array.</param>
        /// <param name="lo">Low index pointer of a string.</param>
        /// <param name="hi">High index pointer of a string.</param>
        /// <param name="d">Depth of a string.</param>
        /// <param name="sd">Depth of stack.</param>
        private static void RQSort3(string[] a, int lo, int hi, int d, int sd)
        {
            // Check
            if (hi <= lo)
            {
                return;
            }

            // Select index of pivot
            int p = _rand.Next(lo+1, hi);

            // Do three-way partition
            int lt, gt, v;
            Partition3(a, lo, hi, d, sd, out lt, out gt, out v);

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

        private static int Partition(string[] a, int p, int r)
        {
            string v = a[r];
            int i = p - 1;
            for (int j = p; j < r; j++)
            {
                if (string.Compare(a[j], v) <= 0)
                {
                    i++;
                    Swap(ref a[i], ref a[j]);
                }
            }
            Swap(ref a[i + 1], ref a[r]);
            return i + 1;
        }

        private static int RPartition(string[] a, int p, int r)
        {
            int i = _rand.Next(p, r);
            Swap(ref a[r], ref a[i]);
            return Partition(a, p, r);
        }

        /// <summary>
        /// Three-way partitioning.
        /// </summary>
        /// <param name="a">String array.</param>
        /// <param name="lo">Lowest index pointer of a string.</param>
        /// <param name="hi">Highest inedx pointer of a string.</param>
        /// <param name="d">Depth of a string.</param>
        /// <param name="sd">Depth of stack.</param>
        /// <param name="lt">Index of lower threshold.</param>
        /// <param name="gt">Index of higher threshold.</param>
        /// <param name="v">Index of pivot.</param>
        private static void Partition3(string[] a, int lo, int hi, int d, int sd, out int lt, out int gt, out int v)
        {
            int i = lo + 1; // Running index to select target
            int t = -1;     // Preallocate space for target
            lt = lo;
            gt = hi;
            v = CharAt(a[lo], d);   // Pivot

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

        public static void InsertionSort(ref string[] a)
        {
            InsrtSort(a, 0, a.Length);
        }

        public static void InsertionSort(ref string[] a, int left, int right)
        {
            InsrtSort(a, left, right);
        }

        public static void InsertionSort_multikey(ref string[] a)
        {
            InsertionSort_multikey(ref a, 0, a.Length - 1);
        }

        public static void InsertionSort_multikey(ref string[] a, int left, int right)
        {
            int maxLen = FindLongestString(ref a, left, right);
            InsrtSort_mk(a, left, right, maxLen);
        }

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

        private static void InsrtSort(string[] a, int left, int right)
        {
            string temp;    // pivot
            int j;
            for (int i = left + 1; i < right; i++)
            {
                temp = a[i];
                j = i - 1;
                while (j > left - 1 && string.Compare(temp, a[j], StringComparison.Ordinal) < 0)
                {
                    a[j + 1] = a[j];
                    j--;
                }
                a[j + 1] = temp;
            }
        }

        private static void InsrtSort_mk(string[] a, int left, int right, int d)
        {
            string pivot;
            int v = -1; // value of the selected character of pivot
            int j;
            bool canSearch = false;

            for (int i = left + 1; i <= right; i++)
            {
                pivot = a[i];
                v = CharAt(pivot, d);
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
                return;
            }
            else
            {
                InsrtSort_mk(a, left, right, d);
            }
            //for (int i = 0; i < a.Length; i++)
            //{
            //    if (CharAt(a[i], d) != -1)
            //    {
            //        canSearch = true;
            //        break;
            //    }
            //}

            //if (canSearch)
            //{
            //    InsrtSort_mk(a, left, right, d);
            //}
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
        /*
        unsafe private static void UnsafeSwap(string* a, string* b)
        {
            char** temp = a;
            a = b;
            b = temp;
        }*/

        unsafe public static void UnsafeSwap(char* a, char* b)
        {
            /*char* temp = a;
            a = b;
            b = temp;*/
            char* temp = a;
            *a = *b;
            *b = *temp;
        }
        #endregion
    }
}
