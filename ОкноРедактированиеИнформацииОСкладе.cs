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
    public partial class ОкноРедактированиеИнформацииОСкладе : Form
    {
        public ОкноРедактированиеИнформацииОСкладе(string numberWarehouse, string typeWarehouse, string numberGrain, string inputValue, string fullWarehouse)
        {
            InitializeComponent();
            this.numberWarehouse = numberWarehouse;
            this.typeWarehouse = typeWarehouse;
            this.numberGrain = numberGrain;
            this.inputValue = inputValue;
            this.fullWarehouse = fullWarehouse;
        }

        private string numberWarehouse, typeWarehouse, numberGrain, inputValue, fullWarehouse;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=TemikPC;Initial Catalog=СельскоеХозяйство;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateInfoGrain = $"UPDATE [Склады] SET [НомерТипаСклада]='" + comboBox2.SelectedValue + "',[НомерКультуры]='" + comboBox1.SelectedValue + "',[ВесХранимого]='" + textBox1.Text + "',[Заполнен]='" + comboBox3.Text + "' WHERE [НомерСклада]='" + Int32.Parse(numberWarehouse) + "'";
                    SqlCommand commandUpdateInfoGrain = new SqlCommand(updateInfoGrain, connection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = commandUpdateInfoGrain;

                    if (commandUpdateInfoGrain.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ОкноПросмотраСкладов окноПросмотраСкладов = new ОкноПросмотраСкладов();
                        окноПросмотраСкладов.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            ОкноПросмотраСкладов окноПросмотраСкладов = new ОкноПросмотраСкладов();
            окноПросмотраСкладов.Show();
            this.Close();
        }

        private void ОкноРедактированиеИнформацииОСкладе_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedValue = Int32.Parse(typeWarehouse);
            comboBox1.SelectedValue = Int32.Parse(numberGrain);
            textBox1.Text = inputValue;
            comboBox3.Text = fullWarehouse;
        }
    }
}
