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
    public partial class reportdamage : Form
    {
        string db;
        Class1 c = new Class1();
        public UserControl a3;
        public int pid;
        public string balance;
        public int id2;
        public string rate;
        public reportdamage()
        {
            InitializeComponent();
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();

        }

        public void getdeets(string dbase)
        {


            db = dbase;
            tablecall();
            tablecall2();
           

        }

        public void tablecall()
        {
            String query = "select concat(profile_fname,profile_mname,profile_lname) as full_name, User_id, Profile_cpnumber,Profile_Address,Profile_balance from profile";
            dataGridView1.DataSource = c.select(query);
            dataGridView1.Columns["User_id"].Visible = false;
            dataGridView1.Columns["Profile_balance"].Visible = false;
            dataGridView1.Columns["full_name"].HeaderText = "Name";
            dataGridView1.Columns["Profile_cpnumber"].HeaderText = "Contact";
            dataGridView1.Columns["Profile_Address"].HeaderText = "Address";
            dataGridView1.ClearSelection();
        }

        public void tablecall2()
        {


            if (db == "borrowable_item")
            {
                string quer = "select * from borrowable_item";
                dataGridView2.DataSource = c.select(quer);
                dataGridView2.Columns["bitem_ID"].Visible = false;
                dataGridView2.ClearSelection();
            }

            else if (db == "room_item")
            {
                string quer = "select * from room_item";
                dataGridView2.DataSource = c.select(quer);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                pid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["User_id"].Value.ToString());
                balance = dataGridView1.Rows[e.RowIndex].Cells["Profile_balance"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["full_name"].Value.ToString();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (db == "borrowable_item")
            {
                if (e.RowIndex > -1)
                {
                    txtin.Text = dataGridView2.Rows[e.RowIndex].Cells["bitem_name"].Value.ToString();
                    id2 = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["bitem_ID"].Value.ToString());
                    rate = dataGridView2.Rows[e.RowIndex].Cells["bitem_actual"].Value.ToString();
                    textBox2.Text = rate;
                    
                }
            }

            else if (db == "room_item")
            {
                if (e.RowIndex > -1)
                {
                    txtin.Text = dataGridView2.Rows[e.RowIndex].Cells["ritem_name"].Value.ToString();
                    id2 = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["ritem_ID"].Value.ToString());
                    rate = dataGridView2.Rows[e.RowIndex].Cells["ritem_price"].Value.ToString();
                    textBox2.Text = rate;
                    

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (db == "borrowable_item")
            {
     
                string date;

                DialogResult dialogResult = MessageBox.Show("Confirm report", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);


                if (dialogResult == DialogResult.Yes)
                {
                    date = DateTime.Now.ToString("yyyy-M-d");
                    string quer = "insert into bitem_damage_transaction values(NULL, '" + date + "','" + textBox2.Text + "'," + pid+ "," + id2 + ",'" + comboBox2.Text + "','Pending',  NULL, 0,0 )";

                    c.insert(quer);
                    string quer2 = "update borrowable_item set bitem_dmg_status = '" + comboBox3.Text + "' where bitem_ID = " + id2+ "";
                    c.insert(quer2);

                    if (comboBox3.Text == "Out of Order")
                    {
                        string quer3 = "update borrowable_item set bitem_status = 'Unavailable' where bitem_ID = " + id2+ "";
                        c.insert(quer3);
                    }
                    else
                    {
                        DialogResult dialogResult2 = MessageBox.Show("Set item as unavailable?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            String quer3 = "update borrowable_item set bitem_status = 'Unavailable' where bitem_ID = " + id2 + "";
                            c.insert(quer3);
                        }

                    }

                    if (comboBox2.Text == "Check")
                    {
                        string quer4 = "select Profile_balance from profile where user_ID = '" + pid + "'";
                        DataTable d = c.select(quer4);
                        int balance = int.Parse(d.Rows[0]["Profile_balance"].ToString());

                        int rt = int.Parse(textBox2.Text);
                        balance = balance + rt;
                        string quer3 = "update profile set Profile_balance = '" + balance.ToString() + "' where User_id = " + pid + "";
                        c.insert(quer3);
                        this.DialogResult = DialogResult.Yes;

                    }

                    if (comboBox2.Text == "Cash")
                    {
                        string quer4 = "select bdtrans_ID from bitem_damage_transaction where Profile_user_ID = " + pid + " and borrowable_item_bitem_ID = " + id2 + " and bdt_pay_status = 'Pending'";
                        DataTable d = c.select(quer4);
                        int bdtrans_id = int.Parse(d.Rows[0]["bdtrans_ID"].ToString());
                        Payment ch = new Payment();
                        ch.getdeets(textBox2.Text, bdtrans_id, "bitem_damage_transaction", pid);
                        DialogResult result = ch.ShowDialog();
                        if (result == DialogResult.Yes)
                        {
                            this.DialogResult = DialogResult.Yes;
                        }
                    }


                }

            }

            else if (db == "room_item")
            {
                string date;

                DialogResult dialogResult = MessageBox.Show("Confirm report", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);


                if (dialogResult == DialogResult.Yes)
                {
                    date = DateTime.Now.ToString("yyyy-M-d");
                    string quer = "insert into ritem_damage_transaction values(NULL, '" + date + "','" + textBox2.Text + "'," + pid + "," + id2 + ",'" + comboBox2.Text + "','Pending',  NULL, 0,0 )";

                    c.insert(quer);
                    string quer2 = "update room_item set ritem_dmg_stat = '" + comboBox3.Text + "' where ritem_ID = " + id2 + "";
                    c.insert(quer2);
                        

                    if (comboBox2.Text == "Check")
                    {
                        string quer4 = "select Profile_balance from profile where user_ID = '" + pid + "'";
                        DataTable d = c.select(quer4);
                        int balance = int.Parse(d.Rows[0]["Profile_balance"].ToString());

                        int rt = int.Parse(textBox2.Text);
                        balance = balance + rt;
                        string quer3 = "update profile set Profile_balance = '" + balance.ToString() + "' where User_id = " + pid + "";
                        c.insert(quer3);
                        this.DialogResult = DialogResult.Yes;

                    }

                    if (comboBox2.Text == "Cash")
                    {
                        string quer4 = "select rdtrans_ID from ritem_damage_transaction where Profile_user_ID = " + pid + " and ritem_itemID = " + id2 + " and rdt_pay_status = 'Pending'";
                        DataTable d = c.select(quer4);
                        int rdtrans_id = int.Parse(d.Rows[0]["rdtrans_ID"].ToString());
                        Payment ch = new Payment();
                        ch.getdeets(textBox2.Text, rdtrans_id, "ritem_damage_transaction", pid);
                        DialogResult result = ch.ShowDialog();
                        if (result == DialogResult.Yes)
                        {
                            this.DialogResult = DialogResult.Yes;
                        }
                    }


                }
            }
        }
    }
}


