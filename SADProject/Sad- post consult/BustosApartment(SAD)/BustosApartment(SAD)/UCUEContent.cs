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
        }

        private void UCUEContent_Load(object sender, EventArgs e)
        {

        }
    }
}
