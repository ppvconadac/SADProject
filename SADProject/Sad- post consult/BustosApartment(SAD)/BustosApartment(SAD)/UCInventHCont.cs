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
    public partial class UCInventHCont : UserControl
    {
        private static UCInventHCont _instance;
        public UCInventHCont()
        {
            InitializeComponent();
            dates();
        }
        public static UCInventHCont Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCInventHCont();
                return _instance;
            }
        }
        public void dates()
        {
            DateTime d = DateTime.Now;
            int baseyear = 2018;
            int yeargap = d.Year - (baseyear - 1);
            String[,] date = new String[12, 2] {
                {"January","31"},{"Febuary","28"},{"March","31"},{"April","30"},{"May","31"},
                {"June","30"},{"July","31"}, {"August","31"}, {"September","30"},{"October","31"},
                {"November","30"}, {"December","31"}
            };
            comboBox1.Items.Add("");
            comboBox2.Items.Add("");
            comboBox3.Items.Add("");
            for (int i = 0; yeargap > i; i++)
            {
                comboBox1.Items.Add(baseyear);
                baseyear++;
            }
            for (int j = 0; j < 12; j++)
            {
                comboBox2.Items.Add(date[j, 0]);
            }
            for (int k = 1; k <= 31; k++)
            {
                comboBox3.Items.Add(k);
            }
        }

        private void UCInventHCont_Load(object sender, EventArgs e)
        {

        }
    }
}
