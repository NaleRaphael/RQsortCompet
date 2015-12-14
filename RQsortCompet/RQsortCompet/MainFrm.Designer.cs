namespace RQsortCompet
{
    partial class MainFrm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tssl_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_SplitLine01 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Time = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_Start = new System.Windows.Forms.Button();
            this.txt_InputPath = new System.Windows.Forms.TextBox();
            this.lbl_InputPath = new System.Windows.Forms.Label();
            this.btn_SelectInput = new System.Windows.Forms.Button();
            this.btn_SelectOutput = new System.Windows.Forms.Button();
            this.txt_OutputPath = new System.Windows.Forms.TextBox();
            this.lbl_OutputPath = new System.Windows.Forms.Label();
            this.txt_Display = new System.Windows.Forms.TextBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmi_Converter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Benchmark = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Preference = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_Main = new System.Windows.Forms.Panel();
            this.btn_Test = new System.Windows.Forms.Button();
            this.cmb_SortingMethod = new System.Windows.Forms.ComboBox();
            this.lbl_SortingMethod = new System.Windows.Forms.Label();
            this.pnl_Benchmark = new System.Windows.Forms.Panel();
            this.grp_Benchmark = new System.Windows.Forms.GroupBox();
            this.lbl_Description_Benchmark = new System.Windows.Forms.Label();
            this.lbl_Round = new System.Windows.Forms.Label();
            this.txt_Round = new System.Windows.Forms.TextBox();
            this.txt_TestData = new System.Windows.Forms.TextBox();
            this.txt_LogPath = new System.Windows.Forms.TextBox();
            this.btn_SelectTestData = new System.Windows.Forms.Button();
            this.btn_SelectLogPath = new System.Windows.Forms.Button();
            this.btn_Benchmark = new System.Windows.Forms.Button();
            this.lbl_TestData = new System.Windows.Forms.Label();
            this.lbl_LogPath = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.pnl_Main.SuspendLayout();
            this.pnl_Benchmark.SuspendLayout();
            this.grp_Benchmark.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_Status,
            this.tssl_SplitLine01,
            this.tssl_Time});
            this.statusStrip.Location = new System.Drawing.Point(0, 316);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(680, 25);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip";
            // 
            // tssl_Status
            // 
            this.tssl_Status.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tssl_Status.Name = "tssl_Status";
            this.tssl_Status.Size = new System.Drawing.Size(21, 20);
            this.tssl_Status.Text = "   ";
            // 
            // tssl_SplitLine01
            // 
            this.tssl_SplitLine01.Name = "tssl_SplitLine01";
            this.tssl_SplitLine01.Size = new System.Drawing.Size(571, 20);
            this.tssl_SplitLine01.Spring = true;
            // 
            // tssl_Time
            // 
            this.tssl_Time.Name = "tssl_Time";
            this.tssl_Time.Size = new System.Drawing.Size(42, 20);
            this.tssl_Time.Text = "Time: ";
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(230, 256);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 23);
            this.btn_Start.TabIndex = 1;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // txt_InputPath
            // 
            this.txt_InputPath.Location = new System.Drawing.Point(5, 18);
            this.txt_InputPath.Name = "txt_InputPath";
            this.txt_InputPath.ReadOnly = true;
            this.txt_InputPath.Size = new System.Drawing.Size(277, 22);
            this.txt_InputPath.TabIndex = 2;
            this.txt_InputPath.Text = "D:\\Users\\Nale\\Desktop\\alghw\\input\\input.txt";
            // 
            // lbl_InputPath
            // 
            this.lbl_InputPath.AutoSize = true;
            this.lbl_InputPath.Location = new System.Drawing.Point(3, 3);
            this.lbl_InputPath.Name = "lbl_InputPath";
            this.lbl_InputPath.Size = new System.Drawing.Size(50, 12);
            this.lbl_InputPath.TabIndex = 3;
            this.lbl_InputPath.Text = "Input File";
            // 
            // btn_SelectInput
            // 
            this.btn_SelectInput.Location = new System.Drawing.Point(282, 18);
            this.btn_SelectInput.Name = "btn_SelectInput";
            this.btn_SelectInput.Size = new System.Drawing.Size(23, 23);
            this.btn_SelectInput.TabIndex = 1;
            this.btn_SelectInput.Text = "...";
            this.btn_SelectInput.UseVisualStyleBackColor = true;
            this.btn_SelectInput.Click += new System.EventHandler(this.btn_SelectInput_Click);
            // 
            // btn_SelectOutput
            // 
            this.btn_SelectOutput.Location = new System.Drawing.Point(282, 61);
            this.btn_SelectOutput.Name = "btn_SelectOutput";
            this.btn_SelectOutput.Size = new System.Drawing.Size(23, 23);
            this.btn_SelectOutput.TabIndex = 1;
            this.btn_SelectOutput.Text = "...";
            this.btn_SelectOutput.UseVisualStyleBackColor = true;
            this.btn_SelectOutput.Click += new System.EventHandler(this.btn_SelectOutput_Click);
            // 
            // txt_OutputPath
            // 
            this.txt_OutputPath.Location = new System.Drawing.Point(5, 61);
            this.txt_OutputPath.Name = "txt_OutputPath";
            this.txt_OutputPath.ReadOnly = true;
            this.txt_OutputPath.Size = new System.Drawing.Size(277, 22);
            this.txt_OutputPath.TabIndex = 2;
            this.txt_OutputPath.Text = "D:\\Users\\Nale\\Desktop\\alghw\\output\\output_test.txt";
            // 
            // lbl_OutputPath
            // 
            this.lbl_OutputPath.AutoSize = true;
            this.lbl_OutputPath.Location = new System.Drawing.Point(3, 46);
            this.lbl_OutputPath.Name = "lbl_OutputPath";
            this.lbl_OutputPath.Size = new System.Drawing.Size(57, 12);
            this.lbl_OutputPath.TabIndex = 3;
            this.lbl_OutputPath.Text = "Output File";
            // 
            // txt_Display
            // 
            this.txt_Display.Location = new System.Drawing.Point(5, 135);
            this.txt_Display.Multiline = true;
            this.txt_Display.Name = "txt_Display";
            this.txt_Display.ReadOnly = true;
            this.txt_Display.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Display.Size = new System.Drawing.Size(300, 115);
            this.txt_Display.TabIndex = 2;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(149, 256);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 4;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Silver;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Converter,
            this.tsmi_Benchmark,
            this.tsmi_Preference});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(680, 24);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip";
            // 
            // tsmi_Converter
            // 
            this.tsmi_Converter.Name = "tsmi_Converter";
            this.tsmi_Converter.Size = new System.Drawing.Size(75, 20);
            this.tsmi_Converter.Text = "Converter";
            this.tsmi_Converter.Click += new System.EventHandler(this.tsmi_Converter_Click);
            // 
            // tsmi_Benchmark
            // 
            this.tsmi_Benchmark.Name = "tsmi_Benchmark";
            this.tsmi_Benchmark.Size = new System.Drawing.Size(82, 20);
            this.tsmi_Benchmark.Text = "Benchmark";
            this.tsmi_Benchmark.Click += new System.EventHandler(this.tsmi_Benchmark_Click);
            // 
            // tsmi_Preference
            // 
            this.tsmi_Preference.Name = "tsmi_Preference";
            this.tsmi_Preference.Size = new System.Drawing.Size(80, 20);
            this.tsmi_Preference.Text = "Preference";
            this.tsmi_Preference.Click += new System.EventHandler(this.tsmi_Preference_Click);
            // 
            // pnl_Main
            // 
            this.pnl_Main.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_Main.Controls.Add(this.btn_Test);
            this.pnl_Main.Controls.Add(this.cmb_SortingMethod);
            this.pnl_Main.Controls.Add(this.lbl_InputPath);
            this.pnl_Main.Controls.Add(this.btn_Start);
            this.pnl_Main.Controls.Add(this.btn_Clear);
            this.pnl_Main.Controls.Add(this.btn_SelectInput);
            this.pnl_Main.Controls.Add(this.lbl_SortingMethod);
            this.pnl_Main.Controls.Add(this.lbl_OutputPath);
            this.pnl_Main.Controls.Add(this.txt_InputPath);
            this.pnl_Main.Controls.Add(this.txt_Display);
            this.pnl_Main.Controls.Add(this.btn_SelectOutput);
            this.pnl_Main.Controls.Add(this.txt_OutputPath);
            this.pnl_Main.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnl_Main.Location = new System.Drawing.Point(12, 27);
            this.pnl_Main.Name = "pnl_Main";
            this.pnl_Main.Size = new System.Drawing.Size(317, 284);
            this.pnl_Main.TabIndex = 8;
            // 
            // btn_Test
            // 
            this.btn_Test.Location = new System.Drawing.Point(68, 256);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(75, 23);
            this.btn_Test.TabIndex = 9;
            this.btn_Test.Text = "test";
            this.btn_Test.UseVisualStyleBackColor = true;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // cmb_SortingMethod
            // 
            this.cmb_SortingMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SortingMethod.FormattingEnabled = true;
            this.cmb_SortingMethod.Items.AddRange(new object[] {
            "QSort",
            "RQSort",
            "QSort3",
            "RQSort3",
            "RQSort3_hybrid",
            "InsertionSort",
            "InsertionSort_multikey"});
            this.cmb_SortingMethod.Location = new System.Drawing.Point(86, 96);
            this.cmb_SortingMethod.Name = "cmb_SortingMethod";
            this.cmb_SortingMethod.Size = new System.Drawing.Size(121, 20);
            this.cmb_SortingMethod.TabIndex = 8;
            // 
            // lbl_SortingMethod
            // 
            this.lbl_SortingMethod.AutoSize = true;
            this.lbl_SortingMethod.Location = new System.Drawing.Point(3, 99);
            this.lbl_SortingMethod.Name = "lbl_SortingMethod";
            this.lbl_SortingMethod.Size = new System.Drawing.Size(77, 12);
            this.lbl_SortingMethod.TabIndex = 3;
            this.lbl_SortingMethod.Text = "Sorting method";
            // 
            // pnl_Benchmark
            // 
            this.pnl_Benchmark.Controls.Add(this.grp_Benchmark);
            this.pnl_Benchmark.Location = new System.Drawing.Point(348, 27);
            this.pnl_Benchmark.Name = "pnl_Benchmark";
            this.pnl_Benchmark.Size = new System.Drawing.Size(317, 284);
            this.pnl_Benchmark.TabIndex = 9;
            // 
            // grp_Benchmark
            // 
            this.grp_Benchmark.Controls.Add(this.lbl_Description_Benchmark);
            this.grp_Benchmark.Controls.Add(this.lbl_Round);
            this.grp_Benchmark.Controls.Add(this.txt_Round);
            this.grp_Benchmark.Controls.Add(this.txt_TestData);
            this.grp_Benchmark.Controls.Add(this.txt_LogPath);
            this.grp_Benchmark.Controls.Add(this.btn_SelectTestData);
            this.grp_Benchmark.Controls.Add(this.btn_SelectLogPath);
            this.grp_Benchmark.Controls.Add(this.btn_Benchmark);
            this.grp_Benchmark.Controls.Add(this.lbl_TestData);
            this.grp_Benchmark.Controls.Add(this.lbl_LogPath);
            this.grp_Benchmark.Location = new System.Drawing.Point(3, 3);
            this.grp_Benchmark.Name = "grp_Benchmark";
            this.grp_Benchmark.Size = new System.Drawing.Size(311, 278);
            this.grp_Benchmark.TabIndex = 0;
            this.grp_Benchmark.TabStop = false;
            this.grp_Benchmark.Text = "Benchmark";
            // 
            // lbl_Description_Benchmark
            // 
            this.lbl_Description_Benchmark.AutoSize = true;
            this.lbl_Description_Benchmark.Location = new System.Drawing.Point(6, 20);
            this.lbl_Description_Benchmark.Name = "lbl_Description_Benchmark";
            this.lbl_Description_Benchmark.Size = new System.Drawing.Size(126, 12);
            this.lbl_Description_Benchmark.TabIndex = 3;
            this.lbl_Description_Benchmark.Text = "Desciption for benchmark";
            // 
            // lbl_Round
            // 
            this.lbl_Round.AutoSize = true;
            this.lbl_Round.Location = new System.Drawing.Point(6, 93);
            this.lbl_Round.Name = "lbl_Round";
            this.lbl_Round.Size = new System.Drawing.Size(37, 12);
            this.lbl_Round.TabIndex = 3;
            this.lbl_Round.Text = "Round";
            // 
            // txt_Round
            // 
            this.txt_Round.Location = new System.Drawing.Point(49, 88);
            this.txt_Round.Name = "txt_Round";
            this.txt_Round.Size = new System.Drawing.Size(50, 22);
            this.txt_Round.TabIndex = 4;
            this.txt_Round.Text = "10";
            // 
            // txt_TestData
            // 
            this.txt_TestData.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_TestData.Location = new System.Drawing.Point(5, 135);
            this.txt_TestData.Name = "txt_TestData";
            this.txt_TestData.ReadOnly = true;
            this.txt_TestData.Size = new System.Drawing.Size(277, 22);
            this.txt_TestData.TabIndex = 2;
            this.txt_TestData.Text = "D:\\Users\\Nale\\Desktop\\alghw\\input\\input.txt";
            // 
            // txt_LogPath
            // 
            this.txt_LogPath.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_LogPath.Location = new System.Drawing.Point(5, 177);
            this.txt_LogPath.Name = "txt_LogPath";
            this.txt_LogPath.ReadOnly = true;
            this.txt_LogPath.Size = new System.Drawing.Size(277, 22);
            this.txt_LogPath.TabIndex = 2;
            this.txt_LogPath.Text = "D:\\Users\\Nale\\Desktop\\alghw\\log\\log.csv";
            // 
            // btn_SelectTestData
            // 
            this.btn_SelectTestData.Location = new System.Drawing.Point(282, 135);
            this.btn_SelectTestData.Name = "btn_SelectTestData";
            this.btn_SelectTestData.Size = new System.Drawing.Size(23, 23);
            this.btn_SelectTestData.TabIndex = 1;
            this.btn_SelectTestData.Text = "...";
            this.btn_SelectTestData.UseVisualStyleBackColor = true;
            this.btn_SelectTestData.Click += new System.EventHandler(this.btn_SelectTestData_Click);
            // 
            // btn_SelectLogPath
            // 
            this.btn_SelectLogPath.Location = new System.Drawing.Point(282, 177);
            this.btn_SelectLogPath.Name = "btn_SelectLogPath";
            this.btn_SelectLogPath.Size = new System.Drawing.Size(23, 23);
            this.btn_SelectLogPath.TabIndex = 1;
            this.btn_SelectLogPath.Text = "...";
            this.btn_SelectLogPath.UseVisualStyleBackColor = true;
            this.btn_SelectLogPath.Click += new System.EventHandler(this.btn_SelectLogPath_Click);
            // 
            // btn_Benchmark
            // 
            this.btn_Benchmark.Location = new System.Drawing.Point(230, 253);
            this.btn_Benchmark.Name = "btn_Benchmark";
            this.btn_Benchmark.Size = new System.Drawing.Size(75, 23);
            this.btn_Benchmark.TabIndex = 1;
            this.btn_Benchmark.Text = "Start";
            this.btn_Benchmark.UseVisualStyleBackColor = true;
            this.btn_Benchmark.Click += new System.EventHandler(this.btn_Benchmark_Click);
            // 
            // lbl_TestData
            // 
            this.lbl_TestData.AutoSize = true;
            this.lbl_TestData.Location = new System.Drawing.Point(5, 118);
            this.lbl_TestData.Name = "lbl_TestData";
            this.lbl_TestData.Size = new System.Drawing.Size(46, 12);
            this.lbl_TestData.TabIndex = 3;
            this.lbl_TestData.Text = "Test data";
            // 
            // lbl_LogPath
            // 
            this.lbl_LogPath.AutoSize = true;
            this.lbl_LogPath.Location = new System.Drawing.Point(5, 160);
            this.lbl_LogPath.Name = "lbl_LogPath";
            this.lbl_LogPath.Size = new System.Drawing.Size(47, 12);
            this.lbl_LogPath.TabIndex = 3;
            this.lbl_LogPath.Text = "Log path";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 341);
            this.Controls.Add(this.pnl_Benchmark);
            this.Controls.Add(this.pnl_Main);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainFrm";
            this.Text = "String sorting";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.pnl_Main.ResumeLayout(false);
            this.pnl_Main.PerformLayout();
            this.pnl_Benchmark.ResumeLayout(false);
            this.grp_Benchmark.ResumeLayout(false);
            this.grp_Benchmark.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.TextBox txt_InputPath;
        private System.Windows.Forms.Label lbl_InputPath;
        private System.Windows.Forms.Button btn_SelectInput;
        private System.Windows.Forms.Button btn_SelectOutput;
        private System.Windows.Forms.TextBox txt_OutputPath;
        private System.Windows.Forms.Label lbl_OutputPath;
        private System.Windows.Forms.TextBox txt_Display;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Preference;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Status;
        private System.Windows.Forms.ToolStripStatusLabel tssl_SplitLine01;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Time;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Converter;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Benchmark;
        private System.Windows.Forms.Panel pnl_Main;
        private System.Windows.Forms.Panel pnl_Benchmark;
        private System.Windows.Forms.GroupBox grp_Benchmark;
        private System.Windows.Forms.TextBox txt_LogPath;
        private System.Windows.Forms.Button btn_SelectLogPath;
        private System.Windows.Forms.Label lbl_LogPath;
        private System.Windows.Forms.Button btn_Benchmark;
        private System.Windows.Forms.Label lbl_Round;
        private System.Windows.Forms.TextBox txt_Round;
        private System.Windows.Forms.ComboBox cmb_SortingMethod;
        private System.Windows.Forms.Label lbl_SortingMethod;
        private System.Windows.Forms.Label lbl_Description_Benchmark;
        private System.Windows.Forms.TextBox txt_TestData;
        private System.Windows.Forms.Button btn_SelectTestData;
        private System.Windows.Forms.Label lbl_TestData;
        private System.Windows.Forms.Button btn_Test;
    }
}

