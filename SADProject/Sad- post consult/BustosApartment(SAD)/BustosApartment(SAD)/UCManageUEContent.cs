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
        public int tid3;
        public int tid4;
        public double rate;
        public double rate2;
        public double price;
        public double price2;
        public string owner_pay;
        public string owner_pay2;
        public int rid;
        public int rid2;
        public string pay_meth;
        public string pay_meth2;
        public string pay_stat;
        public string pay_stat2;
        public int resolved1;
        public int resolved2;
        public int res_stat;
        public int res_stat2;
        public double excess;
        public double excess2;
        public int uetid;
        public int uwtid;
        public double curread;
        public double curread2;
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
            tablecall3();
        }

        public void tablecall()
        {
            string quer = "select * from utelect_trans";
            dataGridView5.DataSource = c1.select(quer);
            
            dataGridView5.Columns["uelect_ID"].Visible = false;
            dataGridView5.Columns["uelect_trans_stat"].Visible = false;
            dataGridView5.Columns["uelect_void_date"].Visible = false;
            dataGridView5.Columns["uelect_void_loggedin"].Visible = false;
            dataGridView5.Columns["uelect_trans_resolved"].Visible = false;
            dataGridView5.Columns["uelect_date"].HeaderText = "Date";
            dataGridView5.Columns["uelect_bill_price"].HeaderText = "Bill Amount";
            dataGridView5.Columns["uelect_Excess"].HeaderText = "Excess";
            dataGridView5.Columns["uelect_rate"].HeaderText = "Rate";
            dataGridView5.ClearSelection();
        }
        public void tablecall3()
        {
            string quer = "select * from utwat_trans";
            dataGridView6.DataSource = c1.select(quer);
            dataGridView6.Columns["uwat_ID"].Visible = false;
            dataGridView6.Columns["uwat_trans_stat"].Visible = false;
            dataGridView6.Columns["uwat_void_date"].Visible = false;
            dataGridView6.Columns["uwat_void_loggedin"].Visible = false;
            dataGridView6.Columns["uwat_trans_resolved"].Visible = false;
            dataGridView6.Columns["uwat_date"].HeaderText = "Date";
            dataGridView6.Columns["uwat_bill_price"].HeaderText = "Bill Amount";
            dataGridView6.Columns["uwat_Excess"].HeaderText = "Excess";
            dataGridView6.Columns["uwat_rate"].HeaderText = "Rate";
            dataGridView6.ClearSelection();
        }

        private void UCUEContent_Load(object sender, EventArgs e)
        {
            String query1 = "select uelect_date from utelect_trans where uelect_trans_stat =0";
            foreach (DataRow row in c1.select(query1).Rows)
            {
                for (int i = 0; i < row.ItemArray.Length; i++)

                {
                    comboBox1.Items.Add(row.ItemArray[0].ToString());
                    
                }
            }
            String query2 = "select uwat_date from utwat_trans where uwat_trans_stat = 0";
            foreach (DataRow row in c1.select(query2).Rows)
            {
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    comboBox2.Items.Add(row.ItemArray[0].ToString());

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
                        quer = "update utelect_trans set uelect_trans_stat = 2, uelect_void_date = '" + DateTime.Now.ToString("yyyy-M-d") + "', uelect_void_loggedin = " + FmLogin.id + " where uelect_ID = " + tid + "";
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
                res_stat = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["uet_trans_resolved"].Value.ToString());
                uetid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["uet_uelect_id"].Value.ToString());
                curread = double.Parse(dataGridView1.Rows[e.RowIndex].Cells["uet_current"].Value.ToString());
            }
        }

        public void tablecall2()
        {
            string quer = "select uelect_ID from utelect_trans where uelect_date = '" + comboBox1.Text + "'";
            DataTable d = c1.select(quer);
            if (d.Rows.Count > 0)
            {

                int id = int.Parse(d.Rows[0]["uelect_ID"].ToString());

                string quer2 = "select uet_ID,uet_date,uet_prev,uet_current,uet_total,uet_room_id,Room_number,Room_classification_classification_ID, uet_pay_meth,uet_pay_stat, uet_owner_pay,uet_trans_resolved, uet_uelect_id from uelect_trans_specs inner join room where uet_room_id=Room_ID and uet_uelect_id = " + id + " and uet_trans_stat =0";
                dataGridView1.DataSource = c1.select(quer2);
                dataGridView1.Columns["uet_ID"].Visible = false;
                dataGridView1.Columns["uet_room_id"].Visible = false;
                dataGridView1.Columns["Room_classification_classification_ID"].Visible = false;
                dataGridView1.Columns["uet_trans_resolved"].Visible = false;
                dataGridView1.Columns["uet_uelect_id"].Visible = false;
                dataGridView1.Columns["uet_date"].HeaderText = "Date";
                dataGridView1.Columns["uet_prev"].HeaderText = "Previous Reading";
                dataGridView1.Columns["uet_current"].HeaderText = "Current Reading";
                dataGridView1.Columns["uet_total"].HeaderText = "Amount";
                dataGridView1.Columns["uet_pay_meth"].HeaderText = "Payment Method";
                dataGridView1.Columns["uet_pay_stat"].HeaderText = "Payment Status";
                dataGridView1.Columns["uet_owner_pay"].HeaderText = "To Pay";
                dataGridView1.Columns["Room_number"].HeaderText = "Room Number";
                dataGridView1.ClearSelection();
            }
        }

        public void tablecall4()
        {
            string quer = "select uwat_ID from utwat_trans where uwat_date = '" + comboBox2.Text + "'";
            DataTable d = c1.select(quer);
            if (d.Rows.Count > 0)
            {

                int id = int.Parse(d.Rows[0]["uwat_ID"].ToString());

                string quer2 = "select uwt_ID,uwt_date,uwt_prev,uwt_current,uwt_total,uwt_room_id,Room_number,Room_classification_classification_ID, uwt_pay_meth,uwt_pay_stat, uwt_owner_pay,uwt_trans_resolved, uwt_uwat_id from uwat_trans_specs inner join room where uwt_room_id=Room_ID and uwt_uwat_id = " + id + " and uwt_trans_stat =0";
                dataGridView3.DataSource = c1.select(quer2);
                dataGridView3.Columns["uwt_ID"].Visible = false;
                dataGridView3.Columns["uwt_room_id"].Visible = false;
                dataGridView3.Columns["Room_classification_classification_ID"].Visible = false;
                dataGridView3.Columns["uwt_trans_resolved"].Visible = false;
                dataGridView3.Columns["uwt_uwat_id"].Visible = false;
                dataGridView3.Columns["uwt_date"].HeaderText = "Date";
                dataGridView3.Columns["uwt_prev"].HeaderText = "Previous Reading";
                dataGridView3.Columns["uwt_current"].HeaderText = "Current Reading";
                dataGridView3.Columns["uwt_total"].HeaderText = "Amount";
                dataGridView3.Columns["uwt_pay_meth"].HeaderText = "Payment Method";
                dataGridView3.Columns["uwt_pay_stat"].HeaderText = "Payment Status";
                dataGridView3.Columns["uwt_owner_pay"].HeaderText = "To Pay";
                dataGridView3.Columns["Room_number"].HeaderText = "Room Number";
                dataGridView3.ClearSelection();
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
            
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            tablecall2();
            dataGridView3.DataSource = null;
            tablecall4();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (tid2 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else if(pay_meth == "Check")
            {
                MessageBox.Show("Option disabled for check payments");
            }
            else if (owner_pay == "Owner")
            {
                MessageBox.Show("Disabled for owner based charges");
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
                if (owner_pay == "Owner")
                {
                    MessageBox.Show("Disabled for owner based charges");
                }
                else if (pay_stat == "Pending")
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
                    else if (pay_meth2 == "Cash")
                    {
                        MessageBox.Show("Option disabled for cash payments");

                    }

                }
                else if (pay_meth == "Cash")
                {
                    MessageBox.Show("Option disabled for cash payments");

                }
                else
                {
                    MessageBox.Show("Already Paid");
                }

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (tid == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else
            {
                string quer = "select * from uelect_trans_specs where uet_uelect_id = " + tid + " and uet_trans_resolved = 0";
                DataTable d = c1.select(quer);
                if (d.Rows.Count > 0)
                {
                    MessageBox.Show("Cannot resolve transaction with unresolved charges");
                }
                else if (resolved1 == 1)
                {
                    MessageBox.Show("Already Resolved");
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
                        c1.insert(quer2);

                        UCManageGTContent uc = new UCManageGTContent();
                        uc.tablecall();

                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (tid2 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else if(owner_pay == "Owner")
            {
                MessageBox.Show("Disabled for owner based charges");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Confirm change.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    if (pay_stat == "Pending")
                    {
                        if (pay_meth == "Cash")
                        {
                            string quer = "update uelect_trans_specs set uet_pay_meth= 'Check' where uet_ID = " + tid2 + "";
                            c1.insert(quer);
                            tablecall2();
                        }

                        else
                        {
                            string quer = "update uelect_trans_specs set uet_pay_meth= 'Cash' where uet_ID = " + tid2 + "";
                            c1.insert(quer);
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

        private void button12_Click(object sender, EventArgs e)
        {
            if (tid2 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }       
            
            else if(res_stat == 1)
            {
                MessageBox.Show("Already resolved");
            }
            else
            {
                if (owner_pay == "Owner")
                {
                    DialogResult dialogResult = MessageBox.Show("Mark as Resolved", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes)
                    {
                       string date = DateTime.Now.ToString("yyyy-M-d");

                        string quer3 = "update uelect_trans_specs set uet_trans_resolved= 1 where uet_ID = " + tid2 + "";
                        c1.insert(quer3);
                        string quer = "select Owner_Owner_ID from room where Room_ID = "+rid+"";
                        DataTable d = c1.select(quer);
                        int oid = int.Parse(d.Rows[0]["Owner_Owner_ID"].ToString());
                        string quer2 = "insert into in_transaction values(NULL, '" + date + "', " + price + ", " + oid + ", 'Electrical Bill,0, NULL,NULL )";
                        c1.insert(quer2);
                        string quer6 = "update room set room_elecreading = '" + curread.ToString() + "' where Room_ID = " + rid + "";
                        c1.insert(quer6);
                        UCManageIndiEx it = new UCManageIndiEx();
                        it.tablecall();
                        UCRoomContent ucr = new UCRoomContent();
                        ucr.tablecall();
                        tablecall2();

                    }

                }
                else
                {
                    if (owner_pay == "Tenant")
                    {
                        if (pay_stat != "Paid")
                        {
                            MessageBox.Show("Cannot resolve unpaid charges");
                        }
                        else
                        {
                            DialogResult dialogResult = MessageBox.Show("Mark as Resolved", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                            if (dialogResult == DialogResult.Yes)
                            {
                                string date = DateTime.Now.ToString("yyyy-M-d");
                                string quer3 = "update uelect_trans_specs set uet_trans_resolved= 1 where uet_ID = " + tid2 + "";
                                c1.insert(quer3);

                                string quer = "select uelect_bill_price from utelect_trans where uelect_id= " + uetid + "";
                                DataTable d = c1.select(quer);
                                double bill = double.Parse(d.Rows[0]["uelect_bill_price"].ToString());

                                string quer2 = "select SUM(uet_total) from uelect_trans_specs where uet_uelect_id = " + uetid + "";
                                d = c1.select(quer2);
                                
                                double sum = double.Parse(d.Rows[0]["SUM(uet_total)"].ToString());

                                double ex = bill - sum;

                                string quer4 = "update utelect_trans set uelect_excess ='" + ex.ToString() + "'";
                                c1.insert(quer4);
                                string quer6 = "update room set room_elecreading = '" + curread.ToString() + "' where Room_ID = " + rid + "";
                                c1.insert(quer6);
                                UCRoomContent ucr = new UCRoomContent();
                                ucr.tablecall();
                                tablecall2();
                            }
                        }
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (tid2 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else if (res_stat == 1)
            {
                MessageBox.Show("Cannot void resolved charges");
            }
            else 
            {
                string quer = "select * from uespecs_partial where uesp_uelectspecs_id = " + tid2 + "";
                DataTable d = c1.select(quer);
                if(d.Rows.Count > 0)
                {
                    MessageBox.Show("Cannot void charges with partial payments");
                }

                else
                {
                    DialogResult dialogResult = MessageBox.Show("Confirm Void.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes)
                    {
                        quer = "update uelect_trans_specs set uet_trans_stat = 2, uet_void_date = '" + DateTime.Now.ToString("yyyy-M-d") + "', uet_void_loggedin = " + FmLogin.id + " where uet_ID = " + tid2 + "";
                        c1.insert(quer);
                        tablecall2();

                    }
                }
               
            }

            
        }

        private void button21_Click(object sender, EventArgs e)
        {
            watrecmontrans ch = new watrecmontrans();
            ch.a3 = this;
            DialogResult result = ch.ShowDialog();
            if (result == DialogResult.Yes)
            {
                tablecall3();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (tid3== 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else
            {
                eladdchar ch = new eladdchar();
                ch.getdeets(rate2, tid3, "Water");
                DialogResult result = ch.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    tablecall3();
                }
            }
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                tid3 = int.Parse(dataGridView6.Rows[e.RowIndex].Cells["uwat_ID"].Value.ToString());
                rate2 = double.Parse(dataGridView6.Rows[e.RowIndex].Cells["uwat_rate"].Value.ToString());
                resolved2 = int.Parse(dataGridView6.Rows[e.RowIndex].Cells["uwat_trans_resolved"].Value.ToString());
                excess2 = double.Parse(dataGridView6.Rows[e.RowIndex].Cells["uwat_excess"].Value.ToString());
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (tid3 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else
            {
                string quer = "select * from uwat_trans_specs where uwt_uwat_id = " + tid3 + " and uwt_trans_resolved = 0";
                DataTable d = c1.select(quer);
                if (d.Rows.Count > 0)
                {
                    MessageBox.Show("Cannot resolve transaction with unresolved charges");
                }
                else if (resolved1 == 1)
                {
                    MessageBox.Show("Already Resolved");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Mark as Resolved.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes)
                    {
                        quer = "update utwat_trans set uwat_trans_resolved = 1 where uwat_ID = " + tid + "";
                        c1.insert(quer);
                        tablecall3();

                        string quer2;
                        string date = DateTime.Now.ToString("yyyy-M-d");

                        quer2 = "insert into misc_transaction values(NULL, '" + date + "','" + excess.ToString() + "','General','Water - Excess',0, NULL,NULL )";
                        c1.insert(quer2);

                        UCManageGTContent uc = new UCManageGTContent();
                        uc.tablecall();

                    }
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (tid3 == 0)
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
                        string quer = "update utwat_trans set uwat_trans_stat = 1 where uwat_ID = " + tid3 + "";
                        c1.insert(quer);
                        tablecall3();
                    }

                }

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (tid3 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else
            {
                string quer = "select * from uwat_trans_specs where uwt_uwat_id = " + tid3 + "";
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
                        quer = "update utwat_trans set uwat_trans_stat = 2, uwat_void_date = '" + DateTime.Now.ToString("yyyy-M-d") + "', uwat_void_loggedin = " + FmLogin.id + " where uwat_ID = " + tid + "";
                        c1.insert(quer);
                        tablecall3();

                    }

                }

            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            tablecall4();
            dataGridView3.ClearSelection();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                tid4 = int.Parse(dataGridView3.Rows[e.RowIndex].Cells["uwt_ID"].Value.ToString());
                price2 = double.Parse(dataGridView3.Rows[e.RowIndex].Cells["uwt_total"].Value.ToString());
                rid2 = int.Parse(dataGridView3.Rows[e.RowIndex].Cells["uwt_room_id"].Value.ToString());
                owner_pay2 = dataGridView3.Rows[e.RowIndex].Cells["uwt_owner_pay"].Value.ToString();
                pay_meth2 = dataGridView3.Rows[e.RowIndex].Cells["uwt_pay_meth"].Value.ToString();
                pay_stat2 = dataGridView3.Rows[e.RowIndex].Cells["uwt_pay_stat"].Value.ToString();
                res_stat2 = int.Parse(dataGridView3.Rows[e.RowIndex].Cells["uwt_trans_resolved"].Value.ToString());
                uwtid = int.Parse(dataGridView3.Rows[e.RowIndex].Cells["uwt_uwat_id"].Value.ToString());
                curread2 = double.Parse(dataGridView3.Rows[e.RowIndex].Cells["uwt_current"].Value.ToString());
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (tid4 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else
            {

                if (owner_pay2 == "Tenant")
                {
                    string quer3 = "select Profile_user_ID from room_transaction where Room_Room_ID = " + rid2 + " and rt_type = 'Active'";
                    DataTable d = c1.select(quer3);
                    int pid = int.Parse(d.Rows[0]["Profile_user_ID"].ToString());


                    if (pay_meth2 == "Cash")
                    {
                        string amt;
                        string quer = "select SUM(uwsp_amount) from uwspecs_partial where uwsp_uwatspecs_id = " + tid4 + "";
                        d = c1.select(quer);
                        if (d.Rows[0]["SUM(uwsp_amount)"].ToString() == "")
                        {
                            amt = "0";
                        }
                        else
                        {

                            amt = d.Rows[0]["SUM(uwsp_amount)"].ToString();
                        }

                        double remaining = price2 - double.Parse(amt);
                        Payment ch = new Payment();
                        ch.getdeets(remaining.ToString(), tid4, "uwspecs_partial", pid);
                        DialogResult result = ch.ShowDialog();
                        if (result == DialogResult.Yes)
                        {
                            tablecall4();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Option disabled for check payments");
                    }

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tid4 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else if (pay_meth2 == "Check")
            {
                MessageBox.Show("Option disabled for check payments");
            }
            else if (owner_pay2 == "Owner")
            {
                MessageBox.Show("Disabled for owner based charges");
            }
            else
            {
                reviewpayments ch = new reviewpayments();
                ch.getdeets(tid4, "uwspecs_partial");
                ch.Show();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (tid4 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }

            else
            {
                if (owner_pay2 == "Owner")
                {
                    MessageBox.Show("Disabled for owner based charges");
                }
                else if (pay_stat2 == "Pending")
                {
                    if (pay_meth2 == "Check")
                    {

                        DialogResult dialogResult = MessageBox.Show("Mark transaction as paid.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (dialogResult == DialogResult.Yes)
                        {

                            string quer = "update uwat_trans_specs set uwt_pay_stat= 'Paid' where uwt_ID = " + tid4 + "";
                            c1.insert(quer);
                            string date = date = DateTime.Now.ToString("yyyy-M-d");
                            string quer2 = "update uwat_trans_specs set uwt_pay_date= '" + date + "' where uwt_ID = " + tid4 + "";
                            c1.insert(quer2);

                            string quer3 = "select Profile_user_ID from room_transaction where Room_Room_ID = " + rid2 + " and rt_type = 'Active'";
                            DataTable d = c1.select(quer3);
                            int pid = int.Parse(d.Rows[0]["Profile_user_ID"].ToString());
                            string quer4 = "select Profile_balance from profile where user_ID = '" + pid + "'";
                            d = c1.select(quer4);
                            string balance = d.Rows[0]["Profile_balance"].ToString();
                            double bal = double.Parse(balance);
                            double rt = price2;
                            bal = bal - rt;
                            string quer5 = "update profile set Profile_balance = '" + bal.ToString() + "' where User_id = " + pid + "";
                            c1.insert(quer5);

                            MessageBox.Show("Transaction successfully marked as paid");
                            tablecall4();
                        }

                    }
                    else if (pay_meth2 == "Cash")
                    {
                        MessageBox.Show("Option disabled for cash payments");

                    }

                }
                else if (pay_meth2 == "Cash")
                {
                    MessageBox.Show("Option disabled for cash payments");

                }
                else
                {
                    MessageBox.Show("Already Paid");
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tid4 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else if (owner_pay2 == "Owner")
            {
                MessageBox.Show("Disabled for owner based charges");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Confirm change.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    if (pay_stat2 == "Pending")
                    {
                        if (pay_meth2 == "Cash")
                        {
                            string quer = "update uwat_trans_specs set uwt_pay_meth= 'Check' where uwt_ID = " + tid4 + "";
                            c1.insert(quer);
                            tablecall4();
                        }

                        else
                        {
                            string quer = "update uwat_trans_specs set uwt_pay_meth= 'Cash' where uwt_ID = " + tid4 + "";
                            c1.insert(quer);
                            tablecall4();
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (tid4 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }

            else if (res_stat2 == 1)
            {
                MessageBox.Show("Already resolved");
            }
            else
            {
                if (owner_pay2 == "Owner")
                {
                    DialogResult dialogResult = MessageBox.Show("Mark as Resolved", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes)
                    {
                        string date = DateTime.Now.ToString("yyyy-M-d");

                        string quer3 = "update uwat_trans_specs set uwt_trans_resolved= 1 where uwt_ID = " + tid4 + "";
                        c1.insert(quer3);
                        string quer = "select Owner_Owner_ID from room where Room_ID = " + rid2 + "";
                        DataTable d = c1.select(quer);
                        int oid = int.Parse(d.Rows[0]["Owner_Owner_ID"].ToString());
                        string quer2 = "insert into in_transaction values(NULL, '" + date + "', " + price2 + ", " + oid + ", 'Water Bill',0, NULL,NULL )";
                        c1.insert(quer2);
                        string quer6 = "update room set room_watreading = '" + curread2.ToString() + "' where Room_ID = " + rid2 + "";
                        c1.insert(quer6);
                        UCManageIndiEx it = new UCManageIndiEx();
                        it.tablecall();
                        UCRoomContent ucr = new UCRoomContent();
                        ucr.tablecall();
                        tablecall4();

                    }

                }
                else
                {
                    if (owner_pay2 == "Tenant")
                    {
                        if (pay_stat2 != "Paid")
                        {
                            MessageBox.Show("Cannot resolve unpaid charges");
                        }
                        else
                        {
                            DialogResult dialogResult = MessageBox.Show("Mark as Resolved", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                            if (dialogResult == DialogResult.Yes)
                            {
                                string date = DateTime.Now.ToString("yyyy-M-d");
                                string quer3 = "update uwat_trans_specs set uwt_trans_resolved= 1 where uwt_ID = " + tid4 + "";
                                c1.insert(quer3);

                                string quer = "select uwat_bill_price from utwat_trans where uwat_id= " + uwtid + "";
                                DataTable d = c1.select(quer);
                                double bill = double.Parse(d.Rows[0]["uwat_bill_price"].ToString());

                                string quer2 = "select SUM(uwt_total) from uwat_trans_specs where uwt_uwat_id = " + uwtid + "";
                                d = c1.select(quer2);

                                double sum = double.Parse(d.Rows[0]["SUM(uwt_total)"].ToString());

                                double ex = bill - sum;

                                string quer4 = "update utwat_trans set uwat_excess ='" + ex.ToString() + "'";
                                c1.insert(quer4);
                                string quer6 = "update room set room_watreading = '" + curread2.ToString() + "' where Room_ID = " + rid2 + "";
                                c1.insert(quer6);
                                UCRoomContent ucr = new UCRoomContent();
                                ucr.tablecall();
                                tablecall4();
                            }
                        }
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tid4 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else if (res_stat2 == 1)
            {
                MessageBox.Show("Cannot void resolved charges");
            }
            else
            {
                string quer = "select * from uwspecs_partial where uwsp_uwatspecs_id = " + tid4 + "";
                DataTable d = c1.select(quer);
                if (d.Rows.Count > 0)
                {
                    MessageBox.Show("Cannot void charges with partial payments");
                }

                else
                {
                    DialogResult dialogResult = MessageBox.Show("Confirm Void.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes)
                    {
                        quer = "update uwat_trans_specs set uwt_trans_stat = 2, uwt_void_date = '" + DateTime.Now.ToString("yyyy-M-d") + "', uwt_void_loggedin = " + FmLogin.id + " where uwt_ID = " + tid4 + "";
                        c1.insert(quer);
                        tablecall4();

                    }
                }

            }
        }
    }
}

