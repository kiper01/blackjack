public class Player // task 4
{
    public Deck Hand { get; private set; }
    public int Score { get; private set; }
    public bool IsDealer { get; private set; }

    public Player(bool isDealer = false)
    {
        Hand = new Deck();
        Score = 0;
        IsDealer = isDealer;
    }

    public void AddCardToHand(Card card, GameHistory history, Player player) // task 6
    {
        Hand.AddCardToStart(card);
        UpdateScore();
        history.PlayerMove(card, player);
    }

    public void UpdateScore() // task 6
    {
        int aceCount = 0;
        int total = 0;

        var current = Hand.GetHead();
        while (current != null)
        {
            int cardPoints = current.Data.Points;
            if (cardPoints == 11)
            {
                aceCount++;
            }
            total += cardPoints;
            current = current.Next;
        }

        while (total > 21 && aceCount > 0)
        {
            total -= 10;
            aceCount--;
        }

        Score = total;
    }

    public void ClearHand(CardsDeck deck) // task 7
    {
        while (Hand.Count != 0)
        {
            deck.AddCardToStart(Hand.GetCardFromStart());
        }

        Hand.Clear();
        Score = 0;
    }
}
