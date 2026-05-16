using Godot;

namespace MatchTheCards.CardLogic;

public class CardMatcher
{
    private const float Green = 0.6f;  
    private const float Red = 0.6f;  
    private const float Blue = 0.6f;  
    private const float Alpha = 0.5f;  
    
    private Card _card1;
    private Card _card2;
    
    public void ChooseCard(Card card)
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
        
    private void CheckCards()
    {
        if (_card1.Model.Name.Equals(_card2.Model.Name))
        {
            RemoveBothCards();
        }
        else
        {
            FlipBothCards();
            EnableBothCards();
        }

        _card1 = null;
        _card2 = null;
    }

    private void FlipBothCards()
    {
        _card1.FlipCard();
        _card2.FlipCard();
    }

    private void EnableBothCards()
    {
        _card1.SetDisabled(false);
        _card2.SetDisabled(false);
    }

    private void RemoveBothCards()
    {
        RemoveCard(_card1);
        RemoveCard(_card2);
    }
    
    private void RemoveCard(Card card)
    {
        card.Modulate = new Color(Red, Green, Blue, Alpha);
        card.Disabled = true;
    }
}