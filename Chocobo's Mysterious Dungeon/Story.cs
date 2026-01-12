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
        Console.WriteLine("슬라임을 피해 던전의 입구를 찾아라: 🕳️");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("초코보는 폭력이 싫어졌다.");
        Console.ResetColor();
        Console.WriteLine();
    }

    public void PrintTutorial3()
    {
        Console.WriteLine("조작키: ←↕→");
        Console.WriteLine("유령을 피해 던전의 입구를 찾아라: 🕳️");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("유령은 공격이 통하지 않는다.");
        Console.ResetColor();
        Console.WriteLine();
    }

    public void PrintTutorial_Last()
    {
        Console.WriteLine("조작키: ←↕→");
        Console.WriteLine("아기 초코보를 쿠출해라: 🐣");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("잠들어 있다... 무슨 짓을 해도 깨지 않을 것 같다.");
        Console.ResetColor();
        Console.WriteLine();
    }
}

