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

    public partial class UCRoomAsContent : UserControl
    {
        public static int id;
        public static int id5;
        public int id2;
        public int id3;
        public int id4;
        public static string rcid;
        Class1 c = new Class1();

        private static UCRoomAsContent _instance;
        public static UCRoomAsContent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCRoomAsContent();
                return _instance;
            }
        }
        public UCRoomAsContent()
        {
            InitializeComponent();
            tablecall();
            tablecall2();
     
            check();
        }
        public void onload()
        {
            tablecall();
            this.Refresh();

        }
        
        
           
        public void check()
        {
            DataTable d = new DataTable();
            int count = 0;

            string quer = "SELECT rtrans_id,rt_date_expire, room_number FROM room_transaction inner join room inner join profile where" +
                " profile_user_id = user_id and room_room_id = room_id and room_status = 'Using' and rt_type = 'Active'";
            d = c.select(quer);
            string[] arr = new string[d.Rows.Count];
            bool b = true;
            if (d.Rows.Count > 0)
            {
                for (int i = 0; i < d.Rows.Count; i++)
                {
                    if (Convert.ToDateTime(d.Rows[i]["rt_date_expire"].ToString()) <= DateTime.Now)
                    {
                        count++;
                        arr[i] = d.Rows[i]["room_number"].ToString();
                        b = false;
                    }
                   

                }
                if (b == false) {
                    string message = "The following Room/s had passed the expiration date of the room:" + Environment.NewLine;
                    for (int k = 0; k < count; k++)
                    {
                        message = message + arr[k] + Environment.NewLine;
                    }
                    MessageBox.Show(message, "Expired", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public void tablecall()
        {

            String query = "SELECT rtrans_id, room_id, room_number, room_time, room_status, rt_date_start, rt_date_expire, profile_name ,profile_user_id, room_room_id FROM room inner join owner inner join room_classification inner join room_transaction inner" +
                " join profile" +
                " where Owner_ID = Owner_Owner_ID and Room_classification_classification_ID = classification_ID and profile_user_id = user_id and room_room_id = room_id and room_status = 'Using' and rt_type = 'Active'";
            dataGridView2.DataSource = c.select(query);
            dataGridView2.ClearSelection();
            dataGridView2.Columns["room_room_id"].Visible = false;
            dataGridView2.Columns["profile_user_id"].Visible = false;


        }
        public void tablecall2()
        {

            String query = "SELECT room_id, room_number, room_time, room_status, Room_classification_classification_ID FROM room  inner join room_classification" +
                " where Room_classification_classification_ID = classification_ID ";
            dataGridView1.DataSource = c.select(query);
            dataGridView1.ClearSelection();



        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string quer = "select room_status from room where room_id = "+id+"";
            DataTable d = c.select(quer);
            if (id == 0) {
                MessageBox.Show("please select a row", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (d.Rows[0]["room_status"].ToString() == "Using") {
                MessageBox.Show("Room is Using", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                checkin ch = new checkin();
                ch.a3 = this;
                DialogResult result = ch.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    tablecall();
                    tablecall2();
                }
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["room_id"].Value.ToString());
                id2 = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["room_id"].Value.ToString());
                rcid = dataGridView1.Rows[e.RowIndex].Cells["Room_classification_classification_ID"].Value.ToString();
            }
        }

        private void UCRoomAsContent_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


            if (e.RowIndex > -1 &&

                e.ColumnIndex == this.dataGridView1.Columns["room_status"].Index)

            {

                if (e.Value != null)
                {

                    string CNumColour = e.Value.ToString();



                    if (CNumColour == "Available")

                    {

                        this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;

                    }

                    if (CNumColour == "Using")
                    {
                        this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Orange;
                    }
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (id5 == 0)
            {
                MessageBox.Show("please select a row", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string qq = "select room_time from room_classification inner join room where room_classification_classification_id = classification_id" +
                    " and room_id = "+id3+"";
                DataTable dd = c.select(qq);
                if (dd.Rows[0][0].ToString() == "Monthly") {
                    string que1 = "select rt_date_expire, rt_discount from room_transaction where room_room_id = " + id3 + " and rt_type = 'Active' ";
                    DataTable d1 = c.select(que1);
                    DateTime aa = Convert.ToDateTime(d1.Rows[0]["rt_date_expire"].ToString());
                    DateTime nw = Convert.ToDateTime(DateTime.Now.ToString("yyy-M-d"));
                    int mon = ((aa.Year - nw.Year) * 12) + aa.Month - nw.Month;
                    float dic = int.Parse(d1.Rows[0]["rt_discount"].ToString());


                    if (mon > 0)
                    {
                        string que = "select rc_rate from room_classification inner join room where room_classification_classification_id  = classification_id" +
                            " and room_id = " + id3 + " ";
                        DataTable d2 = c.select(que);
                        float prx = float.Parse(d2.Rows[0][0].ToString());
                        float pr =  (prx -(prx * (dic/100)))* mon;
                        string up = "update room_transaction set rt_price  = (rt_price - " + pr + " ) where room_room_id = " + id3 + " and rt_type = 'Active' and rt_date_expire  = '" + d1.Rows[0][0].ToString() + "' ";
                        c.insert(up);

                    }
                }
                else if (dd.Rows[0][0].ToString() == "Daily") {

                    string que1 = "select rt_date_expire, rt_discount from room_transaction where room_room_id = " + id3 + " and rt_type = 'Active' ";
                    DataTable d1 = c.select(que1);
                    DateTime aa = Convert.ToDateTime(d1.Rows[0]["rt_date_expire"].ToString());
                    DateTime nw = Convert.ToDateTime(DateTime.Now.ToString("yyy-M-d"));
                    int mon = Convert.ToInt32((aa - nw).TotalDays);
                    float dic = int.Parse(d1.Rows[0]["rt_discount"].ToString());

                    if (mon > 0)
                    {
                        string que = "select rc_rate from room_classification inner join room where room_classification_classification_id  = classification_id" +
                            " and room_id = " + id3 + " ";
                        DataTable d2 = c.select(que);
                        float prx = float.Parse(d2.Rows[0][0].ToString());
                        float pr = (prx - (prx * (dic / 100))) * mon;
                        string up = "update room_transaction set rt_price  = (rt_price - " + pr + " ) where room_room_id = " + id3 + " and rt_type = 'Active' and rt_date_expire  = '" + d1.Rows[0][0].ToString() + "' ";
                        c.insert(up);

                    }

                }

                string q = "select room_status from room where room_id = " + id3 + "";
                DataTable d = c.select(q);
                string a = d.Rows[0]["room_status"].ToString();
                if (a == "Using")
                {


                    string quer = "update room set room_status = 'Available' where room_id = " + id3 + "";
                    c.insert(quer);
                    string quer2 = "update room_transaction set rt_type = 'Expire' where rtrans_id = " + id4 + "";
                    c.insert(quer2);
                    id = 0;
                    id5 = 0;
                    tablecall();
                    tablecall2();
                  
                }

                else
                {
                    MessageBox.Show("Cannot check out since room is " + a + "", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("please select a row", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string quer = "select room_time from room_classification inner join room where room_id = " + id + " and classification_id = Room_classification_classification_ID ";
                DataTable d = c.select(quer);
                string a = d.Rows[0]["room_time"].ToString();
                if (a == "Monthly")
                {
                    MessageBox.Show("Cant reserve on Monthly rooms", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    reserve rs = new reserve();
                    rs.a3 = this;
                    DialogResult result = rs.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        tablecall();
                        tablecall2();
                    }
                }
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1 &&

                  e.ColumnIndex == this.dataGridView2.Columns["room_status"].Index)

            {

                if (e.Value != null)
                {

                    string CNumColour = e.Value.ToString();

                    if (CNumColour == "Using")
                    {
                        this.dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Orange;
                    }

                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public string puid;
        public string rrid;
        public string rtde;
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                id3 = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["room_id"].Value.ToString());
                id4 = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["rtrans_id"].Value.ToString());
                id5 = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["rtrans_id"].Value.ToString());
                puid = dataGridView2.Rows[e.RowIndex].Cells["profile_user_id"].Value.ToString();
                rrid = dataGridView2.Rows[e.RowIndex].Cells["room_room_id"].Value.ToString();
                rtde = dataGridView2.Rows[e.RowIndex].Cells["rt_date_expire"].Value.ToString(); 

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id5 == 0)
            {
                MessageBox.Show("please select a row", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                extend ex = new extend();
                ex.a3 = this;
                DialogResult result = ex.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    tablecall();
                    tablecall2();
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (id5 == 0)
            {
                MessageBox.Show("please select a row", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
               
                DialogResult dia = MessageBox.Show("Are you Sure to archive this transaction?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if ( dia == DialogResult.Yes)
                {

                    string quer = "SELECT rtrans_id, rt_date_start FROM ba_db.room_transaction where rt_date_expire = '" + rtde + "' and" +
                        " Profile_user_ID = " + puid + " and Room_Room_ID =" + rrid + " and rt_type = 'Extend'";
                    DataTable d = c.select(quer);
                    int iddd;
                    if (d.Rows.Count == 1)
                    {


                        iddd = int.Parse(d.Rows[0]["rtrans_id"].ToString());
                        string ds = d.Rows[0]["rt_date_start"].ToString();
                        string up = "update room_transaction set rt_type = 'arExtend' where rtrans_id =" + iddd + " ";
                        string up4 = "update room_transaction set rt_date_expire = '" + ds + "' where rtrans_id =" + id5 + " ";
                        c.insert(up);
                        c.insert(up4);
                    }
                    else
                    {
                        string up2 = "update room_transaction set rt_type = 'Archive' where rtrans_id =" + id5 + " ";
                        string up3 = "update room set room_status = 'Available' where room_id =" + id3 + " ";
                        c.insert(up2);
                        c.insert(up3);
                    }
               
                    tablecall();
                    tablecall2();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Transfer rs = new Transfer();
            rs.a3 = this;
            DialogResult result = rs.ShowDialog();
            if (result == DialogResult.Yes)
            {
                tablecall();
                tablecall2();
            }
        }
    }
}

