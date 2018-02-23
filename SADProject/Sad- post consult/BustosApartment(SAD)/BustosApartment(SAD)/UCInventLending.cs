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
        public string paystat;
        public string paymeth;
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
            string quer = "select bitem_name, bitem_status,  concat(profile_fname,profile_mname,profile_lname) as full_name, btrans_id,bt_date,bt_pay_method,bt_pay_status,borrowable_item_bitem_ID,bitem_ID,User_id,Profile_user_ID from borrowable_item inner join bitem_transaction inner join profile where bitem_id = borrowable_item_bitem_ID and bt_archive = 0 and user_id = profile_user_id and bitem_status= 'In Use'";
            dataGridView1.DataSource = c1.select(quer);
            dataGridView1.Columns["bitem_ID"].Visible = false;
            dataGridView1.Columns["User_id"].Visible = false;
            dataGridView1.Columns["bitem_status"].Visible = false;
            dataGridView1.Columns["Profile_user_ID"].Visible = false;
            dataGridView1.Columns["borrowable_item_bitem_ID"].Visible = false;

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
                id2= int.Parse(dataGridView1.Rows[e.RowIndex].Cells["bitem_ID"].Value.ToString());
                paystat = dataGridView1.Rows[e.RowIndex].Cells["bt_pay_status"].Value.ToString();
                paymeth = dataGridView1.Rows[e.RowIndex].Cells["bt_pay_method"].Value.ToString();
                fullname = dataGridView1.Rows[e.RowIndex].Cells["full_name"].Value.ToString();
                itemname = dataGridView1.Rows[e.RowIndex].Cells["bitem_name"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Confirm return", "Waning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);


            if (dialogResult == DialogResult.Yes)
            {
                if (paystat == "Paid")
                {
                    string date;
                    string quer = "update borrowable_item set bitem_status = 'Available' where bitem_ID = " + id2 + "";
                    c1.insert(quer);
                    date = DateTime.Now.AddDays(1).ToString("yyyy/M/d");
                    string quer2 = "update bitem_transaction set bt_ret= '" + date + "' where btrans_ID = " + id + "";
                    c1.insert(quer2);
                    tablecall();
                    MessageBox.Show("Return Completed");
                }

                else
                {
                    MessageBox.Show("Cannot return item on unpaid transaction");
                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Mark transaction as paid.", "Waning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.Yes)
            {
                string quer = "update bitem_transaction set bt_pay_status= 'Paid' where btrans_ID = " + id + "";
                c1.insert(quer);
                tablecall();
                

            }
            MessageBox.Show("Transaction successfully marked as paid");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirm change.", "Waning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.Yes)
            {
                if (paymeth == "Cash" )
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lendingdamages1 ld = new lendingdamages1();
            ld.Show();
        }
    }
}



