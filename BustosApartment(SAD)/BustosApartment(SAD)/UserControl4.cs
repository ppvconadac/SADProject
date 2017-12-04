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
    public partial class UserControl4 : UserControl
    {
        private static UserControl4 _instance;

        public static UserControl4 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControl4();
                return _instance;
            }
        }
        public UserControl4()
        {
            InitializeComponent();
            panel2.Controls.Add(UserControl8.Instance);
            UserControl8.Instance.Dock = DockStyle.Fill;
            UserControl8.Instance.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
