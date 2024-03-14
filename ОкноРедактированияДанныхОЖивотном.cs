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
    public partial class ОкноРедактированияДанныхОЖивотном : Form
    {
        public ОкноРедактированияДанныхОЖивотном(string numberAnimal, string nameAnimal, string typeAnimal, string colorAnimal)
        {
            InitializeComponent();
            this.numberAnimal = numberAnimal;
            this.nameAnimal = nameAnimal;
            this.typeAnimal = typeAnimal;
            this.colorAnimal = colorAnimal;
        }

        private string numberAnimal, nameAnimal, typeAnimal, colorAnimal;

        private void ОкноРедактированияДанныхОЖивотном_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сельскоеХозяйствоDataSet.ТипыЖивотных". При необходимости она может быть перемещена или удалена.
            this.типыЖивотныхTableAdapter.Fill(this.сельскоеХозяйствоDataSet.ТипыЖивотных);

            textBox1.Text = nameAnimal;
            comboBox1.SelectedValue = typeAnimal;
            textBox2.Text = colorAnimal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ОкноПросмотраЖивотных окноПросмотраЖивотных = new ОкноПросмотраЖивотных();
            окноПросмотраЖивотных.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=TemikPC;Initial Catalog=СельскоеХозяйство;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateInfoAnimal = $"UPDATE [Животные] SET [НаименованиеЖивотного]='" + textBox1.Text + "',[НомерТипаЖивотного]='" + comboBox1.SelectedValue + "',[ОкрасЖивотного]='" + textBox2.Text + "' WHERE [НомерЖивотного]='" + Int32.Parse(numberAnimal) + "'";
                    SqlCommand commandUpdateInfoAnimal = new SqlCommand(updateInfoAnimal, connection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = commandUpdateInfoAnimal;

                    if (commandUpdateInfoAnimal.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ОкноПросмотраЖивотных окноПросмотраЖивотных = new ОкноПросмотраЖивотных();
                        окноПросмотраЖивотных.Show();
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
    }
}
