using System;


internal class MovePlayer
{
    Player _player;
    Tutorial_Dungeon _tutorial_Dungeon;

    bool _onGoal = false;

    public MovePlayer(Player player, Tutorial_Dungeon tutorial_Dungeon)
    {
        _player = player;
        _tutorial_Dungeon = tutorial_Dungeon;
    }

    public Result PlayerMove(ConsoleKey inputKey)
    {
        Object.Position nextPosition = _player.PlayerPosition;
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

        string _tatgetTutorial = _tutorial_Dungeon.GetObject(nextPosition.X, nextPosition.Y);

        if (_tatgetTutorial == Object.WALL)
        {
            return Result.Fail();
        }

        if(_onGoal)
        {
            _onGoal = false;
            _tutorial_Dungeon.SetObject(_player.PlayerPosition.X, _player.PlayerPosition.Y, Object.GOAL);
        }
        else
        {
            _tutorial_Dungeon.SetObject(_player.PlayerPosition.X, _player.PlayerPosition.Y, Object.EMPTY);
        }

        if (_tutorial_Dungeon.GetObject(nextPosition.X, nextPosition.Y) == Object.GOAL)
        {
            _tutorial_Dungeon.SetObject(nextPosition.X, nextPosition.Y, Object.PLAYER_ON_GOAL);
            _onGoal = true;
        }
        else
        {
            _tutorial_Dungeon.SetObject(nextPosition.X, nextPosition.Y, Object.PLAYER);
        }

            _player.Move(nextPosition);

        return Result.Success();
    }
}
