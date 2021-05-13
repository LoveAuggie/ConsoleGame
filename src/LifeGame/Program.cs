using System;

namespace LifeGame
{
    class Program
    {
        static int width = 20;
        static int StartCount = 100;
        static int[,] Map;
        static void Main(string[] args)
        {
            Console.WindowWidth = (width + 2) * 2;
            Console.WindowHeight = width + 2;
            Map = new int[width, width];

            Random rand = new Random(DateTime.Now.GetHashCode());
            for (int i = 0; i < StartCount; i++)
            {
                var x = rand.Next(0, width);
                var y = rand.Next(0, width);
                Map[x, y] = 1;
            }
            DrawMap();

            while (true)
            {
                ReSetMap();
                DrawMap();
                System.Threading.Thread.Sleep(1000);
            }
        }

        private static void ReSetMap()
        {
            int[,] nMap = new int[width, width];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int Count = GetLiveCount(i, j);
                    if (Count == 3)
                        nMap[i, j] = 1;
                    else if (Count == 2)
                        nMap[i, j] = Map[i, j];
                    else
                        nMap[i, j] = 0;
                }
            }

            Map = nMap;
        }

        private static int GetLiveCount(int x, int y)
        {
            int Total = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i != 0 || j != 0)
                    {
                        var x1 = x + i;
                        var y1 = y + j;
                        if (x1 >= 0 && x1 < width && y1 >= 0 && y1 < width)
                        {
                            Total += Map[x1, y1];
                        }
                    }
                }
            }
            return Total;
        }

        private static void DrawMap()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.SetCursorPosition(1 + (i * 2), j + 1);
                    Console.ForegroundColor = Map[i, j] == 1 ? ConsoleColor.Green : ConsoleColor.Blue;
                    Console.Write('■');
                }
            }
        }
    }
}
