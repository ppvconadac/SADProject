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
    public partial class UCSummaryCont : UserControl
    {
        private static UCSummaryCont _instance;
        Class1 c = new Class1();
        public static UCSummaryCont Instance
        {
            
            get
            {
                if (_instance == null)
                    _instance = new UCSummaryCont();
                return _instance;
            }
        }
        public UCSummaryCont()
        {
            InitializeComponent();
            tablecall();
        }

        public void tablecall() {
            string quer = "SELECT concat(owner_fname,' ',owner_mname,' ',owner_lname) as Name, rt_price as sum from owner inner join room inner join room_transaction where owner_id = room.owner_owner_id and Room_ID = room_transaction.Room_Room_ID" +
                "  and rt_date_start like '"+DateTime.Now.ToString("yyy-M-")+"%' and rt_type != 'Extend' and rt_type != 'Archive' and rt_type != 'arExtend' and emp_status != 2; ";        
           
            dataGridView1.DataSource = c.select(quer);

            string q1 = "SELECT sum(bt_price) FROM ba_db.bitem_transaction where bt_pay_status = 'Paid' and bt_date like '"+DateTime.Now.ToString("yyy-M-")+"%'";
            DataTable d = c.select(q1);
            try
            {
                label2.Text = d.Rows[0][0].ToString();
            }
            catch {
                label2.Text = "0";
            }

            string q2 = "SELECT sum(bdt_price) FROM ba_db.bitem_damage_transaction where bdt_pay_status = 'Paid' and bdt_date like '" + DateTime.Now.ToString("yyy-M-") + "%'";
            DataTable d2 = c.select(q2);
            try
            {
                label3.Text = d2.Rows[0][0].ToString();
            }
            catch {
                label3.Text = "0";
            }

            string quer2 = "SELECT  concat(owner_fname,' ',owner_mname,' ',owner_lname) as Name, rdt_price FROM owner inner join room inner join room_item inner join ritem_damage_transaction " +
                "where owner_id = room.Owner_Owner_ID and room_id = ritem_roomid and ritem_itemID = ritem_id " +
                "and rdt_pay_status = 'Paid' and rdt_date like '" + DateTime.Now.ToString("yyy-M-") + "%'";
            dataGridView2.DataSource = c.select(quer2);

            string quer3 = "SELECT  concat(owner_fname,' ',owner_mname,' ',owner_lname)as name, it_desc, it_price FROM in_transaction " +
                "inner join owner where owner_id = it_owner and it_trans_stat != 2 and it_date like '" + DateTime.Now.ToString("yyy-M-") + "%' ";
            dataGridView3.DataSource = c.select(quer3);

            string quer4 = "SELECT mt_desc, mt_price FROM misc_transaction  where mt_type = 'General' and mt_trans_stat !=2 and mt_date like '" + DateTime.Now.ToString("yyy-M-") + "%'";
            dataGridView4.DataSource = c.select(quer4);

            string quer5 = "SELECT mt_desc, mt_price FROM misc_transaction  where mt_type = 'Transient' and mt_trans_stat !=2 and mt_date like '" + DateTime.Now.ToString("yyy-M-") + "%'";
            dataGridView5.DataSource = c.select(quer5);

        }
        private void UCSummaryCont_Load(object sender, EventArgs e)
        {

        }
    }
}
