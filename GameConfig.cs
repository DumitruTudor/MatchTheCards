using Godot;

namespace MatchTheCards;

public partial class GameConfig : Node
{
    public static GameConfig Instance { get; private set; }
    
    public int GridSize { get; set; } = 2;

    [Export] public PackedScene MainMenuScene { get; set; }
    [Export] public PackedScene OptionsMenuScene { get; set; }
    [Export] public PackedScene GameScene { get; set; }

    public override void _Ready()
    {
        Instance = this; 
    }

    public void GoToMainMenu() => GetTree().ChangeSceneToPacked(MainMenuScene);
    public void GoToOptionsMenu() => GetTree().ChangeSceneToPacked(OptionsMenuScene);
    public void GoToGame() => GetTree().ChangeSceneToPacked(GameScene);
}