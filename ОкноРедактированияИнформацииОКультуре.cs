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
    public partial class ОкноРедактированияИнформацииОКультуре : Form
    {
        public ОкноРедактированияИнформацииОКультуре(string numberGrain, string nameGrain, string colorGrain, string finishDateGrain)
        {
            InitializeComponent();
            this.numberGrain = numberGrain;
            this.nameGrain = nameGrain;
            this.colorGrain = colorGrain;
            this.finishDateGrain = finishDateGrain;
        }

        private string numberGrain, nameGrain, colorGrain, finishDateGrain;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=TemikPC;Initial Catalog=СельскоеХозяйство;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateInfoGrain = $"UPDATE [Культуры] SET [НаименованиеКультуры]='" + textBox1.Text + "',[ЦветКультуры]='" + textBox2.Text + "',[СрокСозревания]='" + textBox3.Text + "' WHERE [НомерКультуры]='" + Int32.Parse(numberGrain) + "'";
                    SqlCommand commandUpdateInfoGrain = new SqlCommand(updateInfoGrain, connection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = commandUpdateInfoGrain;

                    if (commandUpdateInfoGrain.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ОкноПросмотраКультур окноПросмотраКультур = new ОкноПросмотраКультур();
                        окноПросмотраКультур.Show();
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

        private void ОкноРедактированияИнформацииОКультуре_Load(object sender, EventArgs e)
        {
            textBox1.Text = nameGrain;
            textBox2.Text = colorGrain;
            textBox3.Text = finishDateGrain;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ОкноПросмотраКультур окноПросмотраКультур = new ОкноПросмотраКультур();
            окноПросмотраКультур.Show();
            this.Close();
        }
    }
}
