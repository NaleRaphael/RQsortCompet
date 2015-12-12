using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Timers;
using System.Diagnostics;
using System.Threading;
using System.Reflection;

namespace RQsortCompet
{
    public partial class MainFrm : Form
    {
        #region Fields
        // Performance
        private static TimeSpan _ts_read;
        private static TimeSpan _ts_sort;
        private static TimeSpan _ts_write;
        private static long _ms_read;
        private static long _ms_sort;
        private static long _ms_write;
        // IO
        private StreamWriter _writer;
        // Control
        private static bool _enable_benchmark = false;
        // Timer
        private System.Windows.Forms.Timer _ctrl_timer;
        // Form
        private Frm_Preference frm_pref;
        private Frm_DataConverter frm_dataConverter;
        // Thread
        private Thread _worker;
        #endregion

        public MainFrm()
        {
            InitializeComponent();
            InitializeControl();
        }

        public void InitializeControl()
        {
            // For pnl_Benchmark
            this.Width = 356;
            // For searching method
            cmb_SortingMethod.SelectedIndex = 0;
        }

        #region Button
        private void btn_SelectInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"D:\Users\Nale\Desktop\alghw\input";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(ofd.FileName))
                {
                    txt_InputPath.Text = ofd.FileName;
                }
            }
        }

        private void btn_SelectOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                txt_OutputPath.Text = sfd.FileName;
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            // Read file and split them with space
            string raw;
            string[] data;
            Stopwatch sw = new Stopwatch();

            // Read file and generate data
            sw.Start();
            try
            {
                raw = File.ReadAllText(txt_InputPath.Text);
                data = raw.Split(' ');
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            sw.Stop();
            UpdateTimeSpan(ref sw, ref _ts_read, ref _ms_read);

            // TODO: Using multi-threading to host sorting
            sw.Start();
            try
            {
                SortingAlg.InsertionSort_multikey(ref data);
                //SortingAlg.RQSort(ref data);
                //SortingAlg.RQSort3(ref data);
                //SortingAlg.InsertionSort(ref data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sw.Stop();
            UpdateTimeSpan(ref sw, ref _ts_sort, ref _ms_sort);

            // Export result
            sw.Start();
            ExportData(ref data, txt_OutputPath.Text);
            sw.Stop();
            UpdateTimeSpan(ref sw, ref _ts_write, ref _ms_write);

            tssl_Status.Text = "Done";
            tssl_Time.Text = string.Format("Time: {0}", _ts_sort.ToString());
            ShowTimeSpan("Read", _ts_read, _ms_read);
            ShowTimeSpan("Sort", _ts_sort, _ms_sort);
            ShowTimeSpan("Write", _ts_write, _ms_write);

        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_Display.Clear();
        }
        #endregion

        #region Other controls
        private void tsmi_Preference_Click(object sender, EventArgs e)
        {
            if (frm_pref != null)
            {
                return;
            }
            frm_pref = new Frm_Preference();
            frm_pref.Location = IniLoc(this);
            frm_pref.Owner = this;
            frm_pref.FormClosed += tsmi_Preference_Closed;
            frm_pref.Show();
        }

        private void tsmi_Converter_Click(object sender, EventArgs e)
        {
            if (frm_dataConverter != null)
            {
                return;
            }
            frm_dataConverter = new Frm_DataConverter();
            frm_dataConverter.Location = IniLoc(this);
            frm_dataConverter.Owner = this;
            frm_dataConverter.FormClosed += tsmi_dataConverter_Closed;
            frm_dataConverter.Show();
        }

        private void tsmi_Preference_Closed(object sender, EventArgs e)
        {
            frm_pref = null;
        }

        private void tsmi_dataConverter_Closed(object sender, EventArgs e)
        {
            frm_dataConverter = null;
        }

        private static Point IniLoc(Form frm)
        {
            return new Point((int)(frm.Location.X + frm.Width / 4), (int)(frm.Location.Y + frm.Height / 4));
        }

        private void tsmi_Benchmark_Click(object sender, EventArgs e)
        {
            _ctrl_timer = new System.Windows.Forms.Timer();
            _ctrl_timer.Tick += new EventHandler(ShowOrHide_pnl_Benchmark);
            _ctrl_timer.Interval = 1;
            _enable_benchmark = !_enable_benchmark;     // Invert flag of panel control
            pnl_Benchmark.Enabled = _enable_benchmark;  // Lock or unlock panel
            _ctrl_timer.Enabled = true;
        }

        private void ShowOrHide_pnl_Benchmark(object sender, EventArgs e)
        {

            if (_enable_benchmark)
            {
                if (this.Width >= 696)
                {
                    _ctrl_timer.Enabled = false;
                    _ctrl_timer.Dispose();
                }
                else
                {
                    this.Width += 68;
                }
            }
            else
            {
                if (this.Width <= 356)
                {
                    _ctrl_timer.Enabled = false;
                    _ctrl_timer.Dispose();
                }
                else
                {
                    this.Width -= 68;
                }
            }
        }
        #endregion

        #region Other functions
        private void UpdateTimeSpan(ref Stopwatch sw, ref TimeSpan ts, ref long ms)
        {
            ts = sw.Elapsed;
            ms = sw.ElapsedMilliseconds;
        }
        private void ShowTimeSpan(string str, TimeSpan ts, long ms)
        {
            txt_Display.AppendText(string.Format("{0}: \r\nTime span: {1} \r\nTime: {2}ms \r\n", str, ts, ms));
        }
        private void ExportData(ref string[] data, string destination)
        {
            _writer = new StreamWriter(txt_OutputPath.Text);
            for (int i = 0; i < data.Length; i++)
            {
                _writer.WriteLine(data[i]);
            }
            _writer.Close();
        }
        #endregion

        private void btn_Test_Click(object sender, EventArgs e)
        {

        }

        private void btn_Benchmark_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txt_InputPath.Text))
            {
                return;
            }

            string raw = File.ReadAllText(txt_InputPath.Text);
            string[] data = raw.Split(' ');

            // Get method from cmb_SortingMethod
            string methodName = cmb_SortingMethod.SelectedItem.ToString();
            Type type = typeof(SortingAlg);
            MethodInfo method = type.GetMethod(
                methodName,
                BindingFlags.Public | BindingFlags.Static,
                Type.DefaultBinder,
                new[] {typeof(string[]).MakeByRefType(), typeof(int), typeof(int)},
                null);

            // Check
            if (method == null)
            {
                MessageBox.Show("Method not found.");
                return;
            }

            try
            {
                AlgBenchmark.FuncDelegate = (AlgBenchmark.AlgDelegate)Delegate.CreateDelegate(typeof(AlgBenchmark.AlgDelegate), method);
                AlgBenchmark.Start(ref data, Convert.ToInt32(txt_Round.Text), txt_LogPath.Text);
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
