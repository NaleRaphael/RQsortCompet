using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RQsortCompet
{
    public partial class Frm_Preference : Form
    {
        public Frm_Preference()
        {
            InitializeComponent();
            InitializePreference();
        }

        private void InitializePreference()
        {
            txt_MaxStackDepth.Text = Properties.Settings.Default._STACK_DEPTH.ToString();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Save those changed setting?", "Save change", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    Properties.Settings.Default._STACK_DEPTH = Convert.ToInt32(txt_MaxStackDepth.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Properties.Settings.Default.Save();
            }
            else
            {
                return;
            }
        }
    }
}
