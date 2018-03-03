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
        public static string rate;
        public UserControl a3;
        public int id;
        public int id2;
        public string balance;
        Class1 c = new Class1();
        string date;
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
            
            if (b_avail == "Available") {

              
                    DialogResult dialogResult = MessageBox.Show("Confirm lending", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);


                    if (dialogResult == DialogResult.Yes)
                    {
                    string quer;
                    date = DateTime.Now.ToString("yyyy/M/d");
        
                        quer = "insert into bitem_transaction values(NULL, '" + date + "','Pending','" + comboBox2.Text + "','"+rate+"','" + id + "','" + id2 + "', NULL , NULL, 0, NULL, NULL )";



                    c.insert(quer);
                    string quer2 = "update borrowable_item set bitem_status = 'In Use' where bitem_ID = " + id2 + "";
                        c.insert(quer2);


                    if(comboBox2.Text == "Check")
                    {
                        int bal = int.Parse(balance);
                        int rt = int.Parse(rate);
                        bal = bal + rt;
                        string quer3 = "update profile set Profile_balance = '" + bal.ToString() + "' where User_id = " + id + "";
                        c.insert(quer3);
                    }
                            

                    if(comboBox2.Text == "Cash")
                    {
                       string quer4 = "select btrans_ID from bitem_transaction where Profile_user_ID = "+id+ " and borrowable_item_bitem_ID = "+id2+" and bt_pay_status = 'Pending'";
                        DataTable d = c.select(quer4);
                        int btrans_id = int.Parse(d.Rows[0]["btrans_ID"].ToString());
                        Payment ch = new Payment();
                        ch.getdeets(rate,btrans_id, "bitem_transaction", id );
                        DialogResult result = ch.ShowDialog();
                        if (result == DialogResult.Yes)
                        {
                            this.DialogResult = DialogResult.Yes;
                        }
                    }

                    else
                    {
                        this.DialogResult = DialogResult.Yes;
                    }
                   

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
