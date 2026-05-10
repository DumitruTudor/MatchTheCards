using Godot;

namespace MatchTheCards.CardLogic;

public static class CardManager
{
    private const float _green = 0.6f;  
    private const float _red = 0.6f;  
    private const float _blue = 0.6f;  
    private const float _alpha = 0.5f;  
    
    private static Card _card1;
    private static Card _card2;

    public static void ChooseCard(Card card)
    {
        if (_card1 == null)
        {
            _card1 = card;
            _card1.FlipCard();
            _card1.SetDisabled(true);
        }
        else if (_card2 == null)
        {
            _card2 = card;
            _card2.FlipCard();
            _card2.SetDisabled(true);
            CheckCards();
        }
    }

    private static void CheckCards()
    {
        if (_card1.Model.Name.Equals(_card2.Model.Name))
        {
            RemoveCard(_card1);
            RemoveCard(_card2);
        }
        else
        {
            _card1.FlipCard();
            _card2.FlipCard();
            
            _card1.SetDisabled(false);
            _card2.SetDisabled(false);
        }

        _card1 = null;
        _card2 = null;
    }
    
    private static void RemoveCard(Card card)
    {
        card.Modulate = new Color(_red, _green, _blue, _alpha);
        card.Disabled = true;    
    }
}