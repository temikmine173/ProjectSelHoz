﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace СельскоеХозяйство
{
    public partial class ОкноОтчётОбУрожае : Form
    {
        public ОкноОтчётОбУрожае()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ОкноОтчётов окноОтчётов = new ОкноОтчётов();
            окноОтчётов.Show();
            this.Close();
        }
    }
}
