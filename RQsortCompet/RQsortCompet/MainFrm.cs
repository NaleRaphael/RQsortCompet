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
        private delegate void SortingJobEventHandler(ref string[] data);
        private delegate void SortingJobFinishedEventHandler(SortingJobFinishedEventArgs e);
        private static event SortingJobFinishedEventHandler SortingFinishedEvent;
        private delegate void SetTextDelegate(TextBox txtb, string text);

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
            lbl_Description_Benchmark.Text = "1. Please select a file (Test data) for benchmarking.\n";
            lbl_Description_Benchmark.Text += "2. Choose the path for output result (Log path).\n";
            lbl_Description_Benchmark.Text += "3. Set parameters:\n";
            lbl_Description_Benchmark.Text += "    Round: Rounds for benchmarking.\n";
            lbl_Description_Benchmark.Text += "    Loop for average: Repeated times for a single round.\n";
            lbl_Description_Benchmark.Text += "    (Notice: One unit of test data = Data length / Round)\n";
            // For searching method
            cmb_SortingMethod.SelectedIndex = 3;
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

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_Display.Clear();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            try
            {
                string methodName = cmb_SortingMethod.SelectedItem.ToString();
                string inputPath = txt_InputPath.Text;
                SortingFinishedEvent += UpdateInformation;      // Subscribe sorting job finished event
                _worker = new Thread(() => StartSorting(inputPath, methodName));
                _worker.Start();
            }
            catch (Exception ex)
            {
                SortingFinishedEvent -= UpdateInformation;      // Unsubscribe sorting job finished event
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Benchmark_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txt_TestData.Text))
            {
                return;
            }

            try
            {
                string methodName = cmb_SortingMethod.SelectedItem.ToString();
                string inputPath = txt_InputPath.Text;
                int round = Convert.ToInt32(txt_Round.Text);
                int loop = Convert.ToInt32(txt_LoopForAverage.Text);
                _worker = new Thread(() => StartBenchmarking(methodName, inputPath, round, loop, txt_LogPath.Text));
                _worker.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Main functions
        private void StartSorting(string dataPath, string methodName)
        {
            // Read file and split them with space
            string raw;
            string[] data;
            Stopwatch sw = new Stopwatch();

            // Read file and generate data
            sw.Restart();
            try
            {
                raw = File.ReadAllText(dataPath);
                data = raw.Split(' ');

                FileStream fs = File.OpenRead(dataPath);
                BufferedStream bs = new BufferedStream(fs);
                StreamReader reader = new StreamReader(bs);
            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show(ex.Message);
                return;
            }
            sw.Stop();
            UpdateTimeSpan(ref sw, ref _ts_read);

            try
            {
                MethodInfo method = GetSortingAlgorithm(methodName);
                SortingAlg.FuncDelegate = (SortingAlg.AlgDelegate)Delegate.CreateDelegate(typeof(SortingAlg.AlgDelegate), method);
                sw.Restart();
                SortingAlg.Start(ref data);
                sw.Stop();
                UpdateTimeSpan(ref sw, ref _ts_sort);
            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show(ex.Message);
                return;
            }

            // Export result
            sw.Restart();
            ExportData(ref data, txt_OutputPath.Text);
            sw.Stop();
            UpdateTimeSpan(ref sw, ref _ts_write);

            // Release memory
            data = null;
            raw = null;
            GC.Collect();

            SortingJobFinishedEventArgs e = new SortingJobFinishedEventArgs(methodName, sw.Elapsed.TotalMilliseconds);
            SortingFinishedEvent(e);     // fire event to notify user that sorting is done

        }

        private void StartBenchmarking(string selectedAlg, string dataPath, int round, int loop, string logPath)
        {
            string raw = File.ReadAllText(dataPath);
            string[] data = raw.Split(' ');

            // Start benchmarking
            try
            {
                MethodInfo method = GetSortingAlgorithm(selectedAlg);   // Get method from cmb_SortingMethod
                AlgBenchmark.IterationCountDownEvent += this.BenchmarkCountDown;    // Subscribe count down event
                AlgBenchmark.FuncDelegate = (AlgBenchmark.AlgDelegate)Delegate.CreateDelegate(typeof(AlgBenchmark.AlgDelegate), method);
                AlgBenchmark.Start(ref data, round, loop, logPath);
                AlgBenchmark.IterationCountDownEvent -= this.BenchmarkCountDown;    // Unsubscribe count down event
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                AlgBenchmark.IterationCountDownEvent -= this.BenchmarkCountDown;    // Unsubscribe count down event
                MessageBox.Show(ex.Message);
                return;
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
            tssl_Status.Text = e.IterationCount.ToString();
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

        private void UpdateInformation(SortingJobFinishedEventArgs e)
        {
            // Update information to textbox
            string outputText = string.Format("Method: {0}\r\n", e.SelectedAlgName);
            outputText += string.Format("Time for reading: {0}ms\r\n", _ts_read);
            outputText += string.Format("Time for sorting: {0}ms\r\n", _ts_sort);
            outputText += string.Format("Time for writing: {0}ms\r\n", _ts_write);
            SetText(txt_Display, outputText);
            // Update status
            tssl_Status.Text = "Done";
            tssl_Time.Text = string.Format("Time: {0}", e.TimeTaken.ToString());
            // Unsubscribe sorting job finished event
            SortingFinishedEvent -= UpdateInformation;
        }

        private void SetText(TextBox txtb, string text)
        {
            if (txtb.InvokeRequired)
            {
                SetTextDelegate d = new SetTextDelegate(SetText);
                this.Invoke(d, new object[] { txtb, text });
            }
            else
            {
                txtb.Text += text;
            }
        }
        #endregion

        private void btn_Test_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    FileStream fs = File.OpenRead(txt_InputPath.Text);
            //    BufferedStream bs = new BufferedStream(fs);
            //    StreamReader reader = new StreamReader(bs);
            //    string line = string.Empty;
            //    string remaining = string.Empty;
            //    List<string[]> tempData = new List<string[]>(); 
            //    bool isRemaining = false;

            //    string[] data = {};
            //    string[] temp;
            //    int count = 0;
            //    int lastidx = -1;
            //    char[] buffer = new char[512000];

            //    while (!reader.EndOfStream)
            //    {
            //        reader.Read(buffer, 0, 512000);
            //        line = new string(buffer);

            //        if (remaining != string.Empty)
            //        {
            //            line = remaining + line;
            //            remaining = string.Empty;
            //        }

            //        if (line[line.Length - 1] == '\0' || line[line.Length - 1] == ' ')
            //        {
            //            line = line.Trim('\0');
            //            temp = line.Split(' ');
            //        }
            //        else
            //        {
            //            line = line.Trim('\0');
            //            lastidx = line.LastIndexOf(' ');
            //            remaining = line.Substring(lastidx);
            //            line = line.Substring(0, lastidx);
            //            temp = line.Split(' ');
            //        }

            //        tempData.Add(temp);
            //        temp = null;
            //        line = null;
            //        GC.Collect();
            //        txt_Display.AppendText(tempData.Count.ToString()+"\n");
            //    }

                
            //    txt_Display.AppendText(data.Length.ToString());
            //    data = null;
            //    temp = null;
            //    GC.Collect();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_worker != null && _worker.IsAlive)
            {
                try
                {
                    _worker.Abort();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }

    public class SortingJobFinishedEventArgs : EventArgs
    {
        public string SelectedAlgName { get; set; }
        public double TimeTaken { get; set; }

        public SortingJobFinishedEventArgs(string algName, double timeTaken)
        {
            SelectedAlgName = algName;
            TimeTaken = timeTaken;
        }
    }
}
