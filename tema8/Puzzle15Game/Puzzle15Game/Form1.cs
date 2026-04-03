using System;
using System.Drawing;
using System.Windows.Forms;

namespace Puzzle15Game
{
    public partial class Form1 : Form
    {
        private GameLogic game;
        private Button[,] cells;
        private Timer gameTimer;
        private int timeLeft;
        private int movesCount;
        private string difficulty;
        private bool gameActive;
        private ToolStripStatusLabel statusLabel;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
            CreateMenu();
            CreateGameField();
            CreateStatusBar();
            NewGame();
        }

        private void InitializeGame()
        {
            difficulty = "Средний";
            timeLeft = 300;  // 5 минут по умолчанию
            movesCount = 0;
            gameActive = false;
        }

        private void CreateMenu()
        {
            MenuStrip menuStrip = new MenuStrip();

            // Файл
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("Файл");
            ToolStripMenuItem exitItem = new ToolStripMenuItem("Выход");
            exitItem.Click += (s, e) => Application.Exit();
            fileMenu.DropDownItems.Add(exitItem);

            // Настройки
            ToolStripMenuItem settingsMenu = new ToolStripMenuItem("Настройки");
            ToolStripMenuItem difficultyItem = new ToolStripMenuItem("Уровень сложности");

            // Увеличенное время
            ToolStripMenuItem easyItem = new ToolStripMenuItem("Легкий (10 мин)");
            ToolStripMenuItem mediumItem = new ToolStripMenuItem("Средний (5 мин)");
            ToolStripMenuItem hardItem = new ToolStripMenuItem("Сложный (3 мин)");

            easyItem.Click += (s, e) => SetDifficulty("Легкий", 600);
            mediumItem.Click += (s, e) => SetDifficulty("Средний", 300);
            hardItem.Click += (s, e) => SetDifficulty("Сложный", 180);

            difficultyItem.DropDownItems.Add(easyItem);
            difficultyItem.DropDownItems.Add(mediumItem);
            difficultyItem.DropDownItems.Add(hardItem);

            ToolStripMenuItem colorItem = new ToolStripMenuItem("Цвет клеток");
            colorItem.Click += ColorSettings_Click;
            settingsMenu.DropDownItems.Add(difficultyItem);
            settingsMenu.DropDownItems.Add(colorItem);

            // Справка
            ToolStripMenuItem helpMenu = new ToolStripMenuItem("Справка");
            ToolStripMenuItem aboutItem = new ToolStripMenuItem("О программе");
            aboutItem.Click += About_Click;
            ToolStripMenuItem resultsItem = new ToolStripMenuItem("Мои результаты");
            resultsItem.Click += ShowResults_Click;
            helpMenu.DropDownItems.Add(aboutItem);
            helpMenu.DropDownItems.Add(resultsItem);

            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(settingsMenu);
            menuStrip.Items.Add(helpMenu);

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void SetDifficulty(string diff, int seconds)
        {
            difficulty = diff;
            timeLeft = seconds;
            if (gameActive)
            {
                NewGame();
            }
        }

        private void ColorSettings_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (cells[i, j].Text != "")
                            cells[i, j].BackColor = colorDialog.Color;
                    }
                }
            }
        }

        private void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Игра «Пятнашки» (Расставь цифры по порядку)\nВерсия 1.0\n\nЦель: расставить числа от 1 до 15 по порядку.\nПеремещайте фишки кликом мыши.", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowResults_Click(object sender, EventArgs e)
        {
            var results = UserAuth.GetResultsForCurrentUser();
            if (results.Count == 0)
            {
                MessageBox.Show("У вас пока нет сохранённых результатов!", "Результаты", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string message = "Ваши результаты:\n\n";
            foreach (var res in results)
            {
                message += $"📅 {res.Date.ToShortDateString()} | {res.Difficulty} | Ходов: {res.Moves} | Время: {res.TimeSeconds} сек\n";
            }
            MessageBox.Show(message, "Мои результаты", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CreateGameField()
        {
            int startY = 40;
            int cellSize = 80;
            Panel panel = new Panel();
            panel.Size = new Size(cellSize * 4 + 10, cellSize * 4 + 10);
            panel.Location = new Point((this.ClientSize.Width - panel.Width) / 2, startY);

            cells = new Button[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(cellSize, cellSize);
                    btn.Location = new Point(j * cellSize, i * cellSize);
                    btn.Font = new Font("Arial", 20, FontStyle.Bold);
                    btn.BackColor = Color.White;

                    // Сохраняем координаты в Tag
                    btn.Tag = new Point(i, j);
                    btn.Click += Cell_Click;

                    cells[i, j] = btn;
                    panel.Controls.Add(btn);
                }
            }
            this.Controls.Add(panel);
        }

        private void CreateStatusBar()
        {
            StatusStrip statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            statusStrip.Items.Add(statusLabel);
            this.Controls.Add(statusStrip);
        }

        private void NewGame()
        {
            game = new GameLogic();
            game.Shuffle(300);
            movesCount = 0;
            gameActive = true;

            if (gameTimer != null)
                gameTimer.Stop();

            gameTimer = new Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

            UpdateBoard();
            UpdateStatus();
        }

        private void UpdateBoard()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int val = game.GetNumberAt(i, j);
                    cells[i, j].Text = val == 0 ? "" : val.ToString();
                    cells[i, j].BackColor = val == 0 ? Color.LightGray : Color.White;
                }
            }
        }

        // Метод обработки клика
        private void Cell_Click(object sender, EventArgs e)
        {
            if (!gameActive) return;

            Button clicked = sender as Button;
            if (clicked == null) return;

            // Получаем координаты из Tag
            Point coords = (Point)clicked.Tag;
            int row = coords.X;
            int col = coords.Y;

            // Пытаемся переместить фишку
            if (game.Move(row, col))
            {
                movesCount++;
                UpdateBoard();
                UpdateStatus();

                if (game.IsSolved())
                {
                    GameWin();
                }
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                UpdateStatus();
            }
            else
            {
                GameLose();
            }
        }

        private void GameWin()
        {
            gameActive = false;
            gameTimer.Stop();

            int spentTime = (difficulty == "Легкий" ? 300 : difficulty == "Средний" ? 120 : 60) - timeLeft;

            UserAuth.SaveResult(new GameResult
            {
                PlayerName = UserAuth.CurrentUser,
                Moves = movesCount,
                TimeSeconds = spentTime,
                Date = DateTime.Now,
                Difficulty = difficulty
            });

            MessageBox.Show($"ПОБЕДА!\n\nХодов: {movesCount}\nВремя: {spentTime} сек\nРезультат сохранён!", "Поздравляем!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            NewGame();
        }

        private void GameLose()
        {
            gameActive = false;
            gameTimer.Stop();
            MessageBox.Show($"Время вышло!\n\nВы не успели собрать головоломку.", "Поражение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            NewGame();
        }

        private void UpdateStatus()
        {
            int minutes = timeLeft / 60;
            int seconds = timeLeft % 60;
            statusLabel.Text = $"Игрок: {UserAuth.CurrentUser} | Сложность: {difficulty} | Время: {minutes:D2}:{seconds:D2} | Ходов: {movesCount}";
        }
    }
}
