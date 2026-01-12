using System;
using System.Data;
using System.Threading;


public class GameManager
{
    Tutorial_Dungeon _tutorial_Dungeon;
    Dungeon_01 _dungeon01;
    Dungeon_02 _dungeon02;
    Dungeon_Last _dungeon_Last;
    Player _player;
    Player_01 _player_01;
    Player_02 _player_02;
    Player_Last _player_Last;
    MovePlayer _movePlayer;
    MovePlayer_01 _movePlayer_01;
    MovePlayer_02 _movePlayer_02;
    MovePlayer_Last _movePlayer_Last;

    Monster _monster;
    Monster _monster2;
    Monster _monster3;
    Monster _monster4;
    MoveMonster _moveMonster;
    MoveMonster2 _moveMonster2;
    MoveMonster3 _moveMonster3;
    MoveMonster4 _moveMonster4;

    Ghost _ghost;
    Ghost _ghost2;
    Ghost _ghost3;
    Ghost _ghost4;
    Ghost _ghost5;
    Ghost _ghost6;
    Ghost _ghost7;
    MoveGhost _moveghost;
    MoveGhost2 _moveghost2;
    MoveGhost3 _moveghost3;
    MoveGhost4 _moveghost4;
    MoveGhost5 _moveghost5;
    MoveGhost6 _moveghost6;
    MoveGhost7 _moveghost7;

    Story _story;

    public void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Init();

        OpeningScene opening = new OpeningScene();
        opening.Play();

        Console.Clear();
        Console.WriteLine("🐣🐥🐤 Now Loading... 🐣🐥🐤");
        Thread.Sleep(1000);
        Console.Clear();

        _story.PrintTutorial();

        while (true)
        {
            Console.SetCursorPosition(0, 4);
            _tutorial_Dungeon.PrintMap();

            ConsoleKey inputKey = _player.UserInput();

            Result result = _movePlayer.PlayerMove(inputKey);

            if (_player.PlayerPosition.X == 3 && _player.PlayerPosition.Y == 3)
            {
                Console.SetCursorPosition(0, 4);
                _tutorial_Dungeon.PrintMap();

                Console.Beep(784, 150);
                Console.Beep(740, 150);
                Console.Beep(622, 150);
                Console.Beep(440, 150);
                Console.Beep(415, 150);
                Console.Beep(659, 150);
                Console.Beep(831, 150);
                Console.Beep(1047, 400);

                Console.WriteLine("🐣🐥🐤 Now Loading... 🐣🐥🐤");
                Thread.Sleep(1000);
                break;
            }
        }
  
        Console.Clear();
        _story.PrintTutorial2();

        Init2();

        while (true)
        {
            Console.SetCursorPosition(0, 4);
            _dungeon01.PrintMap();

            ConsoleKey inputKey = Console.ReadKey(true).Key;

            Result result = _movePlayer_01.PlayerMove(inputKey);
            Result result2 = _moveMonster.MonsterMove(inputKey);
            Result result3 = _moveMonster2.MonsterMove(inputKey);
            Result result4 = _moveMonster3.MonsterMove(inputKey);
            Result result5 = _moveMonster4.MonsterMove(inputKey);

            if ((_player_01.PlayerPosition.X == _monster.MonsterPosition.X && _player_01.PlayerPosition.Y == _monster.MonsterPosition.Y) ||
                (_player_01.PlayerPosition.X == _monster2.MonsterPosition.X && _player_01.PlayerPosition.Y == _monster2.MonsterPosition.Y) ||
                (_player_01.PlayerPosition.X == _monster3.MonsterPosition.X && _player_01.PlayerPosition.Y == _monster3.MonsterPosition.Y) ||
                (_player_01.PlayerPosition.X == _monster4.MonsterPosition.X && _player_01.PlayerPosition.Y == _monster4.MonsterPosition.Y)
                )
            {
                Console.SetCursorPosition(0, 4);
                _dungeon01.PrintMap();

                Console.Beep(494, 600);
                Console.Beep(587, 300);
                Console.Beep(440, 900);

                Console.Beep(392, 150);
                Console.Beep(440, 150);
                Console.Beep(494, 600);
                Console.Beep(587, 300);
                Console.Beep(440, 900);
                Thread.Sleep(150);

                Console.Beep(494, 600);
                Console.Beep(587, 300);
                Console.Beep(880, 600);
                Console.Beep(784, 300);
                Console.Beep(587, 600);

                Environment.Exit(0);
            }

            if (_player_01.PlayerPosition.X == 17 && _player_01.PlayerPosition.Y == 18)
            {
                Console.SetCursorPosition(0, 4);
                _dungeon01.PrintMap();

                Console.Beep(784, 150);
                Console.Beep(740, 150);
                Console.Beep(622, 150);
                Console.Beep(440, 150);
                Console.Beep(415, 150);
                Console.Beep(659, 150);
                Console.Beep(831, 150);
                Console.Beep(1047, 400);

                Console.WriteLine("🐣🐥🐤 Now Loading... 🐣🐥🐤");
                Thread.Sleep(1000);
                break;
            }
        }
  
        Console.Clear();
        _story.PrintTutorial3();

        Init3();

        while (true)
        {
            Console.SetCursorPosition(0, 4);
            _dungeon02.PrintMap();

            ConsoleKey inputKey = Console.ReadKey(true).Key;

            Result result = _movePlayer_02.PlayerMove(inputKey);
            Result result2 = _moveghost.GhostMove(inputKey);
            Result result3 = _moveghost2.GhostMove(inputKey);
            Result result4 = _moveghost3.GhostMove(inputKey);
            Result result5 = _moveghost4.GhostMove(inputKey);
            Result result6 = _moveghost5.GhostMove(inputKey);
            Result result7 = _moveghost6.GhostMove(inputKey);
            Result result8 = _moveghost7.GhostMove(inputKey);

            if ((_player_02.PlayerPosition.X == _ghost.GhostPosition.X && _player_02.PlayerPosition.Y == _ghost.GhostPosition.Y) ||
              (_player_02.PlayerPosition.X == _ghost2.GhostPosition.X && _player_02.PlayerPosition.Y == _ghost2.GhostPosition.Y) ||
              (_player_02.PlayerPosition.X == _ghost3.GhostPosition.X && _player_02.PlayerPosition.Y == _ghost3.GhostPosition.Y) ||
              (_player_02.PlayerPosition.X == _ghost4.GhostPosition.X && _player_02.PlayerPosition.Y == _ghost4.GhostPosition.Y) ||
              (_player_02.PlayerPosition.X == _ghost5.GhostPosition.X && _player_02.PlayerPosition.Y == _ghost5.GhostPosition.Y) ||
              (_player_02.PlayerPosition.X == _ghost6.GhostPosition.X && _player_02.PlayerPosition.Y == _ghost6.GhostPosition.Y) ||
              (_player_02.PlayerPosition.X == _ghost7.GhostPosition.X && _player_02.PlayerPosition.Y == _ghost7.GhostPosition.Y)
              )
            {
                Console.SetCursorPosition(0, 4);
                _dungeon02.PrintMap();

                Console.Beep(494, 600);
                Console.Beep(587, 300);
                Console.Beep(440, 900);

                Console.Beep(392, 150);
                Console.Beep(440, 150);
                Console.Beep(494, 600);
                Console.Beep(587, 300);
                Console.Beep(440, 900);
                Thread.Sleep(150);

                Console.Beep(494, 600);
                Console.Beep(587, 300);
                Console.Beep(880, 600);
                Console.Beep(784, 300);
                Console.Beep(587, 600);

                Environment.Exit(0);
            }

            if (_player_02.PlayerPosition.X == 12 && _player_02.PlayerPosition.Y == 12)
            {
                Console.SetCursorPosition(0, 4);
                _dungeon02.PrintMap();

                Console.Beep(784, 150);
                Console.Beep(740, 150);
                Console.Beep(622, 150);
                Console.Beep(440, 150);
                Console.Beep(415, 150);
                Console.Beep(659, 150);
                Console.Beep(831, 150);
                Console.Beep(1047, 400);

                Console.WriteLine("🐣🐥🐤 Now Loading... 🐣🐥🐤");
                Thread.Sleep(1000);
                break;
            }
        }
  
        Console.Clear();
        _story.PrintTutorial_Last();

        Init_Last();

        while (true)
        {
            Console.SetCursorPosition(0, 4);
            _dungeon_Last.PrintMap();

            ConsoleKey inputKey = _player_Last.UserInput();

            Result result = _movePlayer_Last.PlayerMove(inputKey);

            if (_player_Last.PlayerPosition.X == 3 && _player_Last.PlayerPosition.Y == 5)
            {
                Console.SetCursorPosition(0, 4);
                _dungeon_Last.PrintMap();

                Console.WriteLine("🎉Victory!");
                Thread.Sleep(1000);
                break;
            }

        }

        Console.CursorVisible = false;

        EndingScene scene = new EndingScene();

        scene.RenderApproach();

        MusicPlayer.PlayMarioClear(() => { scene.AddHeartRising(); });

        scene.ShowHappyEnd();

        Console.ResetColor();
        Console.Clear();
    }

    public void Init()
    {
        _tutorial_Dungeon = new Tutorial_Dungeon();
        _player = new Player();
        _movePlayer = new MovePlayer(_player, _tutorial_Dungeon);
        _story = new Story();

        _tutorial_Dungeon.Init();
        _tutorial_Dungeon.SpawnPlayer(_player);
    }

    public void Init2()
    {
        _dungeon01 = new Dungeon_01();
        _player_01 = new Player_01();
        _movePlayer_01 = new MovePlayer_01(_player_01, _dungeon01);

        _monster = new Monster();
        _monster2 = new Monster();
        _monster3 = new Monster();
        _monster4 = new Monster();
        _moveMonster = new MoveMonster(_monster, _dungeon01);
        _moveMonster2 = new MoveMonster2(_monster2, _dungeon01);
        _moveMonster3 = new MoveMonster3(_monster3, _dungeon01);
        _moveMonster4 = new MoveMonster4(_monster4, _dungeon01);


        _dungeon01.Init();
        _dungeon01.SpawnPlayer(_player_01);
        _dungeon01.SpawnMonster(_monster);
        _dungeon01.SpawnMonster(_monster2);
        _dungeon01.SpawnMonster(_monster3);
        _dungeon01.SpawnMonster(_monster4);
    }

    public void Init3()
    {
        _dungeon02 = new Dungeon_02();
        _player_02 = new Player_02();
        _movePlayer_02 = new MovePlayer_02(_player_02, _dungeon02);

        _ghost = new Ghost();
        _ghost2 = new Ghost();
        _ghost3 = new Ghost();
        _ghost4 = new Ghost();
        _ghost5 = new Ghost();
        _ghost6 = new Ghost();
        _ghost7 = new Ghost();
        _moveghost = new MoveGhost(_ghost, _dungeon02);
        _moveghost2 = new MoveGhost2(_ghost2, _dungeon02);
        _moveghost3 = new MoveGhost3(_ghost3, _dungeon02);
        _moveghost4 = new MoveGhost4(_ghost4, _dungeon02);
        _moveghost5 = new MoveGhost5(_ghost5, _dungeon02);
        _moveghost6 = new MoveGhost6(_ghost6, _dungeon02);
        _moveghost7 = new MoveGhost7(_ghost7, _dungeon02);

        _dungeon02.Init();
        _dungeon02.SpawnPlayer(_player_02);
        _dungeon02.SpawnGhost(_ghost);
        _dungeon02.SpawnGhost(_ghost2);
        _dungeon02.SpawnGhost(_ghost3);
        _dungeon02.SpawnGhost(_ghost4);
        _dungeon02.SpawnGhost(_ghost5);
        _dungeon02.SpawnGhost(_ghost6);
        _dungeon02.SpawnGhost(_ghost7);
    }

    public void Init_Last()
    {
        _dungeon_Last = new Dungeon_Last();
        _player_Last = new Player_Last();
        _movePlayer_Last = new MovePlayer_Last(_player_Last, _dungeon_Last);

        _dungeon_Last.Init();
        _dungeon_Last.SpawnPlayer(_player_Last);
    }
}
