using Godot;
using System;

public partial class Enemy : CronCharacter
{
    private ExecutePlayer _executePlayer;

    public Enemy()
    {
        this.CronPosition = new CronVector(5, -5);
        this.Position = this.CronPosition.ToVector2();
        this._executePlayer = GetNode<ExecutePlayer>("ExecutePlayer");
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Timer resolveTimer = GetNode<Timer>("ResolveTimer");
        resolveTimer.Timeout += Hunt;
    }

    private void Hunt()
    {
        CronVector cronDistance = this.CronPosition.Subtract(_executePlayer.CronPosition);
        CronVector cronMove;
        if (cronDistance.X == cronDistance.Y)
        {
            cronMove = new CronVector(cronDistance.X / Math.Abs(cronDistance.X), 0);
        }
        else
        {
            cronMove = cronDistance.X > cronDistance.Y ?
                new CronVector(cronDistance.X / Math.Abs(cronDistance.X), 0) :
                new CronVector(0, cronDistance.Y / Math.Abs(cronDistance.Y));
        }
        this.CronMove(cronMove);
    }
}
