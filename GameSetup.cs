using System.Collections.Generic;
using Godot;
using MatchTheCards.CardLogic;

namespace MatchTheCards;

public class GameSetup
{
    private Deck _deck;
    private int _gridSize;
    private readonly CardMatcher _cardMatcher = new();
    private readonly PackedScene _cardScene;
    private readonly Grid _grid;
    
    public GameSetup(PackedScene cardScene, Grid grid, int gridSize)
    {
        _cardScene = cardScene;
        _grid = grid;
        _gridSize = gridSize;
    }

    public void StartGame()
    {
        SetupDeck();
        PlaceDeckOnScreen();
        FlipAllCards();
        SetAllCardsDisabled(true);
    }
    
    private void SetupDeck()
    {
        _deck = new Deck();
        _deck.FillDeck();
    }
    
    private void PlaceDeckOnScreen()
    {
        int totalCards = _gridSize * _gridSize;
        int pairCount = totalCards / 2;

        _grid.SetColumns(_gridSize);
        List<CardModel> selectedCards = _deck.GetShuffledPairs(pairCount);

        foreach (CardModel card in selectedCards)
        {
            PlaceCard(card);
        }
    }

    private void PlaceCard(CardModel card)
    {
        Card tarotCard = _cardScene.Instantiate<Card>();
        tarotCard.Initialise(card, _cardMatcher);
        _grid.CardContainer.AddChild(tarotCard);
    }
    
    public void FlipAllCards()
    {
        foreach (Node child in _grid.CardContainer.GetChildren())
        {
            if (child is Card card)
            {
                card.FlipCard();
                card.SetDisabled(false);
            }
        }
        
        
    }

    private void SetAllCardsDisabled(bool disabled)
    {
        foreach (Node child in _grid.CardContainer.GetChildren())
        {
            if (child is Card card)
                card.SetDisabled(disabled);
        }
    }

}