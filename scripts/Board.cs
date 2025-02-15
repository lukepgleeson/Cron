using Godot;
using System;

public partial class Board : GridContainer
{
    public override void _Ready()
    {
        this.Columns = SizeConstants.BOARD_COLUMNS;
        while (this.GetChildCount() < Math.Pow(this.Columns, 2))
        {
            createSlot();
        }
    }

    public override void _Process(double delta)
    {
    }

    private void createSlot()
    {
        ColorRect slot = new ColorRect();
        float opacity = (this.GetChildCount() + (this.GetChildCount() / this.Columns)) % 2 == 0 ? 0.2f : 0.8f;
        slot.Color = new Color(Colors.OrangeRed, opacity);
        slot.CustomMinimumSize = new Vector2(20, 20);
        this.AddChild(slot);
    }
}
