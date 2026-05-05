using GdUnit4;
using JetBrains.Annotations;
using static GdUnit4.Assertions;
namespace MatchTheCards.MatchTheCardsTests;

[TestSuite]
public class TestsForCards 
{
    [TestCase]
    [RequireGodotRuntime, UsedImplicitly]
    public void WhenCardSpriteTextureIsBackSpriteReturnTrue()
    {
        CardSprite cardSprite = AutoFree(new CardSprite());
        AddNode(cardSprite);
    
        cardSprite.Texture = cardSprite.SetCardSprite();
    
        AssertThat(cardSprite.IsBackSprite()).IsTrue();
    }
}