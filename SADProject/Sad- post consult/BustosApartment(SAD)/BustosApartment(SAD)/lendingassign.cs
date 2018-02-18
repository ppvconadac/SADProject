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
    public partial class lendingassign : Form
    {
        public UserControl a3;
        public int id;
        public int id2;
        Class1 c = new Class1();
        public lendingassign()
        {
           
            InitializeComponent();
             tablecall();
            tablecall2();
        }

        private void lendingassign_Load(object sender, EventArgs e)
        {

        }
        public void tablecall() {
            String query = "select concat(profile_fname,profile_mname,profile_lname) as full_name, User_id, Profile_cpnumber,Profile_Address from profile";
            dataGridView1.DataSource = c.select(query);
            dataGridView1.Columns["User_id"].Visible = false;
            dataGridView1.Columns["full_name"].HeaderText = "Name";
            dataGridView1.Columns["Profile_cpnumber"].HeaderText = "Contact";
            dataGridView1.Columns["Profile_Address"].HeaderText = "Address";
           
            
        }
        public void tablecall2()
        {
            string quer = "select * from borrowable_item";
            dataGridView2.DataSource = c.select(quer);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string date;
            DialogResult dialogResult = MessageBox.Show("Confirm lending", "Waning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);


            if (dialogResult == DialogResult.Yes)
            {

                


                //  this.Close();
                this.DialogResult = DialogResult.Yes;



            }
            else
            {


            }
        }


      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1)
            {
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["User_id"].Value.ToString());
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["full_name"].Value.ToString();
                
            }
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtin.Text = dataGridView2.Rows[e.RowIndex].Cells["bitem_name"].Value.ToString();
                id2 = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["bitem_ID"].Value.ToString());
            }
        }
    }
}
