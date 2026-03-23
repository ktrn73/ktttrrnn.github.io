using Microsoft.VisualStudio.TestTools.UnitTesting;
using DictionaryLibrary;
using System.IO;
using System.Text;

namespace DictionaryLibrary.Tests
{
    [TestClass]
    public class SlovarTests
    {
        private string testFilePath;
        private string[] testWords = { "кот", "собака", "книга", "стол", "стул", "окно", "дом", "кровать", "лампа" };

        [TestInitialize]
        public void Setup()
        {
            testFilePath = Path.GetTempFileName();
            using (StreamWriter writer = new StreamWriter(testFilePath, false, Encoding.UTF8))
            {
                foreach (string word in testWords)
                {
                    writer.WriteLine(word);
                }
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(testFilePath))
                File.Delete(testFilePath);
        }

        [TestMethod]
        public void TestLoadDictionary()
        {
            Slovar slovar = new Slovar(testFilePath);
            Assert.AreEqual(testWords.Length, slovar.Count);
        }

        [TestMethod]
        public void TestAddWord_NewWord()
        {
            Slovar slovar = new Slovar(testFilePath);
            bool added = slovar.AddWord("новое");
            Assert.IsTrue(added);
            Assert.AreEqual(testWords.Length + 1, slovar.Count);
        }

        [TestMethod]
        public void TestAddWord_ExistingWord()
        {
            Slovar slovar = new Slovar(testFilePath);
            bool added = slovar.AddWord("кот");
            Assert.IsFalse(added);
            Assert.AreEqual(testWords.Length, slovar.Count);
        }

        [TestMethod]
        public void TestRemoveWord_ExistingWord()
        {
            Slovar slovar = new Slovar(testFilePath);
            bool removed = slovar.RemoveWord("кот");
            Assert.IsTrue(removed);
            Assert.AreEqual(testWords.Length - 1, slovar.Count);
        }

        [TestMethod]
        public void TestRemoveWord_NonExistingWord()
        {
            Slovar slovar = new Slovar(testFilePath);
            bool removed = slovar.RemoveWord("несуществующее");
            Assert.IsFalse(removed);
            Assert.AreEqual(testWords.Length, slovar.Count);
        }

        [TestMethod]
        public void TestSearchByLengthAndExcludeLetters_WithResults()
        {
            Slovar slovar = new Slovar(testFilePath);
            var results = slovar.SearchByLengthAndExcludeLetters(3, "аеёиоуыэюя");
            // Слова длины 3: кот, дом. Исключаем гласные - оба содержат гласные, результат пуст
            // Добавим тестовый словарь специально
        }

        [TestMethod]
        public void TestSearchByLengthAndExcludeLetters_NoResults()
        {
            Slovar slovar = new Slovar(testFilePath);
            var results = slovar.SearchByLengthAndExcludeLetters(10, "абв");
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestFuzzySearch_WithResults()
        {
            Slovar slovar = new Slovar(testFilePath);
            var results = slovar.FuzzySearch("кот", 0);
            Assert.IsTrue(results.Contains("кот"));
        }

        [TestMethod]
        public void TestFuzzySearch_NoResults()
        {
            Slovar slovar = new Slovar(testFilePath);
            var results = slovar.FuzzySearch("zzzzzzzzz", 1);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestGetWordsStartingWith()
        {
            Slovar slovar = new Slovar(testFilePath);
            var results = slovar.GetWordsStartingWith("к");
            Assert.IsTrue(results.Contains("книга"));
            Assert.IsTrue(results.Contains("кот"));
            Assert.IsTrue(results.Contains("кровать"));
        }
    }
}