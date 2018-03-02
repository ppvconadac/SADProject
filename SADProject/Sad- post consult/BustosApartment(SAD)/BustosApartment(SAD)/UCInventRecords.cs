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
    public partial class UCInventRecords : UserControl
    {
        Class1 c = new Class1();
        private static UCInventRecords _instance;
       
        public static UCInventRecords Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCInventRecords();
                return _instance;
            }
        }
        public UCInventRecords()
        {
            InitializeComponent();
        }

        
        public void dgclear()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
        }
        public void tablecall()
        {

            string quer = "select bitem_name, bitem_status,  concat(profile_fname,profile_mname,profile_lname) as full_name, btrans_id,bt_date,bt_pay_method,bt_pay_status,bt_trans_stat,borrowable_item_bitem_ID,bitem_ID,User_id,Profile_user_ID,bitem_rate from borrowable_item inner join bitem_transaction inner join profile where bitem_id = borrowable_item_bitem_ID and user_id = profile_user_id and bitem_status= 'In Use' and bt_trans_stat =1";
            dataGridView1.DataSource = c.select(quer);
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
        public void tablecall2()
        {

            string quer = "select ntrans_ID, nt_date, nitem_name, nitem_transaction.nt_quantity, nonborrowable_item_nitem_ID,nt_type from nonborrowable_item inner join nitem_transaction where nitem_ID = nonborrowable_item_nitem_ID and nt_trans_stat =0";
            dataGridView1.DataSource = c.select(quer);
            dataGridView1.Columns["ntrans_ID"].Visible = false;
            dataGridView1.Columns["nonborrowable_item_nitem_ID"].Visible = false;
            dataGridView1.ClearSelection();


        }

            private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tablecall();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tablecall2();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
