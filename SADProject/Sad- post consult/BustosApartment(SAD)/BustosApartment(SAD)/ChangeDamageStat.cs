using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BustosApartment_SAD_
{
    public partial class ChangeDamageStat : Form
    {

        int item_id;
        string db;
        Class1 c = new Class1();
        public ChangeDamageStat()
        {
            InitializeComponent();
        }

        public void getdeets(int id, string dbase)
        {
            item_id = id;
            db = dbase;

            if (db == "borrowable_item")
            {
                string quer = "select bitem_dmg_status from borrowable_item where bitem_ID = " + item_id + "";
                DataTable d = c.select(quer);
                comboBox3.Text = d.Rows[0]["bitem_dmg_status"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirm Payment", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.Yes)
            {
                if (db == "borrowable_item")
                {

                }
            }
        }
    }
}