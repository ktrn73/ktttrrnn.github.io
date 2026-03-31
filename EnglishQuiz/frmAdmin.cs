using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace EnglishQuiz
{
    public partial class frmAdmin : Form
    {
        private string xmlPath;

        public frmAdmin(string xmlPath)
        {
            InitializeComponent();
            this.xmlPath = xmlPath;
            LoadExistingTopics();
        }

        private void LoadExistingTopics()
        {
            cmbExistingTopics.Items.Clear();
            cmbTopicTypeForQuestion.Items.Clear();

            // Заполним типы вопросов для выпадающего списка
            cmbTopicTypeForQuestion.Items.Add("anagram");
            cmbTopicTypeForQuestion.Items.Add("translation");
            cmbTopicTypeForQuestion.Items.Add("fillblank");
            cmbTopicTypeForQuestion.SelectedIndex = 0;

            if (!File.Exists(xmlPath)) return;

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            XmlNodeList topics = doc.SelectNodes("//topic");

            foreach (XmlNode topic in topics)
            {
                string name = topic.Attributes["name"]?.Value;
                string type = topic.Attributes["type"]?.Value ?? "anagram";
                cmbExistingTopics.Items.Add($"{name} ({type})");
            }

            if (cmbExistingTopics.Items.Count > 0)
                cmbExistingTopics.SelectedIndex = 0;
        }

        private void btnAddTopic_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTopic.Text))
            {
                MessageBox.Show("Введите название темы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string type = cmbTopicTypeForQuestion.SelectedItem?.ToString() ?? "anagram";

            XmlDocument doc = new XmlDocument();
            if (File.Exists(xmlPath))
                doc.Load(xmlPath);
            else
            {
                XmlDeclaration decl = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(decl);
                XmlElement test = doc.CreateElement("test");
                doc.AppendChild(test);
            }

            XmlElement root = doc.DocumentElement;
            if (root == null || root.Name != "test")
            {
                root = doc.CreateElement("test");
                doc.AppendChild(root);
            }

            // Проверка на дубликат
            XmlNode existing = root.SelectSingleNode($"topic[@name='{txtTopic.Text.Trim()}']");
            if (existing != null)
            {
                MessageBox.Show("Тема с таким названием уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            XmlElement newTopic = doc.CreateElement("topic");
            newTopic.SetAttribute("name", txtTopic.Text.Trim());
            newTopic.SetAttribute("type", type);

            for (int i = 1; i <= 3; i++)
            {
                XmlElement level = doc.CreateElement("level");
                level.SetAttribute("id", i.ToString());
                newTopic.AppendChild(level);
            }

            root.AppendChild(newTopic);
            doc.Save(xmlPath);

            MessageBox.Show($"Тема '{txtTopic.Text}' добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtTopic.Clear();
            LoadExistingTopics();
        }

        private void btnSaveQuestion_Click(object sender, EventArgs e)
        {
            string selectedFull = cmbExistingTopics.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedFull))
            {
                MessageBox.Show("Выберите тему.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Извлекаем имя темы (убираем тип в скобках)
            int bracketIndex = selectedFull.LastIndexOf('(');
            string selectedTopic = bracketIndex > 0 ? selectedFull.Substring(0, bracketIndex).Trim() : selectedFull;

            if (string.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                MessageBox.Show("Введите текст вопроса.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] answersText = { txtAnswer1.Text, txtAnswer2.Text, txtAnswer3.Text, txtAnswer4.Text };
            bool[] isRight = { chkRight1.Checked, chkRight2.Checked, chkRight3.Checked, chkRight4.Checked };

            int rightCount = 0;
            foreach (bool b in isRight) if (b) rightCount++;

            if (rightCount == 0)
            {
                MessageBox.Show("Отметьте хотя бы один правильный ответ.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);

            XmlNode topicNode = doc.SelectSingleNode($"//topic[@name='{selectedTopic}']");
            if (topicNode == null)
            {
                MessageBox.Show("Тема не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int levelId = (int)numLevel.Value;
            XmlNode levelNode = topicNode.SelectSingleNode($"level[@id='{levelId}']");

            // Создаем уровень, если вдруг его нет (защита от ошибок)
            if (levelNode == null)
            {
                levelNode = doc.CreateElement("level");
                ((XmlElement)levelNode).SetAttribute("id", levelId.ToString());
                topicNode.AppendChild(levelNode);
            }

            XmlElement question = doc.CreateElement("question");
            question.SetAttribute("text", txtQuestion.Text.Trim());
            question.SetAttribute("src", txtImagePath.Text.Trim());

            for (int i = 0; i < answersText.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(answersText[i]))
                {
                    XmlElement answer = doc.CreateElement("answer");
                    if (isRight[i])
                        answer.SetAttribute("right", "yes");
                    answer.InnerText = answersText[i].Trim();
                    question.AppendChild(answer);
                }
            }

            levelNode.AppendChild(question);
            doc.Save(xmlPath);

            MessageBox.Show("Вопрос добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearQuestionForm();
        }

        private void ClearQuestionForm()
        {
            txtQuestion.Clear();
            txtImagePath.Clear();
            txtAnswer1.Clear(); txtAnswer2.Clear(); txtAnswer3.Clear(); txtAnswer4.Clear();
            chkRight1.Checked = false; chkRight2.Checked = false; chkRight3.Checked = false; chkRight4.Checked = false;
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Сохраняем только имя файла, если картинка лежит в папке проекта, или полный путь
                // Для простоты сохраняем полный путь, но в реальном проекте лучше копировать в папку Resources
                txtImagePath.Text = openFileDialog.FileName;
            }
        }

        // Обработчик выбора темы для обновления типа в подсказке (опционально)
        private void cmbExistingTopics_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}