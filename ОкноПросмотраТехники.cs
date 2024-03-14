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
    public partial class ОкноПросмотраТехники : Form
    {
        public ОкноПросмотраТехники()
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
            ОкноДобавленияТехники окноДобавленияТехники = new ОкноДобавленияТехники();
            окноДобавленияТехники.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string numberAvto = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[0].Value != null)
                    {
                        numberAvto = selectedRow.Cells[0].Value.ToString();
                    }
                }

                string nameAvto = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[1].Value != null)
                    {
                        nameAvto = selectedRow.Cells[1].Value.ToString();
                    }
                }

                string numberTypeAvto = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[2].Value != null)
                    {
                        numberTypeAvto = selectedRow.Cells[2].Value.ToString();
                    }
                }

                string colorAvto = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[3].Value != null)
                    {
                        colorAvto = selectedRow.Cells[3].Value.ToString();
                    }
                }

                string strenghtAvto = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells[4].Value != null)
                    {
                        strenghtAvto = selectedRow.Cells[4].Value.ToString();
                    }
                }

                ОкноРедактированиеИнформацииОТехнике окноРедактированиеИнформацииОТехнике = new ОкноРедактированиеИнформацииОТехнике(numberAvto,nameAvto,numberTypeAvto,colorAvto,strenghtAvto);
                окноРедактированиеИнформацииОТехнике.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ОкноПросмотраТехники_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сельскоеХозяйствоDataSet.Техника". При необходимости она может быть перемещена или удалена.
            this.техникаTableAdapter.Fill(this.сельскоеХозяйствоDataSet.Техника);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dataGridView1.DataSource;
            bindingSource.Filter = "НаименованиеТехники like '%" + textBox1.Text + "%'";
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

                    string deleteFromTable = $"DELETE FROM [Техника] WHERE [НомерТехники] = @numberAvto";
                    SqlCommand commandDeleteFromTable = new SqlCommand(deleteFromTable, connection);

                    commandDeleteFromTable.Parameters.AddWithValue("@numberAvto", dataGridView1.CurrentRow.Cells[0].Value);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = commandDeleteFromTable;

                    if (commandDeleteFromTable.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Запись удалена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.техникаTableAdapter.Update(this.сельскоеХозяйствоDataSet.Техника);
                        this.техникаTableAdapter.Fill(this.сельскоеХозяйствоDataSet.Техника);
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
