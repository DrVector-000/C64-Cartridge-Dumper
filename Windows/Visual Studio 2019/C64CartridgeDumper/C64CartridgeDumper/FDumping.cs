using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C64CartridgeDumper
{
    public partial class FDumping : Form
    {

        public string CRTName { get; set; }
        public string CRTPath { get; set; }
        public int CRTBanks { get; set; }

        public FDumping()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CRTName = tBCRTName.Text;
            CRTPath = tBCRTPath.Text;
            CRTBanks = (int)nUDBanks.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tBCRTPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
