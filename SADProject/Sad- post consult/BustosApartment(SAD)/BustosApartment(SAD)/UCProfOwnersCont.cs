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
    
    public partial class UCProfOwnersCont : UserControl
    {
        Class1 c1 = new Class1();
        public string id;
        public UCProfOwnersCont()
        {
           
            InitializeComponent();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtfname.Text != "" && txtmname.Text != "" && txtlname.Text != "" && txtuser.Text != "" && txtpass.Text != "")
            {
                string quer = "insert into owner values(NULL, '" + txtfname.Text + "', '" + txtmname.Text + "'," +
                    " '" + txtlname.Text + "', '" + txtuser.Text + "', '" + txtpass.Text + "')";
                c1.insert(quer);
                txtfname.Text = "";
                txtmname.Text = "";
                txtlname.Text = "";
                txtuser.Text = "";
                txtpass.Text = "";
            }
            else {
                label17.Text = "Incomplete Input: Please Fill the Form";
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtfname2.Text != "" && txtmname2.Text != "" && txtlname2.Text != "" && txtuser2.Text != "" && txtpass2.Text != "") {
                string quer = "update owner set owner_fname = '"+txtfname2.Text+"', owner_manme = '"+txtmname2.Text+"', owner_lname" +
                    "= '"+txtlname2.Text+"', username = '"+txtuser2.Text+"', password = '"+txtpass2.Text+"' where owner_id = "+id+"";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtfname.Text = dataGridView1.Rows[e.RowIndex].Cells["owner_fname"].Value.ToString();
                txtfname2.Text = dataGridView1.Rows[e.RowIndex].Cells["owner_fname"].Value.ToString();
                txtlname.Text = dataGridView1.Rows[e.RowIndex].Cells["owner_lname"].Value.ToString();
                txtlname2.Text = dataGridView1.Rows[e.RowIndex].Cells["owner_lname"].Value.ToString();
                txtmname.Text = dataGridView1.Rows[e.RowIndex].Cells["owner_mname"].Value.ToString();
                txtmname2.Text = dataGridView1.Rows[e.RowIndex].Cells["owner_mname"].Value.ToString();
                txtuser.Text = dataGridView1.Rows[e.RowIndex].Cells["username"].Value.ToString();
                txtuser2.Text = dataGridView1.Rows[e.RowIndex].Cells["username"].Value.ToString();
                txtpass.Text = dataGridView1.Rows[e.RowIndex].Cells["password"].Value.ToString();
                txtpass2.Text = dataGridView1.Rows[e.RowIndex].Cells["password"].Value.ToString();
                id = dataGridView1.Rows[e.RowIndex].Cells["owner_id"].Value.ToString();
            }
        }
    }
}
