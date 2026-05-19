using Godot;

namespace MatchTheCards.CardLogic;

public partial class CardMatcher : Node
{
    [Signal] public delegate void AllCardsMatchedEventHandler();

    private const float FlipBackDelay = 1.0f;
    private static readonly Color MatchedTint = new(0.2f, 0.8f, 0.2f, 0.5f);

    private Card _card1;
    private Card _card2;
    private Timer _flipBackTimer;
    private int _remainingPairs;

    public void Initialise(int totalCards)
    {
        _remainingPairs = totalCards / 2;

        _flipBackTimer = new Timer();
        _flipBackTimer.WaitTime = FlipBackDelay;
        _flipBackTimer.OneShot = true;
        _flipBackTimer.Timeout += OnFlipBackTimeout;
        AddChild(_flipBackTimer);
    }

    public void ChooseCard(Card card)
    {
        if (_flipBackTimer.TimeLeft > 0) return; // ignore clicks during delay

        if (_card1 == null)
        {
            _card1 = card;
            _card1.FlipCard();
            _card1.SetDisabled(true);
        }
        else if (_card2 == null && card != _card1)
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
            MarkBothMatched();
            _card1 = null;
            _card2 = null;

            _remainingPairs--;
            if (_remainingPairs <= 0)
                EmitSignal(SignalName.AllCardsMatched);
        }
        else
        {
            DisableBothCards();
            _flipBackTimer.Start();
        }
    }

    private void OnFlipBackTimeout()
    {
        FlipBothCards();
        EnableBothCards();
        _card1 = null;
        _card2 = null;
    }

    private void MarkBothMatched()
    {
        MarkMatched(_card1);
        MarkMatched(_card2);
    }

    private void MarkMatched(Card card)
    {
        card.Modulate = MatchedTint;
        card.SetDisabled(true);
    }

    private void FlipBothCards()
    {
        _card1.FlipCard();
        _card2.FlipCard();
    }

    private void DisableBothCards()
    {
        _card1.SetDisabled(true);
        _card2.SetDisabled(true);
    }

    private void EnableBothCards()
    {
        _card1.SetDisabled(false);
        _card2.SetDisabled(false);
    }
}