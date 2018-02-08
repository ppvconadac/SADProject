using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BustosApartment_SAD_
{
    public partial class reserve : Form
    {
        Class1 c = new Class1();
   
        public int pid;
        public UserControl a3;
        public reserve()
        {
            InitializeComponent();
            tablecall();
            placeholder();
        }
        public void tablecall()
        {
            String query = "select * from profile";
            dataGridView1.DataSource = c.select(query);
            dataGridView1.Columns["User_id"].Visible = false;
            dataGridView1.Columns["Profile_balance"].Visible = false;
            dataGridView1.Columns["profile_idt"].Visible = false;
            dataGridView1.Columns["profile_idn"].Visible = false;
            dataGridView1.Columns["profile_remark"].Visible = false;
            dataGridView1.Columns["Profile_name"].HeaderText = "Name";
            dataGridView1.Columns["Profile_cpnumber"].HeaderText = "Contact";
            dataGridView1.Columns["Profile_Address"].HeaderText = "Address";
            dataGridView1.Columns["profile_fname"].HeaderText = "First Name";
            dataGridView1.Columns["profile_mname"].HeaderText = "Middle Name";
            dataGridView1.Columns["profile_lname"].HeaderText = "Last Name";
        }
        public void placeholder()
        {
            string quer = "select owner_fname, owner_mname, owner_lname, rc_rate, room_number, room_time" +
                " from room inner join room_classification" +
                " inner join owner where Room_classification_classification_ID =" +
                " classification_ID and owner_id = owner_owner_id and room_id = " + UCRoomAsContent.id + "";
            // dt.Rows[0]["Owner_fname"].ToString() +" "+dt.Rows[0]["Owner_lname"].ToString();
            DataTable dt = c.select(quer);
            if (dt.Rows.Count == 1)
            {
                txtroom.Text = "ROOM " + dt.Rows[0]["room_number"].ToString();
                txtown.Text = dt.Rows[0]["owner_fname"].ToString() + " " + dt.Rows[0]["owner_mname"].ToString() + ". " + dt.Rows[0]["owner_lname"].ToString();
                txtrate.Text = dt.Rows[0]["rc_rate"].ToString();
                txttime.Text = dt.Rows[0]["room_time"].ToString();
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void reserve_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["profile_name"].Value.ToString();
                pid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["user_id"].Value.ToString());
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            var sp = textBox5.Text.Split(' ');
            string quer = "";

            if (sp.Length == 1)
            {
                quer = "select * from profile where profile_name like '%" + sp[0] + "%' " +
                    "or profile_fname like '%" + sp[0] + "%' or profile_lname like '%" + sp[0] + "%'";

                dataGridView1.DataSource = c.select(quer);
            }
            else
            {

                quer = "select *, concat(profile_fname, ' ', profile_lname) as " +
                    "fn, concat(profile_fname, ' ', profile_mname, ' ', profile_lname) as" +
                    " fmn from profile where concat(profile_fname, ' ', profile_lname) like '%" + textBox5.Text + "%' or profile_fname like '%" + textBox5.Text + "%' or" +
                    " concat(profile_fname, ' ', profile_mname, ' ', profile_lname) like '%" + textBox5.Text + "%' ";
                dataGridView1.DataSource = c.select(quer);
                dataGridView1.Columns["fn"].Visible = false;
                dataGridView1.Columns["fmn"].Visible = false;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int a = UCRoomAsContent.id;
            DateTime check;
            DialogResult dialogResult = 
                MessageBox.Show("Are you sure to reserve this person to this room?", "Waning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes) {
           
                if (DateTime.TryParse(dateTimePicker1.Text, out check) && check < DateTime.Now)
                {
                    MessageBox.Show("Date has passed!", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    string quer = "insert into reservation values(NULL, '" + dateTimePicker1.Text + "', " + pid + ", " + a + "  )";
                    c.insert(quer);
                    string quer2 = "update room set room_status = 'Reserved' where room_id = " + a + "";
                    c.insert(quer2);             
                    this.DialogResult = DialogResult.Yes;


                }
            }
        }
    }
}
