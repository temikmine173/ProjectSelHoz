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
    public partial class ОкноДобавленияСотрудника : Form
    {
        public ОкноДобавленияСотрудника()
        {
            InitializeComponent();
        }

        int numberEmployee;

        private void ОкноДобавленияСотрудника_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=TemikPC;Initial Catalog=СельскоеХозяйство;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectLastId = $"SELECT MAX([НомерСотрудника]) FROM [Сотрудники]";
                    SqlCommand commandSelectLastId = new SqlCommand(selectLastId, connection);
                    numberEmployee = (int)commandSelectLastId.ExecuteScalar();

                    numberEmployee += 1;

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
            ОкноПросмотраСотрудников окноПросмотраСотрудников = new ОкноПросмотраСотрудников();
            окноПросмотраСотрудников.Show();
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

                    string addNewEmployee = $"INSERT INTO [Сотрудники] ([НомерСотрудника],[ФИО],[ДатаРождения],[НомерПаспорта],[НомерТелефона],[СтажРаботы]) Values (@numberEmployee,@fio,@birthdayDate,@numberPassport,@numberPhone,@ageInWork)";
                    SqlCommand commandAddNewEmployee = new SqlCommand(addNewEmployee, connection);

                    commandAddNewEmployee.Parameters.AddWithValue("@numberEmployee", numberEmployee);
                    commandAddNewEmployee.Parameters.AddWithValue("@fio",textBox1.Text);
                    commandAddNewEmployee.Parameters.AddWithValue("@birthdayDate",dateTimePicker1.Value);
                    commandAddNewEmployee.Parameters.AddWithValue("@numberPassport",maskedTextBox1.Text);
                    commandAddNewEmployee.Parameters.AddWithValue("@numberPhone",maskedTextBox2.Text);
                    commandAddNewEmployee.Parameters.AddWithValue("@ageInWork", textBox2.Text);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = commandAddNewEmployee;

                    if (commandAddNewEmployee.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Сотрудник успешно добавлен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ОкноПросмотраСотрудников окноПросмотраСотрудников = new ОкноПросмотраСотрудников();
                        окноПросмотраСотрудников.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Произошла ошибка при добавлении сотрудника, попробуйте ещё раз!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
