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
    public partial class UCManageIndiEx : UserControl
    {
        private static UCManageIndiEx _instance;
        public int id = 0;
        public string desc;
        public static UCManageIndiEx Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCManageIndiEx();
                return _instance;
            }
        }
        Class1 c1 = new Class1();
        public UCManageIndiEx()
        {
            InitializeComponent();
            tablecall();
        }

        public void tablecall()
        {
            string quer = "select intrans_ID,it_date,it_price,it_owner,it_desc,concat (Owner_fname,' ', owner_mname, ' ', owner_lname) as fullname from in_transaction inner join owner  where it_owner = Owner_ID and it_trans_stat = 0";
            dataGridView1.DataSource = c1.select(quer);
            dataGridView1.Columns["intrans_ID"].Visible = false;
            dataGridView1.Columns["it_owner"].Visible = false;
            dataGridView1.Columns["it_date"].HeaderText = "Date";
            dataGridView1.Columns["it_price"].HeaderText = "Amount";
            dataGridView1.Columns["fullname"].HeaderText = "Owner";
            dataGridView1.Columns["it_desc"].HeaderText = "Description";
            dataGridView1.ClearSelection();

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            indiexassign ch = new indiexassign();
            ch.a3 = this;
            DialogResult result = ch.ShowDialog();
            if (result == DialogResult.Yes)
            {
                tablecall();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (id == 0)
            {
                MessageBox.Show("No Entry Detected");
            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("Confirm archive.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    string quer = "update in_transaction set it_trans_stat = 1 where intrans_ID = " + id + "";
                    c1.insert(quer);
                    tablecall();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) {
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["intrans_id"].Value.ToString());
                desc = dataGridView1.Rows[e.RowIndex].Cells["it_desc"].Value.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else if (desc == "Electrical Bill" || desc == "Water Bill")
            {
                MessageBox.Show("Cannot void this entry");
            }

            else
            {
                authorizearch ch = new authorizearch();
                ch.a3 = this;
                DialogResult result = ch.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    DialogResult dialogResult = MessageBox.Show("Confirm Void?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes)
                    {
                        string quer = "update in_transaction set it_trans_stat = 2, it_void_date = '" + DateTime.Now.ToString("yyyy-M-d") + "', it_void_loggedin = " + FmLogin.id + " where intrans_ID = " + id + "";
                        c1.insert(quer);
                        tablecall();
                    }

                }
               
            }
        }

        private void UCManageIndiEx_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
