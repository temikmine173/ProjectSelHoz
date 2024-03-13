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
    public partial class ОкноДобавитьСклад : Form
    {
        public ОкноДобавитьСклад()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ОкноПросмотраСкладов окноПросмотраСкладов = new ОкноПросмотраСкладов();
            окноПросмотраСкладов.Show();
            this.Close();
        }

        private void ОкноДобавитьСклад_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сельскоеХозяйствоDataSet.ТипыСкладов". При необходимости она может быть перемещена или удалена.
            this.типыСкладовTableAdapter.Fill(this.сельскоеХозяйствоDataSet.ТипыСкладов);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сельскоеХозяйствоDataSet.Культуры". При необходимости она может быть перемещена или удалена.
            this.культурыTableAdapter.Fill(this.сельскоеХозяйствоDataSet.Культуры);

        }
    }
}
