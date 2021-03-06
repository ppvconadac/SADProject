﻿using System;
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
                UCInventLending.Instance.refresh();
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
                UCInventStInOut.Instance.refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UCInventMaint.Instance))
            {
                panelMain2.Controls.Add(UCInventMaint.Instance);
                UCInventMaint.Instance.Dock = DockStyle.Fill;
                UCInventMaint.Instance.BringToFront();
            }
            else
            {
                UCInventMaint.Instance.BringToFront();
                UCInventMaint.Instance.refresh();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UCInventHCont.Instance))
            {
                panelMain2.Controls.Add(UCInventHCont.Instance);
                UCInventHCont.Instance.Dock = DockStyle.Fill;
                UCInventHCont.Instance.BringToFront();
            }
            else
            {
                UCInventHCont.Instance.BringToFront();
                UCInventHCont.Instance.refresh();
          
            }
        }
    }   
}
