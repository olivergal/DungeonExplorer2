using System;

namespace DungeonExplorer
{
    public class Weapon : ICollectible
    {
        public string Name { get; }

        public Weapon(string name)
        {
            Name = name;
        }

        public void Use()
        {
            Console.WriteLine($"You equipped the {Name}. It will deal damage based on the weapon.");
        }

        public override string ToString() => Name;
    }
}
