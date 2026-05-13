using Godot;

namespace MatchTheCards;

public partial class Main : Node
{
    [Export] public PackedScene CardScene { get; set; }
    [Export] public Grid GridNode { get; set; }
    
    private Timer _previewTimer;
    private GameSetup _setup;
    public override void _Ready()
    {
        _setup = new(CardScene, GridNode, GameConfig.Instance.GridSize);
        _setup.StartGame();
        
        _previewTimer = new Timer();
        _previewTimer.WaitTime = 5.0f;
        _previewTimer.OneShot = true;
        _previewTimer.Timeout += OnPreviewTimeout;
        AddChild(_previewTimer);
        _previewTimer.Start();

    }
    private void OnPreviewTimeout()
    {
        _setup.FlipAllCards();
    }
}