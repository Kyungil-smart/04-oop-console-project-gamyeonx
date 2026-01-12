using System;


    public class Monster
    {
    public Object.Position MonsterPosition { get; private set; }

    public void Init(int PositionX, int PositionY)
    {
        MonsterPosition = new Object.Position() { X = PositionX, Y = PositionY };
    }

    public void Move(Object.Position nextPosition)
    {
        MonsterPosition = nextPosition;
    }
}
