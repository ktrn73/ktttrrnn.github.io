using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DictionaryLibrary
{
    public class Slovar
    {
        private List<string> list = new List<string>();
        private string filename;
        private int count;

        public Slovar(string filename)
        {
            this.filename = filename;
            OpenFile();
            count = list.Count;
        }

        public int Count
        {
            get { return count; }
        }

        public List<string> GetWords()
        {
            return new List<string>(list);
        }

        private void OpenFile()
        {
            try
            {
                list.Clear();
                using (StreamReader f = new StreamReader(filename, Encoding.UTF8))
                {
                    while (!f.EndOfStream)
                    {
                        string word = f.ReadLine()?.Trim();
                        if (!string.IsNullOrEmpty(word))
                        {
                            list.Add(word);
                        }
                    }
                }
            }
            catch
            {
                throw new Exception("Ошибка доступа к файлу!");
            }
        }

        public void SaveToFile(string outputFilename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(outputFilename, false, Encoding.UTF8))
                {
                    foreach (string word in list)
                    {
                        writer.WriteLine(word);
                    }
                }
            }
            catch
            {
                throw new Exception("Ошибка сохранения файла!");
            }
        }

        public bool AddWord(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return false;

            string trimmedWord = word.Trim();
            if (!list.Contains(trimmedWord, StringComparer.OrdinalIgnoreCase))
            {
                list.Add(trimmedWord);
                count = list.Count;
                return true;
            }
            return false;
        }

        public bool RemoveWord(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return false;

            string trimmedWord = word.Trim();
            int index = list.FindIndex(w => string.Equals(w, trimmedWord, StringComparison.OrdinalIgnoreCase));
            if (index >= 0)
            {
                list.RemoveAt(index);
                count = list.Count;
                return true;
            }
            return false;
        }

        public List<string> GetWordsStartingWith(string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
                return new List<string>(list);

            return list.Where(w => w.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                       .OrderBy(w => w)
                       .ToList();
        }

        // Нечёткий поиск с расстоянием Левенштейна не более 3
        public List<string> FuzzySearch(string pattern, int maxDistance = 3)
        {
            if (string.IsNullOrEmpty(pattern))
                return new List<string>();

            var results = new List<string>();
            foreach (string word in list)
            {
                int distance = LevenshteinDistance(pattern.ToLower(), word.ToLower());
                if (distance <= maxDistance)
                {
                    results.Add(word);
                }
            }
            return results;
        }

        // Алгоритм Левенштейна
        private int LevenshteinDistance(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            if (n == 0) return m;
            if (m == 0) return n;

            for (int i = 0; i <= n; d[i, 0] = i++) ;
            for (int j = 0; j <= m; d[0, j] = j++) ;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (s[i - 1] == t[j - 1]) ? 0 : 1;
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            return d[n, m];
        }

        // Поиск слов заданной длины, не включающих буквы заданного слова
        public List<string> SearchByLengthAndExcludeLetters(int length, string excludeLetters)
        {
            if (length <= 0)
                return new List<string>();

            var results = new List<string>();
            string excludeLower = excludeLetters.ToLower();

            foreach (string word in list)
            {
                if (word.Length != length)
                    continue;

                bool containsExcluded = false;
                string wordLower = word.ToLower();

                foreach (char c in excludeLower)
                {
                    if (wordLower.Contains(c))
                    {
                        containsExcluded = true;
                        break;
                    }
                }

                if (!containsExcluded)
                {
                    results.Add(word);
                }
            }

            return results;
        }
    }
}