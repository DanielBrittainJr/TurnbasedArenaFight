using System;
using System.Collections.Generic;
using System.Text;

namespace Arena
{
    class Warrior
    {
        private string name;

        private int health;

        private int maxHealth;

        private int damage;

        private int defense;

        private RollingDie die;

        private string message;

        public Warrior(string name, int health, int damage, int defense, RollingDie die)
        {
            this.name = name;
            this.health = health;
            this.maxHealth = health;
            this.damage = damage;
            this.defense = defense;
            this.die = die;
        }

        public override string ToString() //return warrior name for each action
        {
            return name;
        }

        public bool Alive() //using bool value to tell whether warrior is alive or not
        {
            return (health > 0);
        }

        public string HealthBar()
        {
            string s = "[";
            int total = 20; //max 20
            double count = Math.Round(((double)health / maxHealth) * total); //since we use double, if the character has less than one visible health but greater than zero, it rounds to one
            if ((count == 0) && (Alive())) //if count is 0 and alive is true count is 1
                count = 1;
            for (int i = 0; i < count; i++) //this creates the visual pound representation
                s += "#";
            s = s.PadRight(total + 1); //padright used to add spaces in place of empty pound sign
            s += "]";
            return s;
        }
        
        public void Defend(int hit)
            {
                int injury = hit - (defense + die.Roll()); //hit - defense + die roll = damage amount
            if (injury > 0) //if injury is more than 0  health with subtract by injury amount
            {
                health -= injury;
                message = String.Format("{0} defended against the attack but still lost {1} hp", name, injury);
                if (health <= 0) //cleaning up for negative health to == zero
                {
                    health = 0;
                    message += " and died;";
                    }
            } else
                message = String.Format("{0} blocked the hit", name);
            SetMessage(message);
            }

        public void Attack(Warrior enemy)
        {
            int hit = damage + die.Roll();
            SetMessage(String.Format("{0} attacks with a hit worth {1} hp", name, hit));
            enemy.Defend(hit); //calculate hit against enemies defence
        }
        
        private void SetMessage(string message)
        {
            this.message = message;
        }

        public string GetLastMessage()
        {
            return message;
        }
        
        }

    }

