using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BustosApartment_SAD_
{
    public partial class UCOverHeader : UserControl
    {
        private static UCOverHeader _instance;

        public static UCOverHeader Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCOverHeader();
                return _instance;
            }
        }
        public UCOverHeader()
        {
            InitializeComponent();
            if (!panelMain2.Controls.Contains(UCOverStatusCont.Instance))
            {
                panelMain2.Controls.Add(UCOverStatusCont.Instance);
                UCOverStatusCont.Instance.Dock = DockStyle.Fill;
                UCOverStatusCont.Instance.BringToFront();
            }
            else
            {
                UCOverStatusCont.Instance.BringToFront();
            }
        }

        private void UserControl5_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UCOverStatusCont.Instance))
            {
                panelMain2.Controls.Add(UCOverStatusCont.Instance);
                UCOverStatusCont.Instance.Dock = DockStyle.Fill;
                UCOverStatusCont.Instance.BringToFront();
            }
            else
            {              
              
                UCOverStatusCont.Instance.BringToFront();
            }
        }
    }
}
