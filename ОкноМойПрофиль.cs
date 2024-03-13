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
    public partial class ОкноМойПрофиль : Form
    {
        public ОкноМойПрофиль()
        {
            InitializeComponent();
        }

        int numberUser, numberEmployee;

        private void ОкноМойПрофиль_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=TemikPC;Initial Catalog=СельскоеХозяйство;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectInfoEmployee = $"SELECT [ФИО],[ДатаРождения],[НомерПаспорта],[НомерТелефона],[СтажРаботы],[Пользователи].[Логин],[Пользователи].[Пароль] FROM [Сотрудники] INNER JOIN [Пользователи] ON [Сотрудники].[НомерСотрудника] = [Пользователи].[НомерСотрудника] WHERE [Пользователи].[Пароль]='" + UserData.userPassword + "'";
                    SqlCommand commandSelectInfoEmployee = new SqlCommand(selectInfoEmployee, connection);
                    SqlDataReader reader = commandSelectInfoEmployee.ExecuteReader();

                    while (reader.Read())
                    {
                        textBox1.Text = reader["ФИО"].ToString();
                        dateTimePicker1.Value = DateTime.Parse(reader["ДатаРождения"].ToString());
                        maskedTextBox1.Text = reader["НомерПаспорта"].ToString();
                        maskedTextBox2.Text = reader["НомерТелефона"].ToString();
                        textBox2.Text = reader["Логин"].ToString();
                        textBox3.Text = reader["Пароль"].ToString();
                    }
                    reader.Close();

                    string selectIdEmployee = $"SELECT [Сотрудники].[НомерСотрудника] FROM [Сотрудники] INNER JOIN [Пользователи] ON [Сотрудники].[НомерСотрудника] = [Пользователи].[НомерСотрудника] WHERE [Пользователи].[Пароль]='" + UserData.userPassword + "'";
                    SqlCommand commandSelectIdEmployee = new SqlCommand(selectIdEmployee, connection);
                    numberEmployee = (int)commandSelectIdEmployee.ExecuteScalar();


                    string selectIdUser = $"SELECT [НомерПользователя] FROM [Пользователи]  WHERE [Пользователи].[Пароль]='" + UserData.userPassword + "'";
                    SqlCommand commandSelectIdUser = new SqlCommand(selectIdUser, connection);
                    numberUser = (int)commandSelectIdUser.ExecuteScalar();

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
            try
            {
                string connectionString = @"Data Source=TemikPC;Initial Catalog=СельскоеХозяйство;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string backInMenu = $"SELECT [Роль] FROM [Пользователи] WHERE [Пароль]='"+ UserData.userPassword +"'";
                    SqlCommand commandBackInMenu = new SqlCommand(backInMenu, connection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = commandBackInMenu;

                    object result = commandBackInMenu.ExecuteScalar();

                    if (result != null)
                    {
                        string Role = result.ToString();

                        switch (Role)
                        {
                            case "Директор":
                                ОкноДиректора окноДиректора = new ОкноДиректора();
                                окноДиректора.Show();
                                this.Close();
                                break;

                            case "Руководитель АПК":
                                ОкноРуководителя окноРуководителя = new ОкноРуководителя();
                                окноРуководителя.Show();
                                this.Close();
                                break;

                            case "Бухгалтер":
                                ОкноБухгалтера окноБухгалтера = new ОкноБухгалтера();
                                окноБухгалтера.Show();
                                this.Close();
                                break;
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label8.Visible = true;
                textBox4.Visible = true;
                textBox3.Enabled = true;
            }
            else
            {
                label8.Visible = false;
                textBox4.Visible = false;
                textBox3.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                try
                {
                    string connectionString = @"Data Source=TemikPC;Initial Catalog=СельскоеХозяйство;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string updateInfoEmployee = $"UPDATE [Сотрудники] SET [ФИО]='" + textBox1.Text + "', [ДатаРождения]='" + dateTimePicker1.Value + "', [НомерПаспорта]='" + maskedTextBox1.Text + "', [НомерТелефона]='" + maskedTextBox2.Text + "' WHERE [НомерСотрудника]='" + numberEmployee + "'";
                        SqlCommand commandUpdateInfoEmployee = new SqlCommand(updateInfoEmployee, connection);
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                        sqlDataAdapter.SelectCommand = commandUpdateInfoEmployee;

                        string updateLoginAndPassword = $"UPDATE [Пользователи] SET [Логин]='"+ textBox2.Text +"', [Пароль]='"+ textBox3.Text +"' WHERE [НомерПользователя]='"+ numberUser +"'";
                        SqlCommand commandUpdateLoginAndPassword = new SqlCommand(updateLoginAndPassword, connection);
                        sqlDataAdapter.SelectCommand = commandUpdateLoginAndPassword;

                        if (textBox4.Text == textBox3.Text)
                        {
                            if (commandUpdateInfoEmployee.ExecuteNonQuery() == 1 && commandUpdateLoginAndPassword.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Данные успешно обновлены, авторизуйтесь снова для работы в системе!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Авторизация авторизация = new Авторизация();
                                авторизация.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Произошла ошибка при обновлении данных, попробуйте ещё раз!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    string connectionString = @"Data Source=TemikPC;Initial Catalog=СельскоеХозяйство;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string updateInfoEmployee = $"UPDATE [Сотрудники] SET [ФИО]='" + textBox1.Text + "', [ДатаРождения]='" + dateTimePicker1.Value + "', [НомерПаспорта]='" + maskedTextBox1.Text + "', [НомерТелефона]='" + maskedTextBox2.Text + "' WHERE [НомерСотрудника]='" + numberEmployee + "'";
                        SqlCommand commandUpdateInfoEmployee = new SqlCommand(updateInfoEmployee, connection);
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                        sqlDataAdapter.SelectCommand = commandUpdateInfoEmployee;

                        string updateLoginAndPassword = $"UPDATE [Пользователи] SET [Логин]='" + textBox2.Text + "', [Пароль]='" + textBox3.Text + "' WHERE [НомерПользователя]='" + numberUser + "'";
                        SqlCommand commandUpdateLoginAndPassword = new SqlCommand(updateLoginAndPassword, connection);
                        sqlDataAdapter.SelectCommand = commandUpdateLoginAndPassword;

                        if (commandUpdateInfoEmployee.ExecuteNonQuery() == 1 && commandUpdateLoginAndPassword.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Данные успешно обновлены, авторизуйтесь снова для работы в системе!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Авторизация авторизация = new Авторизация();
                            авторизация.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Произошла ошибка при обновлении данных, попробуйте ещё раз!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
}