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
    public partial class ОкноОтчётов : Form
    {
        public ОкноОтчётов()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ОкноБухгалтера окноБухгалтера = new ОкноБухгалтера();
            окноБухгалтера.Show();
            this.Close();
        }

        private void ОкноОтчётов_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ОкноОтчётОПрибыли окноОтчётОПрибыли = new ОкноОтчётОПрибыли();
            окноОтчётОПрибыли.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ОкноОтчётОбУрожае окноОтчётОбУрожае = new ОкноОтчётОбУрожае();
            окноОтчётОбУрожае.Show();
            this.Close();
        }
    }
}
