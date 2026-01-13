using System;


public class Boss
{
    public Object.Position BossPosition { get; private set; }

    public void Init(int PositionX, int PositionY)
    {
        BossPosition = new Object.Position() { X = PositionX, Y = PositionY };
    }
    public void Move(Object.Position nextPosition)
    {
        BossPosition = nextPosition;
    }
}
