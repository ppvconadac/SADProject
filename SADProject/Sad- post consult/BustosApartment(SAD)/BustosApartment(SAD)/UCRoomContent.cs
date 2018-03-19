using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BustosApartment_SAD_
{
    public partial class UCRoomContent : UserControl
    {
        MySqlConnection conn;
        Class1 c = new Class1();
        public int id1;
        private static UCRoomContent _instance;

        public static UCRoomContent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCRoomContent();
                return _instance;
            }
        }
        public UCRoomContent()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=ba_db;uid=root; pwd =root; ");
            tablecall();
            onload();
            dates();
            tablecall2();
        }

        public void onload()
        {
            

        }
        public void tablecall() {
            String query = "SELECT room_id, room_number, room_desc, owner_fname, room_time, rc_rate FROM room inner join owner inner join room_classification " +
                "where Owner_ID = Owner_Owner_ID and Room_classification_classification_ID = classification_ID";
            dataGridView1.DataSource = c.select(query);
            dataGridView1.Columns["room_ID"].Visible = false;
            dataGridView1.ClearSelection();
        }
        private void UCRoomContent_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();

            String query1 = "select owner_fname from owner";
            foreach (DataRow row in c.select(query1).Rows)
            {
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    comboBox3.Items.Add(row.ItemArray[0].ToString());
                    comboBox4.Items.Add(row.ItemArray[0].ToString());
                }
            }


        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void tablecall2() {
            DateTime d = DateTime.Now;
            int a = d.Month - 1;
            string ym = d.Year.ToString() + "-" + a.ToString()+ "-%";
            try
            {
                string quer = "SELECT profile_name, rt_date_start, rt_date_expire from profile inner join room_transaction where user_ID = profile_user_ID " 
                    + "and rt_type != 'Extend' and rt_type != 'Archive' and rt_date_start like '"+ym+"' and room_room_id = "+id1+"";
                dataGridView2.DataSource = c.select(quer);
            }
            catch {
            }
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
          
            comboBox5.Items.Add("");
            comboBox6.Items.Add("");
            for (int i = 0; yeargap > i; i++)
            {
                comboBox5.Items.Add(baseyear);
                baseyear++;
            }
            for (int j = 0; j < 12; j++)
            {
                comboBox6.Items.Add(date[j, 0]);
            }
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // desc- tb1 id tb2 own- cb3 type- 4
            if (txtDesc.Text != "" && textBox2.Text != "" && comboBox3.Text != "" && comboBox1.Text != "") {
                string desc = txtDesc.Text;
                int id = int.Parse(textBox2.Text);
                string owner = comboBox3.Text;
                
                    String query = "select owner_id from owner where owner_fname= '" + owner + "'";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    conn.Close();
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                
                string idr = dt.Rows[0]["Owner_ID"].ToString();
                int type;
                if (comboBox1.Text == "Daily")
                    type = 1;
                else
                    type = 2;
                string query1 = "Insert into Room values( NULL, " + idr + ",'" + desc + "', " + type + ",'"+ id +"', 'Available')";
                c.insert(query1);
                MessageBox.Show("Data Has Been Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDesc.Text = "";
                textBox2.Text = "";
                comboBox3.Text = "";
                comboBox1.Text = "";
                tablecall();

            }
            else{
                label17.Text = "Incomplete Input: Please Fill the Form";
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox6.Text != "" && comboBox2.Text != "" && comboBox4.Text != "")
            {
                string desc = textBox3.Text;
                
                int id = int.Parse(textBox6.Text);
                string owner = comboBox4.Text;

                String query = "select owner_id from owner where owner_fname= '" + owner + "'";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                string idr = dt.Rows[0]["Owner_ID"].ToString();
                int type;
                if (comboBox2.Text == "Daily")
                    type = 1;
                else
                    type = 2;
                string query1 = "update Room set room_number = " + id + ", Owner_Owner_ID = " + idr + ", room_desc = '" + desc + "'," +
                    " Room_classification_classification_ID = " + type + " where room_ID = "+id1+" ";
                c.insert(query1);
                MessageBox.Show("Data Has Been Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox6.Text = "";
                textBox3.Text = "";
                comboBox2.Text = "";
                comboBox4.Text = "";
                tablecall();

            }
            else
            {
                label18.Text = "Incomplete Input: Please Fill the Form";
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        { //tb6  cb4 cb2  tb3
            if (e.RowIndex > -1) {

                id1 = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["room_id"].Value.ToString());
                string query = "SELECT room_number, Room_classification_classification_ID, Owner_Owner_ID, room_desc, owner_fname, room_time, rc_rate FROM room inner join owner inner join room_classification where Owner_ID = Owner_Owner_ID and Room_classification_classification_ID = classification_ID and Room_ID = " + id1+"";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                string name = dt.Rows[0]["Owner_fname"].ToString(); 
                string day = dt.Rows[0]["room_time"].ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["room_number"].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["room_number"].Value.ToString();
                textBox4.Text = dt.Rows[0]["rc_rate"].ToString();
                comboBox4.Text = name;
                comboBox2.Text = day;
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["room_desc"].Value.ToString();
                label15.Text = dt.Rows[0]["room_number"].ToString();
                tablecall2();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int pr = 0;
            try
            {
                 pr = int.Parse(textBox4.Text);
            }
            catch {
                MessageBox.Show("Invalid input!", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            string quer = "select room_classification_classification_id from room where room_number = " + textBox1.Text + "";
            DataTable d = c.select(quer);
            if (d.Rows.Count == 0)
            {
                MessageBox.Show("please select a row!", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                string up = "update room_classification set rc_rate = "+pr+" where" +
                    " classification_id = "+d.Rows[0]["room_classification_classification_id"].ToString() +"";
                c.insert(up);
                MessageBox.Show("Data Has Been Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            tablecall();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int mo;
            string m = comboBox6.Text;
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

            string date = "%%";
            if (comboBox5.Text == "")
                date = "%-" + mo + "-%";
            else if (comboBox6.Text ==""){
                date = comboBox5.Text + "-%";
            }

           
            string quer = "SELECT profile_name, rt_date_start, rt_date_expire from profile inner join room_transaction where user_ID = profile_user_ID "
                     + "and rt_type != 'Extend' and rt_type != 'Archive' and rt_date_start like '" + date + "' and room_room_id = " + id1 + "";
            dataGridView2.DataSource = c.select(quer);
        }
    }
}
