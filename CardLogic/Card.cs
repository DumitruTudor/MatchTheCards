using System.Net.Mime;
using Godot;

namespace MatchTheCards.CardLogic;

public partial class Card : TextureButton
{
	private const string CardBack = "res://Assets/Cards/CardBack.png";

	public CardModel Model { get; set; }
	private Texture2D _cardFace;
	
	public override void _Ready()
	{
		GD.Print($"[Card] _Ready — Model is: {(Model == null ? "NULL" : Model.Name)}");
	}

	public void Initialise(CardModel model)
	{
		GD.Print($"[Card] Initialise called with: {model.Name}");
		Model = model;
		
		_cardFace = GD.Load<Texture2D>(CardBack);
		SetTextureNormal(_cardFace);
	}

	public void FlipCard()
	{
		string cardImage = $"res://Assets/Cards/{Model.Index}-{Model.Name}.png";
		Texture2D cardTexture = GD.Load<Texture2D>(cardImage);
		_cardFace = GD.Load<Texture2D>(_cardFace.Equals(cardTexture) ? CardBack : cardImage);

		SetTextureNormal(_cardFace);
	}

	public override void _Pressed()
	{
		CardManager.ChooseCard(this);
	}
}