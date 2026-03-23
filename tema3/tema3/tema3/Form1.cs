using System;
using System.Drawing;
using System.Windows.Forms;
using tema3;

namespace tema3
{
    public partial class Form1 : Form
    {
        // --- Переменные для управления движением ---
        private int circleRadius = 20;          // Радиус круга
        private int circleX, circleY;           // Координаты левого верхнего угла прямоугольника круга
        private int stepSize = 3;                // Шаг перемещения (скорость)

        // Направления движения по периметру (по часовой стрелке)
        private enum Direction { Right, Down, Left, Up }
        private Direction currentDirection = Direction.Right; // Текущее направление
        private int stepCounter = 0;             // Счетчик шагов на текущей стороне

        // Цвета для смены на каждой стороне
        private Color[] sideColors = { Color.Red, Color.Blue, Color.Green, Color.Yellow };
        private int colorIndex = 0;              // Индекс текущего цвета

        // Флаг для остановки движения
        private bool isMoving = true;

        // Переменная для хранения текущей скорости (интервала таймера)
        private int currentSpeed = 5; // Значение от 1 до 10

        // --- Конструктор ---
        public Form1()
        {
            InitializeComponent();
            SetInitialPosition();
        }

        // --- Установка начальной позиции круга (левый верхний угол) ---
        private void SetInitialPosition()
        {
            circleX = circleRadius;
            circleY = circleRadius;
            currentDirection = Direction.Right;
            stepCounter = 0;
            colorIndex = 0;
        }

        // --- Обработчик рисования ---
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            using (SolidBrush brush = new SolidBrush(sideColors[colorIndex]))
            {
                g.FillEllipse(brush, circleX, circleY, 2 * circleRadius, 2 * circleRadius);
            }
        }

        // --- Обработчик таймера (движение) ---
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isMoving) return; // Если движение остановлено, ничего не делаем

            // Получаем актуальные размеры клиентской области формы
            int clientWidth = this.ClientSize.Width;
            int clientHeight = this.ClientSize.Height;

            // Эффективная ширина/высота для движения (с учетом радиуса)
            int maxX = clientWidth - 2 * circleRadius;
            int maxY = clientHeight - 2 * circleRadius;

            // Если форма слишком маленькая, выходим
            if (maxX <= 0 || maxY <= 0) return;

            // Двигаем круг в зависимости от направления
            switch (currentDirection)
            {
                case Direction.Right:
                    circleX += stepSize;
                    break;
                case Direction.Down:
                    circleY += stepSize;
                    break;
                case Direction.Left:
                    circleX -= stepSize;
                    break;
                case Direction.Up:
                    circleY -= stepSize;
                    break;
            }

            stepCounter += stepSize;

            // Проверяем, не пора ли сменить направление (дошли до угла)
            bool needChange = false;
            switch (currentDirection)
            {
                case Direction.Right:
                    if (circleX >= maxX) needChange = true;
                    break;
                case Direction.Down:
                    if (circleY >= maxY) needChange = true;
                    break;
                case Direction.Left:
                    if (circleX <= circleRadius) needChange = true;
                    break;
                case Direction.Up:
                    if (circleY <= circleRadius) needChange = true;
                    break;
            }

            // Если нужно сменить направление
            if (needChange)
            {
                // Переходим к следующему направлению
                currentDirection = (Direction)(((int)currentDirection + 1) % 4);
                stepCounter = 0;

                // Меняем цвет
                colorIndex = (colorIndex + 1) % sideColors.Length;

                // Корректируем координаты, чтобы круг точно был в углу
                switch (currentDirection)
                {
                    case Direction.Right:  // Сейчас будем двигаться вправо (значит мы в левом верхнем углу)
                        circleX = circleRadius;
                        circleY = circleRadius;
                        break;
                    case Direction.Down:   // Будем двигаться вниз (мы в правом верхнем углу)
                        circleX = maxX;
                        circleY = circleRadius;
                        break;
                    case Direction.Left:   // Будем двигаться влево (мы в правом нижнем углу)
                        circleX = maxX;
                        circleY = maxY;
                        break;
                    case Direction.Up:     // Будем двигаться вверх (мы в левом нижнем углу)
                        circleX = circleRadius;
                        circleY = maxY;
                        break;
                }
            }

            // Перерисовываем форму
            this.Invalidate();
        }

        // --- Обработчик изменения размеров формы ---
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                // Корректируем позицию круга, чтобы он не оказался за границами
                int clientWidth = this.ClientSize.Width;
                int clientHeight = this.ClientSize.Height;
                int maxX = clientWidth - 2 * circleRadius;
                int maxY = clientHeight - 2 * circleRadius;

                if (maxX > 0 && maxY > 0)
                {
                    circleX = Math.Max(circleRadius, Math.Min(circleX, maxX));
                    circleY = Math.Max(circleRadius, Math.Min(circleY, maxY));
                }
                this.Invalidate();
            }
        }

        // --- Кнопка "Стоп" ---
        private void btnStop_Click(object sender, EventArgs e)
        {
            isMoving = !isMoving; // Переключаем состояние (Стоп/Пуск)
            btnStop.Text = isMoving ? "Стоп" : "Пуск"; // Меняем текст кнопки
        }

        // --- Кнопка "Настройки" ---
        private void btnSettings_Click(object sender, EventArgs e)
        {
            // Создаем форму настроек, передаем текущие параметры
            using (SettingsForm settingsForm = new SettingsForm(sideColors[colorIndex], currentSpeed))
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    // Применяем цвет (заменяем текущий цвет в палитре)
                    sideColors[colorIndex] = settingsForm.SelectedColor;

                    // Применяем скорость
                    currentSpeed = settingsForm.SpeedValue;

                    // Преобразуем значение скорости (1-10) в интервал таймера (100-10 мс)
                    // 1 -> 100 мс (медленно), 10 -> 10 мс (быстро)
                    timer1.Interval = 110 - currentSpeed * 10;
                }
            }
        }
    }
}