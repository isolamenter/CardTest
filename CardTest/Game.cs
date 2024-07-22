namespace CardTest;
using static CardDefinition;

public class Game
{
    public Queue<Card> Deck;
    public List<Card> DiscardPile;
    public List<List<Card>> Players;
    private CardDefinition _cardDefinition;

    public Game(int num)
    {
        Players = new List<List<Card>>();
        for (var i = 0; i < num; i++)
        {
            var player = new List<Card>();
            Players.Add(player);
        }

        _cardDefinition = new CardDefinition();
    }

    public void Start()
    {
        var cards = _cardDefinition.GetNewCards();
        Deck = new Queue<Card>(_cardDefinition.ShuffleCards(cards));
    }

    public void Deal()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < Players.Count; j++)
            {
                Players[j].Add(DrawFromDeck());
            }
        }
    }
    
    private Card DrawFromDeck()
    {
        if (Deck.TryDequeue(out var card))
        {
            return card;
        }

        NewDeck();
        return Deck.Dequeue();
    }
    
    private void NewDeck()
    {
        
    }
}