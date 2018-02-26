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

    public partial class UCProfContent : UserControl
    {
        MySqlConnection conn;
        Class1 c = new Class1();
        public int a;

        private static UCProfContent _instance;

        public static UCProfContent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCProfContent();
                return _instance;
            }
        }
        public UCProfContent()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=ba_db;uid=root; pwd =root; ");
            tablecall();

        }

        private void UserControl3_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

      

        public void tablecall()
        {
            string query = "select * from profile";          
            dataGridView1.DataSource = c.select(query);
            dataGridView1.Columns["User_id"].Visible = false;
            
            dataGridView1.Columns["profile_idt"].Visible = false;
            dataGridView1.Columns["profile_idn"].Visible = false;
            dataGridView1.Columns["profile_remark"].Visible = false;
            dataGridView1.Columns["Profile_name"].HeaderText = "Name";
            dataGridView1.Columns["Profile_cpnumber"].HeaderText = "Contact";
            dataGridView1.Columns["Profile_Address"].HeaderText = "Address";
            dataGridView1.Columns["profile_fname"].HeaderText = "First Name";
            dataGridView1.Columns["profile_mname"].HeaderText = "Middle Name";
            dataGridView1.Columns["profile_lname"].HeaderText = "Last Name";
            dataGridView1.Columns["Profile_balance"].HeaderText = "Balance";
            dataGridView1.ClearSelection();
        }
        public void histcall() {
            string quer = "select rtrans_ID, room_number, rt_date_start, rt_date_expire from room_transaction inner join room inner join profile" +
                " where room_room_id = room_id and profile_user_id = user_id and user_id =  " + a + "";
            dataGridView2.DataSource = c.select(quer);
            dataGridView2.ClearSelection();
        }
      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 13 - cn 12-fn 11-ln 10-cn 9-add 7-id
            if (e.RowIndex > -1)
            {
                int c = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["profile_idt"].Value.ToString());
                string b;
                if (c==1)
                {
                     b = "Passport";
                }
                else if (c==2)
                {
                    b = "Driver's License";
                }
                else
                {
                    b = "National ID";
                }
                textBox13.Text = dataGridView1.Rows[e.RowIndex].Cells["profile_name"].Value.ToString();
                textBox12.Text = dataGridView1.Rows[e.RowIndex].Cells["profile_fname"].Value.ToString();
                textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells["profile_lname"].Value.ToString();
                textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells["profile_cpnumber"].Value.ToString();
                textBox14.Text = dataGridView1.Rows[e.RowIndex].Cells["profile_remark"].Value.ToString();
                textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells["profile_address"].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["profile_idn"].Value.ToString();
                textBox16.Text = dataGridView1.Rows[e.RowIndex].Cells["profile_mname"].Value.ToString();
                comboBox2.Text = b;
                label30.Text = dataGridView1.Rows[e.RowIndex].Cells["profile_fname"].Value.ToString() +" "+
                dataGridView1.Rows[e.RowIndex].Cells["profile_mname"].Value.ToString() +". "+
                dataGridView1.Rows[e.RowIndex].Cells["profile_lname"].Value.ToString();
                label31.Text = dataGridView1.Rows[e.RowIndex].Cells["profile_name"].Value.ToString();
                label22.Text = b;
                label23.Text = dataGridView1.Rows[e.RowIndex].Cells["profile_idn"].Value.ToString(); 
                a = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["user_ID"].Value.ToString());
                histcall();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string query = "delete from profile where User_id = " + a + "";
            c.insert(query);
            tablecall();

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
            else {
  
                quer = "select *, concat(profile_fname, ' ', profile_lname) as " +
                    "fn, concat(profile_fname, ' ', profile_mname, ' ', profile_lname) as" +
                    " fmn from profile where concat(profile_fname, ' ', profile_lname) like '%" + textBox5.Text + "%' or profile_fname like '%" + textBox5.Text + "%' or" +
                    " concat(profile_fname, ' ', profile_mname, ' ', profile_lname) like '%" + textBox5.Text + "%' ";                           
                dataGridView1.DataSource = c.select(quer);
                dataGridView1.Columns["fn"].Visible = false;
                dataGridView1.Columns["fmn"].Visible = false;
            }
          
        }
        
        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox14.Text != "")
                {
                    string quer = "update profile set profile_remark = '" + textBox14.Text + "' where user_id = " + a + "";
                    c.insert(quer);
                    label34.Text = "";
                    MessageBox.Show("Data Has Been Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tablecall();
                }
                else
                {
                    label34.Text = "Incomplete Input: Please Fill the Form";
                }
            }
            catch {
                MessageBox.Show("Please click a data from the table", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // cn -1 fn- 2 ln- 3 nu-4 add- 6 id-8
            int idt;
            try {
                int.Parse(textBox4.Text);
            }
            catch{
                MessageBox.Show("Invalid Input: Must Contain Numbers", "Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (comboBox1.Text =="Passport") {
                idt = 1;
            }
            else if (comboBox1.Text=="Driver's License") {
                idt = 2;
            }
            else {
                idt = 3;
            }
            if (textBox1.Text != "" && textBox2.Text != "" && textBox15.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox6.Text != "" && textBox8.Text != "" && comboBox1.Text != "")
            {
                if (textBox4.Text.Length != 11) {
                    MessageBox.Show("Invalid Input: Must contain 11 Numbers", "Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    string q = "insert into profile values(NULL, '" + textBox1.Text + "','" + textBox2.Text + "', '" + textBox15.Text + "', '" + textBox3.Text + "','" + textBox6.Text + "','" + textBox4.Text + "', 0 , " + idt + ",'" + textBox8.Text + "', '')";
                    c.insert(q);
                    MessageBox.Show("Data Has Been Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox6.Text = "";
                    textBox15.Text = "";
                    textBox8.Text = "";
                    comboBox1.Text = "";
                    tablecall();
                }
            }
            else {
                label17.Text = "Incomplete Input: Please Fill the Form";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idt;
            if (comboBox2.Text == "Passport")
            {
                idt = 1;
            }
            else if (comboBox2.Text == "Driver's License")
            {
                idt = 2;
            }
            else
            {
                idt = 3;
            }
            if (textBox13.Text != "" && textBox12.Text != "" && textBox11.Text != "" && textBox10.Text != "" && textBox9.Text != "" && textBox7.Text != "" && comboBox2.Text != "")
            {
                if (textBox4.Text.Length != 11)
                {
                    MessageBox.Show("Invalid Input", "Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string q = "update profile set profile_name = '" + textBox13.Text + "', profile_fname = '" + textBox12.Text + "', profile_lname = '" + textBox11.Text + "', profile_cpnumber = " +
                    "'" + textBox10.Text + "', profile_address = '" + textBox9.Text + "', profile_idt = '" + idt + "', profile_idn = '" + textBox7.Text + "', profile_mname = '" + textBox16.Text + "' where user_ID = " + a + "";
                    c.insert(q);
                    MessageBox.Show("Data Has Been Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox13.Text = "";
                    textBox12.Text = "";
                    textBox11.Text = "";
                    textBox16.Text = "";
                    textBox10.Text = "";
                    textBox9.Text = "";
                    textBox7.Text = "";
                    comboBox2.Text = "";
                    tablecall();
                }
            }
            else
            {
                label18.Text = "Incomplete Input: Please Fill the Form";
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}