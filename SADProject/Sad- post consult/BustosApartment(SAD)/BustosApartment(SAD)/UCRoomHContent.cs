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
    public partial class UCRoomHContent : UserControl
    {
        private static UCRoomHContent _instance;
        Class1 c1 = new Class1();
        public string quer;

        public static UCRoomHContent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCRoomHContent();
                return _instance;
            }
        }

        public UCRoomHContent()
        {
            InitializeComponent();
            dates();
            tablecall();
           // comboBox1.Items.Add(2016);
        }
        public void tablecall() {
            quer = "select reservation_id, room_number, profile_name, CONCAT(profile_fname, profile_mname, profile_lname) as Name" +
              ", re_date, re_status from reservation inner join profile inner join room where Profile_user_ID = user_id AND Room_Room_ID = room_id AND re_date < curdate() AND re_status = 0";
            dataGridView2.DataSource = c1.select(quer);
            dataGridView2.Columns["re_status"].Visible = false;


        }
        public void dates() {
            DateTime d = DateTime.Now;
            int baseyear = 2018;
            int yeargap = d.Year - (baseyear-1);
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
        private void button1_Click(object sender, EventArgs e)
        {
            string y = comboBox1.Text;
            string m = comboBox2.Text;
            string d = comboBox3.Text;
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
            if (m !="" && d!=""&& y !="") {
                quer = "select reservation_id, room_number, profile_name, CONCAT(profile_fname, profile_mname, profile_lname) as Name" +
             ", re_date, re_status from reservation inner join profile inner join room where Profile_user_ID = user_id AND Room_Room_ID = room_id AND  re_date like '" + y + "-"+mo+"-"+d+"'  AND re_date < curdate() AND re_status = 0";
                dataGridView2.DataSource = c1.select(quer);
                dataGridView2.Columns["re_status"].Visible = false;
            }
            else if (m =="" && d =="") {
                quer = "select reservation_id, room_number, profile_name, CONCAT(profile_fname, profile_mname, profile_lname) as Name" +
              ", re_date, re_status from reservation inner join profile inner join room where Profile_user_ID = user_id AND Room_Room_ID = room_id AND  re_date like '" + y+ "-%'  AND re_date < curdate() AND re_status = 0";
                dataGridView2.DataSource = c1.select(quer);
                dataGridView2.Columns["re_status"].Visible = false;
            }
            else if (y=="" && d=="") {
                quer = "select reservation_id, room_number, profile_name, CONCAT(profile_fname, profile_mname, profile_lname) as Name" +
               ", re_date, re_status from reservation inner join profile inner join room where Profile_user_ID = user_id AND Room_Room_ID = room_id AND  re_date like '%-" + mo + "-%' AND re_date < curdate() AND re_status = 0";
                dataGridView2.DataSource = c1.select(quer);
                dataGridView2.Columns["re_status"].Visible = false;
            }
            else if (y=="" && m=="") {
                quer = "select reservation_id, room_number, profile_name, CONCAT(profile_fname, profile_mname, profile_lname) as Name" +
              ", re_date, re_status from reservation inner join profile inner join room where Profile_user_ID = user_id AND Room_Room_ID = room_id AND re_date like '-%" + d + "' AND re_date < curdate() AND re_status = 0";
                dataGridView2.DataSource = c1.select(quer);
                dataGridView2.Columns["re_status"].Visible = false;
            }
            else if (d=="") {
                quer = "select reservation_id, room_number, profile_name, CONCAT(profile_fname, profile_mname, profile_lname) as Name" +
               ", re_date, re_status from reservation inner join profile inner join room where Profile_user_ID = user_id AND Room_Room_ID = room_id AND  re_date like '" + y + "-"+mo+ "-%' AND re_date < curdate() AND re_status = 0";
                dataGridView2.DataSource = c1.select(quer);
                dataGridView2.Columns["re_status"].Visible = false;
            }
            else if (m=="") {
                quer = "select reservation_id, room_number, profile_name, CONCAT(profile_fname, profile_mname, profile_lname) as Name" +
              ", re_date, re_status from reservation inner join profile inner join room where Profile_user_ID = user_id AND Room_Room_ID = room_id AND  re_date like '" + y + "-%%-" + d + "' AND re_date < curdate() AND re_status = 0";
                dataGridView2.DataSource = c1.select(quer);
                dataGridView2.Columns["re_status"].Visible = false;
            }
            else if (y=="") {
                quer = "select reservation_id, room_number, profile_name, CONCAT(profile_fname, profile_mname, profile_lname) as Name" +
                 ", re_date, re_status from reservation inner join profile inner join room where Profile_user_ID = user_id AND Room_Room_ID = room_id AND re_date like '%-" + mo + "-" + d + "' AND re_date < curdate() AND re_status = 0 ";
                dataGridView2.DataSource = c1.select(quer);
                dataGridView2.Columns["re_status"].Visible = false;
            }
            else {
                tablecall();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
            for (int i = 0; i< 12; i++) {
                if (get == date[i, 0])
                {
                    g = i;
                }           
            }
            comboBox3.Items.Clear();
            comboBox3.Items.Add("");
            for (int k = 1; k <= int.Parse(date[g,1]); k++) {
                comboBox3.Items.Add(k);
            }
            if (comboBox1.Text != "") {
                if (int.Parse(comboBox1.Text) % 4 == 0 && comboBox2.Text == "Febuary") {

                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("");
                    for (int k = 1; k <= 29; k++)
                    {
                        comboBox3.Items.Add(k);
                    }
                }
            }

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
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
            else if(leap > 0 && comboBox2.Text == "Febuary") {

                comboBox3.Items.Clear();
                comboBox3.Items.Add("");
                for (int k = 1; k <= 28; k++)
                {
                    comboBox3.Items.Add(k);
                }
            }

        }
    }
}
