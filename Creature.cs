
using System;

namespace DungeonExplorer
{
    public abstract class Creature : IDamageable
    {
        public string Name { get; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }

        public Creature(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public bool IsDead() => Health <= 0;

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public virtual void Attack(Creature target)
        {
            //default attack logic (can be overridden)
        }
    }
}
