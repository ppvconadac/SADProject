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
        }
    }
}
