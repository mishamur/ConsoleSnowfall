using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mveu1607
{
    public class ConsoleSnowfall
    {
        private int height;
        private int width;

        //массив снежинок
        private char[][] snow;
        public ConsoleSnowfall(int consoleHight, int consoleWidth)
        {
            height = consoleHight;
            width = consoleWidth;
            snow = new char[height][];

            for(int i = 0; i < height; i++)
            {
                snow[i] = new char[width];
            }
        }

        /// <summary>
        /// запустить снегопад
        /// </summary>
        /// <param name="delay">задержка перед отрисовкой новой линии</param>
        public void Run(int delay = 500)
        {
            //начальная инициализация снежинок на 0 строке 
            Random rand = new Random();
            for (int i = 0; i < width; i++)
            {
                if (rand.Next(2) == 1)
                {
                    snow[0][i] = '*';
                }
            }


            while (!Console.KeyAvailable)
            {
                PrintAtConsole();
                UpdateSnow();
                Thread.Sleep(delay);   
            }
            Console.Clear();
            Console.SetCursorPosition(0, 0);
        }
        /// <summary>
        /// генерируем следующий "кадр" снегопада
        /// </summary>
        public void UpdateSnow()
        {
            char[][] temp = new char[height][];
            for(int i = 0; i < height; i++)
            {
                temp[i] = new char[width];
                for (int j = 0; j < temp[i].Length; j++)
                    temp[i][j] = ' ';
            }        
                

            Random rand  = new Random();
            for(int i = 0; i < snow.Length; i++)
            {
                for(int j = 0; j < snow[i].Length - 1; j++)
                {
                    if(snow[i][j] == '*')
                    {                     
                        //т.е c вероятностью 1/3 у нас снежинка падает влево, вправо, или остаётся на том же индексе j
                        int randnNum = rand.Next(-1, 2);
                        if (i + 1 < height && j + randnNum >= 0 && randnNum < width)
                            temp[i + 1][j + randnNum] = '*';
                    }
                }
            }

            //случайным образом заполняем первую строку снежинками
            for (int i = 0; i < width; i++)
            {
                if (rand.Next(2) == 1)
                {
                    temp[0][i] = '*';
                }
            }
            snow = temp;
            return;
        }


        private void PrintAtConsole()
        {
            for (int i = 0; i < snow.Length; i++)
            {
                for(int j = 0; j < snow[i].Length; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(snow[i][j]);
                }   
            }
        }

    }
}
