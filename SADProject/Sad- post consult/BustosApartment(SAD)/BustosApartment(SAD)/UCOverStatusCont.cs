using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calendar.NET;

namespace BustosApartment_SAD_
{
    public partial class UCOverStatusCont : UserControl
    {
        private static UCOverStatusCont _instance;

        public static UCOverStatusCont Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCOverStatusCont();
                return _instance;
            }
        }
        public UCOverStatusCont()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UCOverStatusCont_Load(object sender, EventArgs e)
        {

        }

        private void calendar1_Load(object sender, EventArgs e)
        {
            var exerciseEvent = new CustomEvent
            {
                Date = DateTime.Now,
                RecurringFrequency = RecurringFrequencies.Yearly,
                EventText = "RJ BAYOT"
            };

            calendar1.AddEvent(exerciseEvent);
        }
    }
}
