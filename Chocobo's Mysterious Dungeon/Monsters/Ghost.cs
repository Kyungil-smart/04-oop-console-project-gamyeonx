using System;


public class Ghost
{
    public Object.Position GhostPosition { get; private set; }

    public void Init(int PositionX, int PositionY)
    {
        GhostPosition = new Object.Position() { X = PositionX, Y = PositionY };
    }
    public void Move(Object.Position nextPosition)
    {
        GhostPosition = nextPosition;
    }
}
