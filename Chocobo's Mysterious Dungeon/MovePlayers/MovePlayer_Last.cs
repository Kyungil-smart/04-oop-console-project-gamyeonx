using System;


public class MovePlayer_Last
{
    Player_Last _player_Last;
    Dungeon_Last _dungeon_Last;

    bool _onGoal = false;

    public MovePlayer_Last(Player_Last player_Last, Dungeon_Last dungeon_Last)
    {
        _player_Last = player_Last;
        _dungeon_Last = dungeon_Last;
    }

    public Result PlayerMove(ConsoleKey inputKey)
    {
        Object.Position nextPosition = _player_Last.PlayerPosition;
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

        string _tatgetTutorial = _dungeon_Last.GetObject(nextPosition.X, nextPosition.Y);

        if (_tatgetTutorial == Object.WALL)
        {
            return Result.Fail();
        }

        if (_onGoal)
        {
            _onGoal = false;
            _dungeon_Last.SetObject(_player_Last.PlayerPosition.X, _player_Last.PlayerPosition.Y, Object.GOAL);
        }
        else
        {
            _dungeon_Last.SetObject(_player_Last.PlayerPosition.X, _player_Last.PlayerPosition.Y, Object.EMPTY);
        }

        if (_dungeon_Last.GetObject(nextPosition.X, nextPosition.Y) == Object.GOAL)
        {
            _dungeon_Last.SetObject(nextPosition.X, nextPosition.Y, Object.PLAYER_ON_GOAL);
            _onGoal = true;
        }
        else
        {
            _dungeon_Last.SetObject(nextPosition.X, nextPosition.Y, Object.PLAYER);
        }

        _player_Last.Move(nextPosition);

        return Result.Success();
    }
}

