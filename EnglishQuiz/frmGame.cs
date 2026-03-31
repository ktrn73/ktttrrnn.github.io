using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace EnglishQuiz
{
    public partial class frmGame : Form
    {
        private string xmlPath;
        private string currentTopic;
        private QuestionType currentType;
        private int currentLevel = 1;
        private List<Question> allLevelQuestions;
        private List<Question> sessionQuestions; // 5 случайных вопросов
        private int currentQuestionIndex = 0;
        private int score = 0;
        private const int QuestionsPerSession = 5;
        private int timeLeft = 60;
        private Timer tmrQuestion;

        // Элементы Drag & Drop
        private Panel dragPanel;
        private Label draggedLabel = null;

        public frmGame(string xmlPath, string topic)
        {
            InitializeComponent();
            this.xmlPath = xmlPath;
            this.currentTopic = topic;

            tmrQuestion = new Timer();
            tmrQuestion.Interval = 1000;
            tmrQuestion.Tick += TmrQuestion_Tick;

            DetermineTopicType();
            StartLevel(1);
        }

        private void DetermineTopicType()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            XmlNode topicNode = doc.SelectSingleNode($"//topic[@name='{currentTopic}']");

            string typeStr = "anagram";
            if (topicNode?.Attributes["type"] != null)
                typeStr = topicNode.Attributes["type"].Value;

            switch (typeStr.ToLower())
            {
                case "translation": currentType = QuestionType.Translation; break;
                case "fillblank": currentType = QuestionType.FillBlank; break;
                default: currentType = QuestionType.Anagram; break;
            }

            lblTopicType.Text = $"Тип: {GetTypeDisplayName()}";
        }

        private string GetTypeDisplayName()
        {
            switch (currentType)
            {
                case QuestionType.Translation: return "Перевод (Drag&Drop)";
                case QuestionType.FillBlank: return "Вставь слово (Drag&Drop)";
                default: return "Анаграмма";
            }
        }

        private void StartLevel(int level)
        {
            currentLevel = level;
            allLevelQuestions = new List<Question>();
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);

            string xpath = $"//topic[@name='{currentTopic}']/level[@id='{currentLevel}']/question";
            XmlNodeList nodes = doc.SelectNodes(xpath);

            if (nodes == null || nodes.Count == 0)
            {
                MessageBox.Show($"Нет вопросов для уровня {currentLevel}.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            foreach (XmlNode node in nodes)
            {
                Question q = new Question();
                q.Text = node.Attributes["text"]?.Value ?? "";
                q.ImagePath = node.Attributes["src"]?.Value ?? "";
                q.Type = currentType;

                XmlNodeList answers = node.SelectNodes("answer");
                foreach (XmlNode ans in answers)
                {
                    bool isRight = (ans.Attributes["right"]?.Value == "yes");
                    q.Options.Add(new AnswerOption
                    {
                        Text = ans.InnerText.Trim(),
                        IsCorrect = isRight
                    });
                }
                allLevelQuestions.Add(q);
            }

            // Выбираем 5 случайных вопросов
            Random rnd = new Random();
            sessionQuestions = allLevelQuestions.OrderBy(x => rnd.Next()).Take(QuestionsPerSession).ToList();

            currentQuestionIndex = 0;
            score = 0;
            UpdateScoreDisplay();
            lblLevel.Text = $"Уровень: {currentLevel}";
            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            if (currentQuestionIndex >= sessionQuestions.Count)
            {
                FinishLevel();
                return;
            }

            ClearDynamicControls();
            var q = sessionQuestions[currentQuestionIndex];

            lblQuestion.Text = $"{currentQuestionIndex + 1}. {q.Text}";

            // Картинка
            if (!string.IsNullOrEmpty(q.ImagePath) && System.IO.File.Exists(q.ImagePath))
            {
                try { picQuestion.Image = Image.FromFile(q.ImagePath); }
                catch { picQuestion.Image = null; }
            }
            else { picQuestion.Image = null; }

            // Интерфейс
            if (q.Type == QuestionType.Anagram)
                SetupAnagramUI(q);
            else
                SetupDragDropUI(q);

            timeLeft = 60; // Время на вопрос
            lblTimer.Text = $"Время: {timeLeft}с";
            tmrQuestion.Start();
        }

        private void SetupAnagramUI(Question q)
        {
            lblInstruction.Text = "Введите правильное слово:";
            lblInstruction.Visible = true;

            TextBox txt = new TextBox();
            txt.Name = "txtAnagramAnswer";
            txt.Location = new Point(290, 150);
            txt.Size = new Size(200, 30);
            txt.Font = new Font("Segoe UI", 12F);
            Controls.Add(txt);

            Button btn = new Button();
            btn.Text = "Ответить";
            btn.Location = new Point(500, 148);
            btn.Size = new Size(90, 35);
            btn.Click += (s, e) => CheckAnagram(txt, q);
            Controls.Add(btn);

            txt.Focus();
        }

        private void CheckAnagram(TextBox txt, Question q)
        {
            tmrQuestion.Stop();
            string user = txt.Text.Trim().ToLower();
            string correct = q.GetCorrectAnswerText().ToLower();

            if (user == correct)
            {
                score += 20;
                MessageBox.Show("Верно! (+20)", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Ошибка. Правильно: {correct}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            NextStep();
        }

        private void SetupDragDropUI(Question q)
        {
            lblInstruction.Text = "Перетащите правильный ответ в желтое поле:";
            lblInstruction.Visible = true;

            // Зона сброса
            Panel dropZone = new Panel();
            dropZone.BackColor = Color.LightYellow;
            dropZone.BorderStyle = BorderStyle.FixedSingle;
            dropZone.Size = new Size(250, 50);
            dropZone.Location = new Point(290, 200);
            dropZone.AllowDrop = true;
            dropZone.DragEnter += (s, e) => { if (e.Data.GetDataPresent(DataFormats.Text)) e.Effect = DragDropEffects.Move; };
            dropZone.DragDrop += (s, e) => CheckDragDrop(e, q);
            Controls.Add(dropZone);

            Label lblHint = new Label();
            lblHint.Text = "⟵ Сюда ⟶";
            lblHint.Location = new Point(290, 175);
            Controls.Add(lblHint);

            // Панель вариантов
            dragPanel = new Panel();
            dragPanel.BackColor = Color.LightGray;
            dragPanel.Size = new Size(240, 160);
            dragPanel.Location = new Point(290, 260);
            Controls.Add(dragPanel);

            int y = 10;
            // Перемешиваем варианты для отображения
            var shuffledOptions = q.Options.OrderBy(x => Guid.NewGuid()).ToList();

            foreach (var opt in shuffledOptions)
            {
                Label lbl = new Label();
                lbl.Text = opt.Text;
                lbl.BackColor = Color.White;
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.Size = new Size(220, 30);
                lbl.Location = new Point(10, y);
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Cursor = Cursors.Hand;
                lbl.MouseDown += (s, ev) => {
                    draggedLabel = lbl;
                    lbl.DoDragDrop(lbl.Text, DragDropEffects.Move);
                };
                dragPanel.Controls.Add(lbl);
                y += 35;
            }
        }

        private void CheckDragDrop(DragEventArgs e, Question q)
        {
            tmrQuestion.Stop();
            string dropped = e.Data.GetData(DataFormats.Text).ToString();
            string correct = q.GetCorrectAnswerText();

            if (dropped == correct)
            {
                score += 20;
                MessageBox.Show("Верно! (+20)", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Ошибка. Правильно: {correct}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            NextStep();
        }

        private void NextStep()
        {
            UpdateScoreDisplay();
            currentQuestionIndex++;
            ShowNextQuestion();
        }

        private void ClearDynamicControls()
        {
            var toRemove = Controls.Cast<Control>()
                .Where(c => c.Name == "txtAnagramAnswer" ||
                            (c is Button b && b.Text == "Ответить") ||
                            (c is Panel p && (p.BackColor == Color.LightYellow || p.BackColor == Color.LightGray)) ||
                            (c is Label l && (l.Text == "⟵ Сюда ⟶" || l.Text.StartsWith("Введите") || l.Text.StartsWith("Перетащите"))))
                .ToList();

            foreach (var c in toRemove) { Controls.Remove(c); c.Dispose(); }
            lblInstruction.Visible = false;
        }

        private void UpdateScoreDisplay()
        {
            lblScore.Text = $"Баллы: {score} / 100";
        }

        private void FinishLevel()
        {
            tmrQuestion.Stop();
            string msg = $"Сеанс завершен!\nВаш счет: {score} из 100.";

            bool canNext = score >= 80 && currentLevel < 3;

            if (canNext)
            {
                var res = MessageBox.Show(msg + "\nПерейти на следующий уровень?", "Победа!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    StartLevel(currentLevel + 1);
                    return;
                }
            }
            else if (currentLevel >= 3 && score >= 80)
            {
                msg += "\nПоздравляем! Вы прошли всю игру!"; MessageBox.Show(msg, "Триумф", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); MessageBox.Show(msg, "Триумф", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                msg += "\nНужно 80 баллов для перехода дальше.";
                MessageBox.Show(msg, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

        private void TmrQuestion_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            lblTimer.Text = $"Время: {timeLeft}с";
            if (timeLeft <= 0)
            {
                tmrQuestion.Stop();
                MessageBox.Show("Время вышло!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NextStep();
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вернуться в главное меню? Прогресс текущего сеанса будет потерян.",
                "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}