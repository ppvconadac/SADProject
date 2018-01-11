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
    }   
}
