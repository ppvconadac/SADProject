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
    public partial class UserControl2 : UserControl
    {


        private static UserControl2 _instance;

        public static UserControl2 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControl2();
                return _instance;
            }
        }
        public UserControl2()
        {
            InitializeComponent();
            if (!panelMain2.Controls.Contains(UserControl3.Instance))
            {
                panelMain2.Controls.Add(UserControl3.Instance);
                UserControl3.Instance.Dock = DockStyle.Fill;
                UserControl3.Instance.BringToFront();
                
            }
            else
            {
                UserControl3.Instance.BringToFront();
            }
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UserControl3.Instance))
            {
                panelMain2.Controls.Add(UserControl3.Instance);
                UserControl3.Instance.Dock = DockStyle.Fill;
                UserControl3.Instance.BringToFront();
            }
            else
            {
                UserControl3.Instance.BringToFront();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UserControl4.Instance))
            {
                panelMain2.Controls.Add(UserControl4.Instance);
                UserControl4.Instance.Dock = DockStyle.Fill;
                UserControl4.Instance.BringToFront();

                
            }
            else
            {
                UserControl4.Instance.BringToFront();
            }
        }

        private void panelMain2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
