using System;

namespace DungeonExplorer
{
    public class Potion : ICollectible
    {
        public int HealAmount { get; }

        public Potion(int healAmount)
        {
            HealAmount = healAmount;
        }

        public void Use()
        {
            Console.WriteLine($"You used a potion and healed for {HealAmount} health.");
        }

        public override string ToString() => "Potion";
    }
}
