using System;
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
    public partial class UCRoomHeader : UserControl
    {
        private static UCRoomHeader _instance;

        public static UCRoomHeader Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCRoomHeader();
                return _instance;
            }
        }
        public UCRoomHeader()
        {
            InitializeComponent();
            if (!panelMain2.Controls.Contains(UCRoomContent.Instance))
            {
                panelMain2.Controls.Add(UCRoomContent.Instance);
                UCRoomContent.Instance.Dock = DockStyle.Fill;
                UCRoomContent.Instance.BringToFront();
            }
            else
            {
                UCRoomContent.Instance.BringToFront();
            }

            
        }

        private void UCRoomHeader_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UCRoomContent.Instance))
            {
                panelMain2.Controls.Add(UCRoomContent.Instance);
                UCRoomContent.Instance.Dock = DockStyle.Fill;
                UCRoomContent.Instance.BringToFront();
            }
            else
            {
                UCRoomContent.Instance.BringToFront();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UCRoomRContent.Instance))
            {
                panelMain2.Controls.Add(UCRoomRContent.Instance);
                UCRoomRContent.Instance.Dock = DockStyle.Fill;
                UCRoomRContent.Instance.BringToFront();
            }
            else
            {
                UCRoomRContent.Instance.BringToFront();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UCRoomAsContent.Instance))
            {
                panelMain2.Controls.Add(UCRoomAsContent.Instance);
                UCRoomAsContent.Instance.Dock = DockStyle.Fill;
                UCRoomAsContent.Instance.BringToFront();
            }
            else
            {
                UCRoomAsContent.Instance.BringToFront();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!panelMain2.Controls.Contains(UCRoomHContent.Instance))
            {
                panelMain2.Controls.Add(UCRoomHContent.Instance);
                UCRoomHContent.Instance.Dock = DockStyle.Fill;
                UCRoomHContent.Instance.BringToFront();
            }
            else
            {
                UCRoomHContent.Instance.BringToFront();
            }
        }
    }
}
