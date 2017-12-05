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
    public partial class UserControl4 : UserControl
    {
        MySqlConnection conn;
        Class1 c = new Class1();
        public int a;
        public string name;
        UserControl8 u8 = new UserControl8();
        private static UserControl4 _instance;

        public static UserControl4 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControl4();
                return _instance;
            }
        }
        public UserControl4()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=ba_db;uid=root; pwd =root; ");
            panel2.Controls.Add(UserControl8.Instance);
            UserControl8.Instance.Dock = DockStyle.Fill;
            UserControl8.Instance.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            tablecall();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                a = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["User_id"].Value.ToString());
                name = dataGridView1.Rows[e.RowIndex].Cells["profile_name"].Value.ToString();
                u8.acceptor(a, name); 
        

            }
        }
    }
}
