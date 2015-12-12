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

namespace RQsortCompet
{
    public partial class Frm_DataConverter : Form
    {
        public Frm_DataConverter()
        {
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            lbl_Desciption.Text = "This converter helps you to format your test data.\n";
            lbl_Desciption.Text += "1. Convert all upper cases to lower cases.\n";
            lbl_Desciption.Text += "2. Remove all punctuation marks.\n";
            lbl_Desciption.Text += "3. Remove redundant white spaces.\n";
        }

        private void btn_SelectSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"D:\Users\Nale\Desktop\alghw\input";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txt_Source.Text = ofd.FileName;
            }
            else
            {
                return;
            }
        }

        private void btn_SelectDest_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"D:\Users\Nale\Desktop\alghw\input";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                txt_Destination.Text = sfd.FileName;
            }
            else
            {
                return;
            }
        }

        private void btn_Convert_Click(object sender, EventArgs e)
        {
            tssl_Status.Text = "Start converting...";
            try
            {
                DataConverter.FileToFile(txt_Source.Text, txt_Destination.Text);
                tssl_Status.Text = "Done.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
