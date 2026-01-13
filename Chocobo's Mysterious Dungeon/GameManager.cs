using System;
using System.Data;
using System.Threading;


public class GameManager
{   // 플레이어 그룹
    Tutorial_Dungeon _tutorial_Dungeon;
    Player _player;
    MovePlayer _movePlayer;
    // 플레이어를 다음 스테이지에 넘기고 싶지만 계속 터져서
    // 각층마다 플레이어를 만들었다. 아마 유저들은 모를 것 이다. 
    Dungeon_01 _dungeon01;
    Player_01 _player_01;
    MovePlayer_01 _movePlayer_01;

    Dungeon_02 _dungeon02;
    Player_02 _player_02;
    MovePlayer_02 _movePlayer_02;

    Dungeon_Last _dungeon_Last;
    Player_Last _player_Last;
    MovePlayer_Last _movePlayer_Last;

    // 몬스터그룹
    // 플레이어와 코드가 거의 동일하다.
    // 다가오는 AI를 만들지도 못하고, 랜덤으로 움직이면
    // 맵을 막아버려서  몬스터(슬라임), 고스트 모두 유저입력에
    // 혼란 걸린거마냥 반대, 혹은 다른방향으로 움직이게 했다.
    Monster _monster;
    MoveMonster _moveMonster;
    Monster _monster2;
    MoveMonster2 _moveMonster2;
    Monster _monster3;
    MoveMonster3 _moveMonster3;
    Monster _monster4;
    MoveMonster4 _moveMonster4;
    Monster _monster5;
    MoveMonster5 _moveMonster5;

    Boss _Boss;
    MoveBoss _moveBoss;

    Ghost _ghost;
    MoveGhost _moveghost;
    Ghost _ghost2;
    MoveGhost2 _moveghost2;
    Ghost _ghost3;
    MoveGhost3 _moveghost3;
    Ghost _ghost4;
    MoveGhost4 _moveghost4;
    Ghost _ghost5;
    MoveGhost5 _moveghost5;
    Ghost _ghost6;
    MoveGhost6 _moveghost6;
    Ghost _ghost7;
    MoveGhost7 _moveghost7;

    Story _story;

    public void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Init();

        // 이것은 변명의 여지가 없습니다.
        OpeningScene opening = new OpeningScene();
        opening.Play();

        // 제미나이한테 오프닝 만들어줘 하고 코드를 구경하다
        // 재밌는 아이디어가 떠올라서 그냥 감성만 줘봤다.
        Console.Clear();
        Console.WriteLine("🐣🐥🐤 Now Loading... 🐣🐥🐤");
        Thread.Sleep(1000);
        Console.Clear();

        // 이런거 마져 소코반에서 가져왔다.
        _story.PrintTutorial();

        while (true)
        {
            Console.SetCursorPosition(0, 4);
            _tutorial_Dungeon.PrintMap();

            ConsoleKey inputKey = _player.UserInput();

            Result result = _movePlayer.PlayerMove(inputKey);

            // 일단 구멍위치에만 올라가면 클리어하게 만든 클리어 조건.
            if (_player.PlayerPosition.X == 3 && _player.PlayerPosition.Y == 3)
            {   // 구멍에 올라간 느낌은 나야하는데 바로 다음스테이지로 넘어가서 추가.
                Console.SetCursorPosition(0, 4);
                _tutorial_Dungeon.PrintMap();

                // 이것도 재미나이한테 시켰다.
                Console.Beep(784, 150);
                Console.Beep(740, 150);
                Console.Beep(622, 150);
                Console.Beep(440, 150);
                Console.Beep(415, 150);
                Console.Beep(659, 150);
                Console.Beep(831, 150);
                Console.Beep(1047, 400);

                // 이것도 감성만...
                Console.WriteLine("🐣🐥🐤 Now Loading... 🐣🐥🐤");
                Thread.Sleep(1000);
                break;
            }
        }

        // 이런식으로 다음 스테이지로 넘어간다.
        // _story.PrintTutorial2(); 인건 코드 복붙의 잔재이다.
        Console.Clear();
        _story.PrintTutorial2();

        Init2();

        while (true)
        {
            Console.SetCursorPosition(0, 4);
            _dungeon01.PrintMap();

            // 원래는 밑의 주석 코드였지만, 입력이 두번 눌린후에
            // 캐릭터와 몬스터 같이 움직여서 어찌저찌 한번만 눌러도 동시에
            // 움직여지게  ConsoleKey inputKey에 키 한번만 압력받게 했다.
            // ConsoleKey inputKey = _monster.UserInput();
            // ConsoleKey inputKey = _player.UserInput();
            ConsoleKey inputKey = Console.ReadKey(true).Key;

            // BFS 코드를 거줘 줘도 응용도 못해서 몬스터들도 키 입력을 받게 했다.
            // 처음의 이상한 던전 컨셉도 나와 같이 몬스터가 움직인다는 컨셉이어서
            // 그럴듯?...
            Result result = _movePlayer_01.PlayerMove(inputKey);
            Result result2 = _moveMonster.MonsterMove(inputKey);
            Result result3 = _moveMonster2.MonsterMove(inputKey);
            Result result4 = _moveMonster3.MonsterMove(inputKey);
            Result result5 = _moveMonster4.MonsterMove(inputKey);
            Result result6 = _moveMonster5.MonsterMove(inputKey);
            Result result7 = _moveBoss.BossMove(inputKey);

            // 몬스터에 부딛히면 죽게 구현...
            if ((_player_01.PlayerPosition.X == _monster.MonsterPosition.X && _player_01.PlayerPosition.Y == _monster.MonsterPosition.Y) ||
                (_player_01.PlayerPosition.X == _monster2.MonsterPosition.X && _player_01.PlayerPosition.Y == _monster2.MonsterPosition.Y) ||
                (_player_01.PlayerPosition.X == _monster3.MonsterPosition.X && _player_01.PlayerPosition.Y == _monster3.MonsterPosition.Y) ||
                (_player_01.PlayerPosition.X == _monster4.MonsterPosition.X && _player_01.PlayerPosition.Y == _monster4.MonsterPosition.Y) ||
                (_player_01.PlayerPosition.X == _monster5.MonsterPosition.X && _player_01.PlayerPosition.Y == _monster5.MonsterPosition.Y) ||
                (_player_01.PlayerPosition.X == _Boss.BossPosition.X && _player_01.PlayerPosition.Y == _Boss.BossPosition.Y)
                )
            {
                Console.SetCursorPosition(0, 4);
                _dungeon01.PrintMap();

                // 실력이 없으면 포장이라도 하자는 나쁜 마인드...
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

            // 유저들도 이런게임 빨리 끝내고 싶을거라
            // 보스전은 필요없다고 판단(핑계)
            if (_player_Last.PlayerPosition.X == 3 && _player_Last.PlayerPosition.Y == 5)
            {
                Console.SetCursorPosition(0, 4);
                _dungeon_Last.PrintMap();

                Console.WriteLine("🎉Victory!");
                Thread.Sleep(1000);
                break;
            }
        }

        // 이것도 최첨단 문명이 만든...
        // 그래도 이런게임 플레이해준 사람들에게 클리어의 기쁨만이라도 주고싶었습니다.
        Console.CursorVisible = false;

        EndingScene scene = new EndingScene();

        scene.RenderApproach();

        MusicPlayer.PlayMarioClear(() => { scene.AddHeartRising(); });

        scene.ShowHappyEnd();

        Console.ResetColor();
        Console.Clear();
    }

    // 생성자 말고, 이런식의 방법이 있다는게 재밌었습니다.
    public void Init()
    {
        _tutorial_Dungeon = new Tutorial_Dungeon();
        _player = new Player();
        _movePlayer = new MovePlayer(_player, _tutorial_Dungeon);
        _story = new Story();

        _tutorial_Dungeon.Init();
        // 이것도 영민강사님의 소코반 그대로... 플레이어 랜덤 스폰 너무 좋다.
        _tutorial_Dungeon.SpawnPlayer(_player);
    }

    public void Init2()
    {
        _dungeon01 = new Dungeon_01();
        _player_01 = new Player_01();
        _movePlayer_01 = new MovePlayer_01(_player_01, _dungeon01);

        _monster = new Monster();
        _moveMonster = new MoveMonster(_monster, _dungeon01);
        _monster2 = new Monster();
        _moveMonster2 = new MoveMonster2(_monster2, _dungeon01);
        _monster3 = new Monster();
        _moveMonster3 = new MoveMonster3(_monster3, _dungeon01);
        _monster4 = new Monster();
        _moveMonster4 = new MoveMonster4(_monster4, _dungeon01);
        _monster5 = new Monster();
        _moveMonster5 = new MoveMonster5(_monster5, _dungeon01);

        _Boss = new Boss();
        _moveBoss = new MoveBoss(_Boss, _dungeon01);

        _dungeon01.Init();
        _dungeon01.SpawnPlayer(_player_01);
        // 몬스터도 랜덤 스폰이 되는 공짜코드다.
        _dungeon01.SpawnMonster(_monster);
        _dungeon01.SpawnMonster(_monster2);
        _dungeon01.SpawnMonster(_monster3);
        _dungeon01.SpawnMonster(_monster4);
        _dungeon01.SpawnMonster(_monster5);
        _dungeon01.SpawnBoss(_Boss);
    }

    public void Init3()
    {
        _dungeon02 = new Dungeon_02();
        _player_02 = new Player_02();
        _movePlayer_02 = new MovePlayer_02(_player_02, _dungeon02);

        _ghost = new Ghost();
        _moveghost = new MoveGhost(_ghost, _dungeon02);
        _ghost2 = new Ghost();
        _moveghost2 = new MoveGhost2(_ghost2, _dungeon02);
        _ghost3 = new Ghost();
        _moveghost3 = new MoveGhost3(_ghost3, _dungeon02);
        _ghost4 = new Ghost();
        _moveghost4 = new MoveGhost4(_ghost4, _dungeon02);
        _ghost5 = new Ghost();
        _moveghost5 = new MoveGhost5(_ghost5, _dungeon02);
        _ghost6 = new Ghost();
        _moveghost6 = new MoveGhost6(_ghost6, _dungeon02);
        _ghost7 = new Ghost();
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
