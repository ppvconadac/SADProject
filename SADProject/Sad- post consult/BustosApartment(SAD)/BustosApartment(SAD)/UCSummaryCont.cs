using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BustosApartment_SAD_
{
    public partial class UCSummaryCont : UserControl
    {
        private static UCSummaryCont _instance;
        Class1 c = new Class1();
        public static UCSummaryCont Instance
        {
            
            get
            {
                if (_instance == null)
                    _instance = new UCSummaryCont();
                return _instance;
            }
        }
        public UCSummaryCont()
        {
            InitializeComponent();
            tablecall();
        }
        public void refresh()
        {
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
            dataGridView4.DataSource = null;
            dataGridView4.Rows.Clear();
            dataGridView5.DataSource = null;
            dataGridView5.Rows.Clear();
            tablecall();

        }

        public void tablecall() {
            string quer = "SELECT concat(owner_fname,' ',owner_mname,' ',owner_lname) as Name, rt_price as sum from owner inner join room inner join room_transaction where owner_id = room.owner_owner_id and Room_ID = room_transaction.Room_Room_ID" +
                "  and rt_date_start like '"+DateTime.Now.ToString("yyy-M-")+"%' and rt_type != 'Extend' and rt_type != 'Archive' and rt_type != 'arExtend' and emp_status != 2; ";        
           
            dataGridView1.DataSource = c.select(quer);

            string q1 = "SELECT sum(bt_price) FROM ba_db.bitem_transaction where bt_pay_status = 'Paid' and bt_date like '"+DateTime.Now.ToString("yyy-M-")+"%'";
            DataTable d = c.select(q1);
            try
            {
                label2.Text = d.Rows[0][0].ToString();
            }
            catch {
                label2.Text = "0";
            }

            string q2 = "SELECT sum(bdt_price) FROM ba_db.bitem_damage_transaction where bdt_pay_status = 'Paid' and bdt_date like '" + DateTime.Now.ToString("yyy-M-") + "%'";
            DataTable d2 = c.select(q2);
            try
            {
                label3.Text = d2.Rows[0][0].ToString();
            }
            catch {
                label3.Text = "0";
            }

            string quer2 = "SELECT  concat(owner_fname,' ',owner_mname,' ',owner_lname) as Name, rdt_price FROM owner inner join room inner join room_item inner join ritem_damage_transaction " +
                "where owner_id = room.Owner_Owner_ID and room_id = ritem_roomid and ritem_itemID = ritem_id " +
                "and rdt_pay_status = 'Paid' and rdt_date like '" + DateTime.Now.ToString("yyy-M-") + "%'";
            dataGridView2.DataSource = c.select(quer2);

            string quer3 = "SELECT  concat(owner_fname,' ',owner_mname,' ',owner_lname)as name, it_desc, it_price FROM in_transaction " +
                "inner join owner where owner_id = it_owner and it_trans_stat != 2 and it_date like '" + DateTime.Now.ToString("yyy-M-") + "%' ";
            dataGridView3.DataSource = c.select(quer3);

            string quer4 = "SELECT mt_desc, mt_price FROM misc_transaction  where mt_type = 'General' and mt_trans_stat !=2 and mt_date like '" + DateTime.Now.ToString("yyy-M-") + "%'";
            dataGridView4.DataSource = c.select(quer4);

            string quer5 = "SELECT mt_desc, mt_price FROM misc_transaction  where mt_type = 'Transient' and mt_trans_stat !=2 and mt_date like '" + DateTime.Now.ToString("yyy-M-") + "%'";
            dataGridView5.DataSource = c.select(quer5);

        }
        private void UCSummaryCont_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\USER\\Documents\\GitHub\\SADProject\\"+DateTime.Now.ToString("yyy-M")+"_sales.pdf", FileMode.Create));
            doc.Open();
            Paragraph par = new Paragraph("BUSTOS APARTMENT MONTHLY SUMMARY \n\n");
            par.Alignment = Element.ALIGN_CENTER;
            doc.Add(par);

            string quer = "select concat(owner_fname,' ',owner_mname,' ',owner_lname)as name, owner_id from owner where emp_status != 2 ";
            DataTable d = c.select(quer);


            for (int i = 0; i < d.Rows.Count; i++)
            {
                string sel11 = "select owner_owner_id from room where owner_owner_id = " + d.Rows[i]["owner_id"].ToString() + "";
                DataTable xx = c.select(sel11);
                float no = float.Parse(xx.Rows.Count.ToString());
                string sel12 = "select room_id from room";
                DataTable xx1 = c.select(sel12);
                float no1 = float.Parse(xx1.Rows.Count.ToString());
                string sel13 = "select owner_owner_id from room inner join room_classification where room_classification_classification_id = " +
                    "classification_id and owner_owner_id = " + d.Rows[i][1].ToString() + " and room_time = 'Daily'";
                DataTable xx2 = c.select(sel13);
                float no2 = float.Parse(xx2.Rows.Count.ToString());
                string sel14 = "select room_id from room inner join room_classification where room_classification_classification_id = " +
                    "classification_id and room_time = 'Daily'";
                DataTable xx3 = c.select(sel14);
                float no3 = float.Parse(xx3.Rows.Count.ToString());
                Paragraph l = new Paragraph();
                iTextSharp.text.Font font = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 13, iTextSharp.text.Font.BOLD));
                iTextSharp.text.Font font2 = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL));
                l.IndentationLeft = 30f;
                l.Add(new Chunk(d.Rows[i][0].ToString(), font));
                l.Add(new Paragraph("______________________________________________________________________\n\n"));              
                string quer1 = "SELECT sum(rt_price) as sum from owner inner join room inner join room_transaction where owner_id = room.owner_owner_id and Room_ID = room_transaction.Room_Room_ID" +
                "  and rt_date_start like '" + DateTime.Now.ToString("yyy-M-") + "%' and rt_type != 'Extend' and rt_type != 'Archive' and rt_type != 'arExtend' and emp_status != 2 and owner_id = "+ d.Rows[i]["owner_id"].ToString() + " ";
                DataTable d1 = c.select(quer1);
                if (d1.Rows[0]["sum"].ToString() != "")
                {
                    l.Add(new Chunk("Room Gross: " + d1.Rows[0]["sum"] + "\n", font));
                }
                else {
                    l.Add(new Chunk("Room Gross: 0 \n", font));
                }
                float ttl;
                try
                {
                    string q1 = "SELECT sum(bt_price) FROM ba_db.bitem_transaction where bt_pay_status = 'Paid' and bt_date like '" + DateTime.Now.ToString("yyy-M-") + "%'";
                    DataTable d2 = c.select(q1);
                    ttl = (float.Parse(d2.Rows[0][0].ToString()) / no1) * no;
                }
                catch {
                    ttl = 0;
                }
                l.Add(new Chunk("Total Lending Income: " + ttl +"\n", font));
                float ttl1;
                try
                {
                    string q2 = "SELECT sum(bdt_price) FROM ba_db.bitem_damage_transaction where bdt_pay_status = 'Paid' and bdt_date like '" + DateTime.Now.ToString("yyy-M-") + "%'";
                    DataTable d3 = c.select(q2);
                    ttl1 = (float.Parse(d3.Rows[0][0].ToString()) / no1) * no;
                }
                catch {
                    ttl1 = 0;
                }
               
               
                    l.Add(new Chunk("Total Lending Damage Income: " + ttl1 + "\n", font));
                    string quer2 = "SELECT sum(rdt_price) as sum FROM owner inner join room inner join room_item inner join ritem_damage_transaction " +
                    "where owner_id = room.Owner_Owner_ID and room_id = ritem_roomid and ritem_itemID = ritem_id " +
                    "and rdt_pay_status = 'Paid' and rdt_date like '" + DateTime.Now.ToString("yyy-M-") + "%' and owner_id = " + d.Rows[i]["owner_id"].ToString() + " ";
                    DataTable d4 = c.select(quer2);
                      
                if (d4.Rows[0]["sum"].ToString() != "")
                {

                    l.Add(new Chunk("Total Room Item Damages Income: " + d4.Rows[0]["sum"] + "\n", font));
                }
                else
                {

                    l.Add(new Chunk("Total Room Item Damages Income: 0 \n", font));
                }
                
               
                    string quer3 = "SELECT sum(it_price) as sum FROM in_transaction " +
                  "inner join owner where owner_id = it_owner and it_trans_stat != 2 and it_date like '" + DateTime.Now.ToString("yyy-M-") + "%' and owner_id = " + d.Rows[i]["owner_id"].ToString() + " ";
                    DataTable d5 = c.select(quer3);
                if (d5.Rows[0]["sum"].ToString() != "")
                {
                    l.Add(new Chunk("Total Individual Expense: " + d5.Rows[0]["sum"] + "\n", font));
                }
                else
                {
                    l.Add(new Chunk("Total Individual Expense: 0 \n", font));
                }

                
                float ttl2;
                try
                {
                    string quer4 = "SELECT sum(mt_price) as sum FROM misc_transaction  where mt_type = 'General' and mt_trans_stat !=2 " +
                        "and mt_date like '" + DateTime.Now.ToString("yyy-M-") + "%'";
                    DataTable d6 = c.select(quer4);
                    ttl2 = (float.Parse(d6.Rows[0]["sum"].ToString()) / no1) * no;
                }
                catch {
                    ttl2 = 0;
                }
                l.Add(new Chunk("Total General Expense: " + ttl2+"\n", font));
                float ttl4;
                try
                {
                    string quer5 = "SELECT sum(mt_price) as sum FROM misc_transaction  where mt_type = 'Transient' and mt_trans_stat !=2 and mt_date like '" + DateTime.Now.ToString("yyy-M-") + "%'";
                    DataTable d7 = c.select(quer5);
                    ttl4 = Convert.ToInt32(no2) * (float.Parse(d7.Rows[0]["sum"].ToString()) / Convert.ToInt32(no3));
                }
                catch {
                    ttl4 = 0;
                }
                l.Add(new Chunk("Total Transient Expense: " + ttl4+"\n\n", font));


                doc.Add(l);
            }

            MessageBox.Show("PDF Created", "OK!");
            doc.Close();
        }
    }
}
