using System;
using System.Collections.Generic;
using System.Linq;
using MatchTheCards.CardLogic;

namespace MatchTheCards;

public class Deck
{
    private List<CardModel> DeckOfCards { get; } = [];
    
    private readonly string[] _cardNames =
    [
            "TheFool", "TheMagician", "TheHighPriestess",
            "TheEmpress", "TheEmperor", "TheHierophant",
            "TheLovers", "TheChariot", "Strength",
            "TheHermit", "WheelOfFortune", "Justice",
            "TheHangedMan", "Death", "Temperance",
            "TheDevil", "TheTower", "TheStar",
            "TheMoon", "TheSun", "Judgement",
            "TheWorld"
    ];

    public void FillDeck()
    {
        for (int i = 0; i < _cardNames.Length; i++)
        {
            DeckOfCards.Add(new CardModel(i, _cardNames[i]));
        }
    }
    
    public List<CardModel> GetShuffledPairs(int pairCount)
    {
        List<CardModel> pool = DeckOfCards.OrderBy(_ => Guid.NewGuid())
            .Take(pairCount)
            .ToList();

        // Duplicate each card to make pairs, then shuffle again
        List<CardModel> pairs = pool.Concat(pool)
            .OrderBy(_ => Guid.NewGuid())
            .ToList();

        return pairs;
    }
}