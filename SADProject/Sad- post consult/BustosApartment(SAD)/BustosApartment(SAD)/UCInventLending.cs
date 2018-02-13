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
            string quer = "select * from borrowable_item inner join bitem_transaction where bitem_id = borrowable_item_bitem_ID and bt_archive = 0";
            dataGridView1.DataSource = c1.select(quer);
            dataGridView1.Columns["bitem_ID"].Visible = false;
            dataGridView1.Columns["bitem_status"].Visible = false;
            dataGridView1.Columns["bitem_dmg_status"].Visible = false;
            dataGridView1.Columns["bt_archive"].Visible = false;
            dataGridView1.Columns["bitem_type_bitem_type_ID"].Visible = false;
            dataGridView1.Columns["borrowable_item_bitem_ID"].Visible = false;
        }
    }

}
