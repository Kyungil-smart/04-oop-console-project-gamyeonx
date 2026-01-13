using System;


internal class MovePlayer_01
{   // 던전마다 조작방식이 다를 필요도 쪼~금 있고
    // 나쁜 예시로 교보재로 써도 변명의 여지가 없다.
    Player_01 _player_01;
    Dungeon_01 _dungeon_01;

    bool _onGoal = false;

    public MovePlayer_01(Player_01 player_01, Dungeon_01 dungeon_01)
    {
        _player_01 = player_01;
        _dungeon_01 = dungeon_01;
    }

    public Result PlayerMove(ConsoleKey inputKey)
    {
        Object.Position nextPosition = _player_01.PlayerPosition;

        switch (inputKey)
        {
            case ConsoleKey.UpArrow:
                nextPosition.X--;
                break;
            case ConsoleKey.DownArrow:
                nextPosition.X++;
                break;
            case ConsoleKey.LeftArrow:
                nextPosition.Y--;
                break;
            case ConsoleKey.RightArrow:
                nextPosition.Y++;
                break;
            default:
                return Result.Fail();
        }

        // 이름을 바꾸는걸 깜빡했다.
        // 하지만 바꾸지 않는다.
        string _tatgetTutorial = _dungeon_01.GetObject(nextPosition.X, nextPosition.Y);

        // 몬스터와 겹쳐야 죽는 판정이라 벽만 판정을 만들었다.
        if (_tatgetTutorial == Object.WALL ||
            _tatgetTutorial == Object.BOSS || _tatgetTutorial == Object.WALL2)
        {
            return Result.Fail();
        }

        if (_onGoal)
        {
            _onGoal = false;
            _dungeon_01.SetObject(_player_01.PlayerPosition.X, _player_01.PlayerPosition.Y, Object.GOAL);
        }
        else
        {
            _dungeon_01.SetObject(_player_01.PlayerPosition.X, _player_01.PlayerPosition.Y, Object.EMPTY);
        }

        if (_dungeon_01.GetObject(nextPosition.X, nextPosition.Y) == Object.GOAL)
        {
            _dungeon_01.SetObject(nextPosition.X, nextPosition.Y, Object.PLAYER_ON_GOAL);
            _onGoal = true;
        }
        else
        {
            _dungeon_01.SetObject(nextPosition.X, nextPosition.Y, Object.PLAYER);
        }

        _player_01.Move(nextPosition);

        return Result.Success();
    }
}

