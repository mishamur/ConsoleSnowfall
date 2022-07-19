using mveu1607;

namespace mveu
{

    // подсчёт гл-согл букв в приложении
    // генерация лабиринта
    // снегопад в консли (*)

    
    public static class Program
    {
        public static void Main()
        {
            ConsoleSnowfall consoleSnowfall = new ConsoleSnowfall(Console.WindowHeight, Console.WindowWidth);
            consoleSnowfall.Run(1000);
         
        }


    }
}