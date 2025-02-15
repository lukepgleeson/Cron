using Godot;
using System.Collections.Generic;

public partial class Player : CharacterBody2D
{
    protected List<Vector2> moves = new List<Vector2>();

    public void Init()
    {
        int xStartingPos = -(SizeConstants.BOARD_COLUMNS * SizeConstants.SQUARE) / 2 + SizeConstants.SQUARE / 2;
        int yStartingPos = (SizeConstants.BOARD_COLUMNS * SizeConstants.SQUARE) / 2 - SizeConstants.SQUARE / 2 - 3;
        this.Position = new Vector2(xStartingPos, yStartingPos);
    }
}
