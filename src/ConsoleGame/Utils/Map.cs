using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Utils
{
    public class Map
    {
        //■★
        public static string MapStr =
@"
■■■■■■■■■■■■
★         ■■■
■■  ■■     ◈■   s asasdas112351
■          
■a
■
☼♀☺◐☑√✔☜☝☀☾♂☹◑☒
■■■■■■■■■■■■■■■■■■■■■■■■■■■
         ";

        public static void Show()
        {
            Console.WriteLine(MapStr);

            Console.ReadKey();
        }
    }
}
