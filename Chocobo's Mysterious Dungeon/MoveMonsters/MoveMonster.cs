using System;


public class MoveMonster
{
    Monster _monster;
    Tutorial_Dungeon _tutorial_Dungeon;

    bool _onGoal = false;

    public MoveMonster(Monster monster, Tutorial_Dungeon tutorial_Dungeon)
    {
        _monster = monster;
        _tutorial_Dungeon = tutorial_Dungeon;
    }

    public Result MonsterMove(ConsoleKey inputKey)
    {
        Object.Position nextPosition = _monster.MonsterPosition;

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

        string _tatgetTutorial = _tutorial_Dungeon.GetObject(nextPosition.X, nextPosition.Y);

        if (_tatgetTutorial == Object.WALL)
        {
            return Result.Fail();
        }

        if (_onGoal)
        {
            _onGoal = false;
            _tutorial_Dungeon.SetObject(_monster.MonsterPosition.X, _monster.MonsterPosition.Y, Object.GOAL);
        }
        else
        {
            _tutorial_Dungeon.SetObject(_monster.MonsterPosition.X, _monster.MonsterPosition.Y, Object.EMPTY);
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

        _monster.Move(nextPosition);

        return Result.Success();
    }
}
