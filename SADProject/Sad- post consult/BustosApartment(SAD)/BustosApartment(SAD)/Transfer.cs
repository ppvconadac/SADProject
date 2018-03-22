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
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Missing Inputs", "Error");
            }
            else {
                DialogResult dialogResult = MessageBox.Show("Are you sure to assign this person to this room?", "Waning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    string quer = "select room_id from ba_db.room where room_number = '" + comboBox1.Text + "'";
                    DataTable d = c.select(quer);
                    string qu = "update room set room_status = 'Available' where room_id = " + UCRoomAsContent.id + "";
                    c.insert(qu);
                    string qu1 = "update room set room_status = 'Using' where room_number = '" + comboBox1.Text + "'";
                    c.insert(qu1);
                    string sel = "SELECT rt_date_expire FROM ba_db.room_transaction where rt_type = 'Assigned' and room_room_id = "+UCRoomAsContent.id +"";
                    DataTable d1 = c.select(sel);
                    string a = d.Rows[0]["Room_ID"].ToString();
                    string b = d1.Rows[0]["rt_date_expire"].ToString();
                    qu1 = "update room_transaction set room_room_id = " + a + " where rt_date_expire = '" + b+ "' and room_room_id= " + UCRoomAsContent.id + " ";
                    c.insert(qu1);
                    this.DialogResult = DialogResult.Yes;
                }
            }
        }
    }
}
