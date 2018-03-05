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
    public partial class UCInventRICont : UserControl
    {
        public int id;
        Class1 c = new Class1();

        private static UCInventRICont _instance;



        public static UCInventRICont Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCInventRICont();
                return _instance;
            }
        }
        public UCInventRICont()
        {
            InitializeComponent();
            tablecall();
        }


        public void tablecall()
        {
            string quer = "select * from room_item";
            dataGridView1.DataSource = c.select(quer);
            dataGridView1.Columns["ritem_ID"].Visible = false;

        }

        private void UCInventRICont_Load(object sender, EventArgs e)
        {
            String query1 = "select Room_number from room";
            foreach (DataRow row in c.select(query1).Rows)
            {
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    comboBox2.Items.Add(row.ItemArray[0].ToString());
                    comboBox1.Items.Add(row.ItemArray[0].ToString());
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["ritem_id"].Value.ToString());
                int rid= int.Parse(dataGridView1.Rows[e.RowIndex].Cells["ritem_roomid"].Value.ToString());

                string quer3 = "select Room_number from room where Room_ID = '" + rid+ "'";
                DataTable d = c.select(quer3);
                string rnum = d.Rows[0]["Room_number"].ToString();
                txtuin.Text = dataGridView1.Rows[e.RowIndex].Cells["ritem_name"].Value.ToString();
                comboBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["ritem_dmg_stat"].Value.ToString();
                txtuit.Text = dataGridView1.Rows[e.RowIndex].Cells["ritem_desc"].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["ritem_price"].Value.ToString();
                comboBox1.Text = rnum;
                comboBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["ritem_dmg_stat"].Value.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtin.Text == "" || textBox4.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("No empty fields, try again.");
            }

            else
            {

                string selquer = "select Room_ID from room where Room_number = " + comboBox2.Text + "";
                DataTable d = c.select(selquer);
                int r_id = int.Parse(d.Rows[0]["Room_ID"].ToString());
                string quer = "insert into room_item values(NULL, '" + txtin.Text + "','" + textBox4.Text + "','" + textBox3.Text + "'," + r_id+ ",'" + comboBox3.Text + "')";
                c.insert(quer);
                MessageBox.Show("Data Has Been Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                txtin.Text = "";
                textBox4.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                textBox3.Text = "";
                tablecall();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtuin.Text == "" || txtuit.Text == "" || textBox1.Text == "" || comboBox1.Text == "" || comboBox4.Text == "")
            {
                MessageBox.Show("No empty fields, try again.");
            }

            else
            {

                string quer = "update borrowable_item set ritem_name = '" + txtuin.Text + "', ritem_dmg_stat = '" + comboBox4.Text + "', ritem_desc = '" + txtuit.Text + "', ritem_price = '" + textBox1.Text + "',  ritem_roomid = " + comboBox1.Text + " where  ritem_id = " + id + " ";
                c.insert(quer);
                MessageBox.Show("Data Has Been Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);     
                tablecall();
            }
        }
    }

}
