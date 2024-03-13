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
    public partial class ОкноПросмотраСкладов : Form
    {
        public ОкноПросмотраСкладов()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ОкноРастениеводство окноРастениеводство = new ОкноРастениеводство();
            окноРастениеводство.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ОкноДобавитьСклад окноДобавитьСклад = new ОкноДобавитьСклад();
            окноДобавитьСклад.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ОкноРедактированиеИнформацииОСкладе окноРедактированиеИнформацииОСкладе = new ОкноРедактированиеИнформацииОСкладе();
            окноРедактированиеИнформацииОСкладе.Show();
            this.Close();
        }

        private void ОкноПросмотраСкладов_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сельскоеХозяйствоDataSet.Склады". При необходимости она может быть перемещена или удалена.
            this.складыTableAdapter.Fill(this.сельскоеХозяйствоDataSet.Склады);

        }
    }
}
