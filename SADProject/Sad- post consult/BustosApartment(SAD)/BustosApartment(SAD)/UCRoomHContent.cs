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
    public partial class UCRoomHContent : UserControl
    {
        public UCRoomHContent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            int baseyear = 2018;
            int yeargap = d.Year - baseyear;
            int[,] date = new int[12,2] {
                {1,31},{2,28},{3,31},{4,30},{5,31},
                {6,30},{7,31}, {8,31}, {9,30},{10,31},
                {11,30}, {12,31}
            };
            for (int i = 0;  yeargap > i; i++) {
                comboBox1.Items.Add(baseyear);
                baseyear++;
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
