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
    public partial class ОкноДиректора : Form
    {
        public ОкноДиректора()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Авторизация авторизация = new Авторизация();
            авторизация.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ОкноОформленияПоставкиЗерна окноОформленияПоставкиЗерна = new ОкноОформленияПоставкиЗерна();
            окноОформленияПоставкиЗерна.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ОкноПросмотраСотрудников окноПросмотраСотрудников = new ОкноПросмотраСотрудников();
            окноПросмотраСотрудников.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ОкноМойПрофиль окноМойПрофиль = new ОкноМойПрофиль();
            окноМойПрофиль.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ОкноОформлениеПоставкиЖивотных окноОформлениеПоставкиЖивотных = new ОкноОформлениеПоставкиЖивотных();
            окноОформлениеПоставкиЖивотных.Show();
            this.Close();
        }
    }
}
