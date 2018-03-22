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
    public partial class UCManageGTContent : UserControl
    {
        Class1 c1 = new Class1();
        private static UCManageGTContent _instance;
        public int id;
        public string desc;

        public static UCManageGTContent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCManageGTContent();
                return _instance;
            }
        }
        public UCManageGTContent()
        {
            InitializeComponent();
            tablecall();
        }

        private void UCOEContent_Load(object sender, EventArgs e)
        {
            
        }

        public void tablecall()
        {
            string quer = "select * from misc_transaction where mt_trans_stat = 0";
            dataGridView1.DataSource = c1.select(quer);
            dataGridView1.Columns["mtrans_ID"].Visible = false;
            dataGridView1.Columns["mt_trans_stat"].Visible = false;
            dataGridView1.Columns["mt_void_date"].Visible = false;
            dataGridView1.Columns["mt_void_loggedin"].Visible = false;
            dataGridView1.Columns["mt_date"].HeaderText = "Date";
            dataGridView1.Columns["mt_price"].HeaderText = "Amount";
            dataGridView1.Columns["mt_type"].HeaderText = "Type";
            dataGridView1.Columns["mt_desc"].HeaderText = "Description";
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            gentransexp ch = new gentransexp();
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
                    string quer = "update misc_transaction set mt_trans_stat = 1 where mtrans_ID = " + id + "";
                    c1.insert(quer);
                    tablecall();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["mtrans_id"].Value.ToString());
                desc = dataGridView1.Rows[e.RowIndex].Cells["mt_desc"].Value.ToString();

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else if (desc == "Electricity - Excess" || desc == "Water - Excess")
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
                        string quer = "update misc_transaction set mt_trans_stat = 2 , mt_void_date =" +
                            " '" + DateTime.Now.ToString("yyyy-M-d") + "',mt_void_loggedin = " + FmLogin.id + " where mtrans_ID = " + id + "";
                        c1.insert(quer);



                        tablecall();
                    }

                }
            }
        }

        private void UCManageGTContent_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
