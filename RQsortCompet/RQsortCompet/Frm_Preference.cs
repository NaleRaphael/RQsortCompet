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
            txt_MaxStackDepth.Text = Properties.Settings.Default._MAX_STACK_DEPTH.ToString();
            txt_InitialStackDepth.Text = Properties.Settings.Default._INI_STACK_DEPTH.ToString();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            int max_sd = 0;
            int ini_sd = 0;
            if (!int.TryParse(txt_MaxStackDepth.Text, out max_sd) || max_sd < 0)
            {
                MessageBox.Show("Invalid value for \"Max stack depth\".");
                return;
            }
            if (!int.TryParse(txt_InitialStackDepth.Text, out ini_sd) || ini_sd < 0)
            {
                MessageBox.Show("Invalid value for \"Initial stack depth\".");
                return;
            }

            if (max_sd < ini_sd)
            {
                MessageBox.Show("\"Initial stack depth\" should be greater than \"Max stack depth\".");
                return;
            }

            DialogResult dr = MessageBox.Show("Save those changed setting?", "Save change", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    Properties.Settings.Default._MAX_STACK_DEPTH = Convert.ToInt32(max_sd);
                    Properties.Settings.Default._INI_STACK_DEPTH = Convert.ToInt32(ini_sd);
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
