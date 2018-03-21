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
        public int id =0;
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
            string quer = "select * from in_transaction where it_trans_stat = 0";
            dataGridView1.DataSource = c1.select(quer);

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
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("No Entry Detected");
            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("Confirm Void.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {

                    string quer = "update in_transaction set it_trans_stat = 2, it_void_date = '"+DateTime.Now.ToString("yyyy-M-d")+"', it_void_loggedin = "+FmLogin.id+" where intrans_ID = " + id + "";
                    c1.insert(quer);
                    tablecall();
                }
            }
        }
    }
}
