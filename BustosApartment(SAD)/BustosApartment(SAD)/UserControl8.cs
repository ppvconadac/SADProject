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
    public partial class UserControl8 : UserControl

    {
        private int b;
        private string n;

        private static UserControl8 _instance;

        public void acceptor(int a, string c) {
            label7.Text = c;

        }

        public static UserControl8 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControl8();
                return _instance;
            }
        }
        public UserControl8()
        {
            InitializeComponent();
        }

        private void UserControl8_Load(object sender, EventArgs e)
        {
           
        }
    }
}
