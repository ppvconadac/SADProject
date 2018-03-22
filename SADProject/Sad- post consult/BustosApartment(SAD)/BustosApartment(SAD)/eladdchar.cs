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
    public partial class eladdchar : Form
    {
        Class1 c = new Class1();
        public UserControl a3;
        public double rate;
        public string type;
        public int id;
        public int rid;
        public int classif;

        public eladdchar()
        {
            InitializeComponent();
            
        }

        public void getdeets(double rt, int tid, string tp)
        {
            rate = rt;
            id = tid;
            type = tp;
            tablecall();
        }

        public void tablecall()
        {
            string quer = "select Room_ID,Room_number, Room_classification_classification_ID, room_time, classification_ID, room_elecreading, room_watreading from room inner join room_classification where Room_classification_classification_ID=  classification_ID";
            dataGridView2.DataSource = c.select(quer);
            dataGridView2.ClearSelection();
            textBox3.Text = rate.ToString();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                rid = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["room_ID"].Value.ToString());
                textBox2.Text = dataGridView2.Rows[e.RowIndex].Cells["room_number"].Value.ToString();
                if(type == "Electricity")
                {
                    txtin.Text = dataGridView2.Rows[e.RowIndex].Cells["room_elecreading"].Value.ToString();
                }
                else
                {
                    txtin.Text = dataGridView2.Rows[e.RowIndex].Cells["room_watreading"].Value.ToString();
                }
                classif = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["Room_classification_classification_ID"].Value.ToString());
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           if( double.TryParse(textBox4.Text, out double val))
            {
                double diff = val - double.Parse(txtin.Text);
                double price = diff * rate;
                textBox5.Text = price.ToString();
            }
            else
            {
                MessageBox.Show("Invalid format !", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Text = "";
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("No Empty Fields", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (double.Parse(textBox5.Text) <= 0)
            {
                MessageBox.Show("Invalid amount", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                
                DialogResult dialogResult = MessageBox.Show("Confirm transaction", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);


                if (dialogResult == DialogResult.Yes)
                {
                    
                    string date;
                    string quer;
                    date = DateTime.Now.ToString("yyyy-M-d");

                   
                    if (type == "Electricity")
                    {
                        string quer2 = "select * from uelect_trans_specs where uet_room_id = " + rid + " and uet_trans_resolved = 0";
                        DataTable d = c.select(quer2);
                        if (d.Rows.Count > 0)
                        {
                            MessageBox.Show("Existing unresolved charges, cannot continue with processing", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else {
                            if (classif == 2)
                            {
                                string quer3 = "select Profile_user_ID from room_transaction where Room_Room_ID = " + rid + " and rt_type = 'Active'";
                                d = c.select(quer3);

                                if (d.Rows.Count > 0)
                                {
                                    quer = "insert into uelect_trans_specs values(NULL, '" + date + "'," + double.Parse(txtin.Text) + "," + double.Parse(textBox4.Text) + "," + double.Parse(textBox5.Text) + ", " + id + ", " + rid + ", NULL, NULL,NULL,NULL,NULL,'Tenant', 0,0)";
                                    c.insert(quer);


                                    int pid = int.Parse(d.Rows[0]["Profile_user_ID"].ToString());
                                    utilityselpmeth ch = new utilityselpmeth();
                                    ch.getdeets(id, rid, "Electricity", double.Parse(textBox5.Text), pid);
                                    DialogResult result = ch.ShowDialog();
                                    if (result == DialogResult.Yes)
                                    {
                                        tablecall();
                                    }


                                }
                                else
                                {
                                    quer = "insert into uelect_trans_specs values(NULL, '" + date + "'," + double.Parse(txtin.Text) + "," + double.Parse(textBox4.Text) + "," + double.Parse(textBox5.Text) + ", " + id + ", " + rid + ", NULL, NULL,NULL,NULL,NULL,'Owner', 0,0 )";
                                    c.insert(quer);


                                    this.DialogResult = DialogResult.Yes;
                                }
                            }
                            else
                            {
                                quer = "insert into uelect_trans_specs values(NULL, '" + date + "'," + double.Parse(txtin.Text) + "," + double.Parse(textBox4.Text) + "," + double.Parse(textBox5.Text) + ", " + id + ", " + rid + ", NULL, NULL,NULL,NULL,NULL,'Owner', 0,0)";
                                c.insert(quer);


                                this.DialogResult = DialogResult.Yes;
                            }
                        }
                    }

                    else
                    {
                        string quer2 = "select * from uwat_trans_specs where uwt_room_id = " + rid + " and uwt_trans_resolved = 0";
                        DataTable d = c.select(quer2);
                        if (d.Rows.Count > 0)
                        {
                            MessageBox.Show("Existing unresolved charges, cannot continue with processing", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (classif == 2)
                            {
                                string quer3 = "select Profile_user_ID from room_transaction where Room_Room_ID = " + rid + " and rt_type = 'Active'";
                                 d = c.select(quer3);

                                if (d.Rows.Count > 0)
                                {
                                    quer = "insert into uwat_trans_specs values(NULL, '" + date + "'," + double.Parse(txtin.Text) + "," + double.Parse(textBox4.Text) + "," + double.Parse(textBox5.Text) + ", " + id + ", " + rid + ", NULL, NULL,NULL,NULL,NULL,'Tenant', 0,0)";
                                    c.insert(quer);


                                    int pid = int.Parse(d.Rows[0]["Profile_user_ID"].ToString());
                                    utilityselpmeth ch = new utilityselpmeth();
                                    ch.getdeets(id, rid, "Water", double.Parse(textBox5.Text), pid);
                                    DialogResult result = ch.ShowDialog();
                                    if (result == DialogResult.Yes)
                                    {
                                        tablecall();
                                    }


                                }
                                else
                                {
                                    quer = "insert into uwat_trans_specs values(NULL, '" + date + "'," + double.Parse(txtin.Text) + "," + double.Parse(textBox4.Text) + "," + double.Parse(textBox5.Text) + ", " + id + ", " + rid + ", NULL, NULL,NULL,NULL,NULL,'Owner', 0,0 )";
                                    c.insert(quer);


                                    this.DialogResult = DialogResult.Yes;
                                }
                            }
                            else
                            {
                                quer = "insert into uwatt_trans_specs values(NULL, '" + date + "'," + double.Parse(txtin.Text) + "," + double.Parse(textBox4.Text) + "," + double.Parse(textBox5.Text) + ", " + id + ", " + rid + ", NULL, NULL,NULL,NULL,NULL,'Owner', 0,0)";
                                c.insert(quer);


                                this.DialogResult = DialogResult.Yes;
                            }
                        }
                       
                    }
                    
                    this.DialogResult = DialogResult.Yes;
                }

            }
        }
    }
}
