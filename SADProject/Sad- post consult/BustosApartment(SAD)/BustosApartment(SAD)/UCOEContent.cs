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
    public partial class UCOEContent : UserControl
    {
        Class1 c1 = new Class1();
        private static UCOEContent _instance;

        public static UCOEContent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCOEContent();
                return _instance;
            }
        }
        public UCOEContent()
        {
            InitializeComponent();
            tablecall();
        }

        private void UCOEContent_Load(object sender, EventArgs e)
        {

        }

        public void tablecall()
        {
            string quer = "select * from misc_transaction";
            dataGridView1.DataSource = c1.select(quer);
           
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
    }
}
