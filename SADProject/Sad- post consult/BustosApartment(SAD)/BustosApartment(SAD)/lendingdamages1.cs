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
    public partial class lendingdamages1 : Form
    {

        Class1 c1 = new Class1();
        public lendingdamages1()
        {
            InitializeComponent();
            textinit();
            
            

        }

        public void textinit()
        {

            string quer = "select bitem_dmg_rate, bitem_dmg_status from borrowable_item where bitem_ID = "+ UCInventLending.id2+"";
            DataTable d = c1.select(quer);
            comboBox3.Text = d.Rows[0]["bitem_dmg_status"].ToString();
            textBox4.Text = UCInventLending.fullname;
            txtin.Text = UCInventLending.itemname;
            textBox2.Text = d.Rows[0]["bitem_dmg_rate"].ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date;
           
                DialogResult dialogResult = MessageBox.Show("Confirm report", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);


                if (dialogResult == DialogResult.Yes)
                {
                    date = DateTime.Now.ToString("yyyy/M/d");
                    string quer = "insert into bitem_damage_transaction values(NULL, '" + date + "','" + textBox2.Text + "','" + UCInventLending.id + "','" + UCInventLending.id2 + "','" + comboBox2.Text + "','" +comboBox1.Text+"',  NULL )";

                    c1.insert(quer);
                    string quer2 = "update borrowable_item set bitem_dmg_status = '"+comboBox3.Text+"' where bitem_ID = " + UCInventLending.id2 + "";
                    c1.insert(quer2);

                    if (comboBox3.Text == "Out of Order")
                {
                    string quer3 = "update borrowable_item set bitem_status = 'Unavailable' where bitem_ID = " + UCInventLending.id2 + "";
                    c1.insert(quer3);
                }
                else
                {
                    DialogResult dialogResult2 = MessageBox.Show("Set item as unavailable?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult2 == DialogResult.Yes)
                    {
                        String quer3 = "update borrowable_item set bitem_status = 'Unavailable' where bitem_ID = " + UCInventLending.id2 + "";
                        c1.insert(quer3);
                    }
           
                }

                  

                    //  this.Close();
                    this.DialogResult = DialogResult.Yes;
                }

            }
        }
    }

