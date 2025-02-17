using Godot;
using System.Collections.Generic;

public partial class ExecutePlayer : Player
{
    private Timer resolveTimer;

    public void Resolve(List<CronVector> moves){
        this.moves = moves;
        resolveTimer = GetParent().GetNode<Timer>("ResolveTimer");
        resolveTimer.Timeout += Move;
        resolveTimer.Start();
    }
    
    private void Move(){
        GD.Print("Moving to " + moves[0].ToString());
        this.CronHop(moves[0]);
        moves.RemoveAt(0);
        if(moves.Count == 0){
            resolveTimer.Stop();
        }
    }
}
