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
    
        private static UCProfOwnersCont _instance;
        public static UCProfOwnersCont Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCProfOwnersCont();
                return _instance;
            }
        }
        public UCProfOwnersCont()
        {
           
            InitializeComponent();
            tablecall();
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
                MessageBox.Show("Data Has Been Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void tablecall() {
            string quer = "select * from owner";         
            dataGridView1.DataSource = c1.select(quer);
            dataGridView1.Columns["username"].Visible = false;
            dataGridView1.Columns["password"].Visible = false;
            dataGridView1.Columns["remarks"].Visible = false;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtfname2.Text != "" && txtmname2.Text != "" && txtlname2.Text != "" && txtuser2.Text != "" && txtpass2.Text != "")
            {
                
                string quer = "update owner set owner_fname = '" + txtfname2.Text + "', owner_manme = '" + txtmname2.Text + "', owner_lname" +
                    "= '" + txtlname2.Text + "', username = '" + txtuser2.Text + "', password = '" + txtpass2.Text + "' where owner_id= " + id + "";
                c1.insert(quer);
                MessageBox.Show("Data Has Been Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtfname2.Text = "";
                txtmname2.Text = "";
                txtlname2.Text = "";
                txtuser2.Text = "";
                txtpass2.Text = "";
                tablecall();
            }
            else {
                label18.Text = "Incomplete Input: Please Fill the Form";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {             
                txtfname2.Text = dataGridView1.Rows[e.RowIndex].Cells["owner_fname"].Value.ToString();               
                txtlname2.Text = dataGridView1.Rows[e.RowIndex].Cells["owner_lname"].Value.ToString();              
                txtmname2.Text = dataGridView1.Rows[e.RowIndex].Cells["owner_mname"].Value.ToString();             
                txtuser2.Text = dataGridView1.Rows[e.RowIndex].Cells["username"].Value.ToString();
                txtpass2.Text = dataGridView1.Rows[e.RowIndex].Cells["password"].Value.ToString();
                id = dataGridView1.Rows[e.RowIndex].Cells["owner_id"].Value.ToString();
                label30.Text = dataGridView1.Rows[e.RowIndex].Cells["username"].Value.ToString();
                label31.Text = dataGridView1.Rows[e.RowIndex].Cells["owner_fname"].Value.ToString() + " " +
                     dataGridView1.Rows[e.RowIndex].Cells["owner_mname"].Value.ToString() + ". " +
                     dataGridView1.Rows[e.RowIndex].Cells["owner_lname"].Value.ToString();
                textBox14.Text = dataGridView1.Rows[e.RowIndex].Cells["remarks"].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox14.Text != "")
                {
                    string quer = "update owner set remarks = '" + textBox14.Text + "' where owner_id = " + id + "";
                    c1.insert(quer);
                    tablecall();
                    MessageBox.Show("Data Has Been Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    label12.Text = "Incomplete Input: Please Fill the Form";
                }
            }
            catch {
                MessageBox.Show("Please click a data from the table", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UCProfOwnersCont_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
