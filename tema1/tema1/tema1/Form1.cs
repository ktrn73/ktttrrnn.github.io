using System;
using System.Globalization;
using System.Reflection.Emit;
using System.Windows.Forms;
using TextBox = System.Windows.Forms.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tema1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Точное значение через встроенную функцию Math.Exp
        private double ExactValue(double x)
        {
            return Math.Exp(-x);
        }

        // Вычисление суммы ряда e^(-x)
        private double SeriesSum(double x, double eps, out int iterations)
        {
            double sum = 0;
            double term = 1; // первый член ряда (n=0)
            int n = 0;
            iterations = 0;

            // Суммируем, пока член ряда больше точности
            while (Math.Abs(term) > eps)
            {
                sum += term;
                iterations++;

                // рекуррентная формула: следующий член = предыдущий * (-x)/n
                // для n=1: term = 1 * (-x)/1 = -x
                // для n=2: term = (-x) * (-x)/2 = +x²/2! и т.д.
                n++;
                term = term * (-x) / n;

                // защита от бесконечного цикла (на всякий случай)
                if (iterations > 1000000) break;
            }
            return sum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double eps = double.Parse(textBox1.Text.Replace(',', '.'),
                    CultureInfo.InvariantCulture);
                double x = double.Parse(textBox2.Text.Replace(',', '.'),
                    CultureInfo.InvariantCulture);

                // Проверка диапазона: 0 < eps < 1
                if (eps <= 0 || eps >= 1)
                {
                    label3.Text = "Ошибка: точность должна быть 0 < ε < 1";
                    label3.ForeColor = System.Drawing.Color.DarkRed;
                    return;
                }

                double exact = ExactValue(x);
                int count;
                double sum = SeriesSum(x, eps, out count);

                label3.Text = "Вычисление выполнено успешно!";
                label3.ForeColor = System.Drawing.Color.DarkGreen;
                label4.Text = $"e^(-{x}) = {exact:F10}";
                label5.Text = $"Сумма ряда = {sum:F10}";
                label6.Text = $"Кол-во членов ряда = {count}";
            }
            catch (FormatException)
            {
                label3.Text = "Ошибка формата числа";
                label3.ForeColor = System.Drawing.Color.DarkRed;
                label4.Text = "e^(-x) =";
                label5.Text = "Сумма ряда =";
                label6.Text = "Кол-во членов ряда =";
            }
            catch (Exception ex)
            {
                label3.Text = $"Ошибка: {ex.Message}";
                label3.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        // Блокировка кнопки при пустых полях
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text) &&
                              !string.IsNullOrWhiteSpace(textBox2.Text);
        }

        // Проверка ввода (KeyPress)
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            TextBox tb = sender as TextBox;

            // Разрешаем цифры
            if (char.IsDigit(ch))
                return;

            // Разрешаем backspace
            if (ch == '\b')
                return;

            // Разрешаем минус только в начале и только один
            if (ch == '-' && tb.SelectionStart == 0 && !tb.Text.Contains("-"))
                return;

            // Разрешаем разделитель (точку или запятую) только один
            if ((ch == ',' || ch == '.') && !tb.Text.Contains(",") && !tb.Text.Contains("."))
                return;

            // Все остальное запрещаем
            e.Handled = true;
        }
    }
}