using Godot;
using System.Collections.Generic;

public partial class Player : CharacterBody2D
{
    protected List<CronVector> moves = new List<CronVector>();
    protected CronVector CronPosition;
    
    public Player() {
        this.CronPosition = new CronVector(-5,5);
        this.Position = this.CronPosition.ToVector2();
    }
    
    public Player(int CronX, int CronY) {
        this.CronPosition = new CronVector(CronX, CronY);
        this.Position = this.CronPosition.ToVector2();
    }

    public void CronMove(CronVector CronVector) {
        this.CronPosition = this.CronPosition.Add(CronVector);
        this.Position = this.CronPosition.ToVector2();
    }

    public void CronHop(CronVector CronVector) {
        this.CronPosition = CronVector;
        this.Position = this.CronPosition.ToVector2();
    }
}
