using System;


public class Dungeon_Last
{
    readonly Random random = new Random();

    private string[,] _map;
    int _width;
    int _height;
    int _random;

    public void Init()
    {
        _width = random.Next(10, 10);
        _height = random.Next(10, 10);
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
            _map[2, 1] = Object.WALL;
            _map[2, 2] = Object.WALL;
            _map[1, 2] = Object.WALL;
            _map[2, 7] = Object.WALL;
            _map[2, 8] = Object.WALL;
            _map[1, 7] = Object.WALL;
            _map[7, 1] = Object.WALL;
            _map[7, 2] = Object.WALL;
            _map[8, 2] = Object.WALL;
            _map[7, 7] = Object.WALL;
            _map[7, 8] = Object.WALL;
            _map[8, 7] = Object.WALL;

            _map[1, 1] = Object.DUMMY_02;
            _map[1, 8] = Object.DUMMY_01;
            _map[8, 8] = Object.DUMMY_03;
            _map[8, 1] = Object.DUMMY_04;
            
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

    public void SpawnPlayer(Player_Last player_Last)
    {
        SpawnEmptyObject(out int X, out int Y);
        SetObject(X, Y, Object.PLAYER);
        player_Last.Init(X, Y);
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

