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
    public partial class ОкноПросмотраСотрудников : Form
    {
        public ОкноПросмотраСотрудников()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ОкноДиректора окноДиректора = new ОкноДиректора();
            окноДиректора.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ОкноДобавленияСотрудника окноДобавленияСотрудника = new ОкноДобавленияСотрудника();
            окноДобавленияСотрудника.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string numberEmployee = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[0].Value != null)
                    {
                        numberEmployee = selectedRow.Cells[0].Value.ToString();
                    }
                }

                string fio = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[1].Value != null)
                    {
                        fio = selectedRow.Cells[1].Value.ToString();
                    }
                }

                string birthdayDate = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[2].Value != null)
                    {
                        birthdayDate = selectedRow.Cells[2].Value.ToString();
                    }
                }

                string numberPassport = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[3].Value != null)
                    {
                        numberPassport = selectedRow.Cells[3].Value.ToString();
                    }
                }

                string numberPhone = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[4].Value != null)
                    {
                        numberPhone = selectedRow.Cells[4].Value.ToString();
                    }
                }

                string ageInWork = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[5].Value != null)
                    {
                        ageInWork = selectedRow.Cells[5].Value.ToString();
                    }
                }

                ОкноРедактированияДанныхСотрудника окноРедактированияДанныхСотрудника = new ОкноРедактированияДанныхСотрудника(numberEmployee,fio,birthdayDate,numberPassport,numberPhone,ageInWork);
                окноРедактированияДанныхСотрудника.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ОкноПросмотраСотрудников_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сельскоеХозяйствоDataSet.Сотрудники". При необходимости она может быть перемещена или удалена.
            this.сотрудникиTableAdapter.Fill(this.сельскоеХозяйствоDataSet.Сотрудники);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dataGridView1.DataSource;
            bindingSource.Filter = "ФИО like '%" + textBox1.Text + "%'";
            dataGridView1.DataSource = bindingSource;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string connectionString = @"Data Source=TemikPC;Initial Catalog=СельскоеХозяйство;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string deleteFromTable = $"DELETE FROM [Сотрудники] WHERE [НомерСотрудника] = @numberEmployee";
                    SqlCommand commandDeleteFromTable = new SqlCommand(deleteFromTable, connection);

                    commandDeleteFromTable.Parameters.AddWithValue("@numberEmployee", dataGridView1.CurrentRow.Cells[0].Value);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = commandDeleteFromTable;

                    if (commandDeleteFromTable.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Запись удалена!","Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.сотрудникиTableAdapter.Update(this.сельскоеХозяйствоDataSet.Сотрудники);
                        this.сотрудникиTableAdapter.Fill(this.сельскоеХозяйствоDataSet.Сотрудники);
                    }
                    else
                    {
                        MessageBox.Show("Запись не удалена!","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Ошибка при удалении! Неправильно выбрана строка в таблице покупатели!","Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
