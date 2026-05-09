using Godot;

namespace MatchTheCards.CardLogic;

public partial class Card : TextureButton
{

	public const string CardBack = "res://Assets/Cards/CardBack.png";

	public CardModel Model { get; private set; }
	private Texture2D _cardFace;
	
	public void Initialise(CardModel model)
	{
		Model = model;
		_cardFace = GD.Load<Texture2D>($"res://Assets/Cards/{model.Index}-{model.Name}.png");
		SetTextureNormal(_cardFace);
	}
}