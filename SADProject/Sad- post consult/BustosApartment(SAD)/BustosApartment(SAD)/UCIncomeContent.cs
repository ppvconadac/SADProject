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
    public partial class UCIncomeContent : UserControl
    {
        private static UCIncomeContent _instance;
        Class1 c = new Class1();

        public static UCIncomeContent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCIncomeContent();
                return _instance;
            }
        }
        public UCIncomeContent()
        {
            InitializeComponent();
            tablecall();
            tablecall2();
        }

        private void UCIncomeContent_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
        }
        public void tablecall() {

<<<<<<< HEAD
            string quer = "select rt_date_start ,room_number,rc_rate from room_transaction inner join room " +
                " inner join room_classification where room_transaction.Room_Room_ID = Room_ID" +
                " and Room_classification_classification_ID = classification_ID and rt_date_start like '2018-2-%' and rt_type != 'Archived' and rt_type != 'Extend'";
=======
            string quer = "select profile_name , rt_date_start ,room_number,rc_rate,rt_type from room_transaction inner join room " +
                "inner join profile inner join room_classification where room_transaction.Profile_user_ID = user_ID and room_transaction.Room_Room_ID = Room_ID" +
                " and Room_classification_classification_ID = classification_ID and rt_date_start like '"+DateTime.Now.ToString("yyy-M-")+"%' and rt_type != 'Archived' and rt_type != 'Extend'";
>>>>>>> 545ee79732d4cd87386d7686c6c2fe98f0e89cbc
            dataGridView1.DataSource = c.select(quer);
            
            dataGridView1.Columns["rt_date_start"].HeaderText = "Date";
            dataGridView1.Columns["room_number"].HeaderText = "Room Number";
            dataGridView1.Columns["rc_rate"].HeaderText = "Amount Earned";
            dataGridView1.ClearSelection();


        }
        public void tablecall2() {
<<<<<<< HEAD
            string quer = "SELECT bt_date, bt_pay_method, bt_price, bitem_name FROM bitem_transaction inner join borrowable_item  where" +
                " borrowable_item_bitem_ID = bitem_id " +
                "and bt_pay_status = 'Paid'";
=======
            string quer = "SELECT profile_name,bt_date, bt_pay_method, bt_price, bitem_name FROM bitem_transaction inner join borrowable_item inner join profile where" +
                " Profile_user_ID = user_ID and borrowable_item_bitem_ID = bitem_id " +
                "and bt_pay_status = 'Paid' and bt_date like '" + DateTime.Now.ToString("yyy-M-") + "%'";
>>>>>>> 545ee79732d4cd87386d7686c6c2fe98f0e89cbc
            dataGridView2.DataSource = c.select(quer);
            dataGridView2.Columns["bt_date"].HeaderText = "Date";
            dataGridView2.Columns["bt_pay_method"].HeaderText = "Payment Method";
            dataGridView2.Columns["bt_price"].HeaderText = "Amount Earned";
            dataGridView2.ClearSelection();

        }

        private void button1_Click(object sender, EventArgs e)
        {
          

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\USER\\Documents\\GitHub\\SADProject\\text.pdf", FileMode.Create));
                doc.Open();
                Paragraph par = new Paragraph("BUSTOS APARTMENT MONTHLY INCOME\n\n");
                par.Alignment = Element.ALIGN_CENTER;
                doc.Add(par);
            
                string quer = "select room_number, room_id from room order by room_number";
                DataTable d = c.select(quer);
         

            for (int  i = 0; i <d.Rows.Count; i++) {
                Paragraph l = new Paragraph();
                iTextSharp.text.Font font = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 13, iTextSharp.text.Font.BOLD));
                iTextSharp.text.Font font2 = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL));
                l.IndentationLeft = 30f;
                l.Add(new Chunk("Room " + d.Rows[i][0],font));
                l.Add(new Paragraph("______________________________________________________________________\n\n"));
                   doc.Add(l);
                string quer2 = "select room_number, rt_date_start, profile_name, rt_type, rt_price, rt_extend_start from room inner join room_transaction" +
            " inner join profile where room_id = Room_Room_ID and Profile_user_ID = user_ID and room_number = "+d.Rows[i][0]+ " and rt_type != 'Archived' and rt_type != 'Extend' and rt_date_start like '2018-2-%'";
                DataTable d2 = c.select(quer2);
                string quer3 = "SELECT sum(rt_price) FROM ba_db.room_transaction where Room_Room_ID = "+ d.Rows[i][1] + " and rt_type != 'Archived' and rt_type != 'Extend' and rt_date_start like '2018-2-%'";
                DataTable d3 = c.select(quer3);
                if (d2.Rows.Count == 0) {

                    Paragraph l2 = new Paragraph();
                    l2.IndentationLeft = 40f;
                    l2.Add(new Chunk("No Transacions This Month\n\n", font2));
                    doc.Add(l2);
                }

                


                for (int j = 0; j < d2.Rows.Count; j++) {
                    PdfPTable table = new PdfPTable(4);
                    table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    string x;
                    if (d2.Rows[j][5].ToString() == "")
                    {
                        x = "Check-In";
                    }
                    else {
                        x = "Extension";
                    }
                    table.AddCell(new Phrase(new Chunk("NAME:  " +d2.Rows[j][2].ToString(), font2)));
                    table.AddCell(new Phrase(new Chunk("DATE:  "+d2.Rows[j][1].ToString(), font2)));
                    table.AddCell(new Phrase(new Chunk("AMOUNT: "+d2.Rows[j][4].ToString(), font2)));
                    table.AddCell(new Phrase("TYPE:  "+x, font2));

                    doc.Add(table);
                
                }
                if (d3.Rows[0][0].ToString() != "")
                {
                    Paragraph l4 = new Paragraph();
                    l4.IndentationLeft = 40f;
                    l4.Add(new Chunk("TOTAL AMOUNT : " + d3.Rows[0][0] + "\n\n", font2));
                    doc.Add(l4);
                }

            }
            
            MessageBox.Show("PDF Created, OK!");
            doc.Close();

        }
    }
}
