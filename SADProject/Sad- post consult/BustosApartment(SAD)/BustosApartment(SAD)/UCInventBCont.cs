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
    public partial class UCInventBCont : UserControl
    {
        Class1 c1 = new Class1();
        public int id;
        private static UCInventBCont _instance;



        public static UCInventBCont Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCInventBCont();
                return _instance;
            }
        }
        public UCInventBCont()
        {
            InitializeComponent();
            tablecall();

        }
        public void tablecall()
        {
            string quer = "select * from borrowable_item inner join bitem_type where bitem_type_id = bitem_type_bitem_type_id";
            dataGridView1.DataSource = c1.select(quer);
            dataGridView1.Columns["bitem_ID"].Visible = false;
            dataGridView1.Columns["bitem_type_ID"].Visible = false;
            dataGridView1.Columns["bitem_type_bitem_type_ID"].Visible = false;

        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtuin.Text = dataGridView1.Rows[e.RowIndex].Cells["bitem_name"].Value.ToString();
                txtuit.Text = dataGridView1.Rows[e.RowIndex].Cells["bitem_type_name"].Value.ToString();
                txtuis.Text = dataGridView1.Rows[e.RowIndex].Cells["bitem_status"].Value.ToString();
                txtuids.Text = dataGridView1.Rows[e.RowIndex].Cells["bitem_dmg_status"].Value.ToString();
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["bitem_id"].Value.ToString());


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UCInventBCont_Load(object sender, EventArgs e)     
        {
            dataGridView1.ClearSelection();
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtuit.Text != "" && txtuin.Text != "" && txtuis.Text != "" && txtuids.Text != "") {
                string quer = "update borrowable_item set bitem_name = '" + txtuin.Text + "', bitem_status = '" + txtuis.Text + "', bitem_dmg_status = '" + txtuids.Text + "' where  bitem_id = " + id + " ";
                c1.insert(quer);
                string quer2 = "select bitem_type_bitem_type_ID from borrowable_item where bitem_id = " + id + "";
                DataTable dt = c1.select(quer2);
                int id2 = int.Parse(dt.Rows[0][0].ToString());
                string quer3 = "update bitem_type set bitem_type_name = '" + txtuit.Text + "' where bitem_type_id = " + id2 + "";
                MessageBox.Show("Data Has Been Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tablecall();
                
            }
            else {
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void txtin_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtuids_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtuit_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtuis_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtuin_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }
    }
}
    