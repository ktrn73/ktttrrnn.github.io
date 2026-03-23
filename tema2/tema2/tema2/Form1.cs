using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tema2
{
    public partial class Form1 : Form
    {
        private List<Point> points; // Хранилище введенных точек

        public Form1()
        {
            InitializeComponent();
            points = new List<Point>();
            listBoxPoints.DataSource = null; // Сброс привязки
            UpdatePointsList();
        }

        // Обновление отображения списка точек в ListBox
        private void UpdatePointsList()
        {
            // Просто очищаем и добавляем точки заново
            listBoxPoints.Items.Clear();

            foreach (Point point in points)
            {
                listBoxPoints.Items.Add(point);  // Добавляем каждую точку
            }

            // Для отладки - покажем количество точек
            groupBoxList.Text = $"Введенные точки ({points.Count})";
        }

        // Обработчик кнопки "Добавить точку"
        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            string xStr = textBoxX.Text.Trim();
            string yStr = textBoxY.Text.Trim();

            // Используем метод TryParsePoint из логического класса для валидации
            string combinedInput = $"{xStr} {yStr}";
            if (GeometryLogic.TryParsePoint(combinedInput, out Point newPoint))
            {
                points.Add(newPoint);
                UpdatePointsList();
                textBoxX.Clear();
                textBoxY.Clear();
                textBoxX.Focus();
                labelResult.Text = "Результат:";
            }
            else
            {
                MessageBox.Show("Некорректный ввод координат. Используйте числа (разделитель ',' или '.')",
                                "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Обработчик кнопки "Найти ближайшие пары"
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                var closestPairs = GeometryLogic.FindClosestPairs(points);

                if (closestPairs.Count == 0)
                {
                    labelResult.Text = "Результат: Недостаточно точек для поиска пар (нужно минимум 2).";
                }
                else
                {
                    double minDist = closestPairs[0].distance;
                    string resultText = $"Минимальное расстояние: {minDist:F4}\nПары:\n";
                    foreach (var pair in closestPairs)
                    {
                        resultText += $"{pair.p1} - {pair.p2}\n";
                    }
                    labelResult.Text = resultText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при вычислении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик кнопки "Очистить"
        private void btnClear_Click(object sender, EventArgs e)
        {
            points.Clear();
            UpdatePointsList();
            textBoxX.Clear();
            textBoxY.Clear();
            labelResult.Text = "Результат:";
        }
    }
}