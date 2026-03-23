/// <summary>
/// Класс, представляющий одного кандидата.
/// </summary>
public class Candidate
{
    // Приватные поля
    private string name; // Имя кандидата
    private int vote;     // Количество голосов

    /// <summary>
    /// Конструктор для создания нового кандидата.
    /// </summary>
    /// <param name="name">Имя кандидата.</param>
    /// <param name="vote">Количество голосов.</param>
    public Candidate(string name, int vote)
    {
        this.name = name;
        this.vote = vote;
    }

    // Свойство для доступа к имени (только чтение)
    public string Name
    {
        get { return name; }
    }

    // Свойство для доступа к количеству голосов (чтение и запись)
    public int Vote
    {
        get { return vote; }
        set { vote = value; }
    }
}