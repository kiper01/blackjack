using System;
using System.Collections.Generic;

public class CardsDeck : Deck
{
    public CardsDeck()
    {
        InitializeDeck();
    }

    private void InitializeDeck() // task 3
    {
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        int[] points = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };

        foreach (var suit in suits)
        {
            for (int i = 0; i < values.Length; i++)
            {
                string imageName = $"{values[i]}_{suit}";
                if (int.TryParse(values[i], out int result))
                {
                    imageName = "_" + imageName;
                }
                AddCardToStart(new Card(suit, values[i], points[i], imageName));
            }
        }
    }

    public void ShuffleDeck() // task 3
    {
        Random rand = new Random();
        List<Card> cardsList = new List<Card>();

        while (count > 0)
        {
            cardsList.Add(GetCardFromStart());
        }

        for (int i = 0; i < cardsList.Count * 2; i++)
        {
            int index = rand.Next(cardsList.Count);
            Card card = cardsList[index];
            cardsList.RemoveAt(index);
            cardsList.Insert(rand.Next(cardsList.Count), card);
        }

        foreach (var card in cardsList)
        {
            AddCardToStart(card);
        }
    }
}
