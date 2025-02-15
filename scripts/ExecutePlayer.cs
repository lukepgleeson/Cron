using Godot;
using System.Collections.Generic;

public partial class ExecutePlayer : Player
{
    private Timer resolveTimer;

    public override void _Ready(){
        Init();
    }

    public void Resolve(List<Vector2> moves){
        this.moves = moves;
        resolveTimer = GetParent().GetNode<Timer>("ResolveTimer");
        resolveTimer.Timeout += Move;
        resolveTimer.Start();
    }
    
    private void Move(){
        GD.Print("Moving to " + moves[0]);
        this.Position = moves[0];
        moves.RemoveAt(0);
        if(moves.Count == 0){
            resolveTimer.Stop();
        }
    }
}
