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
    public partial class UCInventStInOut : UserControl
    {
        private static UCInventStInOut _instance;
        Class1 c1 = new Class1();
        public int ida = 0;
        public int id2;
        public string nt_quan;
        public string type;

        public static UCInventStInOut Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCInventStInOut();
                return _instance;
            }
        }
        public UCInventStInOut()
        {
            InitializeComponent();
            tablecall();
        }

        public void tablecall()
        {
            string quer = "select ntrans_ID, nt_date, nitem_name, nitem_transaction.nt_quantity, nonborrowable_item_nitem_ID,nt_type from nonborrowable_item inner " +
                "join nitem_transaction where nitem_ID = nonborrowable_item_nitem_ID and nt_trans_stat =0";
            dataGridView1.DataSource = c1.select(quer);
            dataGridView1.Columns["ntrans_ID"].Visible = false;
            dataGridView1.Columns["nonborrowable_item_nitem_ID"].Visible = false;
            dataGridView1.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stinstockout ch = new stinstockout();
            ch.a3 = this;
            DialogResult result = ch.ShowDialog();
            if (result == DialogResult.Yes)
            {
                tablecall();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stinstockin ch = new stinstockin();
            ch.a3 = this;
            DialogResult result = ch.ShowDialog();
            if (result == DialogResult.Yes)
            {
                tablecall();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stinlosses ch = new stinlosses();
            ch.a3 = this;
            DialogResult result = ch.ShowDialog();
            if (result == DialogResult.Yes)
            {
                tablecall();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ida == 0)
            {
                MessageBox.Show("No Entry Detected");
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
                        string quer = "update nitem_transaction set nt_trans_stat = 2 , nt_archive_date =" +
                            " '" + DateTime.Now.ToString("yyy-M-d") + "', nt_archived_loggedin = " + FmLogin.id + " where ntrans_ID = " + ida + "";
                        c1.insert(quer);

                       if(type == "Stock-in")
                        {
                            string quer2 = "select nt_quantity from nonborrowable_item where nitem_ID = '" + id2 + "'";
                            DataTable d = c1.select(quer2);
                            string quantity = d.Rows[0]["nt_quantity"].ToString();
                            int quan = int.Parse(quantity);    
                            quan = quan - int.Parse(nt_quan);
                            string quer3 = "update nonborrowable_item set nt_quantity = '" + quan.ToString() + "' where nitem_ID = " + id2 + "";
                            c1.insert(quer3);
                        }
                        else
                        {
                            string quer2 = "select nt_quantity from nonborrowable_item where nitem_ID = '" + id2 + "'";
                            DataTable d = c1.select(quer2);
                            string quantity = d.Rows[0]["nt_quantity"].ToString();
                            int quan = int.Parse(quantity);
                            quan = quan + int.Parse(nt_quan);
                            string quer3 = "update nonborrowable_item set nt_quantity = '" + quan.ToString() + "' where nitem_ID = " + id2 + "";
                            c1.insert(quer3);
                        }

                        tablecall();
                    }

                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                
                ida = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["ntrans_id"].Value.ToString());
                type = dataGridView1.Rows[e.RowIndex].Cells["nt_type"].Value.ToString();
                id2 = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["nonborrowable_item_nitem_ID"].Value.ToString());
                nt_quan = dataGridView1.Rows[e.RowIndex].Cells["nt_quantity"].Value.ToString();
            }
        }
    }
}
