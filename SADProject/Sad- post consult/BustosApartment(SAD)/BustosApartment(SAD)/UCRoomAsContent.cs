﻿using System;
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
    public partial class UCRoomAsContent : UserControl
    {
        public static int id;
        public int id2;
        Class1 c = new Class1();

        private static UCRoomAsContent _instance;
        public static UCRoomAsContent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCRoomAsContent();
                return _instance;
            }
        }
        public UCRoomAsContent()
        {
            InitializeComponent();
            tablecall();
        }
        public void onload() {
            tablecall();
            this.Refresh();

        }
        public void tablecall()
        {

            String query = "SELECT room_id, room_number, room_desc, owner_fname, room_time, room_status FROM room inner join owner inner join room_classification " +
                "where Owner_ID = Owner_Owner_ID and Room_classification_classification_ID = classification_ID";
            dataGridView1.DataSource = c.select(query);


        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            checkin ch = new checkin();
            ch.a3 = this;
            DialogResult result = ch.ShowDialog();
            if (result == DialogResult.Yes)
            {
                tablecall();
            }
           


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["room_id"].Value.ToString());
                id2 = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["room_id"].Value.ToString());
            }
        }

        private void UCRoomAsContent_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            {

                if (e.RowIndex > -1 &&

                    e.ColumnIndex == this.dataGridView1.Columns["room_status"].Index)

                {

                    if (e.Value != null)
                    {

                        string CNumColour = e.Value.ToString();



                        if (CNumColour == "Available")

                        {

                            this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;

                        }
                        if (CNumColour == "Reserved")
                        {
                            this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;

                        }
                        if (CNumColour == "Using")
                        {
                            this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Orange;
                        }
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string q = "select room_status from room where room_id = "+id2+"";
            DataTable d =  c.select(q);
            string a = d.Rows[0]["room_status"].ToString();
            if (a == "Using")
            {
                string quer = "update room set room_status = 'Available' where room_id = " + id2 + "";
                c.insert(quer);
                tablecall();
            }
            else {
                MessageBox.Show("Cannot check out since room is "+a+"", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

