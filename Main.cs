using System.Collections.Generic;
using Godot;
using MatchTheCards.CardLogic;

namespace MatchTheCards;

public partial class Main : Node
{
    [Export] public PackedScene CardScene { get; set; }
    
    private Deck _deck;

    private int _gridSize;
    
    public override void _Ready()
    {
        PlaceDeckOnScreen();
    }

    private void PlaceDeckOnScreen()
    {
        SetupDeck();
        SetGridSize();
        List<CardModel> selectedCards = _deck.GetShuffledPairs(_gridSize);
        
        foreach(CardModel card in selectedCards)
        {
            Card tarotCard = CardScene.Instantiate<Card>();
            tarotCard.Initialise(card);
            Grid.Instance.CardContainer.AddChild(tarotCard);
        }
    }

    private void SetupDeck()
    {
        _deck = new Deck();
        _deck.FillDeck();
    }
    
    private void SetGridSize()
    {
        _gridSize = 2;
        Grid.Instance.SetColumns(_gridSize);
    }
}