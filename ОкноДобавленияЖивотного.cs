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
    public partial class ОкноДобавленияЖивотного : Form
    {
        public ОкноДобавленияЖивотного()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ОкноПросмотраЖивотных окноПросмотраЖивотных = new ОкноПросмотраЖивотных();
            окноПросмотраЖивотных.Show();
            this.Close();
        }

        private void ОкноДобавленияЖивотного_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сельскоеХозяйствоDataSet.ТипыЖивотных". При необходимости она может быть перемещена или удалена.
            this.типыЖивотныхTableAdapter.Fill(this.сельскоеХозяйствоDataSet.ТипыЖивотных);

        }
    }
}
