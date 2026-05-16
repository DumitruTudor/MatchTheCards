using System.Net.Mime;
using Godot;

namespace MatchTheCards.CardLogic;

public partial class Card : TextureButton
{
	public CardModel Model { get; private set; }
	
	private Texture2D _cardFace;
	private CardMatcher _cardMatcher;
	private const string CardBack = "res://Assets/Cards/CardBack.png";
	private Timer _matchTimer;

	public void Initialise(CardModel model, CardMatcher cardMatcher)
	{
		Model = model;
		_cardMatcher = cardMatcher;
		SetTextureToCardBack();
	}

	private void SetTextureToCardBack()
	{
		_cardFace = GD.Load<Texture2D>(CardBack);
		SetTextureNormal(_cardFace);
	}
	
	public void FlipCard()
	{
		SetTextureToCardFront();
	}

	private void SetTextureToCardFront()
	{
		string cardImage = $"res://Assets/Cards/{Model.Index}-{Model.Name}.png";
		Texture2D cardTexture = GD.Load<Texture2D>(cardImage);
		_cardFace = GD.Load<Texture2D>(_cardFace.Equals(cardTexture) ? CardBack : cardImage);

		SetTextureNormal(_cardFace);
	}

	public override void _Pressed()
	{
		_cardMatcher.ChooseCard(this);
	}
}