using System;


public class Tutorial_Dungeon
{
    readonly Random random = new Random();

    private string[,] _map;
    int _width;
    int _height;

    public void Init()
    {
        _width = random.Next(5, 5);
        _height = random.Next(5, 5);
        _map = new string[_width, _height];

        for (int i = 0; i < _map.GetLength(0); i++)
        {
            for (int j = 0; j < _map.GetLength(1); j++)
            {
                if (i == 0 || i == _width - 1 || j == 0 || j == _height - 1)
                {
                    _map[i, j] = Object.WALL;
                }
                else _map[i, j] = Object.EMPTY;
            }
        }
        _map[3, 3] = Object.GOAL;
    }

    public void PrintMap()
    {
        for (int i = 0; i < _map.GetLength(0); i++)
        {
            for (int j = 0; j < _map.GetLength(1); j++)
            {
                Console.Write(_map[i, j]);
            }
            Console.WriteLine();
        }
    }

    public string GetObject(int X, int Y)
    {
        return _map[X, Y];
    }
    public void SetObject(int X, int Y, string Value)
    {
        _map[X, Y] = Value;
    }

    public void SpawnPlayer(Player player)
    {
        SpawnEmptyObject(out int X, out int Y);
        SetObject(X, Y, Object.PLAYER);
        player.Init(X, Y);
    }

    public void SpawnObject(string objectString)
    {
        SpawnEmptyObject(out int X, out int Y);
        SetObject(X, Y, objectString);
    }
    void SpawnEmptyObject(out int PositionX, out int PositionY)
    {
        while (true)
        {
            PositionX = random.Next(2, _width - 2);
            PositionY = random.Next(2, _height - 2);

            if (_map[PositionX, PositionY] == Object.EMPTY)
                break;
        }
    }
}

