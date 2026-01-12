using System;
using System.Threading;


public class EndingScene
{
    private int centerX = Console.WindowWidth / 2;
    private int centerY = 20;
    private int heartLevel = 1;

    public void RenderApproach()
    {
        int parentX = Console.WindowWidth - 10;
        while (parentX > centerX + 2)
        {
            Console.Clear();
            Console.SetCursorPosition(centerX, centerY);
            Console.Write("🐣");
            Console.SetCursorPosition(parentX, centerY);
            Console.Write("🐤");

            parentX -= 1;
            Thread.Sleep(50);
        }

        Console.Clear();
        Console.SetCursorPosition(centerX, centerY);
        Console.Write("🐣 🐤");
    }

    public void AddHeartRising()
    {
        int xOffset = (heartLevel % 2 == 0) ? 1 : -1;
        int targetY = centerY - heartLevel;

        if (targetY > 0)
        {
            Console.SetCursorPosition(centerX + xOffset, targetY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("💕");
            Console.ResetColor();
            heartLevel++;
        }
    }

    public void ShowHappyEnd()
    {
        Thread.Sleep(1200);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
        Thread.Sleep(1000);

        Console.ForegroundColor = ConsoleColor.Yellow;
        string[] bigEnd = {
                "██╗  ██╗ █████╗ ██████╗ ██████╗ ██╗   ██╗    ███████╗███╗   ██╗██████╗ ",
                "██║  ██║██╔══██╗██╔══██╗██╔══██╗╚██╗ ██╔╝    ██╔════╝████╗  ██║██╔══██╗",
                "███████║███████║██████╔╝██████╔╝ ╚████╔╝     █████╗  ██╔██╗ ██║██║  ██║",
                "██╔══██║██╔══██║██╔═══╝ ██╔═══╝   ╚██╔╝      ██╔══╝  ██║╚██╗██║██║  ██║",
                "██║  ██║██║  ██║██║     ██║        ██║       ███████╗██║ ╚████║██████╔╝",
                "╚═╝  ╚═╝╚═╝  ╚═╝╚═╝     ╚═╝        ╚═╝       ╚══════╝╚═╝  ╚═══╝╚═════╝ "
            };

        int startY = (Console.WindowHeight / 2) - 3;
        foreach (string line in bigEnd)
        {
            Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, startY++);
            Console.WriteLine(line);
            Thread.Sleep(150);
        }
        Thread.Sleep(3000);
    }
}

public static class MusicPlayer
{
    public const int G4 = 392, Ab4 = 415, Bb4 = 466, C5 = 523, D5 = 587, Eb5 = 622, E5 = 659,
                     F5 = 698, G5 = 784, Ab5 = 831, Bb5 = 932, C6 = 1047, D6 = 1175,
                     Eb6 = 1244, E6 = 1319, F6 = 1397, G6 = 1568, Ab6 = 1661, Bb6 = 1865, C7 = 2093;

    public static void PlayMarioClear(Action onBeat)
    {
        onBeat?.Invoke(); Console.Beep(G4, 80); Console.Beep(C5, 80); Console.Beep(E5, 80);
        onBeat?.Invoke(); Console.Beep(G5, 80); Console.Beep(C6, 80); Console.Beep(E6, 80);
        Console.Beep(G6, 250); Console.Beep(E6, 250);

        onBeat?.Invoke(); Console.Beep(Ab4, 80); Console.Beep(C5, 80); Console.Beep(Eb5, 80);
        onBeat?.Invoke(); Console.Beep(Ab5, 80); Console.Beep(C6, 80); Console.Beep(Eb6, 80);
        Console.Beep(Ab6, 250); Console.Beep(Eb6, 250);

        onBeat?.Invoke(); Console.Beep(Bb4, 80); Console.Beep(D5, 80); Console.Beep(F5, 80);
        onBeat?.Invoke(); Console.Beep(Bb5, 80); Console.Beep(D6, 80); Console.Beep(F6, 80);
        Console.Beep(Bb6, 250);

        Thread.Sleep(50);
        onBeat?.Invoke();
        Console.Beep(Bb6, 120); Console.Beep(Bb6, 120); Console.Beep(Bb6, 120);
        Console.Beep(C7, 600);
    }
}
