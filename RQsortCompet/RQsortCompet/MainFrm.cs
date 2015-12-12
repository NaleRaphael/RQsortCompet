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
        private static double _ts_read;
        private static double _ts_sort;
        private static double _ts_write;
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

        private enum FileDialogMode { Input = 0, output }
        #endregion

        public MainFrm()
        {
            InitializeComponent();
            InitializeControl();
        }

        public void InitializeControl()
        {
            // For Benchmark
            this.Width = 356;
            lbl_Description_Benchmark.Text = "Please select a file ";
            // For searching method
            cmb_SortingMethod.SelectedIndex = 0;
        }

        #region Button
        private void btn_SelectInput_Click(object sender, EventArgs e)
        {
            SetFileDialog(txt_InputPath, FileDialogMode.Input);
        }

        private void btn_SelectOutput_Click(object sender, EventArgs e)
        {
            SetFileDialog(txt_OutputPath, FileDialogMode.output);
        }

        private void btn_SelectTestData_Click(object sender, EventArgs e)
        {
            SetFileDialog(txt_TestData, FileDialogMode.Input);
        }

        private void btn_SelectLogPath_Click(object sender, EventArgs e)
        {
            SetFileDialog(txt_LogPath, FileDialogMode.Input);
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
            UpdateTimeSpan(ref sw, ref _ts_read);

            // TODO: Using multi-threading to host sorting
            sw.Start();
            try
            {
                MethodInfo method = GetSortingAlgorithm(cmb_SortingMethod.SelectedItem.ToString());
                SortingAlg.FuncDelegate = (SortingAlg.AlgDelegate)Delegate.CreateDelegate(typeof(SortingAlg.AlgDelegate), method);
                SortingAlg.Start(ref data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sw.Stop();
            UpdateTimeSpan(ref sw, ref _ts_sort);

            // Export result
            sw.Start();
            ExportData(ref data, txt_OutputPath.Text);
            sw.Stop();
            UpdateTimeSpan(ref sw, ref _ts_write);

            tssl_Status.Text = "Done";
            tssl_Time.Text = string.Format("Time: {0}", _ts_sort.ToString());
            txt_Display.AppendText(string.Format("Method: {0}\n", cmb_SortingMethod.SelectedItem.ToString()));
            ShowTimeSpan("reading", _ts_read);
            ShowTimeSpan("sorting", _ts_sort);
            ShowTimeSpan("writing", _ts_write);

        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_Display.Clear();
        }

        private void btn_Benchmark_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txt_TestData.Text))
            {
                return;
            }

            string raw = File.ReadAllText(txt_TestData.Text);
            string[] data = raw.Split(' ');

            // Start benchmarking
            try
            {
                MethodInfo method = GetSortingAlgorithm(cmb_SortingMethod.SelectedItem.ToString()); // Get method from cmb_SortingMethod
                AlgBenchmark.IterationCountDownEvent += this.BenchmarkCountDown;    // Subscribe count down event
                AlgBenchmark.FuncDelegate = (AlgBenchmark.AlgDelegate)Delegate.CreateDelegate(typeof(AlgBenchmark.AlgDelegate), method);
                AlgBenchmark.Start(ref data, Convert.ToInt32(txt_Round.Text), txt_LogPath.Text);
                AlgBenchmark.IterationCountDownEvent -= this.BenchmarkCountDown;    // Unsubscribe count down event
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                AlgBenchmark.IterationCountDownEvent -= this.BenchmarkCountDown;    // Unsubscribe count down event
                MessageBox.Show(ex.Message);
            }
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
        private void UpdateTimeSpan(ref Stopwatch sw, ref double ts)
        {
            ts = sw.Elapsed.TotalMilliseconds;
        }

        private void ShowTimeSpan(string str, double ts)
        {
            txt_Display.AppendText(string.Format("Time for {0}: {1}ms \r\n", str, ts));
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

        private void BenchmarkCountDown(IterationEventArgs e)
        {
            txt_Display.AppendText(string.Format("Remaining round: {0}\n", e.IterationCount));
        }

        private MethodInfo GetSortingAlgorithm(string methodName)
        {
            Type type = typeof(SortingAlg);
            MethodInfo method = type.GetMethod(
                methodName,
                BindingFlags.Public | BindingFlags.Static,
                Type.DefaultBinder,
                new[] { typeof(string[]).MakeByRefType(), typeof(int), typeof(int) },
                null);
            if (method == null)
            {
                throw new MethodNotFoundException(string.Format("Method: {0} is not available.", methodName));
            }
            return method;
        }

        private void SetFileDialog(TextBox txtb, FileDialogMode fm)
        {
            if (fm == FileDialogMode.Input)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = Properties.Settings.Default._DEFAULT_INPUT_DIRECTORY;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(ofd.FileName))
                    {
                        txtb.Text = ofd.FileName;
                        Properties.Settings.Default._DEFAULT_INPUT_DIRECTORY = Path.GetDirectoryName(ofd.FileName);
                        Properties.Settings.Default.Save();
                    }
                }
            }
            else if (fm == FileDialogMode.output)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.InitialDirectory = Properties.Settings.Default._DEFAULT_OUTPUT_DIRECTORY;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    txtb.Text = sfd.FileName;
                    Properties.Settings.Default._DEFAULT_OUTPUT_DIRECTORY = Path.GetDirectoryName(sfd.FileName);
                    Properties.Settings.Default.Save();
                }
            }
        }
        #endregion
    }
}
