using Godot;
using System;

public partial class Player : CharacterBody2D
{
    private bool canMove = false;
    Vector2 moveDirection = new Vector2(0,0);

    public override void _Process(double delta) {
        move();
    }

    private void move() {

        var up = new Vector2(0, -SizeConstants.SQUARE);
        var down = new Vector2(0, SizeConstants.SQUARE);
        var left = new Vector2(-SizeConstants.SQUARE, 0);
        var right = new Vector2(SizeConstants.SQUARE, 0);

        if(Input.IsActionJustPressed("move_down")) {
            moveDirection = down;
        }
        if(Input.IsActionJustPressed("move_up")) {
            moveDirection = up;
        }
        if(Input.IsActionJustPressed("move_left")) {
            moveDirection = left;
        }
        if(Input.IsActionJustPressed("move_right")) {
            moveDirection = right;
        }
        if((Math.Abs((this.Position + moveDirection).X) > (SizeConstants.SQUARE * SizeConstants.BOARD_COLUMNS)/2) ||
        (Math.Abs((this.Position + moveDirection).Y) > (SizeConstants.SQUARE * SizeConstants.BOARD_COLUMNS)/2)){
            moveDirection = Vector2.Zero;
        };

        this.Position = this.Position + moveDirection;
        moveDirection = Vector2.Zero;
    }
}
