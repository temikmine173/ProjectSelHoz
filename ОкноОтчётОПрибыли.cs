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
using System.Windows.Forms.DataVisualization.Charting;

namespace СельскоеХозяйство
{
    public partial class ОкноОтчётОПрибыли : Form
    {
        public ОкноОтчётОПрибыли()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ОкноОтчётов окноОтчётов = new ОкноОтчётов();
            окноОтчётов.Show();
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

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                    string selectPriceFromDeliveryGrain = $"SELECT Sum([ЦенаПоставки]) AS ПрибыльОтПоставокЗерна FROM [ПоставкиЗерна]";
                    SqlCommand commandSelectPriceFromDeliveryGrain = new SqlCommand(selectPriceFromDeliveryGrain, connection);

                    string selectPriceFromDeliveryAnimal = $"SELECT SUM([ЦенаПоставки]) AS ПрибыльОтПоставокЖивотных FROM [ПоставкиЖивотных]";
                    SqlCommand commandSelectPriceFromDeliveryAnimal = new SqlCommand(selectPriceFromDeliveryAnimal, connection);

                    int profitFromGrainDeliveries = Convert.ToInt32(commandSelectPriceFromDeliveryGrain.ExecuteScalar());
                    int profitFromAnimalDeliveries = Convert.ToInt32(commandSelectPriceFromDeliveryAnimal.ExecuteScalar());

                    // Добавление результатов в круговую диаграмму
                    chart1.Series["Series1"].Points.AddXY("Прибыль от поставок зерна", profitFromGrainDeliveries);
                    chart1.Series["Series1"].Points.AddXY("Прибыль от поставок животных", profitFromAnimalDeliveries);

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
