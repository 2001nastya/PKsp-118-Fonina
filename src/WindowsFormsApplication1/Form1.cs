using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser.Height += 55;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //вызовем диалог открытия файла
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                //зададим фильтр на такие файлы (в mhtml не работают скрипты)
                openFileDialog1.Filter = "html files |*.htm; *.html;";


                //если пользователь отменил диалог - выходим
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;

                //форматируем строку к стандарту uri
                String uriString = String.Format("file:///{0}", System.IO.Path.GetFullPath(openFileDialog1.FileName));

                //грузим в браузер этот файл
                webBrowser.Navigate(new Uri(uriString));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения файла! Подробности:" + ex.Message.ToString());
            }
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser.Height -= 55;
            groupBox1.Visible = true;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа вебраузер и вычисление принадлежности. \r\n Фонина Анастасия, 1 вариант");
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                double x = double.Parse(tbX.Text);
                double y = double.Parse(tbY.Text);

                if (!(x * x + y * y == 2 * 2) && (y >= -x) && (x <= -2))
                    MessageBox.Show("Точка принадлежит области");
                else
                    MessageBox.Show("Точка не принадлежит области");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка чтения файла! Подробности:" + ex.Message.ToString());
            }
        }
    }
}
