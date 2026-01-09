using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

internal class OpeningScene
{
    private readonly Dictionary<string, double> _nt = new Dictionary<string, double> {
            {"C",261.6},{"C#",277.2},{"D",293.7},{"D#",311.1},{"E",329.6},{"F",349.2},{"F#",370.0},{"G",392.0},{"G#",415.3},{"A",440.0},{"A#",466.2},{"B",493.9}
        };
    private readonly object _lk = new object();
    private bool _run = true;
    private int _lt, _lb;

    public void Play()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false; Console.Clear();
        _lt = Console.WindowHeight / 2 - 4; _lb = _lt + 6;

        var ts = new[] { Task.Run(PlayBgm), Task.Run(AnimateChicks) };
        ShowLogo();

        ts[0].Wait(); 
        _run = false;
        ts[1].Wait();

       
        ShowPressAnyKey();
    }

    private void ShowLogo()
    {
        string[] lg = {
                "  ██████╗██╗  ██╗ ██████╗  ██████╗ ██████╗ ██████╗  ██████╗ ",
                " ██╔════╝██║  ██║██╔═══██╗██╔════╝██╔═══██╗██╔══██╗██╔═══██╗",
                " ██║     ███████║██║   ██║██║     ██║   ██║██████╔╝██║   ██║",
                " ██║     ██╔══██║██║   ██║██║     ██║   ██║██╔══██╗██║   ██║",
                " ╚██████╗██║  ██║╚██████╔╝╚██████╗╚██████╔╝██████╔╝╚██████╔╝",
                "  ╚═════╝╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚═════╝ ╚═════╝  ╚═════╝ "
            };
        int lx = (Console.WindowWidth - lg[0].Length) / 2;
        for (int y = -6; y <= _lt; y++)
        {
            lock (_lk)
            {
                for (int i = -1; i <= 6; i++)
                { 
                    int py = y + i;
                    if (py >= 0 && py < Console.WindowHeight)
                    {
                        Console.SetCursorPosition(0, py); Console.Write(new string(' ', Console.WindowWidth));
                        if (i >= 0 && i < 6)
                        {
                            Console.SetCursorPosition(lx, py);
                            Console.Write("\x1b[38;2;255;255;0m" + lg[i] + "\x1b[0m");
                        }
                    }
                }
            }
            Thread.Sleep(80);
        }
    }

    private void ShowPressAnyKey()
    {
        string msg = "- PRESS ANY KEY TO START -";
        int mx = (Console.WindowWidth - msg.Length) / 2;
        int my = _lb + 2; 

        while (!Console.KeyAvailable)
        {
            lock (_lk)
            {
                Console.SetCursorPosition(mx, my);
                Console.Write("\x1b[38;2;255;255;255m" + msg + "\x1b[0m");
            }
            Thread.Sleep(500);
            lock (_lk)
            {
                Console.SetCursorPosition(mx, my);
                Console.Write(new string(' ', msg.Length)); 
            }
            Thread.Sleep(500);
        }
        Console.ReadKey(true); 
    }

    private void AnimateChicks()
    {
        var r = new Random(); var cs = new List<Ck>();
        for (int i = 0; i < 12; i++) cs.Add(new Ck(r, _lt, _lb));
        while (_run) { lock (_lk) foreach (var c in cs) c.Upd(); Thread.Sleep(100); }
    }

    private void PlayBgm()
    {
        string m = "t145v15l8>dr<bgel16>dr<brgrl8brgrv11l32bv12bv13bbv14bbv15bbv14bbv13bbv15a8l16grgagrfrv11l32gv12gv13ggv14ggv15ggv14ggv13ggv15f8g8l16gb>drerv11l32ffv12ffv13ffv14ffv15ffv14ffv13ffv12ffv15l8erc<af+l16ar>crerl8drgrv11l32dv12dv13ddv14ddv15ddv14ddv13ddv15<b8a8l16abargrv11l32av12av13aav14aav15aav14aav13aav15g8a8l16ab>crdre8r8f+4";
        int t = 145, o = 4, l = 8, p = 0, sc = 0;
        while (p < m.Length && _run)
        {
            char c = char.ToUpper(m[p++]);
            if (c == 'T') t = Rn(m, ref p);
            else if (c == 'O') o = Rn(m, ref p);
            else if (c == 'L') l = Rn(m, ref p);
            else if (c == '>') o++;
            else if (c == '<') o--;
            else if ("CDEFGABR".Contains(c))
            {
                string n = c.ToString(); if (p < m.Length && (m[p] == '+' || m[p] == '#')) { n += "#"; p++; }
                int nl = Rn(m, ref p); if (nl == 0) nl = l; double d = 240000.0 / (t * nl);
                if (nl >= 32 && n != "R") { if (++sc % 3 != 0) continue; d *= 2.5; } else sc = 0;
                if (n == "R") Thread.Sleep((int)d);
                else if (_nt.ContainsKey(n)) Console.Beep((int)(_nt[n] * Math.Pow(2, o - 4)), (int)(d * 0.8));
            }
        }
    }

    private int Rn(string s, ref int p)
    {
        string r = ""; while (p < s.Length && char.IsDigit(s[p])) r += s[p++];
        return r == "" ? 0 : int.Parse(r);
    }

    private class Ck
    {
        float x, y, dx, dy; int s = 0, t = 0, lt, lb;
        public Ck(Random r, int top, int bot)
        {
            lt = top; lb = bot; x = r.Next(2, Console.WindowWidth - 4);
            y = r.Next(2) == 0 ? r.Next(0, 3) : r.Next(Console.WindowHeight - 4, Console.WindowHeight - 1);
            dx = (float)(r.NextDouble() * 2 - 1); dy = (float)(r.NextDouble() * 0.4 - 0.2);
        }
        public void Upd()
        {
            Console.SetCursorPosition((int)x, (int)y); Console.Write("  ");
            if (s < 2) { if (++t > 15) { s++; t = 0; } }
            else
            {
                x += dx; y += dy;
                if (x <= 0 || x >= Console.WindowWidth - 2) dx *= -1;
                if (y <= 0 || y >= Console.WindowHeight - 1 || (y >= lt - 2 && y <= lb + 2)) dy *= -1;
            }
            Console.SetCursorPosition((int)Math.Max(0, x), (int)Math.Max(0, y));
            Console.Write(new[] { "🐣", "🐥", "🐤" }[s]);
        }
    }
}

