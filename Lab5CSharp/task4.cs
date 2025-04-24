// Варіант 1 — Структури
/* using System;
using System.Collections.Generic;

struct SportsTeam
{
    public string Name;
    public string City;
    public int Players;
    public int Points;

    public SportsTeam(string name, string city, int players, int points)
    {
        Name = name;
        City = city;
        Players = players;
        Points = points;
    }

    public void Print() =>
        Console.WriteLine($"Команда: {Name}, Мiсто: {City}, Гравцiв: {Players}, Очки: {Points}");
}

class Program
{
    static void Main()
    {
        List<SportsTeam> teams = new List<SportsTeam>
        {
            new SportsTeam("Леви", "Львiв", 11, 15),
            new SportsTeam("Днiпро", "Днiпро", 12, 8),
            new SportsTeam("Вовки", "Київ", 10, 20)
        };

        Console.Write("Введiть мiнiмальну кiлькiсть очок: ");
        int minPoints = int.Parse(Console.ReadLine()!);

        teams.RemoveAll(t => t.Points < minPoints);

        teams.Insert(0, new SportsTeam("Фенiкс", "Iвано-Франкiвськ", 12, 18));
        teams.Insert(0, new SportsTeam("Титани", "Чернiвцi", 11, 22));

        Console.WriteLine("\nОновлений список команд:");
        foreach (var team in teams)
        {
            team.Print();
        }
    }
}
*/
// Варіант 2 — Кортежі

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<(string Name, string City, int Players, int Points)> teams = new()
        {
            ("Леви", "Львiв", 11, 15),
            ("Днiпро", "Днiпро", 12, 8),
            ("Вовки", "Київ", 10, 20)
        };

        Console.Write("Введiть мiнiмальну кiлькiсть очок: ");
        int minPoints = int.Parse(Console.ReadLine()!);

        teams.RemoveAll(t => t.Points < minPoints);

        teams.Insert(0, ("Фенiкс", "Iвано-Франкiвськ", 12, 18));
        teams.Insert(0, ("Титани", "Чернiвцi", 11, 22));

        Console.WriteLine("\nОновлений список команд:");
        foreach (var team in teams)
        {
            Console.WriteLine($"Команда: {team.Name}, Мiсто: {team.City}, Гравцiв: {team.Players}, Очки: {team.Points}");
        }
    }
}


// Варіант 3 — Записи (record)
/*
using System;
using System.Collections.Generic;

public record SportsTeam(string Name, string City, int Players, int Points);

class Program
{
    static void Main()
    {
        List<SportsTeam> teams = new()
        {
            new SportsTeam("Леви", "Львiв", 11, 15),
            new SportsTeam("Днiпро", "Днiпро", 12, 8),
            new SportsTeam("Вовки", "Київ", 10, 20)
        };

        Console.Write("Введiть мiнiмальну кiлькiсть очок: ");
        int minPoints = int.Parse(Console.ReadLine()!);

        teams.RemoveAll(t => t.Points < minPoints);

        teams.Insert(0, new SportsTeam("Фенiкс", "Iвано-Франкiвськ", 12, 18));
        teams.Insert(0, new SportsTeam("Титани", "Чернiвцi", 11, 22));

        Console.WriteLine("\nОновлений список команд:");
        foreach (var team in teams)
        {
            Console.WriteLine($"Команда: {team.Name}, Мiсто: {team.City}, Гравцiв: {team.Players}, Очки: {team.Points}");
        }
    }
}
*/
