using Godot;

namespace MatchTheCards;

public partial class OptionsMenu : Control
{
    [Export] public Button TwoByTwo { get; set; }
    [Export] public Button FourByFour { get; set; }
    [Export] public Button SixBySix { get; set; }

    [Signal] public delegate void GridSizeChosenEventHandler(int gridSize);

    public override void _Ready()
    {
        TwoByTwo.Pressed += () => OnGridSizeChosen(2);
        FourByFour.Pressed += () => OnGridSizeChosen(4);
        SixBySix.Pressed += () => OnGridSizeChosen(6);
    }

    private void OnGridSizeChosen(int gridSize)
    {
        GameConfig.Instance.GridSize = gridSize;
        GameConfig.Instance.GoToMainMenu();
    }
}