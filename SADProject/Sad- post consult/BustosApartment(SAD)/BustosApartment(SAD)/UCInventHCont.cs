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
    public partial class UCInventHCont : UserControl
    {
        private static UCInventHCont _instance;
        public int ch = 1;
        Class1 c1 = new Class1();
        public string quer = "";
        public UCInventHCont()
        {
            InitializeComponent();
            tablecall();
            tablecall4();
            dates();
        }
        public static UCInventHCont Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCInventHCont();
                return _instance;
            }
        }
        public void tablecall() {
            quer = "select bitem_name, bitem_status,concat(profile_fname,profile_mname,profile_lname) as full" +
                "_name, btrans_id,bt_date,bt_pay_method,bt_pay_status, bitem_dmg_status,bt_trans_stat,borrowable_item_bitem_ID,bitem_ID,User_id,Profile_user_ID," +
                "bitem_rate from borrowable_item inner join bitem_transaction inner join profile where bitem_id = borrowable_item_bitem_ID and user_id = profile_user_id and bt_trans_stat =1";
            call(quer);
            dataGridView2.Columns["bitem_ID"].Visible = false;
            dataGridView2.Columns["User_id"].Visible = false;
            dataGridView2.Columns["bitem_status"].Visible = false;
            dataGridView2.Columns["Profile_user_ID"].Visible = false;
            dataGridView2.Columns["borrowable_item_bitem_ID"].Visible = false;
            dataGridView2.Columns["bt_trans_stat"].Visible = false;
            dataGridView2.Columns["btrans_id"].Visible = false;
            dataGridView2.Columns["bitem_rate"].Visible = false;
            dataGridView2.ClearSelection();
        }
        public void tablecall2() {
            quer = "select ntrans_ID, nt_date, nitem_name, nitem_transaction.nt_quantity, nonborrowable_item_nitem_ID,nt_type from nonborrowable_item inner " +
              "join nitem_transaction where nitem_ID = nonborrowable_item_nitem_ID and nt_trans_stat =1";
            call(quer);
            dataGridView2.Columns["ntrans_ID"].Visible = false;
            dataGridView2.Columns["nonborrowable_item_nitem_ID"].Visible = false;
            dataGridView2.ClearSelection();

        }
        public void tablecall3() {
            quer = "select bdtrans_ID, bdt_date, bdt_price, concat(profile_fname,' ',profile_mname,' ',profile_lname) as full_name, bitem_name, " +
                "bdt_pay_method, bdt_pay_status from bitem_damage_transaction inner join profile inner join borrowable_item where Profile_user_ID = user_ID and borrowable_item_bitem_ID " +
                "= bitem_ID and bdt_trans_stat =1";
            call(quer);
            dataGridView2.Columns["bdtrans_ID"].Visible = false;
            dataGridView2.ClearSelection();

        }
        public void tablecall4() {

            quer = "select bitem_name, bitem_status,concat(profile_fname,profile_mname,profile_lname) as full" +
               "_name, btrans_id,bt_date, bt_archive_date, bt_archive_loggedin, bt_pay_method,bt_pay_status, bitem_dmg_status,bt_trans_stat,borrowable_item_bitem_ID,bitem_ID,User_id,Profile_user_ID," +
               "bitem_rate from borrowable_item inner join bitem_transaction inner join profile where bitem_id = borrowable_item_bitem_ID and user_id = profile_user_id and bt_trans_stat =2";
            call2(quer);
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
        public void tablecall5() {
            quer = "select ntrans_ID, nt_date, nitem_name, nitem_transaction.nt_quantity, nitem_transaction.nt_archive_date, " +
                "nitem_transaction.nt_archived_loggedin , nonborrowable_item_nitem_ID, nt_type from nonborrowable_item inner " +
            "join nitem_transaction where nitem_ID = nonborrowable_item_nitem_ID and nt_trans_stat =2";
            call2(quer);
            dataGridView1.Columns["ntrans_ID"].Visible = false;
            dataGridView1.Columns["nonborrowable_item_nitem_ID"].Visible = false;
            dataGridView1.ClearSelection();
        }
        public void tablecall6() {
            quer = "select * from nonborrowable_item where nitem_stat = 1";
            dataGridView1.DataSource = c1.select(quer);
            dataGridView1.Columns["nitem_ID"].Visible = false;
            dataGridView1.Columns["nt_quantity"].Visible = false;
            dataGridView1.Columns["nitem_stat"].Visible = false;
            dataGridView1.ClearSelection();
        }
        public void call(string quer)
        {
            dataGridView2.DataSource = c1.select(quer);
        }
        public void call2(string quer)
        {
            dataGridView1.DataSource = c1.select(quer);
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

        private void UCInventHCont_Load(object sender, EventArgs e)
        {
            dataGridView2.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {//lending transac
            ch = 1;
            tablecall();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ch = 2;
            tablecall2(); ;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ch = 3;
            tablecall3();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ch = 4;
            tablecall4();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ch = 5;
            tablecall5();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ch = 6;
            tablecall6();
        }

        private void comboBox2_TextChanged(object sender, EventArgs e) //leap year
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
            try
            {
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
            catch{
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
                date = "%-"+ mo + "-" + d ;


            if (ch == 1)
            {
                quer = "select bitem_name, bitem_status,concat(profile_fname,profile_mname,profile_lname) as full" +
               "_name, btrans_id,bt_date,bt_pay_method,bt_pay_status, bitem_dmg_status,bt_trans_stat,borrowable_item_bitem_ID,bitem_ID,User_id,Profile_user_ID," +
               "bitem_rate from borrowable_item inner join bitem_transaction inner join profile where bitem_id = borrowable_item_bitem_ID and user_id = profile_user_id and bt_trans_stat =1 and bt_date like '" + date + "'";
                call(quer);
            }
            else if (ch == 2)
            {
                quer = "select ntrans_ID, nt_date, nitem_name, nitem_transaction.nt_quantity, nonborrowable_item_nitem_ID,nt_type from nonborrowable_item inner " +
           "join nitem_transaction where nitem_ID = nonborrowable_item_nitem_ID and nt_trans_stat =1 and nt_date like '" + date + "'";
                call(quer);
            }
            else if (ch == 3)
            {
                quer = "select bdtrans_ID, bdt_date, bdt_price, concat(profile_fname,' ',profile_mname,' ',profile_lname) as full_name, bitem_name, " +
                "bdt_pay_method, bdt_pay_status from bitem_damage_transaction inner join profile inner join borrowable_item where Profile_user_ID = user_ID and borrowable_item_bitem_ID " +
                "= bitem_ID and bdt_trans_stat =1 and bdt_date like '" + date + "'";
                call(quer);
            }
            else if (ch == 5)
            {
                quer = "select ntrans_ID, nt_date, nitem_name, nitem_transaction.nt_quantity, nitem_transaction.nt_archive_date, " +
                "nitem_transaction.nt_archived_loggedin , nonborrowable_item_nitem_ID, nt_type from nonborrowable_item inner " +
            "join nitem_transaction where nitem_ID = nonborrowable_item_nitem_ID and nt_trans_stat =2 and nitem_transaction.nt_archive_date like '" + date + "'";
                call2(quer);
            }
            else if (ch == 4)
            {
                quer = "select bitem_name, bitem_status,concat(profile_fname,profile_mname,profile_lname) as full" +
               "_name, btrans_id,bt_date, bt_archive_date, bt_archive_loggedin, bt_pay_method,bt_pay_status, bitem_dmg_status,bt_trans_stat,borrowable_item_bitem_ID,bitem_ID,User_id,Profile_user_ID," +
               "bitem_rate from borrowable_item inner join bitem_transaction inner join profile where bitem_id = borrowable_item_bitem_ID and user_id = profile_user_id and bt_trans_stat =2 and  bt_archive_date like '" + date + "' ";
                call(quer);
            }
            else if (ch == 6) {
                quer = "select * from nonborrowable_item where nitem_stat = 1 and nt_archive_date like '"+date+"'";
                call2(quer);
            }

            
        }
    }
}
