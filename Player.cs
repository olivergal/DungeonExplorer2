using System.Collections.Generic;
using System;
using System.Linq;

namespace DungeonExplorer
{
    public class Player : Creature
    {
        private List<ICollectible> inventory = new List<ICollectible>();

        public Player(string name, int health) : base(name, health, 5) //no weapon damage is 5
        {
        }

        public void PickUpItem(ICollectible item)
        {
            inventory.Add(item);

            //if picked item update damage
            if (item is Weapon weapon)
            {
                SetWeaponDamage(weapon); 
            }
        }

        public void UseItem(string itemName)
        {
            var item = inventory.FirstOrDefault(i => i.ToString() == itemName);
            if (item != null)
            {
                item.Use();
                inventory.Remove(item);
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }

        public override void Attack(Creature target)
        {
            Console.WriteLine($"You attack {target.Name} for {Damage} damage!");
            target.TakeDamage(Damage);

            //defensive design
            if (Health <= 0)
            {
                Console.WriteLine("You have been defeated! Game Over.");
                Environment.Exit(0);  //end game health is <= 0
            }
        }

        public void SetWeaponDamage(Weapon weapon)
        {
            
            if (weapon.Name == "Sword")
            {
                Damage = 20; //sword deals 20 damage
            }
            else if (weapon.Name == "Axe")
            {
                Damage = 10; //axe deals 10 damage
            }
            else
            {
                Damage = 5; //default damage
            }
        }
    }
}
