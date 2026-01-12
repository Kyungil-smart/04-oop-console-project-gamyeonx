using System;


public class MoveGhost
{
    readonly Random random = new Random();

    Ghost _ghost;
    Dungeon_02 _dungeon_02;

    bool _onGoal = false;

    public MoveGhost(Ghost ghost, Dungeon_02 dungeon_02)
    {
        _ghost = ghost;
        _dungeon_02 = dungeon_02;
    }

    public Result GhostMove(ConsoleKey inputKey)
    {
        Object.Position nextPosition = _ghost.GhostPosition;

        switch (inputKey)
        {
            case ConsoleKey.UpArrow:
                nextPosition.X += random.Next(-1, 1);
                break;
            case ConsoleKey.DownArrow:
                nextPosition.Y += random.Next(-1, 1);
                break;
            case ConsoleKey.LeftArrow:
                nextPosition.X += random.Next(-1, 1);
                break;
            case ConsoleKey.RightArrow:
                nextPosition.Y += random.Next(-1, 1);
                break;
            default:
                return Result.Fail();
        }

        string _tatgetTutorial = _dungeon_02.GetObject(nextPosition.X, nextPosition.Y);

        if (_tatgetTutorial == Object.WALL || _tatgetTutorial == Object.GHOST)
        {
            return Result.Fail();
        }

        if (_onGoal)
        {
            _onGoal = false;
            _dungeon_02.SetObject(_ghost.GhostPosition.X, _ghost.GhostPosition.Y, Object.GOAL);
        }
        else
        {
            _dungeon_02.SetObject(_ghost.GhostPosition.X, _ghost.GhostPosition.Y, Object.EMPTY);
        }

        if (_dungeon_02.GetObject(nextPosition.X, nextPosition.Y) == Object.GOAL)
        {
            _dungeon_02.SetObject(nextPosition.X, nextPosition.Y, Object.GHOST);
            _onGoal = true;
        }
        else
        {
            _dungeon_02.SetObject(nextPosition.X, nextPosition.Y, Object.GHOST);
        }

        if (_dungeon_02.GetObject(nextPosition.X, nextPosition.Y) == Object.PLAYER)
        {
            _dungeon_02.SetObject(nextPosition.X, nextPosition.Y, Object.DEATH);
            _onGoal = true;
        }
        else
        {
            _dungeon_02.SetObject(nextPosition.X, nextPosition.Y, Object.GHOST);
        }

        _ghost.Move(nextPosition);

        return Result.Success();
    }
}
