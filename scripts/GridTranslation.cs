using Godot;
using System;

public static class GridTranslation
{
    public static Vector2 Translate(int x, int y)
    {
        if (x == 0 || y == 0)
        {
            throw new ArgumentException("Neither value of Vector can equal 0:" + "x = " + x + ", y = " + y);
        }

        GD.Print(x+" "+y);
        int Vector2X = (x * SizeConstants.SQUARE) + ((-x / Math.Abs(x)) * (SizeConstants.SQUARE / 2));
        int Vector2Y = (y * SizeConstants.SQUARE) + ((-y / Math.Abs(y)) * ((SizeConstants.SQUARE / 2))
                - (SizeConstants.SQUARE - SizeConstants.PLAYER) / 2);
        GD.Print(Vector2X+" "+Vector2Y);
        if (Math.Abs(Vector2Y) > SizeConstants.BOUNDARY || Math.Abs(Vector2X) > SizeConstants.BOUNDARY)
        {
            throw new ArgumentException("Created Vector exceeds bounds of game. (" + Vector2X + ", " + Vector2Y + ")");
        }

        return new Vector2(Vector2X, Vector2Y);
    }
}
