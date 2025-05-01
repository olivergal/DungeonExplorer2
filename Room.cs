
using System;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private ICollectible item;
        public Enemy Enemy { get; }

        public Room(string description, ICollectible item = null, Enemy enemy = null)
        {
            this.description = description;
            this.item = item;
            this.Enemy = enemy;
        }

        public string GetDescription() => description;

        public void PickUpItem(Player player)
        {
            if (item != null)
            {
                player.PickUpItem(item);
                Console.WriteLine($"You picked up: {item}");
                item = null; //remove item from room
            }
            else
            {
                Console.WriteLine("No item to pick up here.");
            }
        }
    }
}
