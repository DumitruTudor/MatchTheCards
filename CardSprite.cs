using Godot;

namespace MatchTheCards;

public partial class CardSprite : Sprite2D
{
    private const string BackSpritePath = "res://Assets/Cards/CardBack.png";

    public Texture2D SetCardSprite(string spritePath = BackSpritePath)
    {
        return (Texture2D)ResourceLoader.Load(spritePath);
    }
    
    public bool IsBackSprite() => Texture?.ResourcePath == BackSpritePath;
}