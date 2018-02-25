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

        public void tablecall3()
        {
            string quer = "select reservation_id, room_number, profile_name, CONCAT(profile_fname, profile_mname, profile_lname) as Name" +
                ", re_date, re_status from reservation inner join profile inner join room where Profile_user_ID = user_id AND Room_Room_ID = room_id AND re_date > curdate() AND re_status = 0";
       
          
            dataGridView2.DataSource = c1.select(quer);
            dataGridView2.Columns["re_status"].Visible = false;
    
        
            

        }
        public void tablecall2() {
            string quer = "select reservation_id, room_number, profile_name, CONCAT(profile_fname, profile_mname, profile_lname) as Name" +
             ", re_date, re_status from reservation inner join profile inner join room where Profile_user_ID = user_id AND Room_Room_ID = room_id AND re_date < curdate() AND re_status = 0";
            dataGridView2.DataSource = c1.select(quer);
            dataGridView2.Columns["re_status"].Visible = false;

        }
        public void tablecall() {
            string quer = "select reservation_id, room_number, profile_name, CONCAT(profile_fname, profile_mname, profile_lname) as Name" +
            ", re_date, re_status from reservation inner join profile inner join room where Profile_user_ID = user_id  AND Room_Room_ID = room_id AND re_status = 1";
            dataGridView2.DataSource = c1.select(quer);
            dataGridView2.Columns["re_status"].Visible = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
          

              

        }

        private void UCRoomRContent_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DateTime a = DateTime.Now;
           
            DialogResult dialogResult = MessageBox.Show("Are you sure to Archive reservation?", "Waning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes) {
                string quer = "update reservation set re_status = 1 and re_ardate = '"+DateTime.Now.ToString("yyy-M-d")+"'  where reservation_id = " + id1 + " ";
                c1.insert(quer);
                tablecall3();
                
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id1 = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["reservation_id"].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Archived")
            {
                tablecall();
                button3.Text = "Current Reservation List";
                label5.Text = "ARCHIVED DATA";
                label5.Location = new Point(797, 19);



            }
            else
            {
                tablecall3();
                button3.Text = "Archived";
                label5.Text = "RESERVATION";
                label5.Location = new Point(810, 19);
            }

        }
    }
}
