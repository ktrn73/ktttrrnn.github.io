using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DictionaryLibrary;

namespace DictionaryApp
{
    public partial class Form1 : Form
    {
        private Slovar currentDictionary;
        private string currentDictionaryPath;
        private string customDictionaryPath;
        private bool isCustomDictionary = false;

        public Form1()
        {
            InitializeComponent();
            customDictionaryPath = Path.Combine(Application.StartupPath, "custom_dict.txt");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDefaultDictionary();
        }

        private void LoadDefaultDictionary()
        {
            try
            {
                string defaultPath = Path.Combine(Application.StartupPath, "dictionary.txt");
                if (!File.Exists(defaultPath))
                {
                    CreateDefaultDictionary(defaultPath);
                }

                currentDictionary = new Slovar(defaultPath);
                currentDictionaryPath = defaultPath;
                isCustomDictionary = false;
                UpdateStatus($"Словарь загружен: {currentDictionary.Count} слов");
                RefreshWordList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки словаря: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateDefaultDictionary(string path)
        {
            // Создаём пример словаря
            string[] words = {
                "кот", "собака", "книга", "стол", "стул", "окно", "дом", "кровать", "лампа", "компьютер",
                "монитор", "клавиатура", "мышь", "процессор", "память", "диск", "программа", "алгоритм",
                "база", "данные", "файл", "система", "пользователь", "интерфейс", "функция", "метод"
            };
            File.WriteAllLines(path, words, System.Text.Encoding.UTF8);
        }

        private void UpdateStatus(string message)
        {
            toolStripStatusLabel.Text = message;
        }

        private void RefreshWordList()
        {
            if (currentDictionary == null) return;

            string prefix = txtPrefix.Text.Trim();
            var words = currentDictionary.GetWordsStartingWith(prefix);
            listBoxWords.DataSource = null;
            listBoxWords.DataSource = words;
        }

        // Загрузка другого словаря
        private void btnLoadDictionary_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                ofd.Title = "Выберите файл словаря";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        currentDictionary = new Slovar(ofd.FileName);
                        currentDictionaryPath = ofd.FileName;
                        isCustomDictionary = false;
                        UpdateStatus($"Словарь загружен: {currentDictionary.Count} слов");
                        RefreshWordList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки словаря: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Создание собственного словаря
        private void btnCreateCustomDict_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(customDictionaryPath))
                {
                    File.Create(customDictionaryPath).Close();
                }
                currentDictionary = new Slovar(customDictionaryPath);
                currentDictionaryPath = customDictionaryPath;
                isCustomDictionary = true;
                UpdateStatus($"Собственный словарь создан: {currentDictionary.Count} слов");
                RefreshWordList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка создания словаря: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Удаление собственного словаря
        private void btnDeleteCustomDict_Click(object sender, EventArgs e)
        {
            if (!isCustomDictionary)
            {
                MessageBox.Show("Текущий словарь не является собственным", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите удалить собственный словарь?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (File.Exists(customDictionaryPath))
                    {
                        File.Delete(customDictionaryPath);
                    }
                    LoadDefaultDictionary();
                    MessageBox.Show("Собственный словарь удалён", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления словаря: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Добавление слова
        private void btnAddWord_Click(object sender, EventArgs e)
        {
            string word = txtWord.Text.Trim();
            if (string.IsNullOrEmpty(word))
            {
                MessageBox.Show("Введите слово", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool added = currentDictionary.AddWord(word);
            if (added)
            {
                UpdateStatus($"Слово '{word}' добавлено");
                RefreshWordList();
                txtWord.Clear();
            }
            else
            {
                MessageBox.Show($"Слово '{word}' уже существует в словаре", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Удаление слова
        private void btnRemoveWord_Click(object sender, EventArgs e)
        {
            if (listBoxWords.SelectedItem == null)
            {
                MessageBox.Show("Выберите слово для удаления", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string word = listBoxWords.SelectedItem.ToString();
            var result = MessageBox.Show($"Удалить слово '{word}'?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool removed = currentDictionary.RemoveWord(word);
                if (removed)
                {
                    UpdateStatus($"Слово '{word}' удалено");
                    RefreshWordList();
                }
                else
                {
                    MessageBox.Show("Не удалось удалить слово", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Сохранение словаря
        private void btnSaveDictionary_Click(object sender, EventArgs e)
        {
            if (isCustomDictionary)
            {
                try
                {
                    currentDictionary.SaveToFile(currentDictionaryPath);
                    UpdateStatus($"Словарь сохранён: {currentDictionary.Count} слов");
                    MessageBox.Show("Словарь успешно сохранён", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                    sfd.Title = "Сохранить словарь как";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            currentDictionary.SaveToFile(sfd.FileName);
                            UpdateStatus($"Словарь сохранён: {currentDictionary.Count} слов");
                            MessageBox.Show("Словарь успешно сохранён", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        // Поиск 
        private void btnSearchVariant_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtLength.Text, out int length) || length <= 0)
            {
                MessageBox.Show("Введите корректную длину слова", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string excludeLetters = txtExcludeLetters.Text.Trim();

            var results = currentDictionary.SearchByLengthAndExcludeLetters(length, excludeLetters);

            if (results.Count == 0)
            {
                MessageBox.Show("Поиск не дал результатов", "Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearchResults.Clear();
            }
            else
            {
                txtSearchResults.Text = string.Join(Environment.NewLine, results);
                UpdateStatus($"Найдено слов: {results.Count}");
            }
        }

        // Нечёткий поиск
        private void btnFuzzySearch_Click(object sender, EventArgs e)
        {
            string pattern = txtFuzzyPattern.Text.Trim();
            if (string.IsNullOrEmpty(pattern))
            {
                MessageBox.Show("Введите образец для поиска", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var results = currentDictionary.FuzzySearch(pattern, 3);

            if (results.Count == 0)
            {
                MessageBox.Show("Нечёткий поиск не дал результатов", "Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearchResults.Clear();
            }
            else
            {
                txtSearchResults.Text = string.Join(Environment.NewLine, results);
                UpdateStatus($"Найдено слов (нечёткий поиск): {results.Count}");
            }
        }

        // Сохранение результатов поиска
        private void btnSaveResults_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchResults.Text))
            {
                MessageBox.Show("Нет результатов для сохранения", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                sfd.Title = "Сохранить результаты поиска";
                sfd.FileName = "search_results.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(sfd.FileName, txtSearchResults.Text, System.Text.Encoding.UTF8);
                        MessageBox.Show("Результаты сохранены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtPrefix_TextChanged(object sender, EventArgs e)
        {
            RefreshWordList();
        }

        // Очистка результатов
        private void btnClearResults_Click(object sender, EventArgs e)
        {
            txtSearchResults.Clear();
        }
    }
}