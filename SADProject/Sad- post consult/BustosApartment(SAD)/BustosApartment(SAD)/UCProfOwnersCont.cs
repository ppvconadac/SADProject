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
    
    public partial class UCProfOwnersCont : UserControl
    {
        Class1 c1 = new Class1();
        public UCProfOwnersCont()
        {
           
            InitializeComponent();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtfname.Text != "" && txtmname.Text != "" && txtlname.Text != "" && txtuser.Text != "" && txtpass.Text != "")
            {
                string quer = "insert into owner values(NULL, '" + txtfname.Text + "', '" + txtmname.Text + "'," +
                    " '" + txtlname.Text + "', '" + txtuser.Text + "', '" + txtpass.Text + "')";
                c1.insert(quer);
                txtfname.Text = "";
                txtmname.Text = "";
                txtlname.Text = "";
                txtuser.Text = "";
                txtpass.Text = "";
            }
            else {
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
