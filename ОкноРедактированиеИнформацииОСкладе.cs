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
    public partial class ОкноРедактированиеИнформацииОСкладе : Form
    {
        public ОкноРедактированиеИнформацииОСкладе()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ОкноПросмотраСкладов окноПросмотраСкладов = new ОкноПросмотраСкладов();
            окноПросмотраСкладов.Show();
            this.Close();
        }
    }
}
