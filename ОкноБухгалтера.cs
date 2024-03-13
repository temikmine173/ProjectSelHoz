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
    public partial class ОкноБухгалтера : Form
    {
        public ОкноБухгалтера()
        {
            InitializeComponent();
        }

        string fioUser, greeting;
        private void ОкноБухгалтера_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=TemikPC;Initial Catalog=СельскоеХозяйство;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectFioUser = $"SELECT [ФИО] FROM [Сотрудники] INNER JOIN [Пользователи] ON [Пользователи].[НомерСотрудника] = [Сотрудники].[НомерСотрудника] WHERE [Пользователи].[Пароль]='" + UserData.userPassword + "'";
                    SqlCommand commandSelectFioUser = new SqlCommand(selectFioUser, connection);
                    fioUser = (string)commandSelectFioUser.ExecuteScalar();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            DateTime currenttime = DateTime.Now;

            if (currenttime.Hour >= 6 && currenttime.Hour < 11)
            {
                greeting = "Доброе утро!";
            }
            else if (currenttime.Hour >= 11 && currenttime.Hour < 18)
            {
                greeting = "Добрый день!";
            }
            else
            {
                greeting = "Добрый вечер!";
            }
            label2.Text = greeting + " " + fioUser;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Авторизация авторизация = new Авторизация();
            авторизация.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ОкноМойПрофиль окноМойПрофиль = new ОкноМойПрофиль();
            окноМойПрофиль.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ОкноОтчётов окноОтчётов = new ОкноОтчётов();
            окноОтчётов.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ОкноДокументы окноДокументы = new ОкноДокументы();
            окноДокументы.Show();
            this.Close();
        }
    }
}
