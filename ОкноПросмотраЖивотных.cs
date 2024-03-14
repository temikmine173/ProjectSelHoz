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
    public partial class ОкноПросмотраЖивотных : Form
    {
        public ОкноПросмотраЖивотных()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ОкноРуководителя окноРуководителя = new ОкноРуководителя();
            окноРуководителя.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ОкноДобавленияЖивотного окноДобавленияЖивотного = new ОкноДобавленияЖивотного();
            окноДобавленияЖивотного.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string numberAnimal = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[0].Value != null)
                    {
                        numberAnimal = selectedRow.Cells[0].Value.ToString();
                    }
                }

                string nameAnimal = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[1].Value != null)
                    {
                        nameAnimal = selectedRow.Cells[1].Value.ToString();
                    }
                }

                string typeAnimal = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[2].Value != null)
                    {
                        typeAnimal = selectedRow.Cells[2].Value.ToString();
                    }
                }

                string colorAnimal = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[3].Value != null)
                    {
                        colorAnimal = selectedRow.Cells[3].Value.ToString();
                    }
                }

                ОкноРедактированияДанныхОЖивотном окноРедактированияДанныхОЖивотном = new ОкноРедактированияДанныхОЖивотном(numberAnimal, nameAnimal, typeAnimal, colorAnimal);
                окноРедактированияДанныхОЖивотном.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ОкноПросмотраЖивотных_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сельскоеХозяйствоDataSet.Животные". При необходимости она может быть перемещена или удалена.
            this.животныеTableAdapter.Fill(this.сельскоеХозяйствоDataSet.Животные);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сельскоеХозяйствоDataSet.Животные". При необходимости она может быть перемещена или удалена.
            this.животныеTableAdapter.Fill(this.сельскоеХозяйствоDataSet.Животные);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dataGridView1.DataSource;
            bindingSource.Filter = "НаименованиеЖивотного like '%" + textBox1.Text + "%'";
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

                    string deleteFromTable = $"DELETE FROM [Животные] WHERE [НомерЖивотного] = @numberAnimal";
                    SqlCommand commandDeleteFromTable = new SqlCommand(deleteFromTable, connection);

                    commandDeleteFromTable.Parameters.AddWithValue("@numberAnimal", dataGridView1.CurrentRow.Cells[0].Value);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = commandDeleteFromTable;

                    if (commandDeleteFromTable.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Запись удалена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.животныеTableAdapter.Update(this.сельскоеХозяйствоDataSet.Животные);
                        this.животныеTableAdapter.Fill(this.сельскоеХозяйствоDataSet.Животные);
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
