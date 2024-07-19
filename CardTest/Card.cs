namespace CardTest;

public class CardTest
{
    private const int CardMax = 12;

    public enum CardType
    {
        A,
        B,
        C,
        D
    }

    public struct Card
    {
        public CardType type;
        public int number;
    }

    public List<Card> GetNewCards()
    {
        var cards = new List<Card>();
        for (var i = 0; i < CardMax; i++)
        {
            foreach (CardType type in Enum.GetValues(typeof(CardType)))
            {
                cards.Add(new Card
                {
                    type = type,
                    number = i + 1
                });
            }
        }

        return cards;
    }

    public List<Card> ShuffleCards(List<Card> cards)
    {
        return cards.OrderBy(x => Random.Shared.Next()).ToList();
    }
}