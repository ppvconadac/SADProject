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
    public partial class UCInventHeader : UserControl
    {


        private static UCInventHeader _instance;

        public static UCInventHeader Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCInventHeader();
                return _instance;
            }
        }
        public UCInventHeader()
        {
            InitializeComponent();
            if (!panelMain2.Controls.Contains(UCInventLending.Instance))
            {
                panelMain2.Controls.Add(UCInventLending.Instance);
                UCInventLending.Instance.Dock = DockStyle.Fill;
                UCInventLending.Instance.BringToFront();
            }
            else
            {
                UCInventLending.Instance.BringToFront();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UCInventBCont.Instance))
            {
                panelMain2.Controls.Add(UCInventBCont.Instance);
                UCInventBCont.Instance.Dock = DockStyle.Fill;
                UCInventBCont.Instance.BringToFront();
            }
            else
            {
                UCInventBCont.Instance.BringToFront();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UCInventLending.Instance))
            {
                panelMain2.Controls.Add(UCInventLending.Instance);
                UCInventLending.Instance.Dock = DockStyle.Fill;
                UCInventLending.Instance.BringToFront();
            }
            else
            {
                UCInventLending.Instance.BringToFront();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UCInventStInOut.Instance))
            {
                panelMain2.Controls.Add(UCInventStInOut.Instance);
                UCInventStInOut.Instance.Dock = DockStyle.Fill;
                UCInventStInOut.Instance.BringToFront();
            }
            else
            {
                UCInventStInOut.Instance.BringToFront();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UCInventCCont.Instance))
            {
                panelMain2.Controls.Add(UCInventCCont.Instance);
                UCInventCCont.Instance.Dock = DockStyle.Fill;
                UCInventCCont.Instance.BringToFront();
            }
            else
            {
                UCInventCCont.Instance.BringToFront();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UCInventRecords.Instance))
            {
                panelMain2.Controls.Add(UCInventRecords.Instance);
                UCInventRecords.Instance.Dock = DockStyle.Fill;
                UCInventRecords.Instance.BringToFront();
            }
            else
            {
                UCInventRecords.Instance.BringToFront();
            }
        }
    }   
}
