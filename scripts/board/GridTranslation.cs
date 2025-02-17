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

        int vector2X = (x * SizeConstants.SQUARE) + ((-x / Math.Abs(x)) * (SizeConstants.SQUARE / 2));
        int vector2Y = (y * SizeConstants.SQUARE) + ((-y / Math.Abs(y)) * ((SizeConstants.SQUARE / 2))
                - (SizeConstants.SQUARE - SizeConstants.PLAYER) / 2);
        if (Math.Abs(vector2Y) > SizeConstants.BOUNDARY || Math.Abs(vector2X) > SizeConstants.BOUNDARY)
        {
            throw new ArgumentException("Created Vector exceeds bounds of game. (" + vector2X + ", " + vector2Y + ")");
        }

        return new Vector2(vector2X, vector2Y);
    }
}
