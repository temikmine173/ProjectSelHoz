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
    public partial class ОкноПросмотраСотрудников : Form
    {
        public ОкноПросмотраСотрудников()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ОкноДиректора окноДиректора = new ОкноДиректора();
            окноДиректора.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ОкноДобавленияСотрудника окноДобавленияСотрудника = new ОкноДобавленияСотрудника();
            окноДобавленияСотрудника.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ОкноРедактированияДанныхСотрудника окноРедактированияДанныхСотрудника = new ОкноРедактированияДанныхСотрудника();
            окноРедактированияДанныхСотрудника.Show();
            this.Close();
        }
    }
}
