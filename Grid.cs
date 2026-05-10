using Godot;

namespace MatchTheCards;

public partial class Grid : Control
{
	public static Grid Instance { get; private set; }
	[Export] public GridContainer CardContainer { get; set; }
	
	public override void _Ready()
	{
		Instance = this;
	}
	
	public void SetColumns(int numberOfColumns)
	{
		CardContainer.Columns = numberOfColumns;
	}
}