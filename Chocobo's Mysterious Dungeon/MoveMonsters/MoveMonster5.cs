using System;


public class MoveMonster5
{
    Monster _monster;
    Dungeon_01 _dungeon_01;

    bool _onGoal = false;

    public MoveMonster5(Monster monster, Dungeon_01 dungeon_01)
    {
        _monster = monster;
        _dungeon_01 = dungeon_01;
    }

    public Result MonsterMove(ConsoleKey inputKey)
    {
        Object.Position nextPosition = _monster.MonsterPosition;

        switch (inputKey)
        {
            case ConsoleKey.UpArrow:
                nextPosition.X++;
                break;
            case ConsoleKey.DownArrow:
                nextPosition.X--;
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

        string _tatgetTutorial = _dungeon_01.GetObject(nextPosition.X, nextPosition.Y);

        if (_tatgetTutorial == Object.WALL || _tatgetTutorial == Object.MONSTER ||
           _tatgetTutorial == Object.BOSS || _tatgetTutorial == Object.WALL2)
        {
            return Result.Fail();
        }

        if (_onGoal)
        {
            _onGoal = false;
            _dungeon_01.SetObject(_monster.MonsterPosition.X, _monster.MonsterPosition.Y, Object.GOAL);
        }
        else
        {
            _dungeon_01.SetObject(_monster.MonsterPosition.X, _monster.MonsterPosition.Y, Object.EMPTY);
        }

        if (_dungeon_01.GetObject(nextPosition.X, nextPosition.Y) == Object.GOAL)
        {
            _dungeon_01.SetObject(nextPosition.X, nextPosition.Y, Object.MONSTER_ON_GOAL);
            _onGoal = true;
        }
        else
        {
            _dungeon_01.SetObject(nextPosition.X, nextPosition.Y, Object.MONSTER);
        }

        _monster.Move(nextPosition);

        return Result.Success();
    }
}
