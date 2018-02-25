using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BustosApartment_SAD_
{
    public partial class lendingpass : Form
    {
        public UserControl a3;
        Class1 c = new Class1();
        string pass;
        public lendingpass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string quer = "select password from owner where Owner_ID= 1";

             DataTable dt =  c.select(quer);
            if (dt.Rows.Count == 1) {
                 pass = dt.Rows[0]["password"].ToString();
            }

            if (textBox1.Text.Equals(pass))
            {
                this.DialogResult = DialogResult.Yes;
            }

            }
        }
    }

