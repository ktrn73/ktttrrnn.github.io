using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

/// <summary>
/// Класс для управления списком кандидатов и данными опроса.
/// </summary>
public class ArrayCandidate
{
    // Приватные поля
    private List<Candidate> candidates;   // Список объектов Candidate
    private List<double> procent;          // Список рассчитанных процентных долей
    private string pollQuestion;           // Текст вопроса голосования

    /// <summary>
    /// Конструктор по умолчанию. Инициализирует пустые списки.
    /// </summary>
    public ArrayCandidate()
    {
        candidates = new List<Candidate>();
        procent = new List<double>();
        pollQuestion = "";
    }

    /// <summary>
    /// Конструктор, загружающий данные из файла.
    /// </summary>
    /// <param name="fileName">Имя файла для загрузки.</param>
    public ArrayCandidate(string fileName)
    {
        candidates = new List<Candidate>();
        procent = new List<double>();
        LoadFromFile(fileName);
        CalculateAllPercentages();
    }

    // Свойства для доступа к полям
    public string PollQuestion
    {
        get { return pollQuestion; }
        set { pollQuestion = value; }
    }

    public int Count
    {
        get { return candidates.Count; }
    }

    public List<double> Procent
    {
        get { return procent; }
    }

    /// <summary>
    /// Индексатор для доступа к кандидату по индексу.
    /// </summary>
    public Candidate this[int index]
    {
        get
        {
            if (index >= 0 && index < candidates.Count)
                return candidates[index];
            else
                return null;
        }
    }

    /// <summary>
    /// Добавляет нового кандидата в список.
    /// </summary>
    /// <param name="candidate">Объект Candidate для добавления.</param>
    public void Add(Candidate candidate)
    {
        candidates.Add(candidate);
    }

    /// <summary>
    /// Удаляет кандидата по индексу.
    /// </summary>
    public void RemoveAt(int index)
    {
        if (index >= 0 && index < candidates.Count)
        {
            candidates.RemoveAt(index);
        }
    }

    /// <summary>
    /// Пересчитывает процентные доли для всех кандидатов на основе их голосов.
    /// </summary>
    public void CalculateAllPercentages()
    {
        if (candidates.Count == 0)
        {
            procent.Clear();
            return;
        }

        int totalVotes = 0;
        procent.Clear();

        // 1. Считаем общее количество голосов
        foreach (var candidate in candidates)
        {
            totalVotes += candidate.Vote;
        }

        // 2. Рассчитываем процент для каждого, избегая деления на ноль
        if (totalVotes > 0)
        {
            foreach (var candidate in candidates)
            {
                procent.Add(candidate.Vote / (double)totalVotes);
            }
        }
        else
        {
            // Если голосов нет, то доля каждого - 0%
            for (int i = 0; i < candidates.Count; i++)
            {
                procent.Add(0.0);
            }
        }
    }

    /// <summary>
    /// Сохраняет вопрос и данные о кандидатах в текстовый файл.
    /// </summary>
    /// <param name="fileName">Имя файла для сохранения.</param>
    public void SaveToFile(string fileName)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                // Формат файла:
                // строка 1: Вопрос
                // строка 2: Количество кандидатов (N)
                // следующие N строк: Имя|Количество_голосов
                writer.WriteLine(pollQuestion);
                writer.WriteLine(candidates.Count);
                foreach (var candidate in candidates)
                {
                    writer.WriteLine($"{candidate.Name}|{candidate.Vote}");
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}");
        }
    }

    /// <summary>
    /// Загружает вопрос и данные о кандидатах из текстового файла.
    /// </summary>
    /// <param name="fileName">Имя файла для загрузки.</param>
    public void LoadFromFile(string fileName)
    {
        try
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                candidates.Clear();
                procent.Clear();

                // Чтение вопроса
                pollQuestion = reader.ReadLine();

                // Чтение количества кандидатов
                int count = int.Parse(reader.ReadLine());

                // Чтение данных каждого кандидата
                for (int i = 0; i < count; i++)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        string name = parts[0];
                        int vote = int.Parse(parts[1]);
                        candidates.Add(new Candidate(name, vote));
                    }
                }
                // Пересчет процентов после загрузки
                CalculateAllPercentages();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}");
        }
    }
}