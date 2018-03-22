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
    public partial class reviewpayments : Form
    {
        public reviewpayments()
        {
            InitializeComponent();
        }
        Class1 c = new Class1();

        public void getdeets(int tid, string db)
        {
            if(db == "uespecs_partial")
            {
                string quer = "select uesp_date,uesp_amount from uespecs_partial where uesp_uelectspecs_id = "+tid+"";
                dataGridView2.DataSource = c.select(quer);
                dataGridView2.ClearSelection();
               
            }
            else if (db == "uwspecs_partial")
            {
                string quer = "select uwsp_date,uwsp_amount from uwspecs_partial where uwsp_uwatspecs_id = " + tid + "";
                dataGridView2.DataSource = c.select(quer);
                dataGridView2.ClearSelection();
            }
            
        }
    }
}
