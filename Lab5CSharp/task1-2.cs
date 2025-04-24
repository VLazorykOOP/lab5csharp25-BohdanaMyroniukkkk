using System;
using System.Collections.Generic;

// Базовий клас
abstract class State : IComparable<State>
{
    public string Name { get; set; }
    public string Capital { get; set; }

    public State(string name, string capital)
    {
        Name = name;
        Capital = capital;
        Console.WriteLine($"Конструктор State: {Name}");
    }

    public abstract void Display();

    public int CompareTo(State? other)
    {
        if (other == null) return 1;
        return Name.CompareTo(other.Name);
    }

    ~State()
    {
        Console.WriteLine($"Деструктор State: {Name}");
    }
}

// Похідні класи
class Republic : State
{
    public string President { get; set; }

    public Republic(string name, string capital, string president)
        : base(name, capital)
    {
        President = president;
        Console.WriteLine($"Конструктор Republic: {Name}");
    }

    public override void Display()
    {
        Console.WriteLine($"Республiка: {Name}, Столиця: {Capital}, Президент: {President}");
    }

    ~Republic()
    {
        Console.WriteLine($"Деструктор Republic: {Name}");
    }
}

class Monarchy : State
{
    public string Monarch { get; set; }

    public Monarchy(string name, string capital, string monarch)
        : base(name, capital)
    {
        Monarch = monarch;
        Console.WriteLine($"Конструктор Monarchy: {Name}");
    }

    public override void Display()
    {
        Console.WriteLine($"Монархiя: {Name}, Столиця: {Capital}, Монарх: {Monarch}");
    }

    ~Monarchy()
    {
        Console.WriteLine($"Деструктор Monarchy: {Name}");
    }
}

class Kingdom : State
{
    public string King { get; set; }

    public Kingdom(string name, string capital, string king)
        : base(name, capital)
    {
        King = king;
        Console.WriteLine($"Конструктор Kingdom: {Name}");
    }

    public override void Display()
    {
        Console.WriteLine($"Королiвство: {Name}, Столиця: {Capital}, Король: {King}");
    }

    ~Kingdom()
    {
        Console.WriteLine($"Деструктор Kingdom: {Name}");
    }
}

class Program1
{
    static void Main1()
    {
        Console.Write("Введiть номер завдання (1 або 2): ");
        string? input = Console.ReadLine();

        switch (input)
        {
            case "1":
                RunTask1();
                break;
            case "2":
                RunTask2();
                break;
            default:
                Console.WriteLine("Неправильний вибiр. Введiть 1 або 2.");
                break;
        }

        // Змусити збір сміття, щоб побачити деструктори
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    // Завдання 1: 
    static void RunTask1()
    {
        Console.WriteLine("\nЗавдання 1: ");

        Republic republic = new Republic("Україна", "Київ", "Зеленський");
        Monarchy monarchy = new Monarchy("Велика Британiя", "Лондон", "Чарльз III");
        Kingdom kingdom = new Kingdom("Iспанiя", "Мадрид", "Фелiпе VI");

        republic.Display();
        monarchy.Display();
        kingdom.Display();
    }

    // Завдання 2: 
    static void RunTask2()
    {
        Console.WriteLine("\nЗавдання 2: ");

        List<State> states = new List<State>
        {
            new Republic("Україна", "Київ", "Зеленський"),
            new Kingdom("Iспанiя", "Мадрид", "Фелiпе VI"),
            new Monarchy("Велика Британiя", "Лондон", "Чарльз III"),
        };

        Console.WriteLine("\nДо сортування:");
        foreach (var state in states)
            state.Display();

        states.Sort();

        Console.WriteLine("\nПiсля сортування за назвою:");
        foreach (var state in states)
            state.Display();
    }
}
