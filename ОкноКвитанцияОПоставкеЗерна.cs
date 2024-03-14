using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace СельскоеХозяйство
{
    public partial class ОкноКвитанцияОПоставкеЗерна : Form
    {
        public ОкноКвитанцияОПоставкеЗерна()
        {
            InitializeComponent();
        }

        int numberDelivery;
        string numberCustomer, numberGrain, numberEmployee, count, priceDelivery;

        private void button1_Click(object sender, EventArgs e)
        {
            ОкноДокументы окноДокументы = new ОкноДокументы();
            окноДокументы.Show();
            this.Close();
        }

        private void ОкноКвитанцияОПоставкеЗерна_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сельскоеХозяйствоDataSet.ПоставкиЗерна". При необходимости она может быть перемещена или удалена.
            this.поставкиЗернаTableAdapter.Fill(this.сельскоеХозяйствоDataSet.ПоставкиЗерна);

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=TemikPC;Initial Catalog=СельскоеХозяйство;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectInfoFromDeliveryGrain = $"SELECT [НомерПоставки],[НомерЗаказчика],[НомерСотрудника],[НомерКультуры],[КоличествоПоставляемого],[ЦенаПоставки] FROM [ПоставкиЗерна] WHERE [НомерПоставки]='" + comboBox1.SelectedValue + "'";
                    SqlCommand commandSelectInfoFromDeliveryGrain = new SqlCommand(selectInfoFromDeliveryGrain, connection);
                    SqlDataReader reader = commandSelectInfoFromDeliveryGrain.ExecuteReader();

                    while (reader.Read())
                    {
                        numberDelivery = Int32.Parse(reader["НомерПоставки"].ToString());
                        numberCustomer = reader["НомерЗаказчика"].ToString();
                        numberGrain = reader["НомерКультуры"].ToString();
                        numberEmployee = reader["НомерСотрудника"].ToString();
                        count = reader["КоличествоПоставляемого"].ToString();
                        priceDelivery = reader["ЦенаПоставки"].ToString();
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
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Создайте документ PDF
                Document document = new Document();

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF файлы (*.pdf)|*.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string savePath = saveFileDialog.FileName;
                    // Создайте экземпляр PdfWriter и передайте документ и путь сохранения
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(savePath, FileMode.Create));
                    // Откройте документ PDF для записи
                    BaseFont baseFont = BaseFont.CreateFont(@"C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
                    
                    document.Open();
                    document.NewPage();

                    // Здесь вы можете использовать reader.GetInt32, reader.GetString, и так далее
                    Paragraph paragraph1 = new Paragraph("Номер поставки: " + numberDelivery, font);
                    Paragraph paragraph2 = new Paragraph("Номер заказчика: " +  numberCustomer, font);
                    Paragraph paragraph3 = new Paragraph("Номер сотрудника: " + numberGrain, font);
                    Paragraph paragraph4 = new Paragraph("Номер культуры: " + numberEmployee, font);
                    Paragraph paragraph5 = new Paragraph("Количество поставляеммого: " + count, font);
                    Paragraph paragraph6 = new Paragraph("Цена поставки: " + priceDelivery + " рублей ", font);

                    document.Add(paragraph1);
                    document.Add(paragraph2);
                    document.Add(paragraph3);
                    document.Add(paragraph4);
                    document.Add(paragraph5);
                    document.Add(paragraph6);

                    document.Close();
                }
                MessageBox.Show("Данные успешно сохранены в PDF!","Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
