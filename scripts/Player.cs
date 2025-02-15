using Godot;

public partial class Player : CharacterBody2D
{
    private bool canMove = true;
    Vector2 moveDirection = new Vector2(0,0);

    public override void _Ready()
    {
        var timer = GetNode<Timer>("MoveTimer");
        timer.Timeout += moveTimer;
    }

    public override void _Process(double delta) {
        move();
    }


    private void move() {

        var up = new Vector2(0, -SizeConstants.MOVE);
        var down = new Vector2(0, SizeConstants.MOVE);
        var left = new Vector2(-SizeConstants.MOVE, 0);
        var right = new Vector2(SizeConstants.MOVE, 0);

        if(Input.IsActionJustPressed("move_down")) {
            moveDirection = down;
            canMove = false;
        }
        if(Input.IsActionJustPressed("move_up")) {
            moveDirection = up;
            canMove = false;
        }
        if(Input.IsActionJustPressed("move_left")) {
            moveDirection = left;
            canMove = false;
        }
        if(Input.IsActionJustPressed("move_right")) {
            moveDirection = right;
            canMove = false;
        }
    }

    private void moveTimer() {

        GD.Print("In Timer");
		Vector2 velocity = Velocity;

        if(canMove) {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, SizeConstants.MOVE);
            velocity.Y = Mathf.MoveToward(Velocity.Y, 0, SizeConstants.MOVE);
            canMove = false;
        }
        else{
            velocity.X = moveDirection.X * SizeConstants.MOVE;
            velocity.Y = moveDirection.Y * SizeConstants.MOVE;
            canMove = true;
        }
		Velocity = velocity;
		MoveAndSlide();
    }
}
