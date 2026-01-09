using System;
using System.Data;
using System.Threading;


public class GameManager
{
    Tutorial_Dungeon _tutorial_Dungeon;
    Dungeon_01 _dungeon01;
    Player _player;
    Player_01 _player_01;
    MovePlayer _movePlayer;
    MovePlayer_01 _movePlayer_01;
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

            ConsoleKey inputKey = _player_01.UserInput();

            Result result = _movePlayer_01.PlayerMove(inputKey);

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

        _dungeon01.Init();
        _dungeon01.SpawnPlayer(_player_01);
    }
}
