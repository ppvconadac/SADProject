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
    public partial class checkin : Form
    {
    
        Class1 c = new Class1();
        public UserControl a3;
        public int pid;
        public checkin()
        {
            InitializeComponent();
            tablecall();
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            UCRoomAsContent ur = new UCRoomAsContent();
            int a = UCRoomAsContent.id; 
            string date;
            DialogResult dialogResult = MessageBox.Show("Are you sure to assign this person to this room?", "Waning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
         

            if (dialogResult == DialogResult.Yes)
            {
                
                string q = "select room_time, RC_rate from room_classification inner join room where room_classification_classification_id = classification_id and room_id = " + a + "";
                DataTable d = c.select(q);
           
                    string rc = d.Rows[0]["RC_rate"].ToString();
                    string time = d.Rows[0]["room_time"].ToString();
                    if (time == "Monthly")
                    {
                        date = DateTime.Now.AddMonths(1).ToString("M/d/yyyy");
                    }
                    else
                    {
                        date = DateTime.Now.AddDays(1).ToString("M/d/yyyy");
                    }
                    
                    string quer = "insert into room_transaction values(NULL, '" + DateTime.Now.ToString("M/d/yyyy") + "', '" + DateTime.Now.ToString("M/d/yyyy") + "'," +
                        " '" + date + "','"+rc+"', '"+textBox1.Text+"',"+pid+","+a+" )";

                c.insert(quer);
                string quer2 = "update room set room_status = 'Using' where room_id = " + a + "";
                c.insert(quer2);
                UCRoomAsContent.Instance.Refresh();


                this.Close();
        


            }
            else {
                this.Close();
                
            }
        }

        private void checkin_Load(object sender, EventArgs e)
        {

        }
    }
}
