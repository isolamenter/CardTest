namespace CardTest;

public class Player(int score)
{
    private List<CardDefinition.Card> _cards = [];

    public int Score { get; set; } = score;

    public void GetCard(CardDefinition.Card card)
    {
        _cards.Add(card);
    }
}