using System;


public class MovePlayer_02
{
    Player_02 _player_02;
    Dungeon_02 _dungeon_02;

    bool _onGoal = false;

    public MovePlayer_02(Player_02 player_02, Dungeon_02 dungeon_02)
    {
        _player_02 = player_02;
        _dungeon_02 = dungeon_02;
    }

    public Result PlayerMove(ConsoleKey inputKey)
    {
        Object.Position nextPosition = _player_02.PlayerPosition;
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

        string _tatgetTutorial = _dungeon_02.GetObject(nextPosition.X, nextPosition.Y);

        if (_tatgetTutorial == Object.WALL)
        {
            return Result.Fail();
        }

        if (_onGoal)
        {
            _onGoal = false;
            _dungeon_02.SetObject(_player_02.PlayerPosition.X, _player_02.PlayerPosition.Y, Object.GOAL);
        }
        else
        {
            _dungeon_02.SetObject(_player_02.PlayerPosition.X, _player_02.PlayerPosition.Y, Object.EMPTY);
        }

        if (_dungeon_02.GetObject(nextPosition.X, nextPosition.Y) == Object.GOAL)
        {
            _dungeon_02.SetObject(nextPosition.X, nextPosition.Y, Object.PLAYER_ON_GOAL);
            _onGoal = true;
        }
        else
        {
            _dungeon_02.SetObject(nextPosition.X, nextPosition.Y, Object.PLAYER);
        }

        _player_02.Move(nextPosition);

        return Result.Success();
    }
}
