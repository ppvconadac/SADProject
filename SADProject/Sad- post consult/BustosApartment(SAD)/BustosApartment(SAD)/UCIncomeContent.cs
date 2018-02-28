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
    public partial class UCIncomeContent : UserControl
    {
        private static UCIncomeContent _instance;

        public static UCIncomeContent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCIncomeContent();
                return _instance;
            }
        }
        public UCIncomeContent()
        {
            InitializeComponent();
        }

        private void UCIncomeContent_Load(object sender, EventArgs e)
        {

        }
    }
}
