using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BustosApartment_SAD_
{
    public partial class FmMain : Form
    {
        public FmMain()
        {
            InitializeComponent();

            if (!panelMain.Controls.Contains(UCOverHeader.Instance))
            {
                panelMain.Controls.Add(UCOverHeader.Instance);
                UCOverHeader.Instance.Dock = DockStyle.Fill;
                UCOverHeader.Instance.BringToFront();
            }
            else
            {
                UCOverHeader.Instance.BringToFront();
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (!panelMain.Controls.Contains(UCProfHeader.Instance))
            {
                panelMain.Controls.Add(UCProfHeader.Instance);
                UCProfHeader.Instance.Dock = DockStyle.Fill;
                UCProfHeader.Instance.BringToFront();
            }
            else
            {
                UCProfHeader.Instance.BringToFront();
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {

            if (!panelMain.Controls.Contains(UCOverHeader.Instance))
            {
                panelMain.Controls.Add(UCOverHeader.Instance);
                UCOverHeader.Instance.Dock = DockStyle.Fill;
                UCOverHeader.Instance.BringToFront();
            }
            else
            {
                UCOverHeader.Instance.BringToFront();
            }
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}