using GdUnit4;
using JetBrains.Annotations;
using static GdUnit4.Assertions;
namespace MatchTheCards;

[TestSuite]
public class MyTests 
{
    [TestCase]
    [RequireGodotRuntime, UsedImplicitly]
    public void CardSprite_WhenTextureIsBackSprite_IsBackSpriteReturnsTrue()
    {
        CardSprite cardSprite = AutoFree(new CardSprite());
        AddNode(cardSprite);
    
        cardSprite.Texture = cardSprite.SetCardSprite();
    
        AssertThat(cardSprite.IsBackSprite()).IsTrue();
    }
}