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
    public partial class UCBIRCont : UserControl
    {
        private static UCBIRCont _instance;



        public static UCBIRCont Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCBIRCont();
                return _instance;
            }
        }
        public UCBIRCont()
        {
            InitializeComponent();
        }

        private void UCBIRCont_Load(object sender, EventArgs e)
        {

        }
    }
}
