namespace CardTest;

class Program
{
    private static void Main()
    {
        var test = new CardTest();
        var cards = test.GetNewCards();
        cards = test.ShuffleCards(cards);
        foreach (var card in cards)
        {
            Console.WriteLine($"card type: {card.type}\ncard number: {card.number}");
        }
    }
}