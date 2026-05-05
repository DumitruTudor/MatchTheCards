using Godot;

namespace MatchTheCards;

public partial class Card : Node2D
{
	private CardSprite _cardSprite;
	
	public override void _Ready()
	{
		_cardSprite = (CardSprite)GetNode("CardSprite");
		_cardSprite.Texture = _cardSprite.SetCardSprite();
	}
}