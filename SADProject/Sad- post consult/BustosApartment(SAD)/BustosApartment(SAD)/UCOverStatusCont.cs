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
            DataTable d2 = new DataTable();
            string quer = "select reservation_id, re_dateexp, room_number, profile_name, CONCAT(profile_fname, profile_mname, profile_lname) as Name" +
               ", re_date, re_status from reservation inner join profile inner join room where Profile_user_ID = user_id AND Room_Room_ID = room_id AND re_date > curdate() AND re_status = 0";
            d = c.select(quer);
            string quer2 = "select CONCAT(profile_fname, profile_mname, profile_lname) as Name, room_number, rt_date_start, rt_date_expire " +
                "from room_transaction inner join room inner join profile where Profile_user_ID = user_id AND Room_Room_ID = room_id and rt_type = 'Assigned'";
            d2 = c.select(quer2);
            for (int i = 0; i < d.Rows.Count; i++)
            {

                DateTime a = Convert.ToDateTime(d.Rows[i]["re_date"]);
                
                
                    var exerciseEvent = new CustomEvent
                    {
                        Date = a,
                        EventColor = Color.Yellow,
                        EventTextColor = Color.Black,
                        IgnoreTimeComponent = true,
                        EventText = "RESERVE THIS DAY"
                    };
                    calendar1.AddEvent(exerciseEvent);
                          
            }
            for (int i = 0; i < d2.Rows.Count; i++)
            {
                DateTime a = Convert.ToDateTime(d2.Rows[i]["rt_date_start"]);
               
             


            }
            for (int i = 0; i < d2.Rows.Count; i++)
            {
                DateTime b = Convert.ToDateTime(d2.Rows[i]["rt_date_expire"]);
                var exerciseEvent2 = new CustomEvent
                {
                    Date = b,
                    EventColor = Color.Orange,
                    EventTextColor = Color.Black,
                    IgnoreTimeComponent = true,
                    EventText = "Check-Out This day"
                };
                calendar1.AddEvent(exerciseEvent2);
            }
          
        }
        private void calendar1_Load(object sender, EventArgs e)
        {
        
        }

        private void calendar1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
