using System;
using System.Drawing;
using System.Windows.Forms;
// Подключаем библиотеку для Chart
using System.Windows.Forms.DataVisualization.Charting;

namespace tema4
{
    public partial class Form1 : Form
    {
        // Экземпляр нашего класса для хранения данных опроса
        private ArrayCandidate pollData;

        public Form1()
        {
            InitializeComponent();
            // Инициализация пустого опроса при запуске
            pollData = new ArrayCandidate();
            // Настройка таблицы
            SetupDataGridView();
        }

        /// <summary>
        /// Настройка колонок DataGridView
        /// </summary>
        private void SetupDataGridView()
        {
            dataGridViewResults.Columns.Clear();
            dataGridViewResults.Columns.Add("Name", "Кандидат");
            dataGridViewResults.Columns.Add("Votes", "Голоса");
            dataGridViewResults.Columns.Add("Percent", "Доля, %");

            dataGridViewResults.Columns["Name"].Width = 200;
            dataGridViewResults.Columns["Votes"].Width = 100;
            dataGridViewResults.Columns["Percent"].Width = 100;

            // Запрещаем добавление новых строк с помощью "*"
            dataGridViewResults.AllowUserToAddRows = false;
            dataGridViewResults.ReadOnly = true;
        }

        /// <summary>
        /// Обновляет отображение данных во второй и третьей вкладках.
        /// </summary>
        private void UpdateDisplay()
        {
            // --- Обновление DataGridView ---
            dataGridViewResults.Rows.Clear();

            // Проверяем, есть ли данные
            if (pollData != null && pollData.Count > 0)
            {
                for (int i = 0; i < pollData.Count; i++)
                {
                    Candidate c = pollData[i];
                    if (c != null)
                    {
                        // Получаем процент 
                        string percentString = pollData.Procent.Count > i
                            ? pollData.Procent[i].ToString("P2")
                            : "0%";

                        dataGridViewResults.Rows.Add(c.Name, c.Vote, percentString);
                    }
                }
            }

            // --- Обновление диаграммы ---
            DrawChart();
        }

        /// <summary>
        /// Метод для рисования круговой диаграммы 
        /// </summary>
        private void DrawChart()
        {
            // Очищаем предыдущие данные и настройки диаграммы
            chartPoll.Series.Clear();
            chartPoll.Titles.Clear();
            chartPoll.ChartAreas.Clear();

            // Если нет данных, выходим
            if (pollData == null || pollData.Count == 0)
                return;

            // Добавляем область для диаграммы
            ChartArea area = new ChartArea("MainArea");
            chartPoll.ChartAreas.Add(area);

            // Включаем 3D стиль
            area.Area3DStyle.Enable3D = true;
            area.Area3DStyle.Inclination = 30;
            area.Area3DStyle.Rotation = 10;

            // Добавляем заголовок диаграммы
            Title title = new Title("Результаты голосования", Docking.Top, new Font("Arial", 12, FontStyle.Bold), Color.Black);
            chartPoll.Titles.Add(title);

            // Создаем новую серию для круговой диаграммы
            Series series = new Series("VotesSeries");
            series.ChartType = SeriesChartType.Pie;
            series.ChartArea = "MainArea";

            // Настраиваем отображение меток с процентами
            series.Label = "#PERCENT{P2}"; // Показываем процент с 2 знаками
            series.LegendText = "#VALX";    // В легенде показываем имя кандидата
            series.Font = new Font("Arial", 8);

            // Заполняем серию данными
            for (int i = 0; i < pollData.Count; i++)
            {
                Candidate c = pollData[i];
                if (c != null)
                {
                    // Добавляем точку: аргумент (X = Имя) и значение (Y = Голоса)
                    series.Points.AddXY(c.Name, c.Vote);
                }
            }

            // Добавляем серию на диаграмму
            chartPoll.Series.Add(series);

            // Настраиваем легенду
            chartPoll.Legends.Clear();
            Legend legend = new Legend("MainLegend");
            legend.Docking = Docking.Right;
            legend.Alignment = StringAlignment.Center;
            legend.Font = new Font("Arial", 9);
            chartPoll.Legends.Add(legend);
            series.Legend = "MainLegend";
        }

        // --- Обработчики событий ---

        /// <summary>
        /// Обработчик кнопки "Добавить кандидата".
        /// </summary>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // 1. Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введите имя кандидата.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxVotes.Text))
            {
                MessageBox.Show("Введите количество голосов.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Попытка преобразовать голоса в число
            if (!int.TryParse(textBoxVotes.Text, out int votes) || votes < 0)
            {
                MessageBox.Show("Количество голосов должно быть целым неотрицательным числом.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Создаем кандидата и добавляем
            Candidate newCandidate = new Candidate(textBoxName.Text, votes);
            pollData.Add(newCandidate);

            // 4. Пересчитываем проценты
            pollData.CalculateAllPercentages();

            // 5. Очищаем поля ввода
            textBoxName.Clear();
            textBoxVotes.Clear();

            // 6. Обновляем таблицу и диаграмму
            UpdateDisplay();
        }

        /// <summary>
        /// Обработчик кнопки "Сохранить в файл"
        /// </summary>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Проверяем, есть ли что сохранять
            if (pollData == null || pollData.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Используем SaveFileDialog для выбора места сохранения
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveDialog.DefaultExt = "txt";
            saveDialog.FileName = "PollResults.txt";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // Сохраняем данные через метод нашего класса
                pollData.SaveToFile(saveDialog.FileName);
                MessageBox.Show("Данные успешно сохранены.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Обработчик кнопки "Загрузить из файла" 
        /// </summary>
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            // Используем OpenFileDialog для выбора файла
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                // Загружаем данные через метод класса
                pollData.LoadFromFile(openDialog.FileName);

                // Обновляем таблицу и диаграмму
                UpdateDisplay();

                MessageBox.Show("Данные успешно загружены.", "Загрузка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Дополнительно: Можно добавить обработку удаления строк из таблицы по нажатию кнопки Delete
        private void dataGridViewResults_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dataGridViewResults.SelectedRows.Count > 0)
            {
                int index = dataGridViewResults.SelectedRows[0].Index;
                if (index >= 0 && index < pollData.Count)
                {
                    pollData.RemoveAt(index);
                    pollData.CalculateAllPercentages();
                    UpdateDisplay();
                }
            }
        }
    }
}