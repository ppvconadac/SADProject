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
            if (!panelMain2.Controls.Contains(UCRoomAContent.Instance))
            {
                panelMain2.Controls.Add(UCRoomAContent.Instance);
                UCRoomAContent.Instance.Dock = DockStyle.Fill;
                UCRoomAContent.Instance.BringToFront();
            }
            else
            {
                UCRoomAContent.Instance.BringToFront();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
