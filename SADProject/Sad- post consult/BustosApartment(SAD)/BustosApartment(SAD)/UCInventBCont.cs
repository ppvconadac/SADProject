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
            if (txtitn.Text != "" && txtbr.Text != "" && txtdr.Text != "") {
                string quer = "insert into bitem_type values(NULL, '" + txtbr.Text + "', '" + txtdr.Text + "', '" + txtitn.Text + "') ";
                c1.insert(quer);
                MessageBox.Show("Data Has Been Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label17.Text = "";
            }
            else {
                label17.Text = "Incomplete Input: Please Fill the Form";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string quer2 = "select bitem_type_id from bitem_type where bitem_type_name = '" + comboBox1.Text + "'";
            DataTable dt = c1.select(quer2);
            int id =  int.Parse(dt.Rows[0][0].ToString());

            if (&& txtin.Text != "")
            {
                string quer = "insert into borrowable_item values(NULL, '"+txtin.Text+"', 'available' , 'functional', "+id+")";
            }
            else {
                label18.Text = "Incomplete Input: Please Fill the Form";
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
            string query = "select bitem_type_name from bitem_type ";
            foreach (DataRow row in c1.select(query).Rows)
            {
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    comboBox1.Items.Add(row.ItemArray[0].ToString());
                }
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string quer = ""
        }
    }
}
