using System;

public class Object
{
    public static readonly string EMPTY = "\u3000";
    public static readonly string WALL = "🧊";
    public static readonly string PLAYER = "🐤";
    public static readonly string GOAL = "🕳️";
    public static readonly string PLAYER_ON_GOAL = "🐥";

    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public enum eMoveDir
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
     

        NONE
    }
}

