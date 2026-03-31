using System.Collections.Generic;

namespace EnglishQuiz
{
    public enum QuestionType
    {
        Anagram,      // Ввод текста
        Translation,  // Drag & Drop
        FillBlank     // Drag & Drop
    }

    public class AnswerOption
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class Question
    {
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public QuestionType Type { get; set; }
        public List<AnswerOption> Options { get; set; }

        public Question()
        {
            Options = new List<AnswerOption>();
        }

        public string GetCorrectAnswerText()
        {
            var correct = Options.Find(o => o.IsCorrect);
            return correct != null ? correct.Text : string.Empty;
        }
    }
}