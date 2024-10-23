namespace CardTest;
using static CardDefinition;

public class Game
{
    private const int DealCount = 4;
    
    private Queue<Card> _deck = new();
    private Stack<Card> _discardPile = new();
    public readonly List<Player> Players = [];

    public void Start(int num = 4)
    {
        _deck = new Queue<Card>(ShuffleCards(GetNewCards()));
        _discardPile.Clear();
        
        for (var i = 0; i < num; i++)
        {
            var player = new Player(0);
            Players.Add(player);
        }
    }

    public void Deal()
    {
        foreach (var player in Players)
        {
            for (var i = 0; i < DealCount; i++)
            {
                //draw always success in the dealing
                DrawFromDeck(out var card);
                player.GetCard(card);
            }
        }
    }

    private bool DrawFromDeck(out Card card)
    { 
        return _deck.TryDequeue(out card);
    }

    private bool DrawFormDiscardPile(out Card card)
    {
        return _discardPile.TryPop(out card);
    }

    private void CallCABO(Player player)
    {
        var index = Players.IndexOf(player);
        var lastTurnPlayers = Players.Skip(index + 1).Concat(Players.Take(index));
    }
}