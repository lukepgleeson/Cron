using Godot;
using System.Collections.Generic;

public partial class ExecutePlayer : CronCharacter
{
    private Timer _resolveTimer;

    public ExecutePlayer() {
        this.CronPosition = new CronVector(-5, 5);
        this.Position = this.CronPosition.ToVector2();
    }

    public void Resolve(List<CronVector> Moves)
    {
        this.Moves = Moves;
        _resolveTimer = GetParent().GetNode<Timer>("ResolveTimer");
        _resolveTimer.Timeout += Move;
        _resolveTimer.Start();
    }

    private void Move()
    {
        this.CronHop(Moves[0]);
        Moves.RemoveAt(0);
        if (Moves.Count == 0)
        {
            _resolveTimer.Stop();
        }
    }
}
