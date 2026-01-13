using System;
using System.Linq.Expressions;


public class MoveBoss
{
    Boss _boss;
    Dungeon_01 _dungeon_01;

    Player_01 _player_01 = new Player_01();

    bool _onGoal = false;

    public MoveBoss(Boss boss, Dungeon_01 dungeon_01)
    {
        _boss = boss;
        _dungeon_01 = dungeon_01;
    }

    public Result BossMove(ConsoleKey inputKey)
    {
        Object.Position nextPosition = _boss.BossPosition;

        switch (inputKey)
        {
            case ConsoleKey.UpArrow:
                nextPosition.X--;
                nextPosition.X--;
                nextPosition.Y--;
                break;
            case ConsoleKey.DownArrow:
                nextPosition.X++;
                nextPosition.X++;
                nextPosition.Y++;
                break;
            case ConsoleKey.LeftArrow:
                nextPosition.Y--;
                nextPosition.X++;
                nextPosition.X++;
                break;
            case ConsoleKey.RightArrow:
                nextPosition.Y++;
                nextPosition.X--;
                nextPosition.X--;
                break;
            default:
                return Result.Fail();
        }

        if (nextPosition.X < 0 || nextPosition.X >= 20 || nextPosition.Y < 0 || nextPosition.Y >= 20)
        {
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
            _dungeon_01.SetObject(_boss.BossPosition.X, _boss.BossPosition.Y, Object.GOAL);
        }
        else
        {
            _dungeon_01.SetObject(_boss.BossPosition.X, _boss.BossPosition.Y, Object.EMPTY);
        }

        if (_dungeon_01.GetObject(nextPosition.X, nextPosition.Y) == Object.GOAL)
        {
            _dungeon_01.SetObject(nextPosition.X, nextPosition.Y, Object.BOSS_ON_GOAL);
            _onGoal = true;
        }
        else
        {
            _dungeon_01.SetObject(nextPosition.X, nextPosition.Y, Object.BOSS);
        }

        _boss.Move(nextPosition);

        return Result.Success();
    }
}
