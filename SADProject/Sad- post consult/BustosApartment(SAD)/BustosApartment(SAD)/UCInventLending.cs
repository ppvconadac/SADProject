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
    public partial class UCInventLending : UserControl
    {

        private static UCInventLending _instance;
         Class1 c1 = new Class1();
        public static UCInventLending Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCInventLending();
                return _instance;
            }
        }
        public UCInventLending()
        {
            InitializeComponent();
            tablecall();
        }


        public void tablecall()
        {
            string quer = "select bitem_name,  concat(profile_fname,profile_mname,profile_lname) as full_name, btrans_id,bt_date,bt_pay_method,bt_pay_status,borrowable_item_bitem_ID,bitem_ID,User_id,Profile_user_ID from borrowable_item inner join bitem_transaction inner join profile where bitem_id = borrowable_item_bitem_ID and bt_archive = 0 and user_id = profile_user_id";
            dataGridView1.DataSource = c1.select(quer);
            dataGridView1.Columns["bitem_ID"].Visible = false;
            dataGridView1.Columns["User_id"].Visible = false;
            dataGridView1.Columns["Profile_user_ID"].Visible = false;
            dataGridView1.Columns["borrowable_item_bitem_ID"].Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lendingassign ch = new lendingassign();
            ch.a3 = this;
            ch.Show();
        }
    }

}
