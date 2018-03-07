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
    public partial class reportdamage : Form
    {
        string db;
        Class1 c = new Class1();
        public UserControl a3;
        public reportdamage()
        {
            InitializeComponent();
            
        }

        public void getdeets(string dbase)
        {
        
            db = dbase;
            tablecall();
            tablecall2();

        }

        public void tablecall()
        {
            String query = "select concat(profile_fname,profile_mname,profile_lname) as full_name, User_id, Profile_cpnumber,Profile_Address,Profile_balance from profile";
            dataGridView1.DataSource = c.select(query);
            dataGridView1.Columns["User_id"].Visible = false;
            dataGridView1.Columns["Profile_balance"].Visible = false;
            dataGridView1.Columns["full_name"].HeaderText = "Name";
            dataGridView1.Columns["Profile_cpnumber"].HeaderText = "Contact";
            dataGridView1.Columns["Profile_Address"].HeaderText = "Address";
        }

        public void tablecall2()
        {


            if (db == "borrowable_item")
            {
                string quer = "select * from borrowable_item";
                dataGridView2.DataSource = c.select(quer);
                dataGridView2.Columns["bitem_ID"].Visible = false;
            }

            else if (db== "room_item")
            {
                string quer = "select * from room_item";
                dataGridView2.DataSource = c.select(quer);
            }
        }


    }
}
