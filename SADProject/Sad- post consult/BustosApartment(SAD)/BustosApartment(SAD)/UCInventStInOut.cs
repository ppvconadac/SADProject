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
    public partial class UCInventStInOut : UserControl
    {
        private static UCInventStInOut _instance;

        public static UCInventStInOut Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCInventStInOut();
                return _instance;
            }
        }
        public UCInventStInOut()
        {
            InitializeComponent();
        }

        
       
    }
}