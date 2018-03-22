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
    public partial class watrecmontrans : Form
    {
        Class1 c = new Class1();
        public UserControl a3;
        public watrecmontrans()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!double.TryParse(textBox4.Text, out double val))
            {
                MessageBox.Show("Invalid format for bill amount !", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Text = "";
            }

            if (!double.TryParse(txtin.Text, out val))
            {
                MessageBox.Show("Invalid format for rate !", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtin.Text = "";
            }
            else
            {

                DialogResult dialogResult = MessageBox.Show("Confirm transaction", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);



                if (dialogResult == DialogResult.Yes)
                {
                    string date;
                    string quer;
                    date = DateTime.Now.ToString("yyyy-M-d");

                    string quer3 = "select * from utwat_trans where uwat_date = '" + date + "' and uwat_trans_stat =0";
                    DataTable d = c.select(quer3);

                    if (d.Rows.Count > 0)
                    {
                        MessageBox.Show("Transaction already recorded for given date.");
                    }
                    else
                    {
                        double price = double.Parse(textBox4.Text);

                        quer = "insert into utwat_trans values(NULL, '" + date + "'," + price + ",'0','" + double.Parse(txtin.Text) + "', '0', NULL, NULL,0 )";

                        c.insert(quer);
                        this.DialogResult = DialogResult.Yes;
                    }
                }
            }
        }
    }
}
