namespace RQsortCompet
{
    partial class Frm_DataConverter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_Source = new System.Windows.Forms.TextBox();
            this.lbl_Source = new System.Windows.Forms.Label();
            this.btn_SelectSource = new System.Windows.Forms.Button();
            this.txt_Destination = new System.Windows.Forms.TextBox();
            this.lbl_Destination = new System.Windows.Forms.Label();
            this.btn_SelectDest = new System.Windows.Forms.Button();
            this.btn_Convert = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tssl_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_Desciption = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Source
            // 
            this.txt_Source.Location = new System.Drawing.Point(12, 92);
            this.txt_Source.Name = "txt_Source";
            this.txt_Source.ReadOnly = true;
            this.txt_Source.Size = new System.Drawing.Size(300, 22);
            this.txt_Source.TabIndex = 0;
            // 
            // lbl_Source
            // 
            this.lbl_Source.AutoSize = true;
            this.lbl_Source.Location = new System.Drawing.Point(12, 77);
            this.lbl_Source.Name = "lbl_Source";
            this.lbl_Source.Size = new System.Drawing.Size(37, 12);
            this.lbl_Source.TabIndex = 1;
            this.lbl_Source.Text = "Source";
            // 
            // btn_SelectSource
            // 
            this.btn_SelectSource.Location = new System.Drawing.Point(309, 91);
            this.btn_SelectSource.Name = "btn_SelectSource";
            this.btn_SelectSource.Size = new System.Drawing.Size(23, 23);
            this.btn_SelectSource.TabIndex = 2;
            this.btn_SelectSource.Text = "...";
            this.btn_SelectSource.UseVisualStyleBackColor = true;
            this.btn_SelectSource.Click += new System.EventHandler(this.btn_SelectSource_Click);
            // 
            // txt_Destination
            // 
            this.txt_Destination.Location = new System.Drawing.Point(12, 132);
            this.txt_Destination.Name = "txt_Destination";
            this.txt_Destination.ReadOnly = true;
            this.txt_Destination.Size = new System.Drawing.Size(300, 22);
            this.txt_Destination.TabIndex = 0;
            // 
            // lbl_Destination
            // 
            this.lbl_Destination.AutoSize = true;
            this.lbl_Destination.Location = new System.Drawing.Point(12, 117);
            this.lbl_Destination.Name = "lbl_Destination";
            this.lbl_Destination.Size = new System.Drawing.Size(57, 12);
            this.lbl_Destination.TabIndex = 1;
            this.lbl_Destination.Text = "Destination";
            // 
            // btn_SelectDest
            // 
            this.btn_SelectDest.Location = new System.Drawing.Point(309, 131);
            this.btn_SelectDest.Name = "btn_SelectDest";
            this.btn_SelectDest.Size = new System.Drawing.Size(23, 23);
            this.btn_SelectDest.TabIndex = 2;
            this.btn_SelectDest.Text = "...";
            this.btn_SelectDest.UseVisualStyleBackColor = true;
            this.btn_SelectDest.Click += new System.EventHandler(this.btn_SelectDest_Click);
            // 
            // btn_Convert
            // 
            this.btn_Convert.Location = new System.Drawing.Point(257, 160);
            this.btn_Convert.Name = "btn_Convert";
            this.btn_Convert.Size = new System.Drawing.Size(75, 23);
            this.btn_Convert.TabIndex = 3;
            this.btn_Convert.Text = "Convert";
            this.btn_Convert.UseVisualStyleBackColor = true;
            this.btn_Convert.Click += new System.EventHandler(this.btn_Convert_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_Status});
            this.statusStrip.Location = new System.Drawing.Point(0, 190);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(344, 22);
            this.statusStrip.TabIndex = 4;
            // 
            // tssl_Status
            // 
            this.tssl_Status.Name = "tssl_Status";
            this.tssl_Status.Size = new System.Drawing.Size(0, 17);
            // 
            // lbl_Desciption
            // 
            this.lbl_Desciption.AutoSize = true;
            this.lbl_Desciption.Location = new System.Drawing.Point(12, 9);
            this.lbl_Desciption.Name = "lbl_Desciption";
            this.lbl_Desciption.Size = new System.Drawing.Size(58, 12);
            this.lbl_Desciption.TabIndex = 1;
            this.lbl_Desciption.Text = "Description";
            // 
            // Frm_DataConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 212);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btn_Convert);
            this.Controls.Add(this.btn_SelectDest);
            this.Controls.Add(this.btn_SelectSource);
            this.Controls.Add(this.lbl_Destination);
            this.Controls.Add(this.txt_Destination);
            this.Controls.Add(this.lbl_Desciption);
            this.Controls.Add(this.lbl_Source);
            this.Controls.Add(this.txt_Source);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_DataConverter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Data converter";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Source;
        private System.Windows.Forms.Label lbl_Source;
        private System.Windows.Forms.Button btn_SelectSource;
        private System.Windows.Forms.TextBox txt_Destination;
        private System.Windows.Forms.Label lbl_Destination;
        private System.Windows.Forms.Button btn_SelectDest;
        private System.Windows.Forms.Button btn_Convert;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Status;
        private System.Windows.Forms.Label lbl_Desciption;
    }
}