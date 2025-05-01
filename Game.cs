using System.Collections.Generic;
using System;

namespace DungeonExplorer
{
    public class Game
    {
        private Player player;
        private Room currentRoom;
        private List<Room> rooms;

        public Game()
        {
            player = new Player("Hero", 100);
            rooms = new List<Room>
            {
                new Room("The Dark Dungeon", new Weapon("Sword"), new Enemy("Goblin", 30, 10)),
                new Room("The Unknown Caverns", new Potion(10), new Enemy("Zombie", 50, 15)),
                new Room("The Haunted Forest", new Weapon("Axe"), new Enemy("Dragon", 100, 20)) //3 seperate rooms
            };
            currentRoom = rooms[0]; //starting room
        }

        public static object Instance { get; internal set; }

        public void Start()
        {
            bool playing = true;

            while (playing)
            {
                Console.WriteLine(currentRoom.GetDescription());
                Console.WriteLine($"Player: {player.Name} | Health: {player.Health}");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Pick up item");
                Console.WriteLine("2. Fight enemy");                //menu options
                Console.WriteLine("3. Move to another room");
                Console.WriteLine("4. Quit game");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        currentRoom.PickUpItem(player);
                        break;

                    case "2":
                        if (currentRoom.Enemy != null)
                        {
                            player.Attack(currentRoom.Enemy);
                            if (currentRoom.Enemy.IsDead())
                                Console.WriteLine($"You defeated {currentRoom.Enemy.Name}!");
                            else
                                currentRoom.Enemy.Attack(player);
                        }
                        break;

                    case "3":
                        MoveToAnotherRoom();  //method for room navigation
                        break;

                    case "4":
                        playing = false;
                        Console.WriteLine("Game Over!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void MoveToAnotherRoom()
        {
            Console.WriteLine("Which room would you like to go to?");
            for (int i = 0; i < rooms.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {rooms[i].GetDescription()}");
            }

            string choice = Console.ReadLine();
            int roomChoice;
            if (int.TryParse(choice, out roomChoice) && roomChoice > 0 && roomChoice <= rooms.Count)
            {
                currentRoom = rooms[roomChoice - 1];
                Console.WriteLine($"You moved to {currentRoom.GetDescription()}");
            }
            else
            {
                Console.WriteLine("Invalid room choice.");
            }
        }
    }
}
