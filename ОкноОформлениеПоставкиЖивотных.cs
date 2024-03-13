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
    public partial class ОкноОформлениеПоставкиЖивотных : Form
    {
        public ОкноОформлениеПоставкиЖивотных()
        {
            InitializeComponent();
        }

        int numberDelivery, numberEmployee;
        string fioUser;

        private void ОкноОформлениеПоставкиЖивотных_Load(object sender, EventArgs e)
        {
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

                    string selectIdEmployee = $"SELECT [НомерСотрудника] FROM [Сотрудники] INNER JOIN [Пользователи] ON [Сотрудники].[НомерСотрудника] = [Пользователи].[НомерСотрудника] WHERE [Пользователи].[Пароль]='"+ UserData.userPassword +"'";
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

                    string addNewDeliveryAnimal = $"INSERT INTO [ПоставкиЖивотных] ([НомерПоставки],[НомерЗаказчика],[НомерЖивотного],[НомерСотрудника],[Количество],[ЦенаПоставки]) Values (@numberDelivery,@numberCustomer,@numberAnimal,@numberEmployee,@count,@priceDelivery)";
                    SqlCommand commandAddNewDeliveryAnimal = new SqlCommand(addNewDeliveryAnimal, connection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                    commandAddNewDeliveryAnimal.Parameters.AddWithValue("@numberDelivery", numberDelivery);
                    commandAddNewDeliveryAnimal.Parameters.AddWithValue("@numberCustomer", comboBox1.SelectedValue);
                    commandAddNewDeliveryAnimal.Parameters.AddWithValue("@numberAnimal",comboBox2.SelectedValue);
                    commandAddNewDeliveryAnimal.Parameters.AddWithValue("@numberEmployee", numberEmployee);
                    commandAddNewDeliveryAnimal.Parameters.AddWithValue("@count", textBox2.Text);
                    commandAddNewDeliveryAnimal.Parameters.AddWithValue("@priceDelivery", SqlMoney.Parse(textBox3.Text));

                    sqlDataAdapter.SelectCommand = commandAddNewDeliveryAnimal;

                    if (commandAddNewDeliveryAnimal.ExecuteNonQuery() == 1)
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
