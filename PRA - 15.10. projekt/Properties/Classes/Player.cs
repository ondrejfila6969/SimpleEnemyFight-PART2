using PRA___15._10._projekt.Properties.Classes;
using PRA___15._10._projekt.Properties.Enums;
using System.Numerics;

namespace PRA___15._10._projekt
{
    public class Player
    {
        public string Name { get; }
        public double BaseDmg { get; set; }
        public double Hp { get; private set; }

        public Player(string name, double baseDmg, double hp)
        {
            Name = name;
            BaseDmg = baseDmg;
            Hp = hp;
        }

        public void Attack(Enemy enemy)
        {
            Console.WriteLine($"{Name} útočí na {enemy.Name} s dmg {BaseDmg}.");
            enemy.TakeDamage(BaseDmg);
        }

        public void Heal()
        {
            Console.WriteLine("Zadejte potion pro heal: (1 - MagicWater, 2 - DiamondElixir, 3 - Reborner, 4 - GhastTears, 5 - PhoenixForce) ");
            int heal = Convert.ToInt32(Console.ReadLine());
            switch(heal)
            {
                case 1:
                    Hp += (int)HealingPotions.MagicWater;
                    break;
                case 2:
                    Hp += (int)HealingPotions.DiamondElixir;
                    break;
                case 3:
                    Hp += (int)HealingPotions.Reborner;
                    break;
                case 4:
                    Hp += (int)HealingPotions.GhastTears;
                    break;
                case 5:
                    Hp += (int)HealingPotions.PhoenixForce;
                    break;
                default:
                    Console.WriteLine("Zadal jste špatné číslo !!!");
                    break;
            }
            Console.WriteLine($"{Name} se vyléčil, aktuální HP: {Hp}");
        }
        public void Strength()
        {
            Console.WriteLine("Zadejte potion pro vyšší damage: 1 - SmurfEssence, 2 - VikingBlood, 3 - WarriorFury, 4 - ThunderSerum, 5 - StormCallerPower: ");
            int strength = Convert.ToInt32(Console.ReadLine());
            switch(strength)
            {
                case 1:
                    BaseDmg += (int)StrengthPotions.SmurfEssence;
                    break;
                case 2:
                    BaseDmg += (int)StrengthPotions.VikingBlood;
                    break;
                case 3:
                    BaseDmg += (int)StrengthPotions.WarriorFury;
                    break;
                case 4:
                    BaseDmg += (int)StrengthPotions.ThunderSerum;
                    break;
                case 5:
                    BaseDmg += (int)StrengthPotions.StormCallerPower;
                    break;
                default:
                    Console.WriteLine("Zadal jste špatné číslo !!!");
                    break;
            }
            if(strength >= 1 && strength <= 5)
            {
                Console.WriteLine($"{Name} použil strength potion a navyšuje si damage na {BaseDmg} !!!");
            }
        }

        // Metoda pro snížení HP
        public void TakeDamage(double damage)
        {
            Hp -= damage;
            if (Hp < 0) Hp = 0; // Zajišťuje, že HP nebude pod nulou
            Console.WriteLine($"{Name} má nyní {Hp} HP.");
        }
    }
}
