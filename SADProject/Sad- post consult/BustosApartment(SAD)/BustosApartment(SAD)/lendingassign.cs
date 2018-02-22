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
    public partial class lendingassign : Form
    {
        public string b_avail;
        public string rate;
        public UserControl a3;
        public int id;
        public int id2;
        public string balance;
        Class1 c = new Class1();
        public lendingassign()
        {
           
            InitializeComponent();
            tablecall();
            tablecall2();
        }

        private void lendingassign_Load(object sender, EventArgs e)
        {

        }
        public void tablecall() {
            String query = "select concat(profile_fname,profile_mname,profile_lname) as full_name, User_id, Profile_cpnumber,Profile_Address,Profile_balance from profile";
            dataGridView1.DataSource = c.select(query);
            dataGridView1.Columns["User_id"].Visible = false;
            dataGridView1.Columns["Profile_balance"].Visible = false;
            dataGridView1.Columns["full_name"].HeaderText = "Name";
            dataGridView1.Columns["Profile_cpnumber"].HeaderText = "Contact";
            dataGridView1.Columns["Profile_Address"].HeaderText = "Address";
           
            
        }
        public void tablecall2()
        {
            string quer = "select * from borrowable_item";
            dataGridView2.DataSource = c.select(quer);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date;
            if (b_avail == "Available") {

                if (comboBox2.Text == "Check" && comboBox1.Text == "Paid")
                {
                    MessageBox.Show("Payment by check. Status set to pending.");
                    comboBox1.Text = "Pending";
                }

              
                    DialogResult dialogResult = MessageBox.Show("Confirm lending", "Waning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);


                    if (dialogResult == DialogResult.Yes)
                    {
                        date = DateTime.Now.AddDays(1).ToString("yyyy/M/d");
                        string quer = "insert into bitem_transaction values(NULL, '" + date + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + id + "','" + id2 + "', 0 , NULL )";

                        c.insert(quer);
                        string quer2 = "update borrowable_item set bitem_status = 'In Use' where bitem_ID = " + id2 + "";
                        c.insert(quer2);

                        if(comboBox1.Text == "Pending")
                    {
                        int bal = int.Parse(balance);
                        int rt = int.Parse(rate);
                        bal = bal + rt;
                        

                        string quer3 = "update profile set Profile_balance = '" + bal.ToString() + "' where User_id = "+id+"";
                        c.insert(quer3);

                        
                    }

                        //  this.Close();
                        this.DialogResult = DialogResult.Yes;
                    }              

            }

            else
            {
                MessageBox.Show("Item Unavailable");
            }
            
        }


      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1)
            {
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["User_id"].Value.ToString());
                balance = dataGridView1.Rows[e.RowIndex].Cells["Profile_balance"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["full_name"].Value.ToString();
              
                
            }
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtin.Text = dataGridView2.Rows[e.RowIndex].Cells["bitem_name"].Value.ToString();
                id2 = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["bitem_ID"].Value.ToString());
                rate= dataGridView2.Rows[e.RowIndex].Cells["bitem_rate"].Value.ToString();
                textBox2.Text = rate;
                b_avail =dataGridView2.Rows[e.RowIndex].Cells["bitem_status"].Value.ToString();
            }

        }
    }
}
