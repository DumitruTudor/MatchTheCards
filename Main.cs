using Godot;

namespace MatchTheCards;

public partial class Main : Node
{
    [Export] public PackedScene CardScene { get; set; }
    [Export] public Grid GridNode { get; set; }
    
    public override void _Ready()
    {
        GameSetup setup = new(CardScene, GridNode);
        setup.StartGame();
    }
}