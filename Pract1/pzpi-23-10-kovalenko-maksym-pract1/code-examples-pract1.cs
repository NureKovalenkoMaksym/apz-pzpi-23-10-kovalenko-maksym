using System;
using System.Collections.Generic;

// 1. Зберігач (Memento)
public class GameSave
{
    public int Health { get; private set; }
    public string Location { get; private set; }

    public GameSave(int health, string location)
    {
        Health = health;
        Location = location;
    }
}

// 2. Ініціатор (Originator)
public class Player
{
    public int Health { get; set; }
    public string Location { get; set; }

    public GameSave SaveState()
    {
        return new GameSave(Health, Location);
    }

    public void RestoreState(GameSave save)
    {
        Health = save.Health;
        Location = save.Location;
    }
}

// 3. Опікун (Caretaker)
public class SaveManager
{
    private List<GameSave> _history = new List<GameSave>();

    public void AddSave(GameSave save)
    {
        _history.Add(save);
    }

    public GameSave GetSave(int index)
    {
        return _history[index];
    }
}

// Точка входу для перевірки роботи програми
public class Program
{
    public static void Main()
    {
        Player player = new Player { Health = 100, Location = "База" };
        SaveManager manager = new SaveManager();

        Console.WriteLine($"Початковий стан: Здоров'я = {player.Health}, Локація = {player.Location}");

        // Робимо збереження
        manager.AddSave(player.SaveState());
        Console.WriteLine("--- Стан збережено ---");

        // Імітуємо ігрову подію
        player.Health = 20;
        player.Location = "Зона конфлікту";
        Console.WriteLine($"Після події: Здоров'я = {player.Health}, Локація = {player.Location}");

        // Відновлюємо стан
        player.RestoreState(manager.GetSave(0));
        Console.WriteLine($"Відновлений стан: Здоров'я = {player.Health}, Локація = {player.Location}");
    }
}











