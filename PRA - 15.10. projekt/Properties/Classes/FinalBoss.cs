namespace PRA___15._10._projekt.Properties.Classes
{
    public partial class Enemy
    {

        public static partial class Factory
        {
            private class FinalBoss : Enemy
            {
                private int phase = 1;

                public FinalBoss(string name, double baseDmg, double hp) : base(name, baseDmg, hp) { }

                public void Attack(Player player)
                {
                    if (phase == 1)
                    {
                        AttackPhaseOne(player);
                    }
                    else
                    {
                        AttackPhaseTwo(player);
                    }
                }

                private void AttackPhaseOne(Player player)
                {
                    Console.WriteLine($"{Name} útočí na hráče s útokem fáze 1 a dává {BaseDmg} poškození.");
                    player.TakeDamage(BaseDmg);

                    if (Hp < 100) // Pokud HP bosse budou menší než 100, jeho damage bude ve fázi 2
                    {
                        TransitionToPhaseTwo();
                    }
                }

                private void AttackPhaseTwo(Player player)
                {
                    double phaseTwoDamage = BaseDmg * 1.5; //  Dmg ve fázi 2 se vynásobí číslem 1,5
                    Console.WriteLine($"{Name} útočí na hráče s útokem fáze 2 a dává {phaseTwoDamage} poškození.");
                    player.TakeDamage(phaseTwoDamage);
                }

                private void TransitionToPhaseTwo()
                {
                    phase = 2;
                    Console.WriteLine($"{Name} přechází do fáze útoku č.2!!!");
                }
            }
        }
    }
}
