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
    public partial class ОкноДобавленияТехники : Form
    {
        public ОкноДобавленияТехники()
        {
            InitializeComponent();
        }

        int numberAvto;

        private void button1_Click(object sender, EventArgs e)
        {
            ОкноПросмотраТехники окноПросмотраТехники = new ОкноПросмотраТехники();
            окноПросмотраТехники.Show();
            this.Close();
        }

        private void ОкноДобавленияТехники_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сельскоеХозяйствоDataSet.ТипыТехники". При необходимости она может быть перемещена или удалена.
            this.типыТехникиTableAdapter.Fill(this.сельскоеХозяйствоDataSet.ТипыТехники);
            try
            {
                string connectionString = @"Data Source=TemikPC;Initial Catalog=СельскоеХозяйство;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectLastId = $"SELECT MAX([НомерТехники]) FROM [Техника]";
                    SqlCommand commandSelectLastId = new SqlCommand(selectLastId, connection);
                    numberAvto = (int)commandSelectLastId.ExecuteScalar();

                    numberAvto += 1;

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

                    string addNewAvto = $"INSERT INTO [Склады] ([НомерТехники],[НаименованиеТехники],[НомерТипаТехники],[ЦветТехники],[МощностьТехники]) Values (@numberAvto, @nameAvto, @numberTypeAvto, @colorAvto, @strenghtAvto)";
                    SqlCommand commandAddNewAvto = new SqlCommand(addNewAvto, connection);

                    commandAddNewAvto.Parameters.AddWithValue("@numberAvto", numberAvto);
                    commandAddNewAvto.Parameters.AddWithValue("@nameAvto", textBox1.Text);
                    commandAddNewAvto.Parameters.AddWithValue("@numberTypeAvto", comboBox1.SelectedValue);
                    commandAddNewAvto.Parameters.AddWithValue("@colorAvto", textBox2.Text);
                    commandAddNewAvto.Parameters.AddWithValue("@strenghtAvto", textBox3.Text);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = commandAddNewAvto;

                    if (commandAddNewAvto.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Техника успешно добавлена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ОкноПросмотраТехники окноПросмотраТехники = new ОкноПросмотраТехники();
                        окноПросмотраТехники.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Произошла ошибка при добавлении техники, попробуйте ещё раз!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
