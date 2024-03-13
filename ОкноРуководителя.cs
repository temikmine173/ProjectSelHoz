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
    public partial class ОкноРуководителя : Form
    {
        public ОкноРуководителя()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Авторизация авторизация = new Авторизация();
            авторизация.Show();
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
            ОкноРастениеводство окноРастениеводство = new ОкноРастениеводство();
            окноРастениеводство.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ОкноПросмотраЖивотных окноПросмотраЖивотных = new ОкноПросмотраЖивотных();
            окноПросмотраЖивотных.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ОкноПросмотраТехники окноПросмотраТехники = new ОкноПросмотраТехники();
            окноПросмотраТехники.Show();
            this.Close();
        }
    }
}
