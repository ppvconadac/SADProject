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
    public partial class UCUEContent : UserControl
    {
        Class1 c1 = new Class1();
        private static UCUEContent _instance;

        public static UCUEContent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCUEContent();
                return _instance;
            }
        }
        public UCUEContent()
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
    }
}
