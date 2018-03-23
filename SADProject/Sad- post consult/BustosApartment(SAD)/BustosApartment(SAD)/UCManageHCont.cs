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
    public partial class UCManageHCont : UserControl
    {
        private static UCManageHCont _instance;
        Class1 c = new Class1();
        int ch = 1;

        public static UCManageHCont Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCManageHCont();
                return _instance;
            }
        }
        public UCManageHCont()
        {
            InitializeComponent();
            tablecall();
            dates();
        }
        public void refresh()
        {
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            tablecall();        

        }

        public void dates()
        {
            DateTime d = DateTime.Now;
            int baseyear = 2018;
            int yeargap = d.Year - (baseyear - 1);
            String[,] date = new String[12, 2] {
                {"January","31"},{"Febuary","28"},{"March","31"},{"April","30"},{"May","31"},
                {"June","30"},{"July","31"}, {"August","31"}, {"September","30"},{"October","31"},
                {"November","30"}, {"December","31"}
            };
            comboBox1.Items.Add("");
            comboBox2.Items.Add("");
            comboBox3.Items.Add("");
            for (int i = 0; yeargap > i; i++)
            {
                comboBox1.Items.Add(baseyear);
                baseyear++;
            }
            for (int j = 0; j < 12; j++)
            {
                comboBox2.Items.Add(date[j, 0]);
            }
            for (int k = 1; k <= 31; k++)
            {
                comboBox3.Items.Add(k);
            }
        }
        public void tablecall() {
            string quer = "select rt_date_start ,room_number,rt_price from room_transaction inner join room " +
               " inner join room_classification where room_transaction.Room_Room_ID = Room_ID" +
               " and Room_classification_classification_ID = classification_ID and rt_date_start and rt_type != 'Extend'";
            dataGridView2.DataSource = c.select(quer);

            dataGridView2.Columns["rt_date_start"].HeaderText = "Date";
            dataGridView2.Columns["room_number"].HeaderText = "Room Number";
            dataGridView2.Columns["rt_price"].HeaderText = "Amount Earned";
            dataGridView2.ClearSelection();
        }
        public void tablecall(string q)
        {
            string quer = "select rt_date_start ,room_number,rc_rate from room_transaction inner join room " +
               " inner join room_classification where room_transaction.Room_Room_ID = Room_ID" +
               " and Room_classification_classification_ID = classification_ID and rt_type != 'Extend' "+q;
            dataGridView2.DataSource = c.select(quer);

            dataGridView2.Columns["rt_date_start"].HeaderText = "Date";
            dataGridView2.Columns["room_number"].HeaderText = "Room Number";
            dataGridView2.Columns["rc_rate"].HeaderText = "Amount Earned";
            dataGridView2.ClearSelection();
        }
        public void tablecall2() {
            string quer = "SELECT bt_date, bt_pay_method, bt_price, bitem_name FROM bitem_transaction inner join borrowable_item  where" +
                " borrowable_item_bitem_ID = bitem_id " +
                "and bt_pay_status = 'Paid' ";
            dataGridView2.DataSource = c.select(quer);
            dataGridView2.Columns["bt_date"].HeaderText = "Date";
            dataGridView2.Columns["bt_pay_method"].HeaderText = "Payment Method";
            dataGridView2.Columns["bt_price"].HeaderText = "Amount Earned";
            dataGridView2.Columns["bitem_name"].HeaderText = "Item Name";
            dataGridView2.ClearSelection();

        }
        public void tablecall2(string q)
        {
            string quer = "SELECT bt_date, bt_pay_method, bt_price, bitem_name FROM bitem_transaction inner join borrowable_item  where" +
                " borrowable_item_bitem_ID = bitem_id " +
                "and bt_pay_status = 'Paid' "+q;
            dataGridView2.DataSource = c.select(quer);
            dataGridView2.Columns["bt_date"].HeaderText = "Date";
            dataGridView2.Columns["bt_pay_method"].HeaderText = "Payment Method";
            dataGridView2.Columns["bt_price"].HeaderText = "Amount Earned";
            dataGridView2.Columns["bitem_name"].HeaderText = "Item Name";
            dataGridView2.ClearSelection();

        }
        public void tablecall3() {
            string quer = "select * from misc_transaction where mt_trans_stat = 1";
            dataGridView2.DataSource = c.select(quer);
            dataGridView2.Columns["mtrans_ID"].Visible = false;
            dataGridView2.Columns["mt_trans_stat"].Visible = false;
            dataGridView2.Columns["mt_void_date"].Visible = false;
            dataGridView2.Columns["mt_void_loggedin"].Visible = false;
            dataGridView2.Columns["mt_date"].HeaderText = "Date";
            dataGridView2.Columns["mt_price"].HeaderText = "Amount";
            dataGridView2.Columns["mt_type"].HeaderText = "Type";
            dataGridView2.Columns["mt_desc"].HeaderText = "Description";
            dataGridView2.ClearSelection();
        }
        public void tablecall3(string q)
        {
            string quer = "select * from misc_transaction where mt_trans_stat = 1 "+q;
            dataGridView2.DataSource = c.select(quer);
            dataGridView2.Columns["mtrans_ID"].Visible = false;
            dataGridView2.Columns["mt_trans_stat"].Visible = false;
            dataGridView2.Columns["mt_void_date"].Visible = false;
            dataGridView2.Columns["mt_void_loggedin"].Visible = false;
            dataGridView2.Columns["mt_date"].HeaderText = "Date";
            dataGridView2.Columns["mt_price"].HeaderText = "Amount";
            dataGridView2.Columns["mt_type"].HeaderText = "Type";
            dataGridView2.Columns["mt_desc"].HeaderText = "Description";
            dataGridView2.ClearSelection();
        }
        public void tablecall4() {
            string quer = "select intrans_ID,it_date,it_price,it_owner,it_desc,concat (Owner_fname,' ', owner_mname, ' ', owner_lname) as " +
                "fullname from in_transaction inner join owner  where it_owner = Owner_ID and it_trans_stat = 1";
            dataGridView2.DataSource = c.select(quer);
            dataGridView2.Columns["intrans_ID"].Visible = false;
            dataGridView2.Columns["it_owner"].Visible = false;
            dataGridView2.Columns["it_date"].HeaderText = "Date";
            dataGridView2.Columns["it_price"].HeaderText = "Amount";
            dataGridView2.Columns["fullname"].HeaderText = "Owner";
            dataGridView2.Columns["it_desc"].HeaderText = "Description";
            dataGridView2.ClearSelection();
        }
        public void tablecall4(string q)
        {
            string quer = "select intrans_ID,it_date,it_price,it_owner,it_desc,concat (Owner_fname,' ', owner_mname, ' ', owner_lname) as " +
                "fullname from in_transaction inner join owner  where it_owner = Owner_ID and it_trans_stat = 1 "+q;
            dataGridView2.DataSource = c.select(quer);
            dataGridView2.Columns["intrans_ID"].Visible = false;
            dataGridView2.Columns["it_owner"].Visible = false;
            dataGridView2.Columns["it_date"].HeaderText = "Date";
            dataGridView2.Columns["it_price"].HeaderText = "Amount";
            dataGridView2.Columns["fullname"].HeaderText = "Owner";
            dataGridView2.Columns["it_desc"].HeaderText = "Description";
            dataGridView2.ClearSelection();
        }
        public void tablecall5() {
            string quer = "select * from utelect_trans where uelect_trans_stat = 1 ";
            dataGridView2.DataSource = c.select(quer);

            dataGridView2.Columns["uelect_ID"].Visible = false;
            dataGridView2.Columns["uelect_trans_stat"].Visible = false;
            dataGridView2.Columns["uelect_void_date"].Visible = false;
            dataGridView2.Columns["uelect_void_loggedin"].Visible = false;
            dataGridView2.Columns["uelect_trans_resolved"].Visible = false;
            dataGridView2.Columns["uelect_date"].HeaderText = "Date";
            dataGridView2.Columns["uelect_bill_price"].HeaderText = "Bill Amount";
            dataGridView2.Columns["uelect_Excess"].HeaderText = "Excess";
            dataGridView2.Columns["uelect_rate"].HeaderText = "Rate";
            dataGridView2.ClearSelection();
        }
        public void tablecall5(string q)
        {
            string quer = "select * from utelect_trans where uelect_trans_stat = 1 "+q;
            dataGridView2.DataSource = c.select(quer);

            dataGridView2.Columns["uelect_ID"].Visible = false;
            dataGridView2.Columns["uelect_trans_stat"].Visible = false;
            dataGridView2.Columns["uelect_void_date"].Visible = false;
            dataGridView2.Columns["uelect_void_loggedin"].Visible = false;
            dataGridView2.Columns["uelect_trans_resolved"].Visible = false;
            dataGridView2.Columns["uelect_date"].HeaderText = "Date";
            dataGridView2.Columns["uelect_bill_price"].HeaderText = "Bill Amount";
            dataGridView2.Columns["uelect_Excess"].HeaderText = "Excess";
            dataGridView2.Columns["uelect_rate"].HeaderText = "Rate";
            dataGridView2.ClearSelection();
        }
        public void tablecall6() {
            string quer = "select * from utwat_trans where uwat_trans_stat = 1";
            dataGridView2.DataSource = c.select(quer);
            dataGridView2.Columns["uwat_ID"].Visible = false;
            dataGridView2.Columns["uwat_trans_stat"].Visible = false;
            dataGridView2.Columns["uwat_void_date"].Visible = false;
            dataGridView2.Columns["uwat_void_loggedin"].Visible = false;
            dataGridView2.Columns["uwat_trans_resolved"].Visible = false;
            dataGridView2.Columns["uwat_date"].HeaderText = "Date";
            dataGridView2.Columns["uwat_bill_price"].HeaderText = "Bill Amount";
            dataGridView2.Columns["uwat_Excess"].HeaderText = "Excess";
            dataGridView2.Columns["uwat_rate"].HeaderText = "Rate";
            dataGridView2.ClearSelection();
        }
        public void tablecall6(string q)
        {
            string quer = "select * from utwat_trans where uwat_trans_stat = 1 "+q;
            dataGridView2.DataSource = c.select(quer);
            dataGridView2.Columns["uwat_ID"].Visible = false;
            dataGridView2.Columns["uwat_trans_stat"].Visible = false;
            dataGridView2.Columns["uwat_void_date"].Visible = false;
            dataGridView2.Columns["uwat_void_loggedin"].Visible = false;
            dataGridView2.Columns["uwat_trans_resolved"].Visible = false;
            dataGridView2.Columns["uwat_date"].HeaderText = "Date";
            dataGridView2.Columns["uwat_bill_price"].HeaderText = "Bill Amount";
            dataGridView2.Columns["uwat_Excess"].HeaderText = "Excess";
            dataGridView2.Columns["uwat_rate"].HeaderText = "Rate";
            dataGridView2.ClearSelection();
        }

        public void tablecall7() {
            string quer = "select * from misc_transaction where mt_trans_stat = 2";
            dataGridView1.DataSource = c.select(quer);
            dataGridView1.Columns["mtrans_ID"].Visible = false;
            dataGridView1.Columns["mt_trans_stat"].Visible = false;
            dataGridView1.Columns["mt_void_date"].Visible = false;
            dataGridView1.Columns["mt_void_loggedin"].Visible = false;
            dataGridView1.Columns["mt_date"].HeaderText = "Date";
            dataGridView1.Columns["mt_price"].HeaderText = "Amount";
            dataGridView1.Columns["mt_type"].HeaderText = "Type";
            dataGridView1.Columns["mt_desc"].HeaderText = "Description";
            dataGridView1.ClearSelection();
        }
        public void tablecall7(string q)
        {
            string quer = "select * from misc_transaction where mt_trans_stat = 2 "+q;
            dataGridView1.DataSource = c.select(quer);
            dataGridView1.Columns["mtrans_ID"].Visible = false;
            dataGridView1.Columns["mt_trans_stat"].Visible = false;
            dataGridView1.Columns["mt_void_date"].Visible = false;
            dataGridView1.Columns["mt_void_loggedin"].Visible = false;
            dataGridView1.Columns["mt_date"].HeaderText = "Date";
            dataGridView1.Columns["mt_price"].HeaderText = "Amount";
            dataGridView1.Columns["mt_type"].HeaderText = "Type";
            dataGridView1.Columns["mt_desc"].HeaderText = "Description";
            dataGridView1.ClearSelection();
        }
        public void tablecall8()
        {
            string quer = "select intrans_ID,it_date,it_price,it_owner,it_desc,concat (Owner_fname,' ', owner_mname, ' ', owner_lname) as " +
                "fullname from in_transaction inner join owner  where it_owner = Owner_ID and it_trans_stat = 2";
            dataGridView1.DataSource = c.select(quer);
            dataGridView1.Columns["intrans_ID"].Visible = false;
            dataGridView1.Columns["it_owner"].Visible = false;
            dataGridView1.Columns["it_date"].HeaderText = "Date";
            dataGridView1.Columns["it_price"].HeaderText = "Amount";
            dataGridView1.Columns["fullname"].HeaderText = "Owner";
            dataGridView1.Columns["it_desc"].HeaderText = "Description";
            dataGridView1.ClearSelection();
        }
        public void tablecall8(string q)
        {
            string quer = "select intrans_ID,it_date,it_price,it_owner,it_desc,concat (Owner_fname,' ', owner_mname, ' ', owner_lname) as " +
                "fullname from in_transaction inner join owner  where it_owner = Owner_ID and it_trans_stat = 2 " + q;
            dataGridView1.DataSource = c.select(quer);
            dataGridView1.Columns["intrans_ID"].Visible = false;
            dataGridView1.Columns["it_owner"].Visible = false;
            dataGridView1.Columns["it_date"].HeaderText = "Date";
            dataGridView1.Columns["it_price"].HeaderText = "Amount";
            dataGridView1.Columns["fullname"].HeaderText = "Owner";
            dataGridView1.Columns["it_desc"].HeaderText = "Description";
            dataGridView1.ClearSelection();
        }
        public void tablecall9()
        {
            string quer = "select * from utelect_trans where uelect_trans_stat = 2 ";
            dataGridView1.DataSource = c.select(quer);

            dataGridView1.Columns["uelect_ID"].Visible = false;
            dataGridView1.Columns["uelect_trans_stat"].Visible = false;
            dataGridView1.Columns["uelect_void_date"].Visible = false;
            dataGridView1.Columns["uelect_void_loggedin"].Visible = false;
            dataGridView1.Columns["uelect_trans_resolved"].Visible = false;
            dataGridView1.Columns["uelect_date"].HeaderText = "Date";
            dataGridView1.Columns["uelect_bill_price"].HeaderText = "Bill Amount";
            dataGridView1.Columns["uelect_Excess"].HeaderText = "Excess";
            dataGridView1.Columns["uelect_rate"].HeaderText = "Rate";
            dataGridView1.ClearSelection();
        }
        public void tablecall9(string q)
        {
            string quer = "select * from utelect_trans where uelect_trans_stat = 2 " + q;
            dataGridView1.DataSource = c.select(quer);

            dataGridView1.Columns["uelect_ID"].Visible = false;
            dataGridView1.Columns["uelect_trans_stat"].Visible = false;
            dataGridView1.Columns["uelect_void_date"].Visible = false;
            dataGridView1.Columns["uelect_void_loggedin"].Visible = false;
            dataGridView1.Columns["uelect_trans_resolved"].Visible = false;
            dataGridView1.Columns["uelect_date"].HeaderText = "Date";
            dataGridView1.Columns["uelect_bill_price"].HeaderText = "Bill Amount";
            dataGridView1.Columns["uelect_Excess"].HeaderText = "Excess";
            dataGridView1.Columns["uelect_rate"].HeaderText = "Rate";
            dataGridView1.ClearSelection();
        }

      
        public void tablecall10()
        {
            string quer = "select * from utwat_trans where uwat_trans_stat = 2";
            dataGridView1.DataSource = c.select(quer);
            dataGridView1.Columns["uwat_ID"].Visible = false;
            dataGridView1.Columns["uwat_trans_stat"].Visible = false;
            dataGridView1.Columns["uwat_void_date"].Visible = false;
            dataGridView1.Columns["uwat_void_loggedin"].Visible = false;
            dataGridView1.Columns["uwat_trans_resolved"].Visible = false;
            dataGridView1.Columns["uwat_date"].HeaderText = "Date";
            dataGridView1.Columns["uwat_bill_price"].HeaderText = "Bill Amount";
            dataGridView1.Columns["uwat_Excess"].HeaderText = "Excess";
            dataGridView1.Columns["uwat_rate"].HeaderText = "Rate";
            dataGridView1.ClearSelection();
        }
        public void tablecall10(string q)
        {
            string quer = "select * from utwat_trans where uwat_trans_stat = 2 " + q;
            dataGridView1.DataSource = c.select(quer);
            dataGridView1.Columns["uwat_ID"].Visible = false;
            dataGridView1.Columns["uwat_trans_stat"].Visible = false;
            dataGridView1.Columns["uwat_void_date"].Visible = false;
            dataGridView1.Columns["uwat_void_loggedin"].Visible = false;
            dataGridView1.Columns["uwat_trans_resolved"].Visible = false;
            dataGridView1.Columns["uwat_date"].HeaderText = "Date";
            dataGridView1.Columns["uwat_bill_price"].HeaderText = "Bill Amount";
            dataGridView1.Columns["uwat_Excess"].HeaderText = "Excess";
            dataGridView1.Columns["uwat_rate"].HeaderText = "Rate";
            dataGridView1.ClearSelection();
        }
      


        private void button2_Click(object sender, EventArgs e)
        {
            ch = 1;
            tablecall();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ch = 2;
            tablecall2();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ch = 3;
            tablecall3();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ch = 4;
            tablecall4();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ch = 5;
            tablecall5();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ch = 6;
            tablecall6();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ch = 7;
            tablecall7();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ch = 8;
            tablecall8();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            ch = 9;
            tablecall9();
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            ch = 10;
            tablecall10();
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            String[,] date = new String[12, 2] {
                {"January","31"},{"Febuary","28"},{"March","31"},{"April","30"},{"May","31"},
                {"June","30"},{"July","31"}, {"August","31"}, {"September","30"},{"October","31"},
                {"November","30"}, {"December","31"}
            };
            string get = comboBox2.Text;
            int g = 31;
            for (int i = 0; i < 12; i++)
            {
                if (get == date[i, 0])
                {
                    g = i;
                }
            }
            comboBox3.Items.Clear();
            comboBox3.Items.Add("");
            for (int k = 1; k <= int.Parse(date[g, 1]); k++)
            {
                comboBox3.Items.Add(k);
            }
            if (comboBox1.Text != "")
            {
                if (int.Parse(comboBox1.Text) % 4 == 0 && comboBox2.Text == "Febuary")
                {

                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("");
                    for (int k = 1; k <= 29; k++)
                    {
                        comboBox3.Items.Add(k);
                    }
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int leap = int.Parse(comboBox1.Text) % 4;
            if (leap == 0 && comboBox2.Text == "Febuary")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("");
                for (int k = 1; k <= 29; k++)
                {
                    comboBox3.Items.Add(k);
                }
            }
            else if (leap > 0 && comboBox2.Text == "Febuary")
            {

                comboBox3.Items.Clear();
                comboBox3.Items.Add("");
                for (int k = 1; k <= 28; k++)
                {
                    comboBox3.Items.Add(k);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string y = comboBox1.Text;
            string m = comboBox2.Text;
            string d = comboBox3.Text;
            string date = "%%";
            int mo = 0;
            if (m == "January")
                mo = 1;
            else if (m == "Febuary")
                mo = 2;
            else if (m == "March")
                mo = 3;
            else if (m == "April")
                mo = 4;
            else if (m == "May")
                mo = 5;
            else if (m == "June")
                mo = 6;
            else if (m == "July")
                mo = 7;
            else if (m == "August")
                mo = 8;
            else if (m == "September")
                mo = 9;
            else if (m == "October")
                mo = 10;
            else if (m == "November")
                mo = 11;
            else if (m == "December")
                mo = 12;
            else
                mo = 0;
            if (m == "" && d == "" && y == "")
                tablecall();
            else if (m != "" && d != "" && y != "")
                date = y + "-" + mo + "-" + d;
            else if (m == "" && d == "")
                date = y + "-%";
            else if (y == "" && d == "")
                date = "%-" + mo + "-%";
            else if (y == "" && m == "")
                date = "-%" + d;
            else if (d == "")
                date = y + "-" + mo + "-%";
            else if (m == "")
                date = y + "-%% -" + d;
            else if (y == "")
                date = "%-" + mo + "-" + d;


            if (ch == 1)
            {
                string quer = "and rt_date_start like '"+date+"'";
                tablecall(quer);
            }
            else if (ch == 2)
            {
                string quer = "and bt_date like '" + date + "'";
                tablecall2(quer);
            }
            else if (ch == 3)
            {
                string quer = "and mt_date like '" + date + "'";
                tablecall3(quer);
            }
            else if (ch == 4)
            {
                string quer = "and it_date like '" + date + "'";
                tablecall4(quer);
            }
            else if (ch == 5)
            {
                string quer = "and uelect_date like '" + date + "'";
                tablecall5(quer);
            }
            else if (ch == 6)
            {
                string quer = "and uwat_date like '" + date + "'";
                tablecall6(quer);
            }
            else if (ch == 7)
            {
                string quer = "and mt_date like '" + date + "'";
                tablecall7(quer);
            }
            else if (ch == 8)
            {
                string quer = "and it_date like '" + date + "'";
                tablecall8(quer);
            }
            else if (ch == 9)
            {
                string quer = "and uelect_date like '" + date + "'";
                tablecall9(quer);
            }
            else if (ch == 10)
            {
                string quer = "and uwat_date like '" + date + "'";
                tablecall10(quer);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                ch = 1;
                tablecall();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                ch = 7;
                tablecall7();
            }
        }
    }
}
