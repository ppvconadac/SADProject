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
    public partial class indiexassign : Form
    {
        public UserControl a3;
        Class1 c1 = new Class1();
        public static int id;
        public indiexassign()
        {
            InitializeComponent();
            tablecall();
        }

        public void tablecall()
        {
            string quer = "select Owner_ID,Owner_fname,owner_mname,owner_lname,concat(Owner_fname, ' ', owner_mname,' ' , owner_lname) as name from owner where emp_status = 1";
            dataGridView2.DataSource = c1.select(quer);
            dataGridView2.Columns["Owner_ID"].Visible = false;
            dataGridView2.Columns["Owner_fname"].HeaderText = "First Name";
            dataGridView2.Columns["owner_mname"].HeaderText = "Middle Initial";
            dataGridView2.Columns["owner_lname"].HeaderText = "Last Name";
            dataGridView2.Columns["name"].Visible = false;
            dataGridView2.ClearSelection();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtin.Text = dataGridView2.Rows[e.RowIndex].Cells["name"].Value.ToString();
                id = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["Owner_ID"].Value.ToString());

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirm expense", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (textBox2.Text == "" || textBox3.Text == "" || txtin.Text == "")
            {
                MessageBox.Show("No Empty Fields !", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!double.TryParse(textBox3.Text, out double val))
            {
                MessageBox.Show("Invalid format !", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Text = "";
            }
            else
            {
                if (dialogResult == DialogResult.Yes)
                {
                    string quer;
                    string date = DateTime.Now.ToString("yyyy-M-d");

                    quer = "insert into in_transaction values(NULL, '" + date + "','" + double.Parse(textBox3.Text) + "'," + id + ",'" + textBox2.Text + "',0, NULL,NULL )";
                    c1.insert(quer);
                    this.DialogResult = DialogResult.Yes;

                }
            }
        }

        private void indiexassign_Load(object sender, EventArgs e)
        {
            dataGridView2.ClearSelection();
        }
    }
}
