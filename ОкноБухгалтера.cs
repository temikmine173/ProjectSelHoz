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
    public partial class ОкноБухгалтера : Form
    {
        public ОкноБухгалтера()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Авторизация fr2 = new Авторизация();
            fr2.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ОкноМойПрофиль окноМойПрофиль = new ОкноМойПрофиль();
            окноМойПрофиль.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ОкноОтчётов окноОтчётов = new ОкноОтчётов();
            окноОтчётов.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ОкноДокументы окноДокументы = new ОкноДокументы();
            окноДокументы.Show();
            this.Close();
        }
    }
}
