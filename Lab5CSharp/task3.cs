using System;
using System.Collections.Generic;

abstract class Publication
{
    public string Title { get; set; }
    public string AuthorSurname { get; set; }

    public Publication(string title, string authorSurname)
    {
        Title = title;
        AuthorSurname = authorSurname;
    }

    public abstract void DisplayInfo();
    public abstract bool IsAuthorMatch(string surname);
}

class Book : Publication
{
    public int Year { get; set; }
    public string Publisher { get; set; }

    public Book(string title, string authorSurname, int year, string publisher)
        : base(title, authorSurname)
    {
        Year = year;
        Publisher = publisher;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Книга: {Title}, Автор: {AuthorSurname}, Рiк: {Year}, Видавництво: {Publisher}");
    }

    public override bool IsAuthorMatch(string surname)
    {
        return AuthorSurname.Equals(surname, StringComparison.OrdinalIgnoreCase);
    }
}

class Article : Publication
{
    public string JournalName { get; set; }
    public int IssueNumber { get; set; }
    public int Year { get; set; }

    public Article(string title, string authorSurname, string journalName, int issueNumber, int year)
        : base(title, authorSurname)
    {
        JournalName = journalName;
        IssueNumber = issueNumber;
        Year = year;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Стаття: {Title}, Автор: {AuthorSurname}, Журнал: {JournalName}, Номер: {IssueNumber}, Рiк: {Year}");
    }

    public override bool IsAuthorMatch(string surname)
    {
        return AuthorSurname.Equals(surname, StringComparison.OrdinalIgnoreCase);
    }
}

class ElectronicResource : Publication
{
    public string Link { get; set; }
    public string Annotation { get; set; }

    public ElectronicResource(string title, string authorSurname, string link, string annotation)
        : base(title, authorSurname)
    {
        Link = link;
        Annotation = annotation;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Електронний ресурс: {Title}, Автор: {AuthorSurname}, Посилання: {Link}, Анотацiя: {Annotation}");
    }

    public override bool IsAuthorMatch(string surname)
    {
        return AuthorSurname.Equals(surname, StringComparison.OrdinalIgnoreCase);
    }
}

class Program2
{
    static void Main2()
    {
        List<Publication> catalog = new List<Publication>
        {
            new Book("Архiтектура ХХI столiття", "Гаращук", 2020, "Наука i технiка"),
            new Article("Сталий розвиток мiст", "Паланиця", "Мiстобудування", 2, 2022),
            new ElectronicResource("Моделювання конструкцiй", "Iваненко", "https://example.com", "Ресурс з моделювання будiвельних конструкцiй")
        };

        Console.WriteLine("=== Повна iнформацiя з каталогу ===");
        foreach (var publication in catalog)
        {
            publication.DisplayInfo();
        }

        Console.WriteLine("\n=== Пошук за прiзвищем автора ===");
        Console.Write("Введiть прiзвище автора: ");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Прiзвище не введено або воно порожнє!");
            return;
        }

        string searchSurname = input;
        bool found = false;

        foreach (var publication in catalog)
        {
            if (publication.IsAuthorMatch(searchSurname))
            {
                publication.DisplayInfo();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Нiчого не знайдено.");
        }
    }
}