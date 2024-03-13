using System;
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
    public partial class ОкноМойПрофиль : Form
    {
        public ОкноМойПрофиль()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label8.Visible = true;
                textBox4.Visible = true;
            }
            else
            {
                label8.Visible = false;
                textBox4.Visible = false;
            }
        }
    }
}
