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
            String query = "SELECT * FROM room inner join owner inner join room_classification where Owner_ID = Owner_Owner_ID and Room_classification_classification_ID = classification_ID";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["Owner_Owner_ID"].Visible = false;
            dataGridView1.Columns["Room_classification_classification_ID"].Visible = false;
            dataGridView1.Columns["Owner_ID"].Visible = false;
            dataGridView1.Columns["username"].Visible = false;
            dataGridView1.Columns["password"].Visible = false;
            dataGridView1.Columns["remarks"].Visible = false;
            dataGridView1.Columns["classification_ID"].Visible = false;
            dataGridView1.Columns["RC_Rate"].Visible = false;
        }
        private void UCRoomContent_Load(object sender, EventArgs e)
        {
           

            String query1 = "select owner_name from owner";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);
            foreach (DataRow row in dt1.Rows)
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
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox3.Text != "" && comboBox1.Text != "") {
                string desc = textBox1.Text;
                int id = int.Parse(textBox2.Text);
                string owner = comboBox3.Text;
                
                    String query = "select owner_id from owner where owner_name= '" + owner + "'";
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
                string query1 = "Insert into Room values(" + id + ", " + idr + ",'" + desc + "', " + type + ")";
                c.insert(query1);
                MessageBox.Show("Data Added!", "Complete");
                textBox1.Text = "";
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

                String query = "select owner_id from owner where owner_name= '" + owner + "'";
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
                string query1 = "update Room set room_ID = " + id + ", Owner_Owner_ID = " + idr + ", room_desc = '" + desc + "'," +
                    " Room_classification_classification_ID = " + type + " where room_ID = "+id1+" ";
                c.insert(query1);
                MessageBox.Show("Data Updated!", "Complete");
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
                string query = "SELECT * FROM room inner join owner inner join room_classification where Owner_ID = Owner_Owner_ID and Room_classification_classification_ID = classification_ID and Room_ID = "+id1+"";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                string name = dt.Rows[0]["Owner_name"].ToString(); 
                string day = dt.Rows[0]["room_time"].ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["room_ID"].Value.ToString();
                comboBox4.Text = name;
                comboBox2.Text = day;
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["room_desc"].Value.ToString();

            }
        }
    }
}
