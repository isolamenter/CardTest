namespace CardTest;

class Program
{
    private static void Main()
    {
        var game = new Game(4);
        game.Start();
        game.Deal();
        
        for (int i = 0; i < game.Players.Count; i++)
        {
            Debug(i, game.Players[i]);
        }
    }

    private static void Debug(int index, List<CardDefinition.Card> cards)
    {
        foreach (var card in cards)
        {
            Console.WriteLine($"Play{index}" +
                              $"\ncard type: {card.type}" +
                              $"\ncard number: {card.number}");
        }
    }
}