using PRA___15._10._projekt.Properties.Enums;
using System.Numerics;

namespace PRA___15._10._projekt.Properties.Classes
{
    public partial class Enemy
    {
        public string Name { get; }
        public double BaseDmg { get; }
        public double Hp { get; private set; }

        public Enemy(string name, double baseDmg, double hp)
        {
            Name = name;
            BaseDmg = baseDmg;
            Hp = hp;
        }

        public void Attack(Player player)
        {
            Console.WriteLine($"{Name} útočí na hráče s dmg {BaseDmg}.");
            player.TakeDamage(BaseDmg); 
        }

        public void TakeDamage(double damage)
        {
            Hp -= damage;
            if (Hp < 0) Hp = 0; // Zajišťuje, že HP nebude pod nulou
            Console.WriteLine($"{Name} má nyní {Hp} HP.");
        }

        public static partial class Factory
        {
            public static Enemy CreateOger()
            {
                return new Enemy("Oger", 5, 50);
            }

            public static Enemy CreateGoblin()
            {
                return new Enemy("Goblin", 7, 20);
            }

            public static Enemy CreateChestTroll()
            {
                return new Enemy("Troll", 10, 10);
            }
            public static Enemy CreateBoss()
            {
                return new FinalBoss("Boss", 24, 100);
            }
        }
    }
}
