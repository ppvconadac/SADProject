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
    public partial class UCSummaryCont : UserControl
    {
        private static UCSummaryCont _instance;

        public static UCSummaryCont Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCSummaryCont();
                return _instance;
            }
        }
        public UCSummaryCont()
        {
            InitializeComponent();
        }

        private void UCSummaryCont_Load(object sender, EventArgs e)
        {

        }
    }
}
