using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace СельскоеХозяйство
{
    public partial class ГлавнаяФорма : Form
    {
        public ГлавнаяФорма()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ОПрограмме aboutBox1 = new ОПрограмме();
            aboutBox1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Авторизация fr2 = new Авторизация();
            fr2.Show();
            this.Hide();
        }

        private void ГлавнаяФорма_Load(object sender, EventArgs e)
        {

        }
    }
}
