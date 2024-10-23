namespace CardTest;

class Program
{
    private static void Main()
    {
        var game = new Game();
        game.Start();
        game.Deal();
    }

    private static void Debug(int index, List<CardDefinition.Card> cards)
    {
        foreach (var card in cards)
        {
            Console.WriteLine($"Play{index}" +
                              $"\ncard type: {card.Type}" +
                              $"\ncard number: {card.Number}");
        }
    }
}