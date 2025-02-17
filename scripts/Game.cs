using Godot;

public partial class Game : Node2D
{
    public override void _Ready()
    {
        Button roundEndButton = GetNode<Button>("RoundResolverButton");
        roundEndButton.Pressed += RoundResolverButtonPressed;
    }

    private void RoundResolverButtonPressed()
    {
        PlanPlayer planPlayer = GetNode<PlanPlayer>("PlanPlayer");
        planPlayer.Freeze = true;
        ExecutePlayer executePlayer = GetNode<ExecutePlayer>("ExecutePlayer");
        executePlayer.Resolve(planPlayer.Moves);
    }
}
