using Godot;
using System.Collections.Generic;

public partial class CronCharacter : CharacterBody2D
{
    public CronVector CronPosition;
    public List<CronVector> Moves { get => Moves; set => Moves = value; }

    public CronCharacter()
    {
        this.Moves = new List<CronVector>();
    }

    public CronCharacter(int CronX, int CronY)
    {
        this.CronPosition = new CronVector(CronX, CronY);
        this.Position = this.CronPosition.ToVector2();
        this.Moves = new List<CronVector>();
    }

    public void CronMove(CronVector CronVector)
    {
        this.CronPosition = this.CronPosition.Add(CronVector);
        this.Position = this.CronPosition.ToVector2();
    }

    public void CronHop(CronVector CronVector)
    {
        this.CronPosition = CronVector;
        this.Position = this.CronPosition.ToVector2();
    }
}
