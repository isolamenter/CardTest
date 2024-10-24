namespace CardTest;
using static CardDefinition;

public class Game
{
    private const int DealCount = 4;
    
    private Queue<Card> _deck = new();
    private Stack<Card> _discardPile = new();
    private readonly List<Player> _players = [];
    public bool IsEnded { get; private set; }

    public void Start(int num = 4)
    {
        _deck = new Queue<Card>(ShuffleCards(GetNewCards()));
        _discardPile.Clear();
        
        for (var i = 0; i < num; i++)
        {
            var player = new Player(0);
            _players.Add(player);
        }
    }

    public void Deal()
    {
        foreach (var player in _players)
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
        var index = _players.IndexOf(player);
        var lastTurnPlayers = _players.Skip(index + 1).Concat(_players.Take(index));
    }

    private void OnPlayerTurn(Player player)
    {
        
    }
}