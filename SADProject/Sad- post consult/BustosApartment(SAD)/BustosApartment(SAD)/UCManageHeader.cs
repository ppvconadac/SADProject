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
    public partial class UCManageHeader : UserControl
    {
        private static UCManageHeader _instance;

        public static UCManageHeader Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCManageHeader();
                return _instance;
            }
        }
        public UCManageHeader()
        {

            InitializeComponent();
            if (!panelMain2.Controls.Contains(UCIncomeContent.Instance))
            {
                panelMain2.Controls.Add(UCIncomeContent.Instance);
                UCIncomeContent.Instance.Dock = DockStyle.Fill;
                UCIncomeContent.Instance.BringToFront();
            }
            else
            {
                UCIncomeContent.Instance.BringToFront();
            }
        }

        private void UCManageHeader_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UCIncomeContent.Instance))
            {
                panelMain2.Controls.Add(UCIncomeContent.Instance);
                UCIncomeContent.Instance.Dock = DockStyle.Fill;
                UCIncomeContent.Instance.BringToFront();
            }
            else
            {
                UCIncomeContent.Instance.BringToFront();
                UCIncomeContent.Instance.refresh();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UCManageGTContent.Instance))
            {
                panelMain2.Controls.Add(UCManageGTContent.Instance);
                UCManageGTContent.Instance.Dock = DockStyle.Fill;
                UCManageGTContent.Instance.BringToFront();
            }
            else
            {
                UCManageGTContent.Instance.BringToFront();
                UCManageGTContent.Instance.refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UCManageUEContent.Instance))
            {
                panelMain2.Controls.Add(UCManageUEContent.Instance);
                UCManageUEContent.Instance.Dock = DockStyle.Fill;
                UCManageUEContent.Instance.BringToFront();
            }
            else
            {
                UCManageUEContent.Instance.BringToFront();
                UCManageUEContent.Instance.refresh();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UCSummaryCont.Instance))
            {
                panelMain2.Controls.Add(UCSummaryCont.Instance);
                UCSummaryCont.Instance.Dock = DockStyle.Fill;
                UCSummaryCont.Instance.BringToFront();
            }
            else
            {
                UCSummaryCont.Instance.BringToFront();
                UCSummaryCont.Instance.refresh();
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UCManageIndiEx.Instance))
            {
            if (!panelMain2.Controls.Contains(UCManageIndiEx.Instance))
                panelMain2.Controls.Add(UCManageIndiEx.Instance);
                UCManageIndiEx.Instance.Dock = DockStyle.Fill;
                UCManageIndiEx.Instance.BringToFront();
            }
            else
            {
                UCManageIndiEx.Instance.BringToFront();
                UCManageIndiEx.Instance.refresh();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UCManageHCont.Instance))
            {
                if (!panelMain2.Controls.Contains(UCManageHCont.Instance))
                    panelMain2.Controls.Add(UCManageHCont.Instance);
                UCManageHCont.Instance.Dock = DockStyle.Fill;
                UCManageHCont.Instance.BringToFront();
            }
            else
            {
                UCManageHCont.Instance.BringToFront();
                UCManageHCont.Instance.refresh();
            }
        }
    }
}
