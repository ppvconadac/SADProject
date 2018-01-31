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
    public partial class UCRoomRContent : UserControl
    {
        public int id;
        public int id1;
        Class1 c1 = new Class1();
        private static UCRoomRContent _instance;

        public static UCRoomRContent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCRoomRContent();
                return _instance;
            }
        }

      

        public UCRoomRContent()
        {
            InitializeComponent();
            tablecall();
            tablecall2();
            tablecall3();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public void tablecall() {
            string quer = "select profile_name, profile_fname, profile_mname, profile_lname, user_id from profile";
            dataGridView1.DataSource = c1.select(quer);
            dataGridView1.Columns["User_ID"].Visible = false;
        }
        public void tablecall2()
        {
            string quer = "select room_number, room_id from room where room_status  = 'Available'";
            dataGridView3.DataSource = c1.select(quer);
            dataGridView3.Columns["room_id"].Visible = false;
        }
        public void tablecall3()
        {
            string quer = "select room_number, profile_name, CONCAT(profile_fname, profile_mname, profile_lname) as Name" +
                ", re_date from reservation inner join profile inner join room where Profile_user_ID = user_id AND Room_Room_ID = room_id";
            dataGridView2.DataSource = c1.select(quer);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells["profile_name"].Value.ToString();
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["user_id"].Value.ToString());
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtRoom.Text = dataGridView3.Rows[e.RowIndex].Cells["room_number"].Value.ToString();
                id1 = int.Parse(dataGridView3.Rows[e.RowIndex].Cells["room_id"].Value.ToString());
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DateTime check;
            if (txtName.Text != "" && txtRoom.Text != "") {
                if (DateTime.TryParse(dateTimePicker1.Text, out check) && check < DateTime.Now)
                {
                    MessageBox.Show("Date has passed!", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  
                }
                else {
                    string quer = "insert into reservation values(NULL, '" + dateTimePicker1.Text + "', " + id + ", " + id1 + "  )";
                    c1.insert(quer);
                    string quer2 = "update room set room_status = 'Reserved' where room_id = "+id1+"" ;
                    c1.insert(quer2);
                    MessageBox.Show("Data Has Been Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Text = "";
                    txtRoom.Text = "";
                    tablecall();
                    tablecall2();
                    tablecall3();

                }
            }

        }
    }
}
