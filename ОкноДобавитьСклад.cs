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
    public partial class ОкноДобавитьСклад : Form
    {
        public ОкноДобавитьСклад()
        {
            InitializeComponent();
        }

        int numberWarehouse;

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

            try
            {
                string connectionString = @"Data Source=TemikPC;Initial Catalog=СельскоеХозяйство;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectLastId = $"SELECT MAX([НомерСклада]) FROM [Склады]";
                    SqlCommand commandSelectLastId = new SqlCommand(selectLastId, connection);
                    numberWarehouse = (int)commandSelectLastId.ExecuteScalar();

                    numberWarehouse += 1;

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

                    string addNewWarehouse = $"INSERT INTO [Склады] ([НомерСклада],[НомерТипаСклада],[НомерКультуры],[ВесХранимого],[Заполнен]) Values (@numberWarehouse, @typeWarehouse, @numberGrain, @inputValue, @fullWarehouse)";
                    SqlCommand commandAddNewWarehouse = new SqlCommand(addNewWarehouse, connection);

                    commandAddNewWarehouse.Parameters.AddWithValue("@numberWarehouse", numberWarehouse);
                    commandAddNewWarehouse.Parameters.AddWithValue("@typeWarehouse", comboBox2.SelectedValue);
                    commandAddNewWarehouse.Parameters.AddWithValue("@numberGrain",comboBox1.SelectedValue);
                    commandAddNewWarehouse.Parameters.AddWithValue("@inputValue", textBox1.Text);
                    commandAddNewWarehouse.Parameters.AddWithValue("@fullWarehouse", comboBox3.Text);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = commandAddNewWarehouse;

                    if (commandAddNewWarehouse.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Склад успешно добавлен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ОкноПросмотраСкладов окноПросмотраСкладов = new ОкноПросмотраСкладов();
                        окноПросмотраСкладов.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Произошла ошибка при добавлении склада, попробуйте ещё раз!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
