using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

public class MonsterBFS
{
    private Dungeon_01 _dungeon;

    public MonsterBFS(Dungeon_01 dungeon)
    {
        _dungeon = dungeon;
    }
    public Object.Position solution(Object.Position monsterPosition, Object.Position playerPosition)
    {
        int width = 20;
        int height = 20;

        int[] dx = { 0, 0, -1, 1 };
        int[] dy = { -1, 1, 0, 0 };

        int[,] moveCount = new int[width, height];
        Object.Position[,] origin = new Object.Position[width, height];

        Queue<Object.Position> queue = new Queue<Object.Position>();
        queue.Enqueue(monsterPosition);
        moveCount[0, 0] = 1;

        while (queue.Count > 0)
        {
            Object.Position current = queue.Dequeue();
            int currentY = current.Y;
            int currentX = current.X;

            if (currentY == playerPosition.X && currentX == playerPosition.Y)
            {
                return TraceNextStep(monsterPosition, playerPosition, origin);
            }

            for (int i = 0; i < 4; i++)
            {
                int targetY = currentY + dy[i];
                int targetX = currentX + dx[i];

                if (targetY >= 0 && targetY < width && targetX >= 0 && targetX < height)
                {
                    string _targetObject = _dungeon.GetObject(targetX, targetY);
                    if ((_targetObject != Object.WALL && moveCount[targetX, targetY] == 0) || (targetX == playerPosition.X && targetY == playerPosition.Y))
                    {
                        moveCount[targetY, targetX] = moveCount[currentY, currentX] + 1;
                        origin[targetX, targetY] = current;
                        queue.Enqueue(new Object.Position { X = targetX, Y = targetY });
                    }
                }
            }
        }

        return monsterPosition;
    }

    private Object.Position TraceNextStep(Object.Position start, Object.Position goal, Object.Position[,] origin)
    {
        Object.Position current = goal;
        while (origin[current.X, current.Y].X != start.X || origin[current.X, current.Y].Y != start.Y)
        {
            current = origin[current.X, current.Y];
            if (current.X == 0 && current.Y == 0) break;
        }

        return current;
    }
}