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
    public partial class ОкноКвитанцияОПоставкеЗерна : Form
    {
        public ОкноКвитанцияОПоставкеЗерна()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ОкноДокументы окноДокументы = new ОкноДокументы();
            окноДокументы.Show();
            this.Close();
        }

        private void ОкноКвитанцияОПоставкеЗерна_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сельскоеХозяйствоDataSet.ПоставкиЗерна". При необходимости она может быть перемещена или удалена.
            this.поставкиЗернаTableAdapter.Fill(this.сельскоеХозяйствоDataSet.ПоставкиЗерна);

        }
    }
}
