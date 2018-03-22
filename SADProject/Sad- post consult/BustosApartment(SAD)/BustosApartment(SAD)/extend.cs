using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BustosApartment_SAD_
{
    public partial class extend : Form
    {

        Class1 c = new Class1();

        public UserControl a3;
        public int pid;
        public extend()
        {
            InitializeComponent();
            placeholder();
        }

        public void placeholder()
        {
       
            string quer = "select  profile_name, rc_rate, room_number, room_time, rt_date_start, rt_date_expire from profile inner join room inner join room_transaction inner join room_classification where profile_user_id = user_id and room_id = room_room_id and " +
                "Room_classification_classification_ID = classification_ID and rTrans_ID = " + UCRoomAsContent.id5 + "";         
            DataTable d = c.select(quer); ;
            txtown.Text = d.Rows[0]["profile_name"].ToString();
            txtrate.Text = d.Rows[0]["rc_rate"].ToString();
            txtroom.Text = d.Rows[0]["room_number"].ToString();
            txttime.Text = d.Rows[0]["room_time"].ToString();
            label7.Text = d.Rows[0]["rt_date_start"].ToString(); 
            label8.Text = d.Rows[0]["rt_date_expire"].ToString(); 

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            
            string quer = "select re_date from reservation where re_date > now()";
            DataTable d = c.select(quer);
            int pp = d.Rows.Count;
            string quer2 = "select rt_date_start, rt_date_expire, rt_price, room_time, rt_discount, Profile_user_ID, Room_Room_ID, rt_re_pay from room_transaction" +
                " inner join room inner join room_classification where" +
                " room_room_id = room_id and room_classification_classification_id = classification_id and rtrans_id = " + UCRoomAsContent.id5 + "";
            DataTable d2 = c.select(quer2);
            int cou = d.Rows.Count;
            bool b = true;
            string date = "";
            float dis = float.Parse(d2.Rows[0]["rt_discount"].ToString());
         
            DialogResult dialogResult = MessageBox.Show("Are you sure to assign this person to this room?", "Waning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < cou; i++)
                {
                    for (int j = 0; j < int.Parse(numericUpDown1.Text); j++)
                    {
                        string dt = d.Rows[i]["re_date"].ToString();
                        string dt2 = Convert.ToDateTime(d2.Rows[0]["rt_date_expire"].ToString()).AddDays(j).ToString("yyy-M-d");
                        if (dt ==dt2 )
                        {
                            MessageBox.Show("Day/s selected had been reserved", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            b = false;
                        }
                       
                    }

                }
                if (d2.Rows[0]["room_time"].ToString() == "Daily")
                {
                    date = Convert.ToDateTime(d2.Rows[0]["rt_date_expire"].ToString()).AddDays(int.Parse(numericUpDown1.Text)).ToString("yyy-M-d");
                   
                }
                else
                {
                   
                    date = Convert.ToDateTime(d2.Rows[0]["rt_date_expire"].ToString()).AddMonths(int.Parse(numericUpDown1.Text)).ToString("yyy-M-d");
                }
                if (b == true)
                {
                    if (comboBox1.Text == "Cash") {
                        string q1 = "select room_time, RC_rate  from room_classification inner join room where room_classification_classification_id = classification_id and room_id = " + d2.Rows[0]["room_room_id"].ToString() + "";
                        DataTable d3 = c.select(q1);

                        string rc = d3.Rows[0]["RC_rate"].ToString();
                        float rc2 = float.Parse(numericUpDown1.Text) * float.Parse(d3.Rows[0]["RC_rate"].ToString());
                        float rc3 = rc2 - (rc2 * (dis / 100));
                        string q = "insert into room_transaction values(NULL, 'Extend'" +
                            ", '" + d2.Rows[0]["rt_date_expire"].ToString() + "', '" + date + "',  NULL " +
                            "," + int.Parse(d2.Rows[0]["rt_discount"].ToString()) + ", " + int.Parse(d2.Rows[0]["profile_user_id"].ToString()) + ", " +
                            "" + int.Parse(d2.Rows[0]["room_room_id"].ToString()) + ", '" + DateTime.Now.ToString("yyy-M-d") + "','Cash', NULL ) ";
                        c.insert(q);
                        string q2 = "update room_transaction set rt_date_expire = '" + date + "', rt_price = (rt_price + " + rc3 + ")  where rtrans_id = " + UCRoomAsContent.id5 + "";
                        c.insert(q2);
                    }
                    else if(comboBox1.Text == "Check") {
                        string q1 = "select room_time, RC_rate  from room_classification inner join room where room_classification_classification_id = classification_id and room_id = " + d2.Rows[0]["room_room_id"].ToString() + "";
                        DataTable d3 = c.select(q1);

                        string rc = d3.Rows[0]["RC_rate"].ToString();
                        float rc2 = float.Parse(numericUpDown1.Text) * float.Parse(d3.Rows[0]["RC_rate"].ToString());
                        float rc3 = rc2 - (rc2 * (dis / 100));
                        string q = "insert into room_transaction values(NULL, 'Extend'" +
                            ", '" + d2.Rows[0]["rt_date_expire"].ToString() + "', '" + date + "',  NULL " +
                            "," + int.Parse(d2.Rows[0]["rt_discount"].ToString()) + ", " + int.Parse(d2.Rows[0]["profile_user_id"].ToString()) + ", " +
                            "" + int.Parse(d2.Rows[0]["room_room_id"].ToString()) + ", '" + DateTime.Now.ToString("yyy-M-d") + "','Check', NULL ) ";
                        c.insert(q);
                        string q2 = "update room_transaction set rt_date_expire = '" + date + "', rt_re_pay = (rt_re_pay + " + rc3 + ")  where rtrans_id = " + UCRoomAsContent.id5 + "";
                        c.insert(q2);
                        string q3 = "update profile set profile_balance = (profile_balance - "+rc3+") where user_id ="+d2.Rows[0]["profile_user_id"].ToString()+"";
                        c.insert(q3);
                    }
                    this.DialogResult = DialogResult.Yes;
                }
                else
                {
                    this.Close();
                }
            }
        }
        decimal lol = 0;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            string quer = "select rc_rate from room inner join room_transaction inner join room_classification where  room_id = room_room_id and " +
                "Room_classification_classification_ID = classification_ID and rTrans_ID = " + UCRoomAsContent.id5 + ""; ;
            DataTable d = c.select(quer);

            if (numericUpDown1.Value > lol)
            {
                int c2 = int.Parse(numericUpDown1.Text) + 1;
                int c3 = int.Parse(d.Rows[0]["rc_rate"].ToString());
                int c1 = c2 * c3;

                txtrate.Text = c1.ToString();
            }
            else if (numericUpDown1.Value < lol)
            {
                int c2 = int.Parse(numericUpDown1.Text) - 1;
                int c3 = int.Parse(d.Rows[0]["rc_rate"].ToString());
                int c1 = c2 * c3;

                txtrate.Text = c1.ToString();
            }
            lol = numericUpDown1.Value;
        }
    }
    
}
