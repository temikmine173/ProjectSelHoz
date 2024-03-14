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
    public partial class ОкноПросмотраСкладов : Form
    {
        public ОкноПросмотраСкладов()
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
            ОкноДобавитьСклад окноДобавитьСклад = new ОкноДобавитьСклад();
            окноДобавитьСклад.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string numberWarehouse = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[0].Value != null)
                    {
                        numberWarehouse = selectedRow.Cells[0].Value.ToString();
                    }
                }

                string typeWarehouse = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[1].Value != null)
                    {
                        typeWarehouse = selectedRow.Cells[1].Value.ToString();
                    }
                }

                string numberGrain = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[2].Value != null)
                    {
                        numberGrain = selectedRow.Cells[2].Value.ToString();
                    }
                }

                string inputValue = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[3].Value != null)
                    {
                        inputValue = selectedRow.Cells[3].Value.ToString();
                    }
                }

                string fullWarehouse = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[4].Value != null)
                    {
                        fullWarehouse = selectedRow.Cells[4].Value.ToString();
                    }
                }

                ОкноРедактированиеИнформацииОСкладе окноРедактированиеИнформацииОСкладе = new ОкноРедактированиеИнформацииОСкладе(numberWarehouse, typeWarehouse, numberGrain, inputValue, fullWarehouse);
                окноРедактированиеИнформацииОСкладе.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ОкноПросмотраСкладов_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сельскоеХозяйствоDataSet.Склады". При необходимости она может быть перемещена или удалена.
            this.складыTableAdapter.Fill(this.сельскоеХозяйствоDataSet.Склады);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dataGridView1.DataSource;
            bindingSource.Filter = "ВесХранимого like '%" + textBox1.Text + "%'";
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

                    string deleteFromTable = $"DELETE FROM [Склады] WHERE [НомерСклада] = @numberWarehouse";
                    SqlCommand commandDeleteFromTable = new SqlCommand(deleteFromTable, connection);

                    commandDeleteFromTable.Parameters.AddWithValue("@numberWarehouse", dataGridView1.CurrentRow.Cells[0].Value);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = commandDeleteFromTable;

                    if (commandDeleteFromTable.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Запись удалена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.складыTableAdapter.Update(this.сельскоеХозяйствоDataSet.Склады);
                        this.складыTableAdapter.Fill(this.сельскоеХозяйствоDataSet.Склады);
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
