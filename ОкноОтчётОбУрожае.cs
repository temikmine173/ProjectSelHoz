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
    public partial class ОкноОтчётОбУрожае : Form
    {
        public ОкноОтчётОбУрожае()
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

                    string selectGrainInWareHouse = $"SELECT [ВесХранимого] FROM [Склады]";
                    SqlCommand commandSelectGrainInWareHouse = new SqlCommand(selectGrainInWareHouse, connection);

                    SqlDataReader reader = commandSelectGrainInWareHouse.ExecuteReader();

                    // Очистка предыдущих данных в диаграмме
                    chart1.Series["Series1"].Points.Clear();

                    // Добавление результатов в диаграмму
                    while (reader.Read())
                    {
                        int grainCount = Convert.ToInt32(reader["ВесХранимого"]);
                        chart1.Series["Series1"].Points.AddXY("Количество урожая(центеры)", grainCount);
                    }
                    reader.Close();

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
