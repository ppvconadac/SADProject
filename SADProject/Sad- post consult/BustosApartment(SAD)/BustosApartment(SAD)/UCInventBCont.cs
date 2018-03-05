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
            string quer = "select * from borrowable_item";
            dataGridView1.DataSource = c1.select(quer);
            dataGridView1.Columns["bitem_ID"].Visible = false;
            dataGridView1.ClearSelection();


        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtuin.Text = dataGridView1.Rows[e.RowIndex].Cells["bitem_name"].Value.ToString();
                comboBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["bitem_dmg_status"].Value.ToString();
                txtuit.Text = dataGridView1.Rows[e.RowIndex].Cells["bitem_desc"].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["bitem_actual"].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["bitem_rate"].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["bitem_status"].Value.ToString();
                comboBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["bitem_dmg_status"].Value.ToString();
                
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["bitem_id"].Value.ToString());


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtin.Text== "" || textBox4.Text == "" || comboBox2.Text== "" || comboBox3.Text == "" || textBox3.Text =="" || textBox2.Text == "" ) {
                MessageBox.Show("No empty fields, try again.");
            }

            else if (comboBox3.Text == "Out of Order" && comboBox2.Text != "Unavailable") {
                MessageBox.Show("Out of Order item must be set to Unavailable.");
                comboBox2.Text = "Unavailable";
            }

            else
            {
                string quer = "insert into borrowable_item values(NULL, '" + txtin.Text + "','" + textBox4.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox3.Text + "','" + textBox2.Text + "')";
                c1.insert(quer);
                MessageBox.Show("Data Has Been Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tablecall();
            }


        }


        private void UCInventBCont_Load(object sender, EventArgs e)     
        {
            dataGridView1.ClearSelection();
        
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (txtuin.Text == "" || txtuit.Text == "" || textBox1.Text == "" || textBox7.Text == "" || comboBox1.Text == "" || comboBox4.Text == "")
            {
                MessageBox.Show("No empty fields, try again.");
            }

            else if (comboBox3.Text == "Out of Order" && comboBox2.Text != "Unavailable")
            {
                MessageBox.Show("Out of Order item must be set to Unavailable.");
                comboBox2.Text = "Unavailable";
            }

            else
            {

                string quer = "update borrowable_item set bitem_name = '" + txtuin.Text + "', bitem_dmg_status = '" + comboBox4.Text + "', bitem_desc = '" + txtuit.Text + "', bitem_actual = '" + textBox1.Text + "',  bitem_rate = '" + textBox7.Text + "', bitem_status = '" + comboBox1.Text + "' where  bitem_id = " + id + " ";
                c1.insert(quer);
                MessageBox.Show("Data Has Been Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tablecall();
            }     
    
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
    