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
            String query = "select owner_name from owner";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataSet dt = new DataSet();

            onload();
        }

        public void onload()
        {


        }

        private void UCRoomContent_Load(object sender, EventArgs e)
        {
            String query = "select * from room";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataSet dt = new DataSet();
            adp.Fill(dt);
            comboBox3.DataSource = dt.Tables[0];
            comboBox3.DisplayMember = "Owner_name";
            comboBox3.ValueMember = "Owner_ID";
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




        private void button1_Click(object sender, EventArgs e)
        {
            // desc- tb1 id tb2 own- cb3 type- 4
      

        }


        private void button2_Click(object sender, EventArgs e)
        {

        }




    }
}
