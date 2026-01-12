using System;


public class Dungeon_02
{
    readonly Random random = new Random();

    private string[,] _map;
    int _width;
    int _height;

    public void Init()
    {
        _width = random.Next(25, 25);
        _height = random.Next(25, 25);
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
        _map[12, 11] = Object.WALL;
        _map[11, 11] = Object.WALL;
        _map[11, 12] = Object.WALL;
        _map[13, 11] = Object.WALL;
        _map[13, 12] = Object.WALL;
        _map[13, 13] = Object.WALL;
        _map[11, 13] = Object.WALL;
        _map[13, 14] = Object.WALL;
        _map[13, 15] = Object.WALL;
        _map[12, 15] = Object.WALL;
        _map[11, 15] = Object.WALL;
        _map[10, 15] = Object.WALL;
        _map[9, 15] = Object.WALL;
        _map[9, 14] = Object.WALL;
        _map[9, 13] = Object.WALL;
        _map[9, 12] = Object.WALL;
        _map[9, 11] = Object.WALL;
        _map[9, 10] = Object.WALL;
        _map[9, 9] = Object.WALL;
        _map[10, 9] = Object.WALL;
        _map[11, 9] = Object.WALL;
        _map[12, 9] = Object.WALL;
        _map[13, 9] = Object.WALL;
        _map[14, 9] = Object.WALL;
        _map[15, 9] = Object.WALL;
        _map[15, 10] = Object.WALL;
        _map[16, 10] = Object.WALL;
        _map[16, 11] = Object.WALL;
        _map[16, 13] = Object.WALL;
        _map[17, 13] = Object.WALL;
        _map[18, 13] = Object.WALL;
        _map[16, 14] = Object.WALL;
        _map[16, 15] = Object.WALL;
        for(int i = 3; i < 10; i++)
        {
            _map[18, i] = Object.WALL;
        }
        _map[19, 6] = Object.WALL;
        for (int i = 2; i < 21; i++)
        {
            _map[20, i] = Object.WALL;
        }
        for (int i = 2; i < 18; i++)
        {
            _map[i, 20] = Object.WALL;
        }
        for (int i = 2; i < 19; i++)
        {
            _map[i, 6] = Object.WALL;
        }
        for (int i = 7; i < 19; i++)
        {
            _map[3, i] = Object.WALL;
        }
        for (int i = 8; i < 20; i++)
        {
            _map[6, i] = Object.WALL;
        }
        _map[15, 21] = Object.WALL;
        _map[15, 22] = Object.WALL;
        _map[14, 22] = Object.WALL;
        _map[15, 21] = Object.WALL;
        _map[15, 22] = Object.WALL;
        _map[14, 22] = Object.WALL;
        _map[12, 23] = Object.WALL;
        _map[12, 22] = Object.WALL;
        _map[11, 22] = Object.WALL;
        _map[9, 22] = Object.WALL;
        _map[9, 21] = Object.WALL;
        _map[7, 21] = Object.WALL;
        _map[6, 22] = Object.WALL;
        _map[7, 22] = Object.WALL;
        _map[2, 23] = Object.WALL;
        for (int i = 1; i < 5; i++)
        {
            _map[5, i] = Object.WALL;
        }
        for (int i = 3; i < 6; i++)
        {
            _map[8, i] = Object.WALL;
        }
        _map[11, 2] = Object.WALL;
        _map[11, 3] = Object.WALL;
        _map[11, 4] = Object.WALL;
        _map[12, 2] = Object.WALL;
        _map[12, 4] = Object.WALL;
        _map[13, 18] = Object.WALL;
        _map[13, 17] = Object.WALL;
        _map[21, 16] = Object.WALL;
        _map[22, 16] = Object.WALL;
        _map[23, 19] = Object.WALL;
        _map[22, 19] = Object.WALL;
        _map[17, 19] = Object.WALL;


        _map[12, 12] = Object.GOAL;
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

    public void SpawnPlayer(Player_02 player_02)
    {
        SpawnEmptyObject(out int X, out int Y);
        SetObject(X, Y, Object.PLAYER);
        player_02.Init(X, Y);
    }

    public void SpawnGhost(Ghost ghost)
    {
        SpawnEmptyObject(out int X, out int Y);
        SetObject(X, Y, Object.GHOST);
        ghost.Init(X, Y);
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

