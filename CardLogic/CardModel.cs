namespace MatchTheCards.CardLogic;

public class CardModel
{
    public int Index { get; }
    public string Name { get; }

    public CardModel(int index, string name)
    {
        Index = index;
        Name = name;
    }
}