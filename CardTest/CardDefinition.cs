namespace CardTest;

public class CardDefinition
{
    private const int CardMax = 12;

    public enum CardType
    {
        A,
        B,
        C,
        D
    }
    
    public enum ActionType
    {
        None,
        Peek,
        Spy,
        Swap
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
    
    public int GetScore(Card card)
    {
        return card is { number: 13, type: CardType.A or CardType.B } ? 0 : card.number;
    }

    public ActionType GetActionType(Card card)
    {
        return card.number switch
        {
            7 or 8 => ActionType.Peek,
            9 or 10 => ActionType.Spy,
            11 or 12 => ActionType.Swap,
            _ => ActionType.None
        };
    }
}