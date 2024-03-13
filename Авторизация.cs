using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace СельскоеХозяйство
{
    public partial class Авторизация : Form
    {
        public Авторизация()
        {
            InitializeComponent();

            loginTimer.Tick += loginTimer_Tick;
        }

        private void Авторизация_Load(object sender, EventArgs e)
        {
            CreateCaptcha();
        }

        string captchaText = "";

        private void button1_Click(object sender, EventArgs e)
        {
            ГлавнаяФорма главнаяФорма = new ГлавнаяФорма();
            главнаяФорма.Show();
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

                    string avtorizationUser = $"SELECT [Роль] FROM [Пользователи] WHERE [Логин]='"+ textBox1.Text +"' AND [Пароль]='"+ textBox2.Text +"'";
                    SqlCommand commandAvtorization = new SqlCommand(avtorizationUser, connection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = commandAvtorization;

                    object result = commandAvtorization.ExecuteScalar();

                    if (captchaText == textBox3.Text)
                    {
                        if (result != null)
                        {
                            string Role = result.ToString();

                            switch (Role)
                            {
                                case "Директор":
                                    ОкноДиректора окноДиректора = new ОкноДиректора();
                                    окноДиректора.Show();
                                    this.Close();
                                    break;

                                case "Руководитель АПК":
                                    ОкноРуководителя окноРуководителя = new ОкноРуководителя();
                                    окноРуководителя.Show();
                                    this.Close();
                                    break;

                                case "Бухгалтер":
                                    ОкноБухгалтера окноБухгалтера = new ОкноБухгалтера();
                                    окноБухгалтера.Show();
                                    this.Close();
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пользователь не найден, неправильный логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Captcha введена неверно, поппробуйте ещё раз!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CheckCaptcha();
                    }

                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateCaptcha()
        {
            Random random = new Random();
            Bitmap bitmap = new Bitmap(200, 50);

            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);

            var charsCaptcha = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var rand = new Random();

            captchaText = new string(Enumerable.Repeat(charsCaptcha, 6).Select(s => s[random.Next(s.Length)]).ToArray());

            Font font = new Font("Comic Sans MS", 24);

            GraphicsPath path = new GraphicsPath();
            path.AddString(captchaText, font.FontFamily, (int)font.Style, font.Size, new Point(0, 0), StringFormat.GenericDefault);
            graphics.DrawPath(new Pen(Color.Black), path);

            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(0, bitmap.Width);
                int y = random.Next(0, bitmap.Height);
                int size = random.Next(1, 5);
                graphics.FillRectangle(new SolidBrush(Color.Gray), x, y, size, size);
            }
            //Вывод капчи в pictureBox
            pictureBox2.Image = bitmap;
        }

        int countAttempts = 0;

        DateTime? blockTime = null;

        private void CheckCaptcha()
        {
            if (countAttempts == 2 && DateTime.Now < blockTime)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                button2.Enabled = false;

                CreateCaptcha();

                loginTimer.Start();

                MessageBox.Show("Вы превысили количество попыток на вход! Попробуйте через некоторое время!");

                return;
            }
            if (textBox3.Text != captchaText)
            {
                countAttempts++;

                if (countAttempts == 2)
                {
                    blockTime = DateTime.Now.AddSeconds(10);
                }
            }
        }

        private void loginTimer_Tick(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            button2.Enabled = true;

            loginTimer.Stop();

            countAttempts = 0;

            blockTime = DateTime.MinValue;
        }
    }
}