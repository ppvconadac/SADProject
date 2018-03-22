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
    public partial class stinstockout : Form
    {
        public int id;
        public int id2;
        Class1 c = new Class1();
        public UserControl a3;
        public stinstockout()
        {
            InitializeComponent();
            textBox3.Text = "Stock-out";
            tablecall();
            tablecall2();
        }

        public void tablecall()
        {
            String query = "select Room_ID,Room_number, Room_desc, Room_status from room where Room_status = 'Using'";
            dataGridView1.DataSource = c.select(query);
            dataGridView1.Columns["Room_ID"].Visible = false;
            dataGridView1.Columns["Room_status"].Visible = false;
            dataGridView1.Columns["Room_number"].HeaderText = "Room number";
            dataGridView1.Columns["Room_desc"].HeaderText = "Room description";
            dataGridView1.ClearSelection();

        }
        public void tablecall2()
        {
            string quer = "select * from nonborrowable_item where nitem_stat = 0";
            dataGridView2.DataSource = c.select(quer);
            dataGridView2.Columns["nitem_id"].Visible = false;
            dataGridView2.Columns["nitem_stat"].Visible = false;
            dataGridView2.Columns["nt_archive_date"].Visible = false;
            dataGridView2.Columns["nt_archive_loggedin"].Visible = false;
            dataGridView2.Columns["nitem_name"].HeaderText = "Name";
            dataGridView2.Columns["nitem_price"].HeaderText = "Price";
            dataGridView2.Columns["nitem_desc"].HeaderText = "Description";
            dataGridView2.Columns["nt_quantity"].HeaderText = "Quantity in-stock";
            dataGridView2.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Room_ID"].Value.ToString());
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Room_number"].Value.ToString();


            }
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
            

            if (textBox4.Text == "" || txtin.Text =="" || textBox2.Text == "")
            {
                MessageBox.Show("No empty fields, try again.");
            }
            else if (!int.TryParse(textBox2.Text, out int val))
            {
                MessageBox.Show("Invalid format !", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Text = "";
            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("Confirm stock-out", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {

                    string quer2 = "select nt_quantity from nonborrowable_item where nitem_ID = '" + id2 + "'";
                    DataTable d = c.select(quer2);
                    string quantity = d.Rows[0]["nt_quantity"].ToString();
                    int quan = int.Parse(quantity);
                    quan = quan - int.Parse(textBox2.Text);
                    if(quan < 0)
                    {
                        MessageBox.Show("Stock-out amount can not exceed quantity in-stock. Stock-out cancelled.");
                        textBox2.Text = "";

                    }
                    else
                    {
                        string quer;
                        date = DateTime.Now.ToString("yyyy-M-d");

                        quer = "insert into nitem_transaction values(NULL, '" + date + "','" + textBox2.Text + "','" + id2 + "', 'Stock-out', NULL, NULL, '" + id + "',0)";
                        c.insert(quer);


                        string quer3 = "update nonborrowable_item set nt_quantity = '" + quan.ToString() + "' where nitem_ID = " + id2 + "";
                        c.insert(quer3);
                        //  this.Close();
                        this.DialogResult = DialogResult.Yes;
                    }
                   


                }
            }

            

        }

        private void stinstockout_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
        }
    }
}
