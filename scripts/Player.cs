using Godot;
using System;

public partial class Player : CharacterBody2D
{
    private bool canMove = false;
    Vector2 moveDirection = new Vector2(0, 0);

    public override void _Ready()
    {
        int xStartingPos = -(SizeConstants.BOARD_COLUMNS*SizeConstants.SQUARE)/2 + SizeConstants.SQUARE/2;
        int yStartingPos = (SizeConstants.BOARD_COLUMNS*SizeConstants.SQUARE)/2 - SizeConstants.SQUARE/2 - 3;
        GD.Print(xStartingPos);
        GD.Print(yStartingPos);
        this.Position = new Vector2(xStartingPos, yStartingPos);
    }

    public override void _Process(double delta)
    {
        move();
    }

    private void move()
    {

        var up = new Vector2(0, -SizeConstants.SQUARE);
        var down = new Vector2(0, SizeConstants.SQUARE);
        var left = new Vector2(-SizeConstants.SQUARE, 0);
        var right = new Vector2(SizeConstants.SQUARE, 0);

        if (Input.IsActionJustPressed("move_down"))
        {
            moveDirection = down;
        }
        if (Input.IsActionJustPressed("move_up"))
        {
            moveDirection = up;
        }
        if (Input.IsActionJustPressed("move_left"))
        {
            moveDirection = left;
        }
        if (Input.IsActionJustPressed("move_right"))
        {
            moveDirection = right;
        }
        int boundary = (SizeConstants.SQUARE * SizeConstants.BOARD_COLUMNS) / 2;
        int futureXPos = (int)Math.Abs(this.Position.X + moveDirection.X);
        int futureYPos = (int)Math.Abs(this.Position.Y + moveDirection.Y);
        if ((futureXPos > boundary) || (futureYPos > boundary))
        {
            moveDirection = Vector2.Zero;
        }
        ;

        this.Position = this.Position + moveDirection;
        moveDirection = Vector2.Zero;
    }
}
