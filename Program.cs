using System;

namespace Arena
{
    class Program
    {
        static void Main(string[] args)
        {
            RollingDie die = new RollingDie(10);
            Warrior DJ = new Warrior("DJ", 100, 20, 10, die);
            Warrior Victoria = new Warrior("Victoria", 60, 18, 15, die);
            Arena arena = new Arena(DJ, Victoria, die);

            arena.Fight();
            Console.ReadKey();
            
        }


    }
}
