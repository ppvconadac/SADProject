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
    public partial class stinstockin : Form
    {
        Class1 c = new Class1();
        public int id2;
        public UserControl a3;
        public stinstockin()
        {
            InitializeComponent();
            textBox3.Text = "Stock-in";
            tablecall2();
        }

        public void tablecall2()
        {
            string quer = "select * from nonborrowable_item where nitem_stat = 0";
            dataGridView2.DataSource = c.select(quer);
            dataGridView2.Columns["nitem_id"].Visible = false;
            dataGridView2.Columns["nitem_stat"].Visible = false;
            dataGridView2.Columns["nt_archive_date"].Visible = false;
            dataGridView2.Columns["nt_archive_loggedin"].Visible = false;
            dataGridView2.ClearSelection();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtin.Text = dataGridView2.Rows[e.RowIndex].Cells["nitem_name"].Value.ToString();
                id2 = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["nitem_ID"].Value.ToString());

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date;


            if (txtin.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("No empty fields, try again.");
            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("Confirm stock-in", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    string quer;
                    date = DateTime.Now.ToString("yyyy-M-d");

                    quer = "insert into nitem_transaction values(NULL, '" + date + "','" + textBox2.Text + "','" + id2 + "', 'Stock-in', NULL, NULL, NULL,0 )";
                    c.insert(quer);

                    string quer2 = "select nt_quantity from nonborrowable_item where nitem_ID = '" + id2 + "'";
                    DataTable d = c.select(quer2);
                    string quantity = d.Rows[0]["nt_quantity"].ToString();
                    int quan = int.Parse(quantity);
                    quan = quan + int.Parse(textBox2.Text);
                    string quer3 = "update nonborrowable_item set nt_quantity = '" + quan.ToString() + "' where nitem_ID = " + id2 + "";
                    c.insert(quer3);
                    //  this.Close();
                    this.DialogResult = DialogResult.Yes;
  
                }
            }
        }
    }
}
