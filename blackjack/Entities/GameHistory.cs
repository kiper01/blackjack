using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

public class GameHistory // task 9
{
    private List<string> moves;

    public GameHistory()
    {
        moves = new List<string>();
    }

    public void AddMove(string move)
    {
        moves.Add(move + Environment.NewLine);
    }

    public void StartGameMove()
    {
        AddMove("Игра началась:");
    }

    public void PlayerMove(Card card, Player player)
    {
        string name;
        name = player.IsDealer? "Дилер" : "Игрок";
        AddMove($"{name} взял карту - {card.ToString()}");
    }

    public void FinishMove(string description, string name)
    {
        AddMove(description);
        AddMove(name);
        SaveToFile();
    }

    public void SaveToFile()
    {
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string filePath = Path.Combine(documentsPath, "GameHistory_" + Guid.NewGuid().ToString() + ".txt");

        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string move in moves)
                {
                    writer.WriteLine(move);
                }
            }
            Console.WriteLine("История ходов сохранена в файл: " + filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при сохранении истории ходов: " + ex.Message);
        }
    }
}

