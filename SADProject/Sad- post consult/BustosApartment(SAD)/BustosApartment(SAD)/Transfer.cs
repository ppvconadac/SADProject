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
  
    public partial class Transfer : Form
    {
        Class1 c = new Class1();
        UCRoomAsContent ras = new UCRoomAsContent();
        public UserControl a3 = new UserControl();
        public Transfer()
        {
            InitializeComponent();
            comb();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void comb() {
           
            string quer = "select room_number from room where room_status = 'Available' and Room_classification_classification_ID = "+ UCRoomAsContent.rcid+"";
            DataTable d = c.select(quer);

            for (int i = 0; i < d.Rows.Count; i++ ) {
                comboBox1.Items.Add(d.Rows[i][0]);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string q = "select re_date from reservation where room_room_id = '"+comboBox1.Text+"'";
            DataTable d3 = c.select(q);
            if (d3.Rows[0][0].ToString() == DateTime.Now.ToString("yyy-M-d"))
            {

                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Missing Inputs", "Error");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure to assign this person to this room?", "Waning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes)
                    {
                        string quer = "select room_id from ba_db.room where room_number = '" + comboBox1.Text + "'";
                        DataTable d = c.select(quer);
                        string qu = "update room set room_status = 'Available' where room_id = " + UCRoomAsContent.id + "";
                        c.insert(qu);
                        string qu1 = "update room set room_status = 'Using' where room_number = '" + comboBox1.Text + "'";
                        c.insert(qu1);
                        string sel = "SELECT * FROM ba_db.room_transaction where rt_type = 'Assigned' and room_room_id = " + UCRoomAsContent.id + "";
                        DataTable d1 = c.select(sel);

                        string smth = "select rc_rate from room_classification where room_time = daily";
                        DataTable dd = c.select(smth);
                        float dis = float.Parse(d1.Rows[0]["rt_discount"].ToString());
                        float rat = float.Parse(dd.Rows[0]["rc_rate"].ToString());
                        string a = d.Rows[0]["Room_ID"].ToString();
                        string b = d1.Rows[0]["rt_date_expire"].ToString();
                        dis = rat * (dis / 100);
                        rat = rat - dis;
                        int aaa = Convert.ToInt32((Convert.ToDateTime(b) - DateTime.Now).TotalDays);
                        rat = rat * aaa;
                        float rat2 = float.Parse(dd.Rows[0]["rc_rate"].ToString()) - rat;
                        string quer3 = "insert into room_transaction values(NULL, '" + "Expire" + "', '" + d1.Rows[0]["rt_date_start"].ToString() + "'," +
                               " '" + d1.Rows[0]["rt_date_expire"].ToString() + "'," + rat2 + ", '" + d1.Rows[0]["rt_discount"].ToString() + "'," + d1.Rows[0]["profile_user_id"].ToString()
                               + "," + d1.Rows[0]["room_room_id"].ToString() + ",NULL" +
                               "'" + d1.Rows[0]["rt_pay_type"].ToString() + "', NULL )";
                        c.insert(quer3);
                        qu1 = "update room_transaction set room_room_id = " + a + ", rt_price = " + rat + " where rt_date_expire = '" + b + "' and room_room_id= " + UCRoomAsContent.id + " ";
                        c.insert(qu1);
                        this.DialogResult = DialogResult.Yes;
                    }
                }
            }
            else {
                MessageBox.Show("day has been reserved", "Error");
            }
        }
    }
}
