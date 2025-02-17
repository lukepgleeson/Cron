using Godot;

public partial class PlanPlayer : Player
{
    public bool Freeze { get => Freeze; set => Freeze = value; }

    public override void _Process(double delta)
    {
        if (!Freeze)
        {
            move();
        }
    }

    private void move()
    {
        CronVector moveDirection = new CronVector(0, 0);
        CronVector up = new CronVector(0, -1);
        CronVector down = new CronVector(0, 1);
        CronVector left = new CronVector(-1, 0);
        CronVector right = new CronVector(1, 0);

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

        if (!moveDirection.Equals(new CronVector(0, 0)))
        {
            this.CronMove(moveDirection);
            Moves.Add(this.CronPosition);
        }
        moveDirection = new CronVector(0, 0);
    }


}
