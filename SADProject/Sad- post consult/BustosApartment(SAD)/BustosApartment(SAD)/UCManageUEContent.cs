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
    public partial class UCManageUEContent : UserControl
    {
        Class1 c1 = new Class1();
        public int tid;
        public int tid2;
        public double rate;
        public double price;
        private static UCManageUEContent _instance;

        public static UCManageUEContent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCManageUEContent();
                return _instance;
            }
        }
        public UCManageUEContent()
        {
            InitializeComponent();
            tablecall();
        }

        public void tablecall()
        {
            string quer = "select * from utelect_trans";
            dataGridView5.DataSource = c1.select(quer);
            dataGridView5.ClearSelection();
        }

        private void UCUEContent_Load(object sender, EventArgs e)
        {
            String query1 = "select uelect_date from utelect_trans where uelect_trans_stat = 0";
            foreach (DataRow row in c1.select(query1).Rows)
            {
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    comboBox1.Items.Add(row.ItemArray[0].ToString());
                    
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            elrecmontrans ch = new elrecmontrans();
            ch.a3 = this;
            DialogResult result = ch.ShowDialog();
            if (result == DialogResult.Yes)
            {
                tablecall();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tid == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else
            {
                eladdchar ch = new eladdchar();
                ch.getdeets(rate, tid, "Electricity");
                DialogResult result = ch.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    tablecall();
                }
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                tid = int.Parse(dataGridView5.Rows[e.RowIndex].Cells["uelect_ID"].Value.ToString());
                rate = double.Parse(dataGridView5.Rows[e.RowIndex].Cells["uelect_rate"].Value.ToString());
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (tid == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else
            {
                string quer = "select * from uelect_trans_specs where uet_uelect_id = " + tid + " and uet_trans_resolved = 0";
                DataTable d = c1.select(quer);
                if (d.Rows.Count > 0)
                {
                    MessageBox.Show("Cannot archive transaction with unresolved charges");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Confirm Archive.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes)
                    {
                        quer = "update utelect_trans set uelect_trans_stat = 1 where uelect_ID = " + tid + "";
                        c1.insert(quer);
                        tablecall();
                    }
                    
                }

                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tid == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else
            {
                string quer = "select * from uelect_trans_specs where uet_uelect_id = " + tid + "";
                DataTable d = c1.select(quer);
                if (d.Rows.Count > 0)
                {
                    MessageBox.Show("Cannot void transaction existing charges");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Confirm Void.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes)
                    {
                        quer = "update utelect_trans set utelect_trans = 2, uelect_void_date = '" + DateTime.Now.ToString("yyyy-M-d") + "', uelect_void_loggedin = " + FmLogin.id + " where uelect_ID = " + tid + "";
                        c1.insert(quer);
                        tablecall();
                       
                    }
                    
                }

            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string quer = "select uelect_ID from utelect_trans where uelect_date = '"+comboBox1.Text+"'";
            DataTable d = c1.select(quer);
            int id = int.Parse(d.Rows[0]["uelect_ID"].ToString());

            string quer2 = "select uet_ID,uet_date,uet_prev,uet_current,uet_room_id,Room_number, uet_pay_meth,uet_pay_stat, uet_owner_pay from uelect_trans_specs inner join room where uet_room_id=Room_ID and uet_uelect_id = " + id + "";
            dataGridView1.DataSource = c1.select(quer2);
            dataGridView1.Columns["uet_ID"].Visible = false;
            dataGridView1.Columns["uet_room_id"].Visible = false;


            dataGridView1.ClearSelection();
        }
    }
}
