using System;
using System.IO; // Добавил библиотек для сохранения
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextEdit_16_03_2022
{
    public partial class Form1 : Form
    {
        static string filename = "";
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text File(*.txt)|*.txt|RTF File(*.rtf)|*.rtf";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // Для даты
        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToLongDateString();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Спрашиваем, был ли результат  диалога нажатием на кнопку отмена
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            // Сохраняем содержимое ричбокса в стринг
            File.WriteAllText(filename, textBox1.Text);
            MessageBox.Show("Файл сохранён получается.");
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // По аналогии с проверкой выше
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            filename = openFileDialog1.FileName;
            string fileText = File.ReadAllText(filename);
            textBox1.Text = fileText;
            MessageBox.Show("Файл открыт получается");
        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(filename))
                File.WriteAllText(filename, textBox1.Text);
        }
        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
                textBox1.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
                textBox1.Paste();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
                textBox1.Cut();
        }
        //Настройки шрифта
        private void цветШрифтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;

            fontDialog1.Font = textBox1.Font;
            fontDialog1.Color = textBox1.ForeColor;

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                textBox1.Font = fontDialog1.Font;
                textBox1.ForeColor = fontDialog1.Color;
            }
        }
        private void настройкиФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            textBox1.BackColor = colorDialog1.Color;
        }

        private void выделитьВсёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
                textBox1.SelectAll();
        }

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                textBox1.ContextMenuStrip = contextMenuStrip1;
        }
        // Правая кнопка, функционал контекстного меню
        private void копироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
                textBox1.Copy();
        }

        private void вставитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
                textBox1.Paste();
        }

        private void вырезатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
                textBox1.Cut();
        }

        private void выделитьВсёToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
                textBox1.SelectAll();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void титрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Работу выполнил студент группы ЭИСБ-24\nРоманычев Даниил Алексеевич получается.");
        }
    }
}