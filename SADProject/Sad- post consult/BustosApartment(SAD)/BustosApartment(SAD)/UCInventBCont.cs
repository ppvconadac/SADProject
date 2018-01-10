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
            tablecall2();
            tablecall3();


        }
        public void tablecall()
        {
            string quer = "select * from borrowable_item inner join bitem_type where bitem_type_id = bitem_type_bitem_type_id";
            dataGridView1.DataSource = c1.select(quer);
            dataGridView1.Columns["bitem_ID"].Visible = false;
            dataGridView1.Columns["bitem_type_bitem_type_ID"].Visible = false;
            comboBox1.Items.Clear();
            string query = "select bitem_type_name from bitem_type ";
            foreach (DataRow row in c1.select(query).Rows)
            {
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    comboBox1.Items.Add(row.ItemArray[0].ToString());
                }
            }

        }
        public void tablecall2() {
            string quer = "select * from bitem_type";
            dataGridView2.DataSource = c1.select(quer);
            dataGridView2.Columns["bitem_type_ID"].Visible = false;
        }
        public void tablecall3() {
            string quer = "select * from borrowable_item";
            dataGridView3.DataSource = c1.select(quer);
            dataGridView3.Columns["bitem_ID"].Visible = false;
            dataGridView3.Columns["bitem_type_bitem_type_ID"].Visible = false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtitn.Text != "" && txtbr.Text != "" && txtdr.Text != "") {
                string quer = "insert into bitem_type values(NULL, '" + txtbr.Text + "', '" + txtdr.Text + "', '" + txtitn.Text + "') ";
                c1.insert(quer);
                MessageBox.Show("Data Has Been Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label17.Text = "";
                tablecall();
                tablecall2();
            }
            else {
                label17.Text = "Incomplete Input: Please Fill the Form";
            }
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
            try
            {
                string quer2 = "select bitem_type_id from bitem_type where bitem_type_name = '" + comboBox1.Text + "'";
                DataTable dt = c1.select(quer2);

                int id3 = int.Parse(dt.Rows[0][0].ToString());
            

            if (txtin.Text != "")
            {
                string quer = "insert into borrowable_item values(NULL, '"+txtin.Text+"', 'available' , 'functional', "+id3+")";
                c1.insert(quer);
                MessageBox.Show("Data Has Been Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label18.Text = "";
                tablecall();
                tablecall3();
            }
            else {
                label18.Text = "Incomplete Input: Please Fill the Form";
            }
            }
            catch
            {
                MessageBox.Show("Please fill up the form", "NANI!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                tablecall2();
                tablecall3();
            }
            else {
            }
        }
    }
}
    