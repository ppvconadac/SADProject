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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            if (!panelMain.Controls.Contains(UserControl5.Instance))
            {
                panelMain.Controls.Add(UserControl5.Instance);
                UserControl5.Instance.Dock = DockStyle.Fill;
                UserControl5.Instance.BringToFront();
            }
            else
            {
                UserControl5.Instance.BringToFront();
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

            if (!panelMain.Controls.Contains(UserControl2.Instance))
            {
                panelMain.Controls.Add(UserControl2.Instance);
                UserControl2.Instance.Dock = DockStyle.Fill;
                UserControl2.Instance.BringToFront();
            }
            else
            {
                UserControl2.Instance.BringToFront();
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {

            if (!panelMain.Controls.Contains(UserControl5.Instance))
            {
                panelMain.Controls.Add(UserControl5.Instance);
                UserControl5.Instance.Dock = DockStyle.Fill;
                UserControl5.Instance.BringToFront();
            }
            else
            {
                UserControl5.Instance.BringToFront();
            }
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (!panelMain.Controls.Contains(UserControl9.Instance))
            {
                panelMain.Controls.Add(UserControl9.Instance);
                UserControl9.Instance.Dock = DockStyle.Fill;
                UserControl9.Instance.BringToFront();
            }
            else
            {
                UserControl9.Instance.BringToFront();
            }
        }
    }
}
