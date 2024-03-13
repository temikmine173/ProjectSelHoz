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
    public partial class ОкноДобавленияКультуры : Form
    {
        public ОкноДобавленияКультуры()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ОкноПросмотраКультур окноПросмотраКультур = new ОкноПросмотраКультур();
            окноПросмотраКультур.Show();
            this.Close();
        }
    }
}
