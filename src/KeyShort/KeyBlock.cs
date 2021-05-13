using System;
using System.Collections.Generic;
using System.Text;

namespace KeyShort
{
    public class KeyBlock
    {
        public char KeyChar { get; private set; }

        public int X { get; private set; }

        public int Y { get; private set; }
        public KeyBlock(char key)
        {
            this.KeyChar = key;
            this.X = new Random().Next(0, 50);
            this.Y = 0;
        }


        public bool Move()
        {
            // 移动一次
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(' ');
            this.Y++;
            if (this.Y >= 20)
                return false;
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(this.KeyChar);
            return true;
        }

        public bool Shot(char key)
        {
            if (key.ToString().ToUpper() == this.KeyChar.ToString().ToUpper())
            {
                Console.SetCursorPosition(this.X, this.Y);
                Console.Write('※');
                System.Threading.Thread.Sleep(50);
                Console.SetCursorPosition(this.X, this.Y);
                Console.Write(' ');
                return true;
            }
            return false;
        }
    }
}
