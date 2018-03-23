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
           
 
        }

        public void onload()
        {
            

        }
        public void tablecall() {
            String query = "SELECT room_id, room_number, room_desc, concat (owner_fname, ' ' , owner_mname, ' ', owner_lname) as full_name, room_time, rc_rate, room_elecreading, room_watreading FROM room inner join owner inner join room_classification " +
                "where Owner_ID = Owner_Owner_ID and Room_classification_classification_ID = classification_ID";
            dataGridView1.DataSource = c.select(query);
            dataGridView1.Columns["room_ID"].Visible = false;
            dataGridView1.Columns["room_number"].HeaderText = "Room Number";
            dataGridView1.Columns["room_desc"].HeaderText = "Description";
            dataGridView1.Columns["full_name"].HeaderText = "Owner";
            dataGridView1.Columns["room_time"].HeaderText = "Room Type";
            dataGridView1.Columns["rc_rate"].HeaderText = "Rate";
            dataGridView1.Columns["room_elecreading"].Visible = false;
            dataGridView1.Columns["room_watreading"].Visible = false;
            dataGridView1.ClearSelection();
        }
        private void UCRoomContent_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();

            String query1 = "select owner_fname from owner where emp_status = 1";
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

       

        private void button1_Click(object sender, EventArgs e)
        {
            // desc- tb1 id tb2 own- cb3 type- 4
            if (txtDesc.Text != "" && textBox2.Text != "" && comboBox3.Text != "" && comboBox1.Text != "") {
                string quer2 = "select * from room where Room_number = '"+textBox2.Text+"'";
                DataTable d = c.select(quer2);
                if (d.Rows.Count > 0)
                {
                    MessageBox.Show("Room Number already taken !", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
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
                    string query1 = "Insert into Room values( NULL, " + idr + ",'" + desc + "', " + type + ",'" + id + "', 'Available', NULL,NULL)";
                    c.insert(query1);
                    MessageBox.Show("Data Has Been Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDesc.Text = "";
                    textBox2.Text = "";
                    comboBox3.Text = "";
                    comboBox1.Text = "";
                    tablecall();

                }
            }
                
            else{
                label17.Text = "Incomplete Input: Please Fill the Form";
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox6.Text != "" && comboBox2.Text != "" && comboBox4.Text != "")
            {
                string quer2 = "select * from room where Room_number = '" + textBox6.Text + "' and Room_ID != "+id1+"";
                DataTable d = c.select(quer2);
                if (d.Rows.Count > 0)
                {
                    MessageBox.Show("Room Number already taken !", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
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
                        " Room_classification_classification_ID = " + type + " where room_ID = " + id1 + " ";
                    c.insert(query1);
                    MessageBox.Show("Data Has Been Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox6.Text = "";
                    textBox3.Text = "";
                    comboBox2.Text = "";
                    comboBox4.Text = "";
                    tablecall();
                }
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
                comboBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["room_time"].Value.ToString();
                textBox4.Text = dt.Rows[0]["rc_rate"].ToString();
                comboBox4.Text = name;
                comboBox2.Text = day;
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["room_desc"].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["room_elecreading"].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["room_watreading"].Value.ToString();
               
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
           double pr;
           if (!double.TryParse(textBox4.Text, out pr))
            {
                MessageBox.Show("Invalid format !", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Text = "";
            }
            else
            {
                string quer = "select room_classification_classification_id from room where Room_ID = " + id1 + "";
                DataTable d = c.select(quer);
                if (d.Rows.Count == 0)
                {
                    MessageBox.Show("please select a row!", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string up = "update room_classification set rc_rate = " + pr + " where" +
                        " classification_id = " + d.Rows[0]["room_classification_classification_id"].ToString() + "";
                    c.insert(up);
                    MessageBox.Show("Data Has Been Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                tablecall();
            }
            
            
           
            
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (id1 == 0)
            {
                MessageBox.Show("No entry selected", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!double.TryParse(textBox7.Text, out double val))
            {
                MessageBox.Show("Invalid format !", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox7.Text = "";
            }
            else if (!double.TryParse(textBox1.Text, out val))
            {
                MessageBox.Show("Invalid format !", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = "";
            }
            else
            {
                string quer = "update room set room_elecreading = '" + textBox7.Text + "', room_watreading = '" + textBox1.Text + "' where Room_ID = " + id1 + "";
                c.insert(quer);
                MessageBox.Show("Data Has Been Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tablecall();
            }

        }
    }
}
