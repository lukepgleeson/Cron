using Godot;
using System;

public class CronVector
{
    public int X;
    public int Y;

    public CronVector(int X, int Y)
    {
        this.X = X;
        this.Y = Y;
    }

    public Vector2 ToVector2()
    {
        return GridTranslation.Translate(this.X, this.Y);
    }

    public CronVector Add(CronVector otherVector)
    {
        int addedX = this.X + otherVector.X == 0 ? otherVector.X / Math.Abs(otherVector.X) : this.X + otherVector.X;
        int addedY = this.Y + otherVector.Y == 0 ? otherVector.Y / Math.Abs(otherVector.Y) : this.Y + otherVector.Y;
        return new CronVector(addedX, addedY);
    }

    public CronVector Subtract(CronVector otherVector)
    {
        int subtractedX = this.X - otherVector.X == 0 ? -otherVector.X / Math.Abs(otherVector.X) : this.X - otherVector.X;
        int subtractedY = this.Y - otherVector.Y == 0 ? -otherVector.Y / Math.Abs(otherVector.Y) : this.Y - otherVector.Y;
        return new CronVector(subtractedX, subtractedY);
    }

    public override string ToString()
    {
        return "x : " + this.X + "," + " y : " + this.Y;
    }

    public override bool Equals(object obj)
    {
        return obj is CronVector vector &&
               X == vector.X &&
               Y == vector.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}
