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
    public partial class UCInventLending : UserControl
    {
        public static int id;
        public static int id2;
        public int ida = 0;
        public int id3;
        public string paystat;
        public string paymeth;
        public string rate;
        public static string fullname;
        public static string itemname;
        private static UCInventLending _instance;
         Class1 c1 = new Class1();
        public static UCInventLending Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCInventLending();
                return _instance;
            }
        }
        public UCInventLending()
        {
            InitializeComponent();
            tablecall();
        }


        public void tablecall()
        {
            
            string quer = "select bitem_name, bitem_status,  concat(profile_fname,profile_mname,profile_lname) as full_name, btrans_id,bt_date,bt_pay_method,bt_pay_status,bt_trans_stat,borrowable_item_bitem_ID,bitem_ID,User_id,Profile_user_ID,bitem_rate from borrowable_item inner join bitem_transaction inner join profile where bitem_id = borrowable_item_bitem_ID and user_id = profile_user_id and bitem_status= 'In Use' and bt_trans_stat =0";
            dataGridView1.DataSource = c1.select(quer);
            dataGridView1.Columns["bitem_ID"].Visible = false;
            dataGridView1.Columns["User_id"].Visible = false;
            dataGridView1.Columns["bitem_status"].Visible = false;
            dataGridView1.Columns["Profile_user_ID"].Visible = false;
            dataGridView1.Columns["borrowable_item_bitem_ID"].Visible = false;
            dataGridView1.Columns["bt_trans_stat"].Visible = false;
            dataGridView1.Columns["btrans_id"].Visible = false;
            dataGridView1.Columns["bitem_rate"].Visible = false;
            dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lendingassign ch = new lendingassign();
            ch.a3 = this;
            DialogResult result = ch.ShowDialog();
            if (result == DialogResult.Yes)
            {
                tablecall();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["btrans_id"].Value.ToString());
                ida = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["btrans_id"].Value.ToString());
                id2 = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["bitem_ID"].Value.ToString());
                id3 = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Profile_user_ID"].Value.ToString());
                paystat = dataGridView1.Rows[e.RowIndex].Cells["bt_pay_status"].Value.ToString();
                paymeth = dataGridView1.Rows[e.RowIndex].Cells["bt_pay_method"].Value.ToString();
                fullname = dataGridView1.Rows[e.RowIndex].Cells["full_name"].Value.ToString();
                itemname = dataGridView1.Rows[e.RowIndex].Cells["bitem_name"].Value.ToString();
                rate = dataGridView1.Rows[e.RowIndex].Cells["bitem_rate"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ida == 0)
            {
                MessageBox.Show("No Entry Detected");
            }

            else
            {
                if (paystat != "Paid")
                {
                    MessageBox.Show("Cannot return item on unpaid transaction");
                }

                else
                {
                    DialogResult dialogResult = MessageBox.Show("Confirm return", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);


                    if (dialogResult == DialogResult.Yes)
                    {
                        if (paystat == "Paid")
                        {
                            string date;
                            string quer = "update borrowable_item set bitem_status = 'Available' where bitem_ID = " + id2 + "";
                            c1.insert(quer);
                            date = DateTime.Now.ToString("yyyy/M/d");
                            string quer2 = "update bitem_transaction set bt_ret= '" + date + "' where btrans_ID = " + id + "";
                            c1.insert(quer2);
                            string quer3 = "update bitem_transaction set bt_trans_stat= 1 where btrans_ID = " + id + "";
                            c1.insert(quer3);
                            tablecall();
                            MessageBox.Show("Return Completed");
                        }

                    }
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ida == 0)
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

                        string quer = "update bitem_transaction set bt_pay_status= 'Paid' where btrans_ID = " + id + "";
                        c1.insert(quer);
                        string date = date = DateTime.Now.ToString("yyyy/M/d");
                        string quer2 = "update bitem_transaction set bt_pay_date= '" + date + "' where btrans_ID = " + id + "";
                        c1.insert(quer2);

                        string quer3 = "select Profile_balance from profile where user_ID = '" + id3 + "'";
                        DataTable d = c1.select(quer3);
                        string balance = d.Rows[0]["Profile_balance"].ToString();
                        int bal = int.Parse(balance);
                        int rt = int.Parse(rate);
                        bal = bal - rt;
                        string quer4 = "update profile set Profile_balance = '" + bal.ToString() + "' where User_id = " + id3 + "";
                        c1.insert(quer4);

                        MessageBox.Show("Transaction successfully marked as paid");
                        tablecall();
                    }
                   
                }
                else
                {
                    MessageBox.Show("Option disabled for cash payments");

                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ida == 0)
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
                            string quer = "update bitem_transaction set bt_pay_method= 'Check' where btrans_ID = " + id + "";
                            c1.insert(quer);
                            tablecall();
                        }

                        else
                        {
                            string quer = "update bitem_transaction set bt_pay_method= 'Cash' where btrans_ID = " + id + "";
                            c1.insert(quer);
                            tablecall();
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (ida == 0)
            {
                MessageBox.Show("No Entry Detected");
            }

            else
            {
                lendingdamages1 ld = new lendingdamages1();
                ld.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ida == 0)
            {
                MessageBox.Show("No Entry Detected");
            }

            else
            {

                authorizearch ch = new authorizearch();
                ch.a3 = this;
                DialogResult result = ch.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    DialogResult dialogResult = MessageBox.Show("Confirm Archive?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes)
                    {
                        string quer = "update bitem_transaction set bt_trans_stat = 2 , bt_archive_date =" +
                            " '" + DateTime.Now.ToString("yyy-M-d") + "', bt_archive_loggedin = " + FmLogin.id + " where btrans_ID = " + id + "";
                        c1.insert(quer);

                        string quer2 = "update borrowable_item set bitem_status = 'Available' where bitem_ID = " + id2 + "";
                        c1.insert(quer2);

                        string quer3 = "select Profile_balance from profile where user_ID = '" + id3 + "'";
                        DataTable d = c1.select(quer3);
                        string balance = d.Rows[0]["Profile_balance"].ToString();
                        int bal = int.Parse(balance);
                        int rt = int.Parse(rate);
                        bal = bal - rt;
                        string quer4 = "update profile set Profile_balance = '" + bal.ToString() + "' where User_id = " + id3 + "";
                        c1.insert(quer4);

                        tablecall();
                    }

                }
            }

           
        }

        private void UCInventLending_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (ida == 0)
            {
                MessageBox.Show("No Entry Detected");
            }

            else
            {
                if (paymeth == "Cash")
                {
                    string amt;
                    string quer = "select SUM(bp_amount) from btrans_partial where bp_trans_id = " + id + "";
                    DataTable d = c1.select(quer);
                    if (d.Rows[0]["SUM(bp_amount)"].ToString() == "")
                    {
                        amt = "0";
                    }
                    else
                    {

                        amt = d.Rows[0]["SUM(bp_amount)"].ToString();
                    }

                    int remaining = int.Parse(rate) - int.Parse(amt);
                    Payment ch = new Payment();
                    ch.getdeets(remaining.ToString(), id, "bitem_transaction", id3);
                    DialogResult result = ch.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        tablecall();
                    }
                }
                else
                {
                    MessageBox.Show("Option disabled for check payments");
                }
            }
        }

                   
    }
}




