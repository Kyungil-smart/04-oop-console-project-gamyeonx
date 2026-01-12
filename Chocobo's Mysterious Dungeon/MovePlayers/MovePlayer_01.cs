using System;


internal class MovePlayer_01
{
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
        Object.eMoveDir dir = Object.eMoveDir.NONE;

        switch (inputKey)
        {
            case ConsoleKey.UpArrow:
                dir = Object.eMoveDir.UP;
                nextPosition.X--;
                break;
            case ConsoleKey.DownArrow:
                dir = Object.eMoveDir.DOWN;
                nextPosition.X++;
                break;
            case ConsoleKey.LeftArrow:
                dir = Object.eMoveDir.LEFT;
                nextPosition.Y--;
                break;
            case ConsoleKey.RightArrow:
                dir = Object.eMoveDir.RIGHT;
                nextPosition.Y++;
                break;
            default:
                return Result.Fail();
        }

        string _tatgetTutorial = _dungeon_01.GetObject(nextPosition.X, nextPosition.Y);

        if (_tatgetTutorial == Object.WALL)
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

