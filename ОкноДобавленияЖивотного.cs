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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace СельскоеХозяйство
{
    public partial class ОкноДобавленияЖивотного : Form
    {
        public ОкноДобавленияЖивотного()
        {
            InitializeComponent();
        }

        int numberAnimal;
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

            try
            {
                string connectionString = @"Data Source=TemikPC;Initial Catalog=СельскоеХозяйство;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectLastId = $"SELECT MAX([НомерЖивотного]) FROM [Животные]";
                    SqlCommand commandSelectLastId = new SqlCommand(selectLastId, connection);
                    numberAnimal = (int)commandSelectLastId.ExecuteScalar();

                    numberAnimal += 1;

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=TemikPC;Initial Catalog=СельскоеХозяйство;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string addNewAnimal = $"INSERT INTO [Животные] ([НомерЖивотного],[НаименованиеЖивотного],[НомерТипаЖивотного],[ОкрасЖивотного]) Values (@numberAnimal, @nameAnimal, @typeAnimal, @colorAnimal)";
                    SqlCommand commandAddNewAnimal = new SqlCommand(addNewAnimal, connection);

                    commandAddNewAnimal.Parameters.AddWithValue("@numberAnimal", numberAnimal);
                    commandAddNewAnimal.Parameters.AddWithValue("@nameAnimal", textBox1.Text);
                    commandAddNewAnimal.Parameters.AddWithValue("@typeAnimal", comboBox1.SelectedValue);
                    commandAddNewAnimal.Parameters.AddWithValue("@colorAnimal", textBox2.Text);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = commandAddNewAnimal;

                    if (commandAddNewAnimal.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Животное успешно добавлено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ОкноПросмотраЖивотных окноПросмотраЖивотных = new ОкноПросмотраЖивотных();
                        окноПросмотраЖивотных.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Произошла ошибка при добавлении животного, попробуйте ещё раз!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
