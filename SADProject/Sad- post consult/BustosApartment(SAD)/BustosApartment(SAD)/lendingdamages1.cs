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
        public int prof_id;
        Class1 c1 = new Class1();
        public UserControl a3;

        public static string rate;
        public lendingdamages1()
        {
            InitializeComponent();
            textinit();
            
            

        }

        public void textinit()
        {

            string quer = "select bitem_dmg_status from borrowable_item where bitem_ID = "+ UCInventLending.id2+"";
            DataTable d = c1.select(quer);
            comboBox3.Text = d.Rows[0]["bitem_dmg_status"].ToString();
            textBox4.Text = UCInventLending.fullname;
            txtin.Text = UCInventLending.itemname;
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prof_id = UCInventLending.id3;
            string date;
           
                DialogResult dialogResult = MessageBox.Show("Confirm report", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);


                if (dialogResult == DialogResult.Yes)
                {
                    date = DateTime.Now.ToString("yyyy/M/d");
                    string quer = "insert into bitem_damage_transaction values(NULL, '" + date + "','" + textBox2.Text + "'," + UCInventLending.id3 + "," + UCInventLending.id2 + ",'" + comboBox2.Text + "','Pending',  NULL, 0,0 )";

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

                    if(comboBox2.Text == "Check")
                {
                    string quer4 = "select Profile_balance from profile where user_ID = '"+prof_id+"'";
                    DataTable d = c1.select(quer4);
                    int balance= int.Parse(d.Rows[0]["Profile_balance"].ToString());
                    
                    int rt = int.Parse(textBox2.Text);
                    balance = balance + rt;
                    string quer3 = "update profile set Profile_balance = '" + balance.ToString() + "' where User_id = " + prof_id + "";
                    c1.insert(quer3);
                    this.DialogResult = DialogResult.Yes;

                }

                if (comboBox2.Text == "Cash")
                {
                    string quer4 = "select bdtrans_ID from bitem_damage_transaction where Profile_user_ID = " + prof_id + " and borrowable_item_bitem_ID = " + UCInventLending.id2 + " and bdt_pay_status = 'Pending'";
                    DataTable d = c1.select(quer4);
                    int bdtrans_id = int.Parse(d.Rows[0]["bdtrans_ID"].ToString());
                    Payment ch = new Payment();
                    ch.getdeets(textBox2.Text, bdtrans_id, "bitem_damage_transaction",prof_id);
                    DialogResult result = ch.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.Yes;
                    }
                }

            
                }

            }
        }
    }

