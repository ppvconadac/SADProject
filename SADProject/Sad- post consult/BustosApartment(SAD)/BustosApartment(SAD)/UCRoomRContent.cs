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
    public partial class UCRoomRContent : UserControl
    {
        public int id;
        public int id1;
        Class1 c1 = new Class1();
        private static UCRoomRContent _instance;

        public static UCRoomRContent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCRoomRContent();
                return _instance;
            }
        }

      

        public UCRoomRContent()
        {
            InitializeComponent();
           
            tablecall3();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
       
        public void tablecall3()
        {
            string quer = "select room_number, profile_name, CONCAT(profile_fname, profile_mname, profile_lname) as Name" +
                ", re_date from reservation inner join profile inner join room where Profile_user_ID = user_id AND Room_Room_ID = room_id";
            dataGridView2.DataSource = c1.select(quer);
        }

     

      

        private void btnCreate_Click(object sender, EventArgs e)
        {
          

              

        }

        private void UCRoomRContent_Load(object sender, EventArgs e)
        {

        }
    }
}
