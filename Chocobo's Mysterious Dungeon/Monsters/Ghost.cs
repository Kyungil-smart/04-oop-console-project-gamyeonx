using System;


public class Ghost
{
    public Object.Position GhostPosition { get; private set; }

    public void Init(int PositionX, int PositionY)
    {
        GhostPosition = new Object.Position() { X = PositionX, Y = PositionY };
    }

    public ConsoleKey UserInput()
    {
        ConsoleKey _inputKey;

        while (true)
        {
            _inputKey = Console.ReadKey(true).Key;

            if (ConsoleKey.UpArrow == _inputKey ||
                ConsoleKey.DownArrow == _inputKey ||
                ConsoleKey.LeftArrow == _inputKey ||
                ConsoleKey.RightArrow == _inputKey
                ) break;
        }

        return _inputKey;
    }

    public void Move(Object.Position nextPosition)
    {
        GhostPosition = nextPosition;
    }
}
