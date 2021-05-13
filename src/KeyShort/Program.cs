using System;
using System.Collections.Generic;

namespace KeyShort
{
    class Program
    {
        static bool End = false;
        static System.Timers.Timer GameTimer;
        static int TotalCount;
        static void Main(string[] args)
        {
            // 游戏区
            Console.WindowHeight = 22;
            Console.WindowWidth = 72;
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0, 20);
            Console.Write("■■■■■■■■■■■■■■■■■■■■■■■■■■");

            Console.SetCursorPosition(56, 3);
            Console.Write("当前分数：0");

            for (int i = 0; i < 21; i++)
            {
                Console.SetCursorPosition(52, i);
                Console.Write('|');
            }

            // 游戏开始
            GameTimer = new System.Timers.Timer();
            GameTimer.Elapsed += GameTimer_Elapsed;
            GameTimer.Interval = 1;
            GameTimer.Enabled = true;

            while (!End)
            {
                try
                {
                    var key = Console.ReadKey(true);
                    var c = key.KeyChar;
                    foreach (var b in blocks)
                    {
                        if (b.Shot(key.KeyChar))
                        {
                            blocks.Remove(b);
                            TotalCount++;
                            Console.SetCursorPosition(66, 3);
                            Console.Write(TotalCount);
                            speed = TotalCount / 10 + 1;
                            if (speed > 9)
                                speed = 9;
                            break;
                        }
                    }
                }
                catch { }
            }
        }

        private static void GameTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                GameTimer.Enabled = false;
                foreach (var block in blocks)
                {
                    if (!block.Move())
                    {
                        Console.SetCursorPosition(56, 5);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("失败，游戏完结！");
                        End = true;
                        return;
                    }
                }
                if (DateTime.Now.Millisecond % 2 == 0 || blocks.Count < 5)
                {
                    blocks.Add(new KeyBlock((char)(DateTime.Now.Millisecond % 27 + 'A')));
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                GameTimer.Interval = 1100 - speed * 100 + new Random().Next(0, 10);
                GameTimer.Enabled = true;
            }
        }

        static List<KeyBlock> blocks = new List<KeyBlock>();
        static int speed = 1;
        private static void StartGame()
        {
            while (!End)
            {
                
            }
        }
    }
}
