//using System;
//using System.Collections.Generic;


//public class MonsterDFS
//{
//    public List<int> DFS(int start)
//    {
//        List<int> path = new List<int>();
//        Stack<int> stack = new Stack<int>();

//        bool[] visited = new bool[_vertextCount];
//        visited[start] = true;
//        stack.Push(start);

//        while (stack.Count > 0)
//        {
//            int current = stack.Pop();
//            path.Add(current);

//            for (int i = 0; i < _vertextCount; i++)
//            {
//                if (_matrix[current, i] && !visited[i])
//                {
//                    visited[i] = true;
//                    stack.Push(i);
//                }
//            }
//        }
//        return path;
//    }
//}

