using Godot;
using System;
using System.Collections.Generic;

public partial class Board : GridContainer
{
    
    GridContainer boardGrid;
    PackedScene slotScene = null;
    List<Node> gridList;
	
    public override void _Ready()
	{
        this.Columns = SizeConstants.BOARD_COLUMNS;
        gridList = new List<Node>();
        while(this.GetChildCount() < Math.Pow(this.Columns,2)){
            createSlot();
        }
	}

	public override void _Process(double delta)
	{
	}

    public int getColumns() {
        return this.Columns;
    }

    private void createSlot() {
        ColorRect slot = new ColorRect();
        float opacity = (this.GetChildCount()+(this.GetChildCount()/this.Columns))%2 == 0 ? 0.2f : 0.8f;
        slot.Color = new Color(Colors.OrangeRed, opacity);
        slot.CustomMinimumSize = new Vector2(20,20);
        this.AddChild(slot);
    }
}
