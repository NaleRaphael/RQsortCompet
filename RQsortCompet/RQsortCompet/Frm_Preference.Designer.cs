﻿namespace RQsortCompet
{
    partial class Frm_Preference
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
            this.txt_MaxStackDepth = new System.Windows.Forms.TextBox();
            this.lbl_MaxStackDepth = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_MaxStackDepth
            // 
            this.txt_MaxStackDepth.Location = new System.Drawing.Point(14, 24);
            this.txt_MaxStackDepth.Name = "txt_MaxStackDepth";
            this.txt_MaxStackDepth.Size = new System.Drawing.Size(100, 22);
            this.txt_MaxStackDepth.TabIndex = 0;
            // 
            // lbl_MaxStackDepth
            // 
            this.lbl_MaxStackDepth.AutoSize = true;
            this.lbl_MaxStackDepth.Location = new System.Drawing.Point(12, 9);
            this.lbl_MaxStackDepth.Name = "lbl_MaxStackDepth";
            this.lbl_MaxStackDepth.Size = new System.Drawing.Size(81, 12);
            this.lbl_MaxStackDepth.TabIndex = 1;
            this.lbl_MaxStackDepth.Text = "Max stack depth";
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(197, 52);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 2;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // Frm_Preference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 87);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.lbl_MaxStackDepth);
            this.Controls.Add(this.txt_MaxStackDepth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Preference";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Preference";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_MaxStackDepth;
        private System.Windows.Forms.Label lbl_MaxStackDepth;
        private System.Windows.Forms.Button btn_Save;
    }
}