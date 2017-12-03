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
   
    public partial class UserControl3 : UserControl
    {
        MySqlConnection conn;
        Class1 c = new Class1();
        public int a;

        private static UserControl3 _instance;

        public static UserControl3 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControl3();
                return _instance;
            }
        }
        public UserControl3()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=ba_db;uid=root; pwd =root; ");
            
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            tablecall();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string contac = textBox3.Text;
            string add = textBox2.Text;
            if (name == "" || contac =="" || add =="") {
                label3.Text = "Please Input the required fields";
            }
            else {
                string query = "insert into profile values(NULL,'" + name + "','" + add + "','" + contac + "',0)";
                c.insert(query);
                label3.Text = "";
                tablecall();
            }
        }

        public void tablecall()
        {
            String query = "select * from profile";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string contac = textBox3.Text;
            string add = textBox2.Text;

            if (name == "" || contac == "" || add == "")
            {
                label3.Text = "Please Input the required fields";
            }
            else {
                string quer = "Update profile set Profile_name = '" + name + "', Profile_address = '" + add + "', Profile_cpnumber = '" + contac + "' where User_ID ="+a+"";
                c.insert(quer);
                tablecall();
                label3.Text = "";
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            a = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["User_id"].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Profile_name"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Profile_cpnumber"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Profile_Address"].Value.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
      
                string query = "delete from profile where User_id = " + a + "";
                c.insert(query);
                tablecall();
            
        }
    }
}
