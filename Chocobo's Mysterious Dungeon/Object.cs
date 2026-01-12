using System;

public class Object
{
    public static readonly string EMPTY = "\u3000";
    public static readonly string WALL = "🧊";
    public static readonly string PLAYER = "🐤";
    public static readonly string GOAL = "🕳️";
    public static readonly string PLAYER_ON_GOAL = "🐥";
    public static readonly string DUMMY_01 = "🐣";
    public static readonly string DUMMY_02 = "🩻";
    public static readonly string DUMMY_03 = "🦴";
    public static readonly string DUMMY_04 = "💩";
    public static readonly string SLIME = "🐽";
    public static readonly string ZOMBIE = "🧟‍♂️";
    public static readonly string BOSS = "🐦‍🔥";
    public static readonly string DEATH = "☠️";
    public static readonly string MONSTER = "🐽";

    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}

