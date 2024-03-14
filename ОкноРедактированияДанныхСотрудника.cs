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
    public partial class ОкноРедактированияДанныхСотрудника : Form
    {
        public ОкноРедактированияДанныхСотрудника(string numberEmployee,string fio,string birthdayDate,string numberPassport,string numberPhone,string ageInWork)
        {
            InitializeComponent();
            this.numberEmployee = numberEmployee;
            this.fio = fio;
            this.birthdayDate = birthdayDate;
            this.numberPassport = numberPassport;
            this.numberPhone = numberPhone;
            this.ageInWork = ageInWork;
        }

        private string numberEmployee, fio, birthdayDate, numberPassport, numberPhone, ageInWork;

        private void ОкноРедактированияДанныхСотрудника_Load(object sender, EventArgs e)
        {
            textBox1.Text = fio;
            dateTimePicker1.Value = DateTime.Parse(birthdayDate);
            maskedTextBox1.Text = numberPassport;
            maskedTextBox2.Text = numberPhone;
            textBox2.Text = ageInWork;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=TemikPC;Initial Catalog=СельскоеХозяйство;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateInfoEmployee = $"UPDATE [Сотрудники] SET [ФИО]='"+ textBox1.Text +"',[ДатаРождения]='"+ dateTimePicker1.Value +"',[НомерПаспорта]='"+ maskedTextBox1.Text +"',[НомерТелефона]='"+ maskedTextBox2.Text +"',[СтажРаботы]='"+ textBox2.Text +"' WHERE [НомерСотрудника]='"+ Int32.Parse(numberEmployee) +"'";
                    SqlCommand commandUpdateInfoEmployee = new SqlCommand(updateInfoEmployee, connection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = commandUpdateInfoEmployee;

                    if (commandUpdateInfoEmployee.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ОкноПросмотраСотрудников окноПросмотраСотрудников = new ОкноПросмотраСотрудников();
                        окноПросмотраСотрудников.Show();
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
            ОкноПросмотраСотрудников окноПросмотраСотрудников = new ОкноПросмотраСотрудников();
            окноПросмотраСотрудников.Show();
            this.Close();
        }
    }
}
