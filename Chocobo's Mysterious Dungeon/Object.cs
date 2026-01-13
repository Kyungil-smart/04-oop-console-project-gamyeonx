using System;

public class Object
{   // 유니코드로 하려니깐, 이런 빈칸이 있더라고요.
    public static readonly string EMPTY = "\u3000";
    public static readonly string WALL = "🧊";
    public static readonly string WALL2 = "🪨";
    public static readonly string PLAYER = "🐤";
    public static readonly string GOAL = "🕳️";
    public static readonly string PLAYER_ON_GOAL = "🐥";
    public static readonly string DUMMY_01 = "🕸️";
    public static readonly string DUMMY_02 = "🩻";
    public static readonly string DUMMY_03 = "🦴";
    public static readonly string DUMMY_04 = "💩";
    public static readonly string BABY = "🐣";
    public static readonly string MONSTER_ON_GOAL = "💮";
    public static readonly string MONSTER = "🐽";
    public static readonly string GHOST = "👻";
    public static readonly string BOSS = "🐦‍🔥";
    public static readonly string BOSS_ON_GOAL = "🔥";

    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    // 이거 트리거로 쓰면 좋을텐데...
    public enum eMoveDir
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,

        NONE
    }
}


