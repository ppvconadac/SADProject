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
    public partial class utilityselpmeth : Form
    {
        Class1 c = new Class1();
        public UserControl a3;
        public int roomid;
        public int transid;
        public string type;
        public double price;
        public int pid;
        public utilityselpmeth()
        {
            InitializeComponent();
        }

        public void getdeets(int tid, int rid, string tp, double pr, int pd)
        {
            transid = tid;
            roomid = rid;
            type = tp;
            price = pr;
            pid = pd;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirm selection", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);


            if (dialogResult == DialogResult.Yes)
            {
                if (comboBox3.Text == "Check")
                {
                    if (type == "Electricity")
                    {
                        string quer = "update uelect_trans_specs set uet_pay_meth = 'Check', uet_pay_stat = 'Pending' where uet_uelect_id =" + transid + " and uet_room_id =" + roomid + " and uet_owner_pay = 'Tenant' and uet_pay_stat is null ";
                        c.insert(quer);
                        this.DialogResult = DialogResult.Yes;
                    }
                    else
                    {
                        string quer = "update uwat_trans_specs set uwt_pay_meth = 'Check', uwt_pay_stat = 'Pending' where uwt_uwat_id =" + transid + " and uwt_room_id =" + roomid + " and uwt_owner_pay = 'Tenant' and uwt_pay_stat is null ";
                        c.insert(quer);
                        this.DialogResult = DialogResult.Yes;
                    }
                }
                else
                {
                    if (type == "Electricity")
                    {
                        string quer = "update uelect_trans_specs set uet_pay_meth = 'Cash', uet_pay_stat = 'Pending' where uet_uelect_id =" + transid + " and uet_room_id =" + roomid + " and uet_owner_pay = 'Tenant' and uet_pay_stat is null ";
                        c.insert(quer);
                        this.DialogResult = DialogResult.Yes;
                    }
                    else
                    {
                        string quer = "update uwat_trans_specs set uwt_pay_meth = 'Cash', uwt_pay_stat = 'Pending' where uwt_uwat_id =" + transid + " and uwt_room_id =" + roomid + " and uwt_owner_pay = 'Tenant' and uwt_pay_stat is null ";
                        c.insert(quer);
                        this.DialogResult = DialogResult.Yes;
                    }
                }
                
            }
        }
    }
}
