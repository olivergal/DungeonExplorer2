
using System;

namespace DungeonExplorer
{
    public class Enemy : Creature
    {
        public Enemy(string name, int health, int damage) : base(name, health, damage) { }

        public override void Attack(Creature target)
        {
            Console.WriteLine($"{Name} attacks you for {Damage} damage!");
            target.TakeDamage(Damage);
        }
    }
}
