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
    public partial class ОкноРедактированияДанныхОЖивотном : Form
    {
        public ОкноРедактированияДанныхОЖивотном()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ОкноПросмотраЖивотных окноПросмотраЖивотных = new ОкноПросмотраЖивотных();
            окноПросмотраЖивотных.Show();
            this.Close();
        }

        private void ОкноРедактированияДанныхОЖивотном_Load(object sender, EventArgs e)
        {

        }
    }
}
