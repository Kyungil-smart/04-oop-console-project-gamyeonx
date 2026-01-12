//using System;
//using System.Collections.Generic;


//public class MonsterBFS
//{
//    public List<int> BFS(int start)
//    {
//        List<int> path = new List<int>();
//        Queue<int> queue = new Queue<int>();

//        bool[] visited = new bool[_vertextCount];
//        visited[start] = true;
//        queue.Enqueue(start);

//        while (queue.Count > 0)
//        {
//            int current = queue.Dequeue();
//            path.Add(current);

//            for (int i = 0; i < _vertextCount; i++)
//            {
//                if (_matrix[current, i] && !visited[i])
//                {
//                    visited[i] = true;
//                    queue.Enqueue(i);
//                }
//            }
//        }
//        return path;
//    }
//}

