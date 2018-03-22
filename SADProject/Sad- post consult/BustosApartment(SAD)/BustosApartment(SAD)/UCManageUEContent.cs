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
    public partial class UCManageUEContent : UserControl
    {
        Class1 c1 = new Class1();
        public int tid;
        public int tid2;
        public double rate;
        public double price;
        public string owner_pay;
        public int rid;
        public string pay_meth;
        public string pay_stat;
        public int resolved1;
        public double excess;
        private static UCManageUEContent _instance;

        public static UCManageUEContent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCManageUEContent();
                return _instance;
            }
        }
        public UCManageUEContent()
        {
            InitializeComponent();
            tablecall();
        }

        public void tablecall()
        {
            string quer = "select * from utelect_trans";
            dataGridView5.DataSource = c1.select(quer);
            dataGridView5.ClearSelection();
        }

        private void UCUEContent_Load(object sender, EventArgs e)
        {
            String query1 = "select uelect_date from utelect_trans where uelect_trans_stat = 0";
            foreach (DataRow row in c1.select(query1).Rows)
            {
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    comboBox1.Items.Add(row.ItemArray[0].ToString());
                    
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            elrecmontrans ch = new elrecmontrans();
            ch.a3 = this;
            DialogResult result = ch.ShowDialog();
            if (result == DialogResult.Yes)
            {
                tablecall();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tid == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else
            {
                eladdchar ch = new eladdchar();
                ch.getdeets(rate, tid, "Electricity");
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
                tid = int.Parse(dataGridView5.Rows[e.RowIndex].Cells["uelect_ID"].Value.ToString());
                rate = double.Parse(dataGridView5.Rows[e.RowIndex].Cells["uelect_rate"].Value.ToString());
                resolved1 = int.Parse(dataGridView5.Rows[e.RowIndex].Cells["uelect_trans_resolved"].Value.ToString());
                excess = double.Parse(dataGridView5.Rows[e.RowIndex].Cells["uelect_excess"].Value.ToString());
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (tid == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else
            {
                
                if (resolved1 == 0)
                {
                    MessageBox.Show("Cannot archive unresolved transaction");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Confirm Archive.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes)
                    {
                        string quer = "update utelect_trans set uelect_trans_stat = 1 where uelect_ID = " + tid + "";
                        c1.insert(quer);
                        tablecall();
                    }
                    
                }

                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tid == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else
            {
                string quer = "select * from uelect_trans_specs where uet_uelect_id = " + tid + "";
                DataTable d = c1.select(quer);
                if (d.Rows.Count > 0)
                {
                    MessageBox.Show("Cannot void transaction existing charges");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Confirm Void.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes)
                    {
                        quer = "update utelect_trans set utelect_trans = 2, uelect_void_date = '" + DateTime.Now.ToString("yyyy-M-d") + "', uelect_void_loggedin = " + FmLogin.id + " where uelect_ID = " + tid + "";
                        c1.insert(quer);
                        tablecall();
                       
                    }
                    
                }

            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            tablecall2();

            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                tid2 = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["uet_ID"].Value.ToString());
                price = double.Parse(dataGridView1.Rows[e.RowIndex].Cells["uet_total"].Value.ToString());
                rid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["uet_room_id"].Value.ToString());
                owner_pay = dataGridView1.Rows[e.RowIndex].Cells["uet_owner_pay"].Value.ToString();
                pay_meth = dataGridView1.Rows[e.RowIndex].Cells["uet_pay_meth"].Value.ToString();
                pay_stat = dataGridView1.Rows[e.RowIndex].Cells["uet_pay_stat"].Value.ToString();

            }
        }

        public void tablecall2()
        {
            string quer = "select uelect_ID from utelect_trans where uelect_date = '" + comboBox1.Text + "'";
            DataTable d = c1.select(quer);
            if (d.Rows.Count > 0)
            {

                int id = int.Parse(d.Rows[0]["uelect_ID"].ToString());

                string quer2 = "select uet_ID,uet_date,uet_prev,uet_current,uet_total,uet_room_id,Room_number,Room_classification_classification_ID, uet_pay_meth,uet_pay_stat, uet_owner_pay from uelect_trans_specs inner join room where uet_room_id=Room_ID and uet_uelect_id = " + id + "";
                dataGridView1.DataSource = c1.select(quer2);
                dataGridView1.Columns["uet_ID"].Visible = false;
                dataGridView1.Columns["uet_room_id"].Visible = false;
                dataGridView1.Columns["Room_classification_classification_ID"].Visible = false;

                dataGridView1.ClearSelection();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {

            if (tid2 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else
            {

                if (owner_pay == "Tenant")
                {         
                    string quer3 = "select Profile_user_ID from room_transaction where Room_Room_ID = " + rid + " and rt_type = 'Active'";
                    DataTable d = c1.select(quer3);
                    int pid = int.Parse(d.Rows[0]["Profile_user_ID"].ToString());


                    if (pay_meth == "Cash")
                    {
                        string amt;
                        string quer = "select SUM(uesp_amount) from uespecs_partial where uesp_uelectspecs_id = " + tid2 + "";
                        d = c1.select(quer);
                        if (d.Rows[0]["SUM(uesp_amount)"].ToString() == "")
                        {
                            amt = "0";
                        }
                        else
                        {

                            amt = d.Rows[0]["SUM(uesp_amount)"].ToString();
                        }

                        double remaining = price - double.Parse(amt);
                        Payment ch = new Payment();
                        ch.getdeets(remaining.ToString(), tid2, "uespecs_partial", pid);
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

        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            tablecall2();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (tid2 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else
            {
                reviewpayments ch = new reviewpayments();
                ch.getdeets(tid2, "uespecs_partial");
                ch.Show();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (tid2 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }

            else
            {
                if (pay_stat == "Pending")
                {
                    if (pay_meth == "Check")
                    {

                        DialogResult dialogResult = MessageBox.Show("Mark transaction as paid.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (dialogResult == DialogResult.Yes)
                        {

                            string quer = "update uelect_trans_specs set uet_pay_stat= 'Paid' where uet_ID = " + tid2 + "";
                            c1.insert(quer);
                            string date = date = DateTime.Now.ToString("yyyy-M-d");
                            string quer2 = "update uelect_trans_specs set uet_pay_date= '" + date + "' where uet_ID = " + tid2 + "";
                            c1.insert(quer2);

                            string quer3 = "select Profile_user_ID from room_transaction where Room_Room_ID = " + rid + " and rt_type = 'Active'";
                            DataTable d = c1.select(quer3);
                            int pid = int.Parse(d.Rows[0]["Profile_user_ID"].ToString());
                            string quer4 = "select Profile_balance from profile where user_ID = '" + pid + "'";
                            d = c1.select(quer4);
                            string balance = d.Rows[0]["Profile_balance"].ToString();
                            double bal = double.Parse(balance);
                            double rt = price;
                            bal = bal - rt;
                            string quer5 = "update profile set Profile_balance = '" + bal.ToString() + "' where User_id = " + pid + "";
                            c1.insert(quer5);

                            MessageBox.Show("Transaction successfully marked as paid");
                            tablecall2();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Option disabled for cash payments");

                    }
                }
                else
                {
                    MessageBox.Show("Already Paid");
                }

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string quer = "select * from uelect_trans_specs where uet_uelect_id = " + tid + " and uet_trans_resolved = 0";
            DataTable d = c1.select(quer);
            if (d.Rows.Count > 0)
            {
                MessageBox.Show("Cannot resolve transaction with unresolved charges");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Mark as Resolved.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    quer = "update utelect_trans set uelect_trans_resolved = 1 where uelect_ID = " + tid + "";
                    c1.insert(quer);
                    tablecall();

                    string quer2;
                    string date = DateTime.Now.ToString("yyyy-M-d");

                    quer2 = "insert into misc_transaction values(NULL, '" + date + "','" + excess.ToString() + "','General','Electricity - Excess',0, NULL,NULL )";
                    c1.insert(quer);
                   
                }
            }
        }
    }
}

