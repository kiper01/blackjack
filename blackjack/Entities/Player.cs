using System;

public class Player
{
    public string Name { get; set; }
    public Deck Hand { get; private set; }
    public int Score { get; private set; }
    public bool IsDealer { get; private set; }

    public Player(string name, bool isDealer = false)
    {
        Name = name;
        Hand = new Deck();
        Score = 0;
        IsDealer = isDealer;
    }

    public void AddCardToHand(Card card)
    {
        Hand.AddCardToStart(card);
        UpdateScore();
    }

    public void UpdateScore()
    {
        int aceCount = 0;
        int total = 0;

        foreach (var card in Hand.GetAllCards())
        {
            int cardPoints = card.Points;
            if (cardPoints == 11)
            {
                aceCount++;
            }
            total += cardPoints;
        }

        while (total > 21 && aceCount > 0)
        {
            total -= 10;
            aceCount--;
        }

        Score = total;
    }

    public void ClearHand()
    {
        Hand.Clear();
        Score = 0;
    }
}