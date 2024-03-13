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
    public partial class ОкноПросмотраКультур : Form
    {
        public ОкноПросмотраКультур()
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
            ОкноДобавленияКультуры окноДобавленияКультуры = new ОкноДобавленияКультуры();
            окноДобавленияКультуры.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ОкноРедактированияИнформацииОКультуре окноРедактированияИнформацииОКультуре = new ОкноРедактированияИнформацииОКультуре();
            окноРедактированияИнформацииОКультуре.Show();
            this.Close();
        }

        private void ОкноПросмотраКультур_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сельскоеХозяйствоDataSet.Культуры". При необходимости она может быть перемещена или удалена.
            this.культурыTableAdapter.Fill(this.сельскоеХозяйствоDataSet.Культуры);

        }
    }
}
