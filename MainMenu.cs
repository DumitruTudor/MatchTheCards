using Godot;

namespace MatchTheCards;

public partial class MainMenu : Control
{
	[Export] public Button StartGame { get; set; }
	[Export] public Button Options { get; set; }
	[Export] public Button Exit { get; set; } 

	public override void _Ready()
	{
		StartGame.Pressed += OnPlayPressed;
		Options.Pressed += OnOptionsPressed;
		Exit.Pressed += () => GetTree().Quit();
	}

	private void OnPlayPressed()
	{ 
		GameConfig.Instance.GoToGame();
	}

	private void OnOptionsPressed() => GameConfig.Instance.GoToOptionsMenu();
}