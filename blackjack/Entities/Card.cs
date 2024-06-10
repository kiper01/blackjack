using System;

public class Card
{
    public string Suit { get; private set; }
    public string Value { get; private set; }
    public int Points { get; private set; }
    public string ImageName { get; private set; }

    public Card(string suit, string value, int points, string imageName)
    {
        Suit = suit;
        Value = value;
        Points = points;
        ImageName = imageName;
    }

    public override string ToString()
    {
        return $"{Value} of {Suit} ({Points} points)";
    }
}
