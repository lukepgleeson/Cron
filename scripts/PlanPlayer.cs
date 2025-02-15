using Godot;
using System;
using System.Collections.Generic;

public partial class PlanPlayer : Player
{
    private bool freeze = false;
    Vector2 moveDirection = new Vector2(0, 0);

    public List<Vector2> Moves { get => moves; }
    public bool Freeze { get => freeze; set => freeze = value; }

    public override void _Ready()
    {
        Init();
    }

    public override void _Process(double delta)
    {
        if(!freeze) {
            move();
        }
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

        if (!moveDirection.Equals(Vector2.Zero))
        {
            this.Position = this.Position + moveDirection;
            Moves.Add(this.Position);
            moveDirection = Vector2.Zero;
        }
    }


}
