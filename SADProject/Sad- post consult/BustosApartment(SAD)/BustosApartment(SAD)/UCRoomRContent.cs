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
            string q = "select re_date from reservation inner join profile inner join room where Profile_user_ID = user_id AND Room_Room_ID = room_id";
            DataTable d = c1.select(q);
            dataGridView2.DataSource = c1.select(quer);
            DateTime check;
            int i = 0;
            dataGridView2.Columns["re_status"].Visible = false;
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                if (DateTime.TryParse(d.Rows[i]["re_date"].ToString(), out check) && check < DateTime.Now)
                {
                    dataGridView2.Rows.Remove(row);
                }
                i++;
            }
        
            

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
          

              

        }

        private void UCRoomRContent_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to Archive reservation?", "Waning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes) {
                string quer = "update reservation set re_status = 1 where reservation_id = " + id1 + " ";
                c1.insert(quer);
                tablecall3();
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id1 = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["reservation_id"].Value.ToString());
        }
    }
}
