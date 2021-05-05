using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Arena
{
    class Arena
    {
        private Warrior warrior1;
        private Warrior warrior2;
        private RollingDie die;

        public Arena(Warrior warrior1, Warrior warrior2, RollingDie die)
        {
            this.warrior1 = warrior1;
            this.warrior2 = warrior2;
            this.die = die;
        }

        private void Render()
        {
            Console.Clear();
            Console.WriteLine("-------------------Arena--------------------- \n");
            Console.WriteLine("Warriors health: \n");
            Console.WriteLine("{0} {1}", warrior1, warrior1.HealthBar());
            Console.WriteLine("{0} {1}", warrior2, warrior2.HealthBar());
        }

        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(500);
        }

        public void Fight()
        {
            Console.WriteLine("Welcome to the Arena!");
            Console.WriteLine("Today {0} will battle against {1}! \n", warrior1, warrior2);
            Console.WriteLine("Let the battle begin...");
            //fight loop
            while (warrior1.Alive() && warrior2.Alive())
            {
                warrior1.Attack(warrior2);
                Render();
                PrintMessage(warrior1.GetLastMessage()); //attack message
                PrintMessage(warrior2.GetLastMessage()); //defense message
                warrior2.Attack(warrior1);
                Render();
                PrintMessage(warrior2.GetLastMessage()); //attack 
                PrintMessage(warrior1.GetLastMessage()); //defense
                Console.WriteLine();
            }
        }


    }
}
