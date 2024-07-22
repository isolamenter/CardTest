namespace CardTest;
using static CardDefinition;

public class Game
{
    public Queue<Card> Deck;
    public Stack<Card> DiscardPile;
    public List<List<Card>> Players;
    private CardDefinition _cardDefinition;
    
    public Game(int num)
    {
        Players = new List<List<Card>>();
        _cardDefinition = new CardDefinition();
        
        for (var i = 0; i < num; i++)
        {
            var player = new List<Card>();
            Players.Add(player);
        }
    }

    public void Start()
    {
        var cards = _cardDefinition.GetNewCards();
        Deck = new Queue<Card>(_cardDefinition.ShuffleCards(cards));
        DiscardPile = new Stack<Card>();
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

    public void PlayerDrawFromDeck()
    {
        var card = DrawFromDeck();
        
    }

    public void PlayerDrawFromDiscardPile()
    {
        
    }
    
    public void PlayerCallCABO()
    {
        
    }

    public void DiscardCards(List<Card> chosenCards)
    {
        foreach (var card in chosenCards)
        {
            DiscardPile.Push(card);
        }
    }

    public void ExchangeCards(List<Card> playerCards, List<Card> chosenCards, Card drawnCard)
    {
        foreach (var card in chosenCards)
        {
            playerCards.Remove(card);
        }
        DiscardCards(chosenCards);
        playerCards.Add(drawnCard);
    }

    public void Peek(List<Card> playerCards, int index)
    {
        
    }

    public void Spy(List<Card> playerCards, int index)
    {
        
    }

    public void Swap(List<Card> player1Cards, int index1, List<Card> player2Cards, int index2)
    {
        
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

    private Card DrawFromDiscardPile()
    {
        return DiscardPile.Pop();
    }
    
    private void NewDeck()
    {
        
    }
}