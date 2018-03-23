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
    public partial class UCInventCCont : UserControl
    {
        private DataGridView dataGridView1;
        private Panel panel1;
        private Panel panel2;
        private Label label5;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox txtin;
        private Label label6;
        private Label label18;
        private Button button2;
        private Label label14;
        private Label label15;
        private TabPage tabPage3;
        private Button button1;
        private TextBox textBox7;
        private TextBox txtuit;
        private TextBox txtuin;
        private Label label2;
        private Button button3;
        private Label label21;
        private Label label23;

        Class1 c1 = new Class1();
        private static UCInventCCont _instance;

        public static UCInventCCont Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCInventCCont();
                return _instance;
            }
        }

        public UCInventCCont()
        {
            InitializeComponent();    
            tablecall();
            
        }
        public string id;

        private void UCInventCCont_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.txtuit = new System.Windows.Forms.TextBox();
            this.txtuin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 47);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(670, 557);
            this.dataGridView1.TabIndex = 43;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1104, 619);
            this.panel1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(687, 69);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(403, 539);
            this.tabControl1.TabIndex = 41;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.txtin);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(395, 505);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Add Item";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.textBox4.Location = new System.Drawing.Point(20, 81);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(358, 23);
            this.textBox4.TabIndex = 66;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.textBox3.Location = new System.Drawing.Point(20, 129);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(358, 23);
            this.textBox3.TabIndex = 61;
            // 
            // txtin
            // 
            this.txtin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtin.Location = new System.Drawing.Point(20, 35);
            this.txtin.Name = "txtin";
            this.txtin.Size = new System.Drawing.Size(358, 23);
            this.txtin.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 18);
            this.label6.TabIndex = 60;
            this.label6.Text = "Item Price :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(17, 463);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(0, 15);
            this.label18.TabIndex = 58;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(265, 454);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 32);
            this.button2.TabIndex = 56;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(123, 18);
            this.label14.TabIndex = 45;
            this.label14.Text = "Item Description :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 18);
            this.label15.TabIndex = 43;
            this.label15.Text = "Item Name :";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.textBox7);
            this.tabPage3.Controls.Add(this.txtuit);
            this.tabPage3.Controls.Add(this.txtuin);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.label23);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(395, 505);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Update Item";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(265, 454);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 32);
            this.button1.TabIndex = 75;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.textBox7.Location = new System.Drawing.Point(20, 129);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(358, 23);
            this.textBox7.TabIndex = 72;
            // 
            // txtuit
            // 
            this.txtuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtuit.Location = new System.Drawing.Point(20, 81);
            this.txtuit.Name = "txtuit";
            this.txtuit.Size = new System.Drawing.Size(358, 23);
            this.txtuit.TabIndex = 66;
            // 
            // txtuin
            // 
            this.txtuin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtuin.Location = new System.Drawing.Point(20, 35);
            this.txtuin.Name = "txtuin";
            this.txtuin.Size = new System.Drawing.Size(358, 23);
            this.txtuin.TabIndex = 62;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 71;
            this.label2.Text = "Item Price :";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(146, 454);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 32);
            this.button3.TabIndex = 70;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(16, 59);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(123, 18);
            this.label21.TabIndex = 65;
            this.label21.Text = "Item Description :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(16, 11);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(88, 18);
            this.label23.TabIndex = 61;
            this.label23.Text = "Item Name :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel2.Location = new System.Drawing.Point(692, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 10);
            this.panel2.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.label5.Location = new System.Drawing.Point(786, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 25);
            this.label5.TabIndex = 39;
            this.label5.Text = "COMPLIMENTARY";
            // 
            // UCInventCCont
            // 
            this.Controls.Add(this.panel1);
            this.Name = "UCInventCCont";
            this.Size = new System.Drawing.Size(1104, 619);
            this.Load += new System.EventHandler(this.UCInventCCont_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        public void tablecall()
        {
            string quer = "select * from nonborrowable_item where nitem_stat = 0";
            dataGridView1.DataSource = c1.select(quer);
            dataGridView1.Columns["nitem_ID"].Visible = false;
            dataGridView1.Columns["nt_archive_date"].Visible = false;
            dataGridView1.Columns["nt_archive_loggedin"].Visible = false;
            dataGridView1.Columns["nitem_stat"].Visible = false;
            dataGridView1.Columns["nitem_name"].HeaderText = "Name";
            dataGridView1.Columns["nitem_price"].HeaderText = "Price";
            dataGridView1.Columns["nitem_desc"].HeaderText = "Description";
            dataGridView1.Columns["nt_quantity"].HeaderText = "Quantity in-stock";
            dataGridView1.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtuin.Text == "" || txtuit.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("No empty fields, try again.");
            }
          
            else if (!double.TryParse(textBox7.Text,  out double val))
            {
                MessageBox.Show("Invalid Price format !", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox7.Text = "";
            }

            else
            {
                string quer = "update nonborrowable_item set nitem_name= '" + txtuin.Text + "', nitem_desc = '" + txtuit.Text + "', nitem_price= '" + textBox7.Text + "'";
                c1.insert(quer);
                txtuin.Text = "";
                textBox7.Text = "";
                txtuit.Text = "";
                MessageBox.Show("Data Has Been Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tablecall();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtin.Text== "" || textBox4.Text == "" || textBox3.Text== "" ) {
                MessageBox.Show("No empty fields, try again.");
            }
            else if (!double.TryParse(textBox3.Text, out double val))
            {
                MessageBox.Show("Invalid Priceformat !", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Text = "";
            }
            
            else
            {
                string quer = "insert into nonborrowable_item values(NULL, '" + txtin.Text + "','" + textBox4.Text + "', '"+ textBox3.Text+"', 0, NULL,NULL, 0)";
                c1.insert(quer);
                MessageBox.Show("Data Has Been Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtin.Text = "";
                textBox4.Text = "";
                textBox3.Text = "";
                tablecall();
            }


        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            authorizearch ch = new authorizearch();
            ch.a3 = this;
            DialogResult result = ch.ShowDialog();
            if (result == DialogResult.Yes)
            {
                DialogResult dialogResult = MessageBox.Show("Confirm Archive?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    string quer = "update nonborrowable_item set nitem_stat = 1 , nt_archive_date =" +
                        " '" + DateTime.Now.ToString("yyy-M-d") + "', nt_archive_loggedin = " + FmLogin.id + " where nitem_ID = " + id + "";
                    c1.insert(quer);

                    txtuin.Text = "";
                    textBox7.Text = "";
                    txtuit.Text = "";

                    tablecall();
                }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtuin.Text = dataGridView1.Rows[e.RowIndex].Cells["nitem_name"].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["nitem_desc"].Value.ToString();
                txtuit.Text = dataGridView1.Rows[e.RowIndex].Cells["nitem_price"].Value.ToString();
                id = dataGridView1.Rows[e.RowIndex].Cells["nitem_ID"].Value.ToString();


            }
        }

        private void UCInventCCont_Load_1(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
