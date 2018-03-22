using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BustosApartment_SAD_
{
    public partial class UCInventMaint : UserControl
    {
        Class1 c = new Class1();
        private static UCInventMaint _instance;
       
        public static UCInventMaint Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCInventMaint();
                return _instance;
            }
        }

        public int bid1;
        public int rid1;
        public int rid2;
        public int rpid2;
        public string ava;
        public string ava2;
        public string dmg;
        public string dmg2;
        public int bid2;
        public int bpid2;
        public string rate;
        public string paymeth;
        public string paystat;
        public string rate2;
        public string paymeth2;
        public string paystat2;
        public UCInventMaint()
        {
            InitializeComponent();
            tablecall();
            tablecall2();
            tablecall4();
            tablecall5();

        }

        

        public void tablecall()
        {

            string quer = "select * from borrowable_item";
            dataGridView5.DataSource = c.select(quer);
            dataGridView5.Columns["bitem_ID"].Visible = false;
            dataGridView5.Columns["bitem_archive_date"].Visible = false;
            dataGridView5.Columns["bitem_archive_loggedin"].Visible = false;
            dataGridView5.Columns["bitem_void_stat"].Visible = false;
            dataGridView5.Columns["bitem_name"].HeaderText = "Name";
            dataGridView5.Columns["bitem_desc"].HeaderText = "Description";
            dataGridView5.Columns["bitem_status"].HeaderText = "Availability";
            dataGridView5.Columns["bitem_dmg_status"].HeaderText = "Condition";
            dataGridView5.Columns["bitem_actual"].HeaderText = "Actual Price";
            dataGridView5.Columns["bitem_rate"].HeaderText = "Rate";


        }
        public void tablecall2()
        {

            string quer = "select bdtrans_ID, bdt_date, bdt_price, Profile_user_ID, concat(profile_fname,' ',profile_mname,' ',profile_lname) as full_name, bitem_name, bdt_pay_method, bdt_pay_status from bitem_damage_transaction inner join profile inner join borrowable_item where Profile_user_ID = user_ID and borrowable_item_bitem_ID = bitem_ID and bdt_trans_stat =0";
            dataGridView1.DataSource = c.select(quer);
            dataGridView1.Columns["bdtrans_ID"].Visible = false;
            dataGridView1.Columns["Profile_user_ID"].Visible = false;
            dataGridView1.ClearSelection();


        }

 

        public void tablecall4()
        {

            string quer = "select * from room_item";
            dataGridView6.DataSource = c.select(quer);
            dataGridView6.Columns["ritem_ID"].Visible = false;
            dataGridView6.Columns["ritem_price"].Visible = false;
            dataGridView6.Columns["ritem_roomid"].Visible = false;
            dataGridView6.ClearSelection();


        }

        public void tablecall5()
        {
            string quer = "select rdtrans_ID, rdt_date, rdt_price, Profile_user_ID, concat(profile_fname,' ',profile_mname,' ',profile_lname) as full_name, ritem_name, rdt_pay_method, rdt_pay_status from ritem_damage_transaction inner join profile inner join room_item where Profile_user_ID = user_ID and ritem_itemID = ritem_ID and rdt_trans_stat =0";
            dataGridView3.DataSource = c.select(quer);
            dataGridView3.Columns["rdtrans_ID"].Visible = false;
            dataGridView3.ClearSelection();
        }

   


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView3.ClearSelection();
            dataGridView5.ClearSelection();
            dataGridView6.ClearSelection();

             bid1 = 0;
             rid1 = 0;
             rid2 = 0;
             rpid2 = 0;
             ava = "";
             ava2 = "";
             dmg = "";
             dmg2 = "";
             bid2 = 0;
             bpid2 = 0;
             rate = "";
             paymeth = "";
             paystat = "";
             rate2 = "";
             paymeth2 = "";
             paystat2 = "";
    }

   
        private void button1_Click(object sender, EventArgs e)
        {
            tablecall();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tablecall2();
        }

 

        private void button18_Click(object sender, EventArgs e)
        {
            if (bid1 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else
            {
                ChangeDamageStat ch = new ChangeDamageStat();
                ch.getdeets(bid1, "borrowable_item");
                DialogResult result = ch.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    tablecall();
                }
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                bid1 = int.Parse(dataGridView5.Rows[e.RowIndex].Cells["bitem_ID"].Value.ToString());
                ava = dataGridView5.Rows[e.RowIndex].Cells["bitem_status"].Value.ToString();
                dmg = dataGridView5.Rows[e.RowIndex].Cells["bitem_dmg_status"].Value.ToString();


            }
        }

        private void UCInventMaint_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView3.ClearSelection();
            dataGridView5.ClearSelection();
            dataGridView6.ClearSelection();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (bid1 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else 
            {

                DialogResult dialogResult = MessageBox.Show("Confirm Change?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    if (ava == "Available")
                    {
                        string quer2 = "update borrowable_item set bitem_status = 'Unavailable' where bitem_ID = " + bid1 + "";
                        c.insert(quer2);
                    }

                    else
                    {
                        if (dmg == "Out of Order")
                        {
                            MessageBox.Show("Item Out of Order, Cannot set to Available.");
                        }
                        else
                        {
                            string quer2 = "update borrowable_item set bitem_status = 'Available' where bitem_ID = " + bid1 + "";
                            c.insert(quer2);
                        }
                    }

                    tablecall();

                }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            reportdamage ch = new reportdamage();
            ch.getdeets("borrowable_item");
            DialogResult result = ch.ShowDialog();
            if (result == DialogResult.Yes)
            {
                tablecall2();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (bid2 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }

            else
            {
                if (paymeth == "Cash")
                {
                    string amt;
                    string quer = "select SUM(bdp_amount) from bdtrans_partial where bdp_trans_id = " + bid2 + "";
                    DataTable d = c.select(quer);
                    if (d.Rows[0]["SUM(bdp_amount)"].ToString() == "")
                    {
                        amt = "0";
                    }
                    else
                    {

                        amt = d.Rows[0]["SUM(bdp_amount)"].ToString();
                    }

                    double remaining = double.Parse(rate) - double.Parse(amt);
                    Payment ch = new Payment();
                    ch.getdeets(remaining.ToString(), bid2, "bitem_damage_transaction", bpid2);
                    DialogResult result = ch.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        tablecall2();
                    }
                }
                else
                {
                    MessageBox.Show("Option disabled for check payments");
                }
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1)
            {
                bid2 = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["bdtrans_id"].Value.ToString());
                bpid2 = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Profile_user_ID"].Value.ToString());
                paystat = dataGridView1.Rows[e.RowIndex].Cells["bdt_pay_status"].Value.ToString();
                paymeth = dataGridView1.Rows[e.RowIndex].Cells["bdt_pay_method"].Value.ToString();
                rate = dataGridView1.Rows[e.RowIndex].Cells["bdt_price"].Value.ToString();
            }
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (bid2 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }

            else
            {
                if (paymeth == "Check")
                {

                    DialogResult dialogResult = MessageBox.Show("Mark transaction as paid.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes)
                    {

                        string quer = "update bitem_damage_transaction set bdt_pay_status= 'Paid' where bdtrans_ID = " + bid2 + "";
                        c.insert(quer);
                        string date = date = DateTime.Now.ToString("yyyy-M-d");
                        string quer2 = "update bitem_damage_transaction set bdt_pay_date= '" + date + "' where bdtrans_ID = " + bid2 + "";
                        c.insert(quer2);

                        string quer3 = "select Profile_balance from profile where user_ID = '" + bpid2 + "'";
                        DataTable d = c.select(quer3);
                        string balance = d.Rows[0]["Profile_balance"].ToString();
                        int bal = int.Parse(balance);
                        int rt = int.Parse(rate);
                        bal = bal - rt;
                        string quer4 = "update profile set Profile_balance = '" + bal.ToString() + "' where User_id = " + bpid2 + "";
                        c.insert(quer4);

                        MessageBox.Show("Transaction successfully marked as paid");
                        tablecall2();
                    }

                }
                else
                {
                    MessageBox.Show("Option disabled for cash payments");

                }

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (bid2 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("Confirm change.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    if (paystat == "Pending")
                    {
                        if (paymeth == "Cash")
                        {
                            string quer = "update bitem_damage_transaction set bdt_pay_method= 'Check' where bdtrans_ID = " + bid2 + "";
                            c.insert(quer);
                            tablecall2();
                        }

                        else
                        {
                            string quer = "update bitem_damage_transaction set bdt_pay_method= 'Cash' where bdtrans_ID = " + bid2 + "";
                            c.insert(quer);
                            tablecall2();
                        }
                        MessageBox.Show("Payment method successfully changed");
                    }
                    else
                    {
                        MessageBox.Show("Cannot change payment method of this transaction");
                    }
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (rid1 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else
            {
                ChangeDamageStat ch = new ChangeDamageStat();
                ch.getdeets(rid1, "room_item");
                DialogResult result = ch.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    tablecall4();
                }
            }
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                rid1 = int.Parse(dataGridView6.Rows[e.RowIndex].Cells["ritem_ID"].Value.ToString());    
                dmg2 = dataGridView6.Rows[e.RowIndex].Cells["ritem_dmg_stat"].Value.ToString();

            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1)
            {
                rid2 = int.Parse(dataGridView3.Rows[e.RowIndex].Cells["rdtrans_id"].Value.ToString());
                rpid2 = int.Parse(dataGridView3.Rows[e.RowIndex].Cells["Profile_user_ID"].Value.ToString());
                paystat2 = dataGridView3.Rows[e.RowIndex].Cells["rdt_pay_status"].Value.ToString();
                paymeth2 = dataGridView3.Rows[e.RowIndex].Cells["rdt_pay_method"].Value.ToString();
                rate2 = dataGridView3.Rows[e.RowIndex].Cells["rdt_price"].Value.ToString();

            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (rid2 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }

            else
            {
                if (paymeth2 == "Cash")
                {
                    string amt;
                    string quer = "select SUM(rdp_amount) from rdtrans_partial where rdp_trans_id = " + rid2 + "";
                    DataTable d = c.select(quer);
                    if (d.Rows[0]["SUM(rdp_amount)"].ToString() == "")
                    {
                        amt = "0";
                    }
                    else
                    {

                        amt = d.Rows[0]["SUM(rdp_amount)"].ToString();
                    }

                    int remaining = int.Parse(rate2) - int.Parse(amt);
                    Payment ch = new Payment();
                    ch.getdeets(remaining.ToString(), rid2, "ritem_damage_transaction", rpid2);
                    DialogResult result = ch.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        tablecall5();
                    }
                }
                else
                {
                    MessageBox.Show("Option disabled for check payments");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            reportdamage ch = new reportdamage();
            ch.getdeets("room_item");
            DialogResult result = ch.ShowDialog();
            if (result == DialogResult.Yes)
            {
                tablecall5();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (rid2 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }

            else
            {
                if (paymeth2 == "Check")
                {

                    DialogResult dialogResult = MessageBox.Show("Mark transaction as paid.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes)
                    {

                        string quer = "update ritem_damage_transaction set rdt_pay_status= 'Paid' where rdtrans_ID = " + rid2 + "";
                        c.insert(quer);
                        string date = date = DateTime.Now.ToString("yyyy-M-d");
                        string quer2 = "update ritem_damage_transaction set rdt_pay_date= '" + date + "' where rdtrans_ID = " + rid2 + "";
                        c.insert(quer2);

                        string quer3 = "select Profile_balance from profile where user_ID = '" + rpid2 + "'";
                        DataTable d = c.select(quer3);
                        string balance = d.Rows[0]["Profile_balance"].ToString();
                        int bal = int.Parse(balance);
                        int rt = int.Parse(rate);
                        bal = bal - rt;
                        string quer4 = "update profile set Profile_balance = '" + bal.ToString() + "' where User_id = " + rpid2 + "";
                        c.insert(quer4);

                        MessageBox.Show("Transaction successfully marked as paid");
                        tablecall5();
                    }

                }
                else
                {
                    MessageBox.Show("Option disabled for cash payments");

                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (rid2 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("Confirm change.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    if (paystat2 == "Pending")
                    {
                        if (paymeth2 == "Cash")
                        {
                            string quer = "update ritem_damage_transaction set rdt_pay_method= 'Check' where rdtrans_ID = " + rid2 + "";
                            c.insert(quer);
                            tablecall5();
                        }

                        else
                        {
                            string quer = "update ritem_damage_transaction set rdt_pay_method= 'Cash' where rdtrans_ID = " + rid2 + "";
                            c.insert(quer);
                            tablecall5();
                        }
                        MessageBox.Show("Payment method successfully changed");
                    }
                    else
                    {
                        MessageBox.Show("Cannot change payment method of this transaction");
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (bid2 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }

            else if (paystat != "Paid")
            {
                MessageBox.Show("Cannot archive unpaid transaction");
            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("Confirm archive.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    
                        string quer = "update bitem_damage_transaction set bdt_trans_stat = 1 where bdtrans_ID = " + bid2 + "";
                        c.insert(quer);
                        tablecall2();
                    
                    
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (rid2 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }

            else if (paystat != "Paid")
            {
                MessageBox.Show("Cannot archive unpaid transaction");
            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("Confirm archive.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {

                    string quer = "update ritem_damage_transaction set rdt_trans_stat = 1 where rdtrans_ID = " + rid2 + "";
                    c.insert(quer);
                    tablecall5();

                }
            }
        }
    }
}
