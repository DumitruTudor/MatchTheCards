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

    public GameSetup(PackedScene cardScene, Grid grid)
    {
        _cardScene = cardScene;
        _grid = grid;
    }

    public void StartGame()
    {
        SetupDeck();
        SetGridSize();
        PlaceDeckOnScreen();
    }
    
    private void SetupDeck()
    {
        _deck = new Deck();
        _deck.FillDeck();
    }
    
    private void SetGridSize()
    {
        _gridSize = 2;
        _grid.SetColumns(_gridSize);
    }
    
    private void PlaceDeckOnScreen()
    {
        List<CardModel> selectedCards = _deck.GetShuffledPairs(_gridSize);
        
        foreach(CardModel card in selectedCards)
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

}