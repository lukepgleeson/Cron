using Godot;
using System;
using System.Collections.Generic;

public partial class Board : GridContainer
{
    
    GridContainer boardGrid;
    PackedScene slotScene = null;
    List<Node> gridList;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        gridList = new List<Node>();
        while(this.GetChildCount() < Math.Pow(this.Columns,2)){
            createSlot();
        }
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    private void createSlot() {
        ColorRect slot = new ColorRect();
        float opacity = (this.GetChildCount()+(this.GetChildCount()/this.Columns))%2 == 0 ? 0.2f : 0.8f;
        slot.Color = new Color(Colors.OrangeRed, opacity);
        slot.CustomMinimumSize = new Vector2(20,20);
        this.AddChild(slot);
    }
}
