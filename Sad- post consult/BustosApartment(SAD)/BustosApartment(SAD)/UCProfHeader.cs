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
    public partial class UCProfHeader : UserControl
    {


        private static UCProfHeader _instance;

        public static UCProfHeader Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCProfHeader();
                return _instance;
            }
        }
        public UCProfHeader()
        {
            InitializeComponent();
            if (!panelMain2.Controls.Contains(UCProfContent.Instance))
            {
                panelMain2.Controls.Add(UCProfContent.Instance);
                UCProfContent.Instance.Dock = DockStyle.Fill;
                UCProfContent.Instance.BringToFront();
            }
            else
            {
                UCProfContent.Instance.BringToFront();
            }
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UCProfContent.Instance))
            {
                panelMain2.Controls.Add(UCProfContent.Instance);
                UCProfContent.Instance.Dock = DockStyle.Fill;
                UCProfContent.Instance.BringToFront();
            }
            else
            {
                UCProfContent.Instance.BringToFront();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void panelMain2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
