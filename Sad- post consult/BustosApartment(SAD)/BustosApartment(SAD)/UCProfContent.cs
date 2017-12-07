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

    public partial class UCProfContent : UserControl
    {
        MySqlConnection conn;
        Class1 c = new Class1();
        public int a;

        private static UCProfContent _instance;

        public static UCProfContent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCProfContent();
                return _instance;
            }
        }
        public UCProfContent()
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
            dataGridView1.Columns["User_id"].Visible = false;
            dataGridView1.Columns["Profile_balance"].Visible = false;
            dataGridView1.Columns["Profile_name"].HeaderText = "Name";
            dataGridView1.Columns["Profile_cpnumber"].HeaderText = "Contact";
            dataGridView1.Columns["Profile_Address"].HeaderText = "Address";
        }

      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
            }
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string quer = "select * from profile where profile_name like '%" + textBox5.Text + "%'";
            MySqlCommand comm = new MySqlCommand(quer, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}