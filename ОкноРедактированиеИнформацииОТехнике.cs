using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace СельскоеХозяйство
{
    public partial class ОкноРедактированиеИнформацииОТехнике : Form
    {
        public ОкноРедактированиеИнформацииОТехнике(string numberAvto, string nameAvto, string numberTypeAvto, string colorAvto, string strenghtAvto)
        {
            InitializeComponent();
            this.numberAvto = numberAvto;
            this.nameAvto = nameAvto;
            this.numberTypeAvto = numberTypeAvto;
            this.colorAvto = colorAvto;
            this.strenghtAvto = strenghtAvto;
        }

        private string numberAvto, nameAvto, numberTypeAvto, colorAvto, strenghtAvto;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=TemikPC;Initial Catalog=СельскоеХозяйство;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateInfoAvto = $"UPDATE [Техника] SET [НаименованиеТехники]='" + textBox1.Text + "',[НомерТипТехники]='" + comboBox1.SelectedValue + "',[ЦветТехники]='" + textBox2.Text + "',[МощностьТехники]='" + textBox3.Text + "' WHERE [НомерТехники]='" + Int32.Parse(numberAvto) + "'";
                    SqlCommand commandUpdateInfoAvto = new SqlCommand(updateInfoAvto, connection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = commandUpdateInfoAvto;

                    if (commandUpdateInfoAvto.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ОкноПросмотраТехники окноПросмотраТехники = new ОкноПросмотраТехники();
                        окноПросмотраТехники.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("При обновлении произошла ошибка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ОкноПросмотраТехники окноПросмотраТехники = new ОкноПросмотраТехники();
            окноПросмотраТехники.Show();
            this.Close();
        }

        private void ОкноРедактированиеИнформацииОТехнике_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сельскоеХозяйствоDataSet.ТипыТехники". При необходимости она может быть перемещена или удалена.
            this.типыТехникиTableAdapter.Fill(this.сельскоеХозяйствоDataSet.ТипыТехники);

            textBox1.Text = nameAvto;
            comboBox1.SelectedValue = Int32.Parse(numberTypeAvto);
            textBox2.Text = colorAvto;
            textBox3.Text = strenghtAvto;   
        }
    }
}
