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
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UCOEContent.Instance))
            {
                panelMain2.Controls.Add(UCOEContent.Instance);
                UCOEContent.Instance.Dock = DockStyle.Fill;
                UCOEContent.Instance.BringToFront();
            }
            else
            {
                UCOEContent.Instance.BringToFront();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UCUEContent.Instance))
            {
                panelMain2.Controls.Add(UCUEContent.Instance);
                UCUEContent.Instance.Dock = DockStyle.Fill;
                UCUEContent.Instance.BringToFront();
            }
            else
            {
                UCUEContent.Instance.BringToFront();
            }
        }
    }
}
