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
    public partial class elrecmontrans : Form
    {
        Class1 c = new Class1();
        public UserControl a3;
        public elrecmontrans()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirm transaction", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);


            if (dialogResult == DialogResult.Yes)
            {
                string date;
                string quer;
                date = DateTime.Now.ToString("yyyy-M-d");

                quer = "insert into utelect_trans values(NULL, '" + date + "','"+textBox4.Text+"','0','" + txtin.Text + "', '0', NULL, NULL )";

                c.insert(quer);
                this.DialogResult = DialogResult.Yes;
            }
            }
    }
}
