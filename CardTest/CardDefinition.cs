namespace CardTest;

public class CardDefinition
{
    private const int CardMin = 0;
    private const int CardMax = 13;
    private const int NormalCardCount = 4;
    private const int SpecialCardCount = 2;
    
    public enum ActionType
    {
        None,
        Peek,
        Spy,
        Swap
    }

    public readonly record struct Card(int Number)
    {
        public ActionType Type => Number switch
        {
            7 or 8 => ActionType.Peek,
            9 or 10 => ActionType.Spy,
            11 or 12 => ActionType.Swap,
            _ => ActionType.None
        };
    }

    public static List<Card> GetNewCards()
    {
        var cards = new List<Card>();
        for (var i = CardMin; i <= CardMax; i++)
        {
            if (i is CardMin or CardMax)
            {
                for (var j = 0; j < SpecialCardCount; j++)
                {
                    cards.Add(new Card(i));
                }
            }
            else
            {
                for (var j = 0; j < NormalCardCount; j++)
                {
                    cards.Add(new Card(i));
                }
            }
        }

        return cards;
    }

    public static List<Card> ShuffleCards(List<Card> cards)
    {
        return cards.OrderBy(x => Random.Shared.Next()).ToList();
    }
}