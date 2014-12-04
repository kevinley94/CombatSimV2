using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatSimv2
{
    class Program
    {
        static void Main(string[] args)
        {
            game game = new game();
            game.PlayGame();
        }
    }
    public class enemy
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _hp;
        public int Hp
        {
            get { return _hp; }
            set { _hp = value; }
        }
        private bool _isAlive;
        public bool IsAlive
        {
            get { return this.Hp > 0; }
        }

        public enemy(string enemyName, int enemyHealth)
        {
            this.Name = enemyName;
            this.Hp = enemyHealth;
        }

        public void DoAttack(player player)
        {
            Random rng = new Random();
            int hitchance = rng.Next(0, 11);
            int damage;
            Console.WriteLine("\nThe Dragon Attacks!");
            if (hitchance <= 3)
            {
                Console.Write("\nHIT\n");
                damage = rng.Next(25, 31);
                player.Hp = player.Hp - damage;
                Console.WriteLine("The Dragon did  " + damage + " points of damage");

            }
            else
            {
                Console.WriteLine("\nMISS\n");
                Console.WriteLine("The Dragon missed");
            }

        }
    }
    public class player
    {
        private int _hp;
        public int Hp
        {
            get { return _hp; }
            set { _hp = value; }
        }
        private bool _isAlive;
        public bool IsAlive
        {
            get { return this.Hp > 0; }
        }
        public player(int playerHealth)
        {
            this.Hp = playerHealth;
        }
        public enum AttackType
        
        {
            Sword = 2,
            Magic,
            Heal
        }
        private AttackType _attack;
        public AttackType Attack
        {
            get { return _attack; }
            set { _attack = value; }
        }
        private AttackType ChooseAttack()
        {
            Console.WriteLine("What do you choose?\n1.Sword\n2.Magic\n3.Heal");
            int reply = int.Parse(Console.ReadLine());
            return (AttackType)reply;
        }
        public void DoAttack(enemy enemy)
        { 
            Random rng = new Random();
            List<string> Outcomes = new List<string> { "You swing your sword furiously!", "You spin graciously to begin your attack", "You charge at the enemy" };
            int damage;
            int hitchance;
            switch (ChooseAttack())
            {
                case AttackType.Sword:
                  hitchance = rng.Next(0, 11);

                if (hitchance <= 7)
                {Console.WriteLine(Outcomes[rng.Next(0, 2)].ToString());
                    Console.Write("\nHIT\n");
                    damage = rng.Next(20, 35);
                   
                    enemy.Hp = enemy.Hp - damage;
                    
                    Console.WriteLine("You did " + damage + " points of damage to the dragon");

                }
                else
                {
                    Console.WriteLine("\nMISS\n");
                    Console.WriteLine("You did 0 points of damage to the dragon");
                }
                break;
                case AttackType.Magic:
                    Console.WriteLine("\nYou Throw a fireball..");
                Console.WriteLine("\nHIT\n");
                damage = rng.Next(10, 16);
                enemy.Hp = enemy.Hp - damage;
                Console.WriteLine("You did " + damage + " points of damage to the dragon");
                break;
                case AttackType.Heal:
                    Console.WriteLine("\nYou heal yourself.\n");
                if (Hp <= 80)
                {
                    damage = rng.Next(10, 21);
                    Hp = Hp + damage;
                    Console.WriteLine("You healed " + damage + " points of damage.");
                }
                else { Console.WriteLine("You have enough health. Be a man."); }
                break;

            }

        }
        
        
    }
    public class game
    {
        public player player { get; set; }
        public enemy enemy { get; set; }
        public game()
        {
            this.player = new player(100);
            this.enemy = new enemy("The Dragon", 200);
        }

        public void DisplayCombatInfo()
        {
            Console.WriteLine("Your HP: {0}\nEnemy HP: {1}", player.Hp, enemy.Hp);
        }
        public void PlayGame()
        {
            while (this.player.IsAlive && this.enemy.IsAlive)
            {
                DisplayCombatInfo();
                
                this.player.DoAttack(this.enemy);
                this.enemy.DoAttack(this.player);
                Console.WriteLine("\nPress any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }
            if (this.player.IsAlive) { Console.WriteLine("You win!"); }
            else { Console.WriteLine("You lose"); }
        }
    }
}
