using Godot;

namespace MatchTheCards;

public partial class Grid : Control
{
	[Export] public GridContainer CardContainer { get; set; }
	
	public void SetColumns(int numberOfColumns)
	{
		CardContainer.Columns = numberOfColumns;
		CardContainer.AddThemeConstantOverride("h_separation", 8);
		CardContainer.AddThemeConstantOverride("v_separation", 8);
	}
}