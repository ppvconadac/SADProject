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
        }

        private void UCOEContent_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
