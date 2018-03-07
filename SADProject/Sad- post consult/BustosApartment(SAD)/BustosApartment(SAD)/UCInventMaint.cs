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
    public partial class UCInventMaint : UserControl
    {
        Class1 c = new Class1();
        private static UCInventMaint _instance;
       
        public static UCInventMaint Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCInventMaint();
                return _instance;
            }
        }

        public int bid1;
        public string ava;
        public string dmg;
        public UCInventMaint()
        {
            InitializeComponent();
            tablecall();
            tablecall2();
            tablecall3();
            tablecall4();
            tablecall5();
            tablecall6();
        }

        
        public void dgclear()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
        }
        public void tablecall()
        {

            string quer = "select * from borrowable_item";
            dataGridView5.DataSource = c.select(quer);
            dataGridView5.Columns["bitem_ID"].Visible = false;
            dataGridView5.Columns["bitem_actual"].Visible = false;
            dataGridView5.Columns["bitem_rate"].Visible = false;
            dataGridView5.ClearSelection();


        }
        public void tablecall2()
        {

            string quer = "select bdtrans_ID, bdt_date, bdt_price, concat(profile_fname,' ',profile_mname,' ',profile_lname) as full_name, bitem_name, bdt_pay_method, bdt_pay_status from bitem_damage_transaction inner join profile inner join borrowable_item where Profile_user_ID = user_ID and borrowable_item_bitem_ID = bitem_ID and bdt_trans_stat =0 and bdt_type =0";
            dataGridView1.DataSource = c.select(quer);
            dataGridView1.Columns["bdtrans_ID"].Visible = false;
            dataGridView1.ClearSelection();


        }

        public void tablecall3()
        {

            string quer = "select bdtrans_ID, bdt_date, bdt_price, bitem_name from bitem_damage_transaction inner join borrowable_item where borrowable_item_bitem_ID = bitem_ID and bdt_trans_stat =0 and bdt_type =1";
            dataGridView2.DataSource = c.select(quer);
            dataGridView2.Columns["bdtrans_ID"].Visible = false;
            dataGridView2.ClearSelection();


        }

        public void tablecall4()
        {

            string quer = "select * from room_item";
            dataGridView6.DataSource = c.select(quer);
            dataGridView6.Columns["ritem_ID"].Visible = false;
            dataGridView6.Columns["ritem_price"].Visible = false;
            dataGridView6.Columns["ritem_roomid"].Visible = false;
            dataGridView6.ClearSelection();


        }

        public void tablecall5()
        {
            string quer = "select rdtrans_ID, rdt_date, rdt_price, concat(profile_fname,' ',profile_mname,' ',profile_lname) as full_name, ritem_name, rdt_pay_method, rdt_pay_status from ritem_damage_transaction inner join profile inner join room_item where Profile_user_ID = user_ID and ritem_itemID = ritem_ID and rdt_trans_stat =0 and rdt_type =0";
            dataGridView3.DataSource = c.select(quer);
            dataGridView3.Columns["rdtrans_ID"].Visible = false;
            dataGridView3.ClearSelection();
        }

        public void tablecall6()
        {
            string quer = "select rdtrans_ID, rdt_date, rdt_price, ritem_name from ritem_damage_transaction inner join room_item where ritem_itemID = ritem_ID and rdt_trans_stat =0 and rdt_type =1";
            dataGridView4.DataSource = c.select(quer);
            dataGridView4.Columns["rdtrans_ID"].Visible = false;
            dataGridView4.ClearSelection();
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();
            dataGridView4.ClearSelection();
            dataGridView5.ClearSelection();
            dataGridView6.ClearSelection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tablecall();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tablecall2();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (bid1 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else
            {
                ChangeDamageStat ch = new ChangeDamageStat();
                ch.getdeets(bid1, "borrowable_item");
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
                bid1 = int.Parse(dataGridView5.Rows[e.RowIndex].Cells["bitem_ID"].Value.ToString());
                ava = dataGridView5.Rows[e.RowIndex].Cells["bitem_status"].Value.ToString();
                dmg = dataGridView5.Rows[e.RowIndex].Cells["bitem_dmg_status"].Value.ToString();


            }
        }

        private void UCInventMaint_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();
            dataGridView4.ClearSelection();
            dataGridView5.ClearSelection();
            dataGridView6.ClearSelection();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (bid1 == 0)
            {
                MessageBox.Show("No Entry Detected");
            }
            else 
            {

                DialogResult dialogResult = MessageBox.Show("Confirm Archive?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    if (ava == "Available")
                    {
                        string quer2 = "update borrowable_item set bitem_status = 'Unavailable' where bitem_ID = " + bid1 + "";
                        c.insert(quer2);
                    }

                    else
                    {
                        if (dmg == "Out of Order")
                        {
                            MessageBox.Show("Item Out of Order, Cannot set to Available.");
                        }
                        else
                        {
                            string quer2 = "update borrowable_item set bitem_status = 'Available' where bitem_ID = " + bid1 + "";
                            c.insert(quer2);
                        }
                    }

                }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            reportdamage ch = new reportdamage();
            ch.getdeets("borrowable_item");
            DialogResult result = ch.ShowDialog();
            if (result == DialogResult.Yes)
            {
                tablecall();
            }
        }
    }
}
