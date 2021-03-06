﻿using System;
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
    public partial class Payment : Form
    {
        public Form a3;
        string amount;
        int tr_id;
        string dbase;
        int p_id;
        double tendered;
        double cb;
        Class1 c = new Class1();

        public Payment()
        {
            InitializeComponent();
        }

        public void getdeets(string amt, int trans_id, string db, int prof_id)
        {
            amount = amt;
            tr_id = trans_id;
            dbase = db;
            p_id = prof_id;

            textBox4.Text = amount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirm Payment", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.Yes)
            {
                if(dbase == "bitem_transaction")
                {
                    if (tendered != 0)
                    {
                        cb = double.Parse(textBox2.Text);
                        string quer;
                        string date = DateTime.Now.ToString("yyyy-M-d");

                        quer = "insert into btrans_partial values(NULL, '" + date + "', '" + tendered.ToString() + "', " + tr_id + " )";
                        c.insert(quer);

                        if (cb >= 0)
                        {
                            string quer2 = "update bitem_transaction set bt_pay_status = 'Paid', bt_pay_date = '" + date + "' where btrans_ID = " + tr_id + "";
                            c.insert(quer2);
                        }
                        else if (cb < 0)
                        {
                            if ((cb * -1) != double.Parse(amount))
                            {
                                string quer2 = "update bitem_transaction set bt_pay_status = 'Partially Paid' where btrans_ID = " + tr_id + "";
                                c.insert(quer2);
                            }
                            string quer3 = "select Profile_balance from profile where user_ID = '" + p_id + "'";
                            DataTable d = c.select(quer3);
                            string balance = d.Rows[0]["Profile_balance"].ToString();
                            double bal = double.Parse(balance);
                            bal = bal + (cb * -1);
                            string quer4 = "update profile set Profile_balance = '" + bal.ToString() + "' where User_id = " + p_id + "";
                            c.insert(quer4);

                        }
                    }
                    
                }

                if(dbase == "bitem_damage_transaction")
                {
                    if (tendered != 0)
                    {
                        cb = double.Parse(textBox2.Text);
                        string quer;
                        string date = DateTime.Now.ToString("yyyy-M-d");

                        quer = "insert into bdtrans_partial values(NULL, '" + date + "', '" + tendered.ToString() + "', " + tr_id + " )";
                        c.insert(quer);

                        if (cb >= 0)
                        {
                            string quer2 = "update bitem_damage_transaction set bdt_pay_status = 'Paid', bdt_pay_date = '" + date + "' where bdtrans_ID = " + tr_id + "";
                            c.insert(quer2);
                        }
                        else if (cb < 0)
                        {
                            if ((cb * -1) != double.Parse(amount))
                            {
                                string quer2 = "update bitem_damage_transaction set bdt_pay_status = 'Partially Paid' where bdtrans_ID = " + tr_id + "";
                                c.insert(quer2);
                            }
                            string quer3 = "select Profile_balance from profile where user_ID = '" + p_id + "'";
                            DataTable d = c.select(quer3);
                            string balance = d.Rows[0]["Profile_balance"].ToString();
                            double bal = double.Parse(balance);
                            bal = bal + (cb * -1);
                            string quer4 = "update profile set Profile_balance = '" + bal.ToString() + "' where User_id = " + p_id + "";
                            c.insert(quer4);

                        }
                    }
                }
                if (dbase == "ritem_damage_transaction")
                {
                    if (tendered != 0)
                    {
                        cb = double.Parse(textBox2.Text);
                        string quer;
                        string date = DateTime.Now.ToString("yyyy-M-d");

                        quer = "insert into rdtrans_partial values(NULL, '" + date + "', '" + tendered.ToString() + "', " + tr_id + " )";
                        c.insert(quer);

                        if (cb >= 0)
                        {
                            string quer2 = "update ritem_damage_transaction set rdt_pay_status = 'Paid', rdt_pay_date = '" + date + "' where rdtrans_ID = " + tr_id + "";
                            c.insert(quer2);
                        }
                        else if (cb < 0)
                        {
                            if ((cb * -1) != double.Parse(amount))
                            {
                                string quer2 = "update ritem_damage_transaction set rdt_pay_status = 'Partially Paid' where rdtrans_ID = " + tr_id + "";
                                c.insert(quer2);
                            }
                            string quer3 = "select Profile_balance from profile where user_ID = '" + p_id + "'";
                            DataTable d = c.select(quer3);
                            string balance = d.Rows[0]["Profile_balance"].ToString();
                            double bal = double.Parse(balance);
                            bal = bal + (cb * -1);
                            string quer4 = "update profile set Profile_balance = '" + bal.ToString() + "' where User_id = " + p_id + "";
                            c.insert(quer4);

                        }
                    }
                }

                if (dbase == "uespecs_partial")
                {
                    if (tendered != 0)
                    {
                        cb = double.Parse(textBox2.Text);
                        string quer;
                        string date = DateTime.Now.ToString("yyyy-M-d");

                        quer = "insert into uespecs_partial values(NULL, '" + date + "', " + tendered + ", " + tr_id + " )";
                        c.insert(quer);

                        if (cb >= 0)
                        {
                            string quer2 = "update uelect_trans_specs set uet_pay_stat = 'Paid', uet_pay_date = '" + date + "' where uet_ID = " + tr_id + "";
                            c.insert(quer2);
                        }
                        else if (cb < 0)
                        {
                            if ((cb* -1) != double.Parse(amount))
                            {
                                string quer2 = "update uelect_trans_specs set uet_pay_stat = 'Partially Paid' where uet_ID = " + tr_id + "";
                                c.insert(quer2);
                            }
                            string quer3 = "select Profile_balance from profile where user_ID = '" + p_id + "'";
                            DataTable d = c.select(quer3);
                            string balance = d.Rows[0]["Profile_balance"].ToString();
                            double bal = double.Parse(balance);
                            bal = bal + (cb * -1);
                            string quer4 = "update profile set Profile_balance = '" + bal.ToString() + "' where User_id = " + p_id + "";
                            c.insert(quer4);

                        }
                    }
                }
                if (dbase == "uwspecs_partial")
                {
                    if (tendered != 0)
                    {
                        cb = double.Parse(textBox2.Text);
                        string quer;
                        string date = DateTime.Now.ToString("yyyy-M-d");

                        quer = "insert into uwspecs_partial values(NULL, '" + date + "', " + tendered + ", " + tr_id + " )";
                        c.insert(quer);

                        if (cb >= 0)
                        {
                            string quer2 = "update uwat_trans_specs set uwt_pay_stat = 'Paid', uwt_pay_date = '" + date + "' where uwt_ID = " + tr_id + "";
                            c.insert(quer2);
                        }
                        else if (cb < 0)
                        {
                            if ((cb * -1) != double.Parse(amount))
                            {
                                string quer2 = "update uwat_trans_specs set uwt_pay_stat = 'Partially Paid' where uwt_ID = " + tr_id + "";
                                c.insert(quer2);
                            }
                            string quer3 = "select Profile_balance from profile where user_ID = '" + p_id + "'";
                            DataTable d = c.select(quer3);
                            string balance = d.Rows[0]["Profile_balance"].ToString();
                            double bal = double.Parse(balance);
                            bal = bal + (cb * -1);
                            string quer4 = "update profile set Profile_balance = '" + bal.ToString() + "' where User_id = " + p_id + "";
                            c.insert(quer4);

                        }
                    }
                }
                this.DialogResult = DialogResult.Yes;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (double.TryParse(textBox1.Text, out tendered))
            {

                tendered = double.Parse(textBox1.Text);
                if (tendered < 0)
                {
                    textBox1.Text = "0";
                }
                textBox2.Text = (tendered - double.Parse(amount)).ToString();

            }


        }
    }

}
