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
    public partial class authorizearch : Form
    {
        public UserControl a3;
        Class1 c = new Class1();
       
        
        public authorizearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string quer = "select * from owner where password = '"+textBox1.Text+ "' and emp_status =0";
             DataTable dt =  c.select(quer);
            if (dt.Rows.Count > 0) {
                this.DialogResult = DialogResult.Yes;
            }


            }
        }
    }

