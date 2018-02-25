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
        Class1 c = new Class1();
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
            calendarcall();
        
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
        public void calendarcall() {
            DataTable d = new DataTable();
            string quer = "select reservation_id, room_number, profile_name, CONCAT(profile_fname, profile_mname, profile_lname) as Name" +
               ", re_date, re_status from reservation inner join profile inner join room where Profile_user_ID = user_id AND Room_Room_ID = room_id AND re_date > curdate() AND re_status = 0";
            d = c.select(quer);

            for (int i = 0; i < d.Rows.Count; i++)
            {
                DateTime a = Convert.ToDateTime(d.Rows[i]["re_date"]);
                var exerciseEvent = new CustomEvent
                {
                    Date = a,
                    EventText = "RESERVE: " + d.Rows[i]["Name"] + ""
                };

                calendar1.AddEvent(exerciseEvent);
            }
        }
        private void calendar1_Load(object sender, EventArgs e)
        {
        
        }
    }
}
