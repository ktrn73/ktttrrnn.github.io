using System;
using System.Windows.Forms;
using System.Xml;

namespace EnglishQuiz
{
    public partial class frmMain : Form
    {
        private XmlDocument xmlDoc;
        private string xmlPath;

        public frmMain()
        {
            InitializeComponent();
            xmlPath = System.IO.Path.Combine(Application.StartupPath, "questions.xml");
            LoadTopics();
        }

        private void LoadTopics()
        {
            try
            {
                // Проверяем существование файла
                if (!System.IO.File.Exists(xmlPath))
                {
                    CreateDefaultXml();
                }

                xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlPath);

                XmlNodeList topics = xmlDoc.SelectNodes("//topic");
                cmbTopic.Items.Clear();
                foreach (XmlNode topic in topics)
                {
                    cmbTopic.Items.Add(topic.Attributes["name"].Value);
                }

                if (cmbTopic.Items.Count > 0)
                    cmbTopic.SelectedIndex = 0;

                lblStatus.Text = "Готов к работе. Выберите тему.";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Ошибка загрузки тем";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show("Ошибка загрузки тем: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateDefaultXml()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration decl = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(decl);

            XmlElement test = doc.CreateElement("test");
            doc.AppendChild(test);

            XmlElement topic = doc.CreateElement("topic");
            topic.SetAttribute("name", "Пример темы");
            test.AppendChild(topic);

            XmlElement level = doc.CreateElement("level");
            level.SetAttribute("id", "1");
            topic.AppendChild(level);

            XmlElement question = doc.CreateElement("question");
            question.SetAttribute("text", "Как сказать 'Привет' по-английски?");
            question.SetAttribute("src", "");
            level.AppendChild(question);

            string[] answers = { "Hello", "Goodbye", "Yes", "No" };
            for (int i = 0; i < answers.Length; i++)
            {
                XmlElement answer = doc.CreateElement("answer");
                if (i == 0)
                    answer.SetAttribute("right", "yes");
                answer.InnerText = answers[i];
                question.AppendChild(answer);
            }

            doc.Save(xmlPath);
        }

        private void cmbTopic_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnStart.Enabled = cmbTopic.SelectedIndex >= 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cmbTopic.SelectedItem == null)
            {
                MessageBox.Show("Выберите тему для тестирования.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedTopic = cmbTopic.SelectedItem.ToString();
            frmGame gameForm = new frmGame(xmlPath, selectedTopic);
            gameForm.ShowDialog();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            frmAdmin adminForm = new frmAdmin(xmlPath);
            adminForm.ShowDialog();
            // Обновляем список тем после закрытия админки
            LoadTopics();
        }
    }
}