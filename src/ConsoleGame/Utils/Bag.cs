using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.Utils
{
    public class Bag
    {
        static int index = 0;
        static int ShowIndex = 0;
        static int ChooseIndex = 0;

        static List<Dictionary<string, int>> bags;

        public static void Show()
        {
            Init();
            Console.WriteLine("---------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[恢复]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[攻击]");
            Console.Write("[使用]");
            Console.WriteLine("");
            Console.WriteLine("---------------");

            ShowBag(index);

            while (true)
            {
                var key = Console.ReadKey().Key;
                if ((int)key >= 37 && (int)key <= 40)
                {
                    if (key == ConsoleKey.RightArrow || key == ConsoleKey.LeftArrow)
                    {
                        if (key == ConsoleKey.RightArrow)
                            index++;
                        else if (key == ConsoleKey.LeftArrow)
                            index--;
                        if (index > 2) index = 0;
                        if (index < 0) index = 2;

                        Console.SetCursorPosition(0, 1);
                        Console.ForegroundColor = index == 0 ? ConsoleColor.Green : ConsoleColor.White;
                        Console.Write("[恢复]");
                        Console.ForegroundColor = index == 1 ? ConsoleColor.Green : ConsoleColor.White;
                        Console.Write("[攻击]");
                        Console.ForegroundColor = index == 2 ? ConsoleColor.Green : ConsoleColor.White;
                        Console.Write("[使用]");
                        ShowIndex = 0;
                        ChooseIndex = 0;
                    }

                    if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow)
                    {
                        if (key == ConsoleKey.UpArrow)
                            ChooseIndex--;
                        else
                            ChooseIndex++;

                        if (ChooseIndex < 0)
                        {
                            ChooseIndex = 0;
                        }
                    }
                    ShowBag(index);
                }

                if ( key == ConsoleKey.Enter)
                {
                    // 返回
                }
            }
        }

        private static void Init()
        {
            bags = new List<Dictionary<string, int>>();

            bags.Add(new Dictionary<string, int>()
            {
                { "恢复药",10},
                { "回灵药",5},
                { "一灵药",5},
                { "二灵药",5},
                { "三灵药",5},
                { "四灵药",5},
                { "五灵药",5},
                { "六灵药",5},
                { "七灵药",5},
                { "八灵药",5},
                { "九灵药",5},
                { "复生旦",1}
            });
            bags.Add(new Dictionary<string, int>()
            {
                { "铁钉",8},
                { "丧魂钉",99}
            });
            bags.Add(new Dictionary<string, int>()
            {
                { "秘籍",10},
                { "天书",5},
                { "不知劵",1},
                { "某物",20}
            });
        }

        private static void ShowBag(int index)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 3);

            var dic = bags[index];
            var vs = dic.Keys.ToList();
            if (ChooseIndex >= vs.Count)
            {
                ChooseIndex = vs.Count - 1;
            }

            if (ChooseIndex < ShowIndex)
                ShowIndex--;
            else if (ChooseIndex >= ShowIndex + 5)
                ShowIndex++;

            for (int i = ShowIndex; i < ShowIndex + 5; i++)
            {
                Console.ForegroundColor = i == ChooseIndex ? ConsoleColor.Green : ConsoleColor.White;

                if (i < vs.Count)
                {
                    Console.WriteLine((vs[i].PadRight(10, ' ') + "x" + dic[vs[i]]).PadRight(20, ' '));
                }
                else
                    Console.WriteLine("".PadRight(20,' '));
            }
        }
    }
}
