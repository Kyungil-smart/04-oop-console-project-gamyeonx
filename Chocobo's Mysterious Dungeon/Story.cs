using System;


public class Story
{
    public void PrintTutorial()
    {
        Console.WriteLine("조작키: ←↕→");
        Console.WriteLine("던전의 입구를 찾아라: 🕳️");
        Console.WriteLine();
    }
    public void PrintTutorial2()
    {
        Console.WriteLine("조작키: ←↕→");
        Console.WriteLine("던전의 입구를 찾아라: 🕳️");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("비가 내리기 시작했다...");
        Console.ResetColor();
        Console.WriteLine();
    }

    public void PrintTutorial3()
    {
        Console.WriteLine("조작키: ←↕→");
        Console.WriteLine("던전의 입구를 찾아라: 🕳️");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("시체 썩은 내가 난다...");
        Console.ResetColor();
        Console.WriteLine();
    }

    public void PrintTutorial_Last()
    {
        Console.WriteLine("조작키: ←↕→");
        Console.WriteLine("보스를 해치워라: 🐦‍🔥");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("던전안이 뜨거워 졌다...");
        Console.ResetColor();
        Console.WriteLine();
    }



}

