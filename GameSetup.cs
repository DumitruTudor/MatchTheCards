using System;
using System.Collections.Generic;
using Godot;
using MatchTheCards.CardLogic;

namespace MatchTheCards;

public class GameSetup
{
    private Deck _deck;
    private readonly int _gridSize;
    private CardMatcher _cardMatcher;
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
        _cardMatcher = new CardMatcher();
        _grid.AddChild(_cardMatcher);
        _cardMatcher.Initialise(_gridSize * _gridSize);
        _cardMatcher.AllCardsMatched += OnAllCardsMatched;
        
        SetupDeck();
        PlaceDeckOnScreen();
        FlipAllCards();
        SetAllCardsDisabled(true);
    }
    
    private void OnAllCardsMatched()
    {
        GameConfig.Instance.GoToMainMenu();
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
    
        Vector2 viewportSize = _grid.GetViewport().GetVisibleRect().Size;
        const float padding = 20f;
        const float spacing = 8f;
        float availableSpace = MathF.Min(viewportSize.X, viewportSize.Y) - padding;
        float cardSize = (availableSpace - (spacing * (_gridSize - 1))) / _gridSize;

        List<CardModel> selectedCards = _deck.GetShuffledPairs(pairCount);
        foreach (CardModel card in selectedCards)
        {
            PlaceCard(card, cardSize);
        }
    }

    private void PlaceCard(CardModel card, float cardSize)
    {
        Card tarotCard = _cardScene.Instantiate<Card>();
        tarotCard.Initialise(card, _cardMatcher);
        tarotCard.CustomMinimumSize = new Vector2(cardSize, cardSize);
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