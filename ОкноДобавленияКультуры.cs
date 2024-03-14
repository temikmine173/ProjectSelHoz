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
    public partial class ОкноДобавленияКультуры : Form
    {
        public ОкноДобавленияКультуры()
        {
            InitializeComponent();
        }

        int numberGrain;
        private void ОкноДобавленияКультуры_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=TemikPC;Initial Catalog=СельскоеХозяйство;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectLastId = $"SELECT MAX([НомерКультуры]) FROM [Культуры]";
                    SqlCommand commandSelectLastId = new SqlCommand(selectLastId, connection);
                    numberGrain = (int)commandSelectLastId.ExecuteScalar();

                    numberGrain += 1;

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
            ОкноПросмотраКультур окноПросмотраКультур = new ОкноПросмотраКультур();
            окноПросмотраКультур.Show();
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

                    string addNewGrain = $"INSERT INTO [Культуры] ([НомерКультуры],[НаименованиеКультуры],[ЦветКультуры],[СрокСозревания]) Values (@numberGrain, @nameGrain, @colorGrain, @finishDateGrain)";
                    SqlCommand commandAddNewGrain = new SqlCommand(addNewGrain, connection);

                    commandAddNewGrain.Parameters.AddWithValue("@numberGrain", numberGrain);
                    commandAddNewGrain.Parameters.AddWithValue("@nameGrain", textBox1.Text);
                    commandAddNewGrain.Parameters.AddWithValue("@colorGrain", textBox2.Text);
                    commandAddNewGrain.Parameters.AddWithValue("@finishDateGrain", textBox3.Text);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = commandAddNewGrain;

                    if (commandAddNewGrain.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Культура успешно добавлена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ОкноПросмотраКультур окноПросмотраКультур = new ОкноПросмотраКультур();
                        окноПросмотраКультур.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Произошла ошибка при добавлении культура, попробуйте ещё раз!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
