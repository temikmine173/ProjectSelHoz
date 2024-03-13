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
    public partial class ОкноПросмотраТехники : Form
    {
        public ОкноПросмотраТехники()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ОкноРуководителя окноРуководителя = new ОкноРуководителя();
            окноРуководителя.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ОкноДобавленияТехники окноДобавленияТехники = new ОкноДобавленияТехники();
            окноДобавленияТехники.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ОкноРедактированиеИнформацииОТехнике окноРедактированиеИнформацииОТехнике = new ОкноРедактированиеИнформацииОТехнике();
            окноРедактированиеИнформацииОТехнике.Show();
            this.Close();
        }
    }
}
