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
    public partial class gentransexp : Form
    {
        Class1 c = new Class1();
        public UserControl a3;
        public gentransexp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirm expense", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if(textBox4.Text == "" || comboBox3.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("No Empty Fields !", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!double.TryParse(textBox2.Text, out double val))
            {
                MessageBox.Show("Invalid format !", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Text = "";
            }
            else
            {
                if (dialogResult == DialogResult.Yes)
                {
                    string quer;
                    string date = DateTime.Now.ToString("yyyy-M-d");

                    quer = "insert into misc_transaction values(NULL, '" + date + "','" + textBox2.Text + "','" + comboBox3.Text + "','" + textBox4.Text + "',0, NULL,NULL )";
                    c.insert(quer);
                    this.DialogResult = DialogResult.Yes;

                }
            }
        }
    }
}
