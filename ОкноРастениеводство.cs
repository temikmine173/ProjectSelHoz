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
    public partial class ОкноРастениеводство : Form
    {
        public ОкноРастениеводство()
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
            ОкноПросмотраКультур окноПросмотраКультур = new ОкноПросмотраКультур();
            окноПросмотраКультур.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ОкноПросмотраСкладов окноПросмотраСкладов = new ОкноПросмотраСкладов();
            окноПросмотраСкладов.Show();
            this.Close();
        }

        private void ОкноРастениеводство_Load(object sender, EventArgs e)
        {

        }
    }
}
