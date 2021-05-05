using System;
using System.Collections.Generic;
using System.Text;

namespace Arena
{
    class RollingDie
    {
        private Random random; //creating private variables so they cant be accessed outside

        private int sidesCount;

        public RollingDie(int sidesCount)
        {
            this.sidesCount = sidesCount; // left variable belings to this instance and the right is treated as a parameter.
            random = new Random();
        }
        public RollingDie() //default/ overloaded method if rollingdie int is not given
        {
            sidesCount = 6;
            random = new Random();
        }

        public int GetSidesCount()
        {
            return sidesCount;
        }

        public int Roll()
        {
            return random.Next(1, sidesCount + 1);
        }

        public override string ToString()
        {
            return String.Format("Rolling a die with {0} sides", sidesCount);
        }
    }
}
