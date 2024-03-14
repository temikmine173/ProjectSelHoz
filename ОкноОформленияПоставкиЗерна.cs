using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace СельскоеХозяйство
{
    public partial class ОкноОформленияПоставкиЗерна : Form
    {
        public ОкноОформленияПоставкиЗерна()
        {
            InitializeComponent();
        }

        int numberDelivery, numberEmployee;
        string fioUser;

        private void ОкноОформленияПоставкиЗерна_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сельскоеХозяйствоDataSet.Культуры". При необходимости она может быть перемещена или удалена.
            this.культурыTableAdapter.Fill(this.сельскоеХозяйствоDataSet.Культуры);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сельскоеХозяйствоDataSet.Заказчики". При необходимости она может быть перемещена или удалена.
            this.заказчикиTableAdapter.Fill(this.сельскоеХозяйствоDataSet.Заказчики);
            try
            {
                string connectionString = @"Data Source=TemikPC;Initial Catalog=СельскоеХозяйство;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectLastId = $"SELECT MAX([НомерПоставки]) FROM [ПоставкиЖивотных]";
                    SqlCommand commandSelectLatsId = new SqlCommand(selectLastId, connection);
                    numberDelivery = (int)commandSelectLatsId.ExecuteScalar();

                    numberDelivery += 1;

                    string selectIdEmployee = $"SELECT [Сотрудники].[НомерСотрудника] FROM [Сотрудники] INNER JOIN [Пользователи] ON [Сотрудники].[НомерСотрудника] = [Пользователи].[НомерСотрудника] WHERE [Пользователи].[Пароль]='" + UserData.userPassword + "'";
                    SqlCommand commandSelectIdEmployee = new SqlCommand(selectIdEmployee, connection);
                    numberEmployee = (int)commandSelectIdEmployee.ExecuteScalar();

                    string selectFio = $"SELECT [ФИО] FROM [Сотрудники] INNER JOIN [Пользователи] ON [Сотрудники].[НомерСотрудника] = [Пользователи].[НомерСотрудника] WHERE [Пользователи].[Пароль]='" + UserData.userPassword + "'";
                    SqlCommand commandSelectFio = new SqlCommand(selectFio, connection);
                    fioUser = (string)commandSelectFio.ExecuteScalar();

                    textBox1.Text = fioUser;

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
            ОкноДиректора окноДиректора = new ОкноДиректора();
            окноДиректора.Show();
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

                    string addNewDeliveryGrain = $"INSERT INTO [ПоставкиЗерна] ([НомерПоставки],[НомерЗаказчика],[НомерСотрудника],[НомерКультуры],[КоличествоПоставляемого],[ЦенаПоставки]) Values (@numberDelivery,@numberCustomer,@numberGrain,@numberEmployee,@count,@priceDelivery)";
                    SqlCommand commandAddNewDeliveryGrain = new SqlCommand(addNewDeliveryGrain, connection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                    commandAddNewDeliveryGrain.Parameters.AddWithValue("@numberDelivery", numberDelivery);
                    commandAddNewDeliveryGrain.Parameters.AddWithValue("@numberCustomer", comboBox1.SelectedValue);
                    commandAddNewDeliveryGrain.Parameters.AddWithValue("@numberGrain", comboBox2.SelectedValue);
                    commandAddNewDeliveryGrain.Parameters.AddWithValue("@numberEmployee", numberEmployee);
                    commandAddNewDeliveryGrain.Parameters.AddWithValue("@count", textBox2.Text);
                    commandAddNewDeliveryGrain.Parameters.AddWithValue("@priceDelivery", SqlMoney.Parse(textBox3.Text));

                    sqlDataAdapter.SelectCommand = commandAddNewDeliveryGrain;

                    if (commandAddNewDeliveryGrain.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Оформление прошло успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ОкноДиректора окноДиректора = new ОкноДиректора();
                        окноДиректора.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("При оформлении поставки произошла ошибка попробуйте ещё раз!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
