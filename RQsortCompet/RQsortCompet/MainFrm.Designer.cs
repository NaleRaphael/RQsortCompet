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
            this.btn_Test = new System.Windows.Forms.Button();
            this.pnl_Main = new System.Windows.Forms.Panel();
            this.pnl_Benchmark = new System.Windows.Forms.Panel();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.pnl_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_Status,
            this.tssl_SplitLine01,
            this.tssl_Time});
            this.statusStrip.Location = new System.Drawing.Point(0, 311);
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
            this.tssl_SplitLine01.Size = new System.Drawing.Size(262, 20);
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
            this.txt_Display.Location = new System.Drawing.Point(5, 90);
            this.txt_Display.Multiline = true;
            this.txt_Display.Name = "txt_Display";
            this.txt_Display.ReadOnly = true;
            this.txt_Display.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Display.Size = new System.Drawing.Size(300, 160);
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
            // btn_Test
            // 
            this.btn_Test.Location = new System.Drawing.Point(68, 256);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(75, 23);
            this.btn_Test.TabIndex = 7;
            this.btn_Test.Text = "test";
            this.btn_Test.UseVisualStyleBackColor = true;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // pnl_Main
            // 
            this.pnl_Main.Controls.Add(this.lbl_InputPath);
            this.pnl_Main.Controls.Add(this.btn_Test);
            this.pnl_Main.Controls.Add(this.btn_Start);
            this.pnl_Main.Controls.Add(this.btn_Clear);
            this.pnl_Main.Controls.Add(this.btn_SelectInput);
            this.pnl_Main.Controls.Add(this.lbl_OutputPath);
            this.pnl_Main.Controls.Add(this.txt_InputPath);
            this.pnl_Main.Controls.Add(this.txt_Display);
            this.pnl_Main.Controls.Add(this.btn_SelectOutput);
            this.pnl_Main.Controls.Add(this.txt_OutputPath);
            this.pnl_Main.Location = new System.Drawing.Point(12, 27);
            this.pnl_Main.Name = "pnl_Main";
            this.pnl_Main.Size = new System.Drawing.Size(317, 284);
            this.pnl_Main.TabIndex = 8;
            // 
            // pnl_Benchmark
            // 
            this.pnl_Benchmark.Location = new System.Drawing.Point(348, 27);
            this.pnl_Benchmark.Name = "pnl_Benchmark";
            this.pnl_Benchmark.Size = new System.Drawing.Size(317, 284);
            this.pnl_Benchmark.TabIndex = 9;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 336);
            this.Controls.Add(this.pnl_Benchmark);
            this.Controls.Add(this.pnl_Main);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainFrm";
            this.Text = "String sorting";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.pnl_Main.ResumeLayout(false);
            this.pnl_Main.PerformLayout();
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
        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.Panel pnl_Main;
        private System.Windows.Forms.Panel pnl_Benchmark;
    }
}

