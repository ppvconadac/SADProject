using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BustosApartment_SAD_
{
    public partial class FmLogin : Form
    {
        MySqlConnection conn;
        public static String name;
        public static String id;

        public FmLogin()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=ba_db;uid=root; pwd =root; ");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String password = textBox2.Text;
            String query = "select * from owner where username = '" + username + "' and password='" + password + "'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                FmMain nextform = new FmMain();
                name = dt.Rows[0]["Owner_fname"].ToString() +" "+dt.Rows[0]["Owner_lname"].ToString();
                id = dt.Rows[0]["Owner_ID"].ToString();
                MessageBox.Show("Welcome " + name);
                nextform.Show();
                nextform.prevform = this;
                this.Hide();

            }
            else
            {
                label5.Text = "Wrong Username or Password Try again";

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AcceptButton = LoginButton;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}