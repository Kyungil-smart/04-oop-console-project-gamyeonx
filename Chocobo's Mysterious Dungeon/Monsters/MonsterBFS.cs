using System;
using System.Collections.Generic;

class Solution
{
    public int solution(int[,] maps)
    {
        int answer = 0;
        int maxY = maps.GetLength(0);
        int maxX = maps.GetLength(1);

        int[] dy = { -1, 1, 0, 0 };
        int[] dx = { 0, 0, -1, 1 };

        int[,] moveCount = new int[maxY, maxX];

        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((0, 0));
        moveCount[0, 0] = 1;

        while (queue.Count > 0)
        {
            (int Y, int X) current = queue.Dequeue();
            int currentY = current.Y;
            int currentX = current.X;

            if (currentY == maxY - 1 && currentX == maxX - 1)
            {
                return answer = moveCount[currentY, currentX];
            }

            for (int i = 0; i < 4; i++)
            {
                int targetY = currentY + dy[i];
                int targetX = currentX + dx[i];

                if (targetY >= 0 && targetY < maxY && targetX >= 0 && targetX < maxX)
                {
                    if (maps[targetY, targetX] == 1 && moveCount[targetY, targetX] == 0)
                    {
                        moveCount[targetY, targetX] = moveCount[currentY, currentX] + 1;
                        queue.Enqueue((targetY, targetX));
                    }
                }
            }
        }

        return answer = -1;
    }
}