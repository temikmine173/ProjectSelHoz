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
    public partial class ОкноПросмотраКультур : Form
    {
        public ОкноПросмотраКультур()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ОкноРастениеводство окноРастениеводство = new ОкноРастениеводство();
            окноРастениеводство.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ОкноДобавленияКультуры окноДобавленияКультуры = new ОкноДобавленияКультуры();
            окноДобавленияКультуры.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string numberGrain = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[0].Value != null)
                    {
                        numberGrain = selectedRow.Cells[0].Value.ToString();
                    }
                }

                string nameGrain = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[1].Value != null)
                    {
                        nameGrain = selectedRow.Cells[1].Value.ToString();
                    }
                }

                string colorGrain = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[2].Value != null)
                    {
                        colorGrain = selectedRow.Cells[2].Value.ToString();
                    }
                }

                string finishDateGrain = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[3].Value != null)
                    {
                        finishDateGrain = selectedRow.Cells[3].Value.ToString();
                    }
                }

                ОкноРедактированияИнформацииОКультуре окноРедактированияИнформацииОКультуре = new ОкноРедактированияИнформацииОКультуре(numberGrain, nameGrain, colorGrain, finishDateGrain);
                окноРедактированияИнформацииОКультуре.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ОкноПросмотраКультур_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сельскоеХозяйствоDataSet.Культуры". При необходимости она может быть перемещена или удалена.
            this.культурыTableAdapter.Fill(this.сельскоеХозяйствоDataSet.Культуры);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dataGridView1.DataSource;
            bindingSource.Filter = "НаименованиеКультуры like '%" + textBox1.Text + "%'";
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

                    string deleteFromTable = $"DELETE FROM [Культуры] WHERE [НомерКультуры] = @numberGrain";
                    SqlCommand commandDeleteFromTable = new SqlCommand(deleteFromTable, connection);

                    commandDeleteFromTable.Parameters.AddWithValue("@numberGrain", dataGridView1.CurrentRow.Cells[0].Value);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = commandDeleteFromTable;

                    if (commandDeleteFromTable.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Запись удалена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.культурыTableAdapter.Update(this.сельскоеХозяйствоDataSet.Культуры);
                        this.культурыTableAdapter.Fill(this.сельскоеХозяйствоDataSet.Культуры);
                    }
                    else
                    {
                        MessageBox.Show("Запись не удалена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    connection.Close();
                }
            }
        }
    }
}
