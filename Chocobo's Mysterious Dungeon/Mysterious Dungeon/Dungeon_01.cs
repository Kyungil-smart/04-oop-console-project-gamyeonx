using System;


public class Dungeon_01
{
    readonly Random random = new Random();

    private string[,] _map;
    int _width;
    int _height;
    int _random;

    public void Init()
    {
        _width = random.Next(20, 20);
        _height = random.Next(20, 20);
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

        for (int i = 5; i < 16; i++)
        {
            _map[5, i] = Object.WALL;
        }
        for (int i = 8; i < 19; i++)
        {
            _map[10, i] = Object.WALL;
        }
        for (int i = 5; i < 19; i++)
        {
            _map[15, i] = Object.WALL;
        }
        for (int i = 5; i < 15; i++)
        {
            _map[i, 5] = Object.WALL;
        }
        _map[1, 6] = Object.WALL;
        _map[2, 6] = Object.WALL;
        _map[3, 6] = Object.WALL;
        _map[6, 9] = Object.WALL;
        _map[5, 9] = Object.WALL;
        _map[4, 9] = Object.WALL;
        _map[1, 12] = Object.WALL;
        _map[2, 12] = Object.WALL;
        _map[3, 12] = Object.WALL;
        _map[5, 1] = Object.WALL;
        _map[5, 2] = Object.WALL;
        _map[5, 3] = Object.WALL;
        _map[7, 6] = Object.WALL;
        _map[7, 5] = Object.WALL;
        _map[7, 4] = Object.WALL;
        _map[9, 1] = Object.WALL;
        _map[9, 2] = Object.WALL;
        _map[9, 3] = Object.WALL;
        _map[11, 6] = Object.WALL;
        _map[11, 5] = Object.WALL;
        _map[11, 4] = Object.WALL;
        _map[16, 15] = Object.WALL;
        _map[17, 15] = Object.WALL;
        _map[11, 15] = Object.WALL;
        _map[19, 13] = Object.WALL;
        _map[18, 13] = Object.WALL;
        _map[17, 13] = Object.WALL;
        _map[16, 11] = Object.WALL;
        _map[17, 11] = Object.WALL;
        _map[11, 11] = Object.WALL;

        _map[17, 18] = Object.GOAL;
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

    public void SpawnPlayer(Player_01 player_01)
    {
        SpawnEmptyObject(out int X, out int Y);
        SetObject(X, Y, Object.PLAYER);
        player_01.Init(X, Y);
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

