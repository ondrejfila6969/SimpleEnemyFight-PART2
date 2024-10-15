using PRA___15._10._projekt.Properties.Classes;
using PRA___15._10._projekt.Properties.Enums;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace PRA___15._10._projekt
{
    internal class Program
    {

        static Player player = new Player("Player", 10, 100);
        static List<Room> rooms = new List<Room>();
        static Room currentRoom;

        static void Main(string[] args)
        {
            Console.WriteLine("Vítejte ve hře SimpleEnemyFight part 2 !!!!!!");

            // Vytvoření místností
            rooms.Add(new Room("Příroda (Lesík)"));
            rooms.Add(new Room("Jeskyně", Enemy.Factory.CreateOger()));
            rooms.Add(new Room("Ztracený důl", Enemy.Factory.CreateGoblin()));
            rooms.Add(new Room("Zapomenuté království", Enemy.Factory.CreateBoss()));

            while (true)
            {
                Console.WriteLine("Zadejte příkaz (m - move, a - attack, h - heal, s - strength, o - openChest): ");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "m":
                        Move();
                        break;
                    case "a":
                        if (currentRoom == null)
                        {
                            Console.WriteLine("Ještě není možné na nikoho útočit !!!");
                        } else
                        {
                            Attack();
                        }
                        break;
                    case "h":
                        player.Heal();
                        break;
                    case "s":
                        player.Strength();
                        break;
                    case "o":
                        OpenChest();
                        break;
                }
            }
            static void Move()
            {
                Console.WriteLine("Vyberte místnost (1, 2, 3, 4): ");
                int roomIndex = int.Parse(Console.ReadLine());

                if (roomIndex >= 0 && roomIndex < rooms.Count + 1)
                {
                    currentRoom = rooms[roomIndex - 1];
                    Console.WriteLine($"Pohybujete se do: {currentRoom.Name}");

                    if (currentRoom.Enemy != null)
                    {
                        Console.WriteLine($"Nepřítel v místnosti: {currentRoom.Enemy.Name}");
                    }
                    else
                    {
                        Console.WriteLine("V místnosti není nepřítel.");
                    }
                }
                else
                {
                    Console.WriteLine("Neplatná místnost !!!");
                }
            }

            static void Attack()
            {
                if (currentRoom.Enemy != null)
                {
                    player.Attack(currentRoom.Enemy);

                    if (currentRoom.Enemy.Hp <= 0)
                    {
                        if (currentRoom == rooms[3])
                        {
                            if (currentRoom.Enemy.Hp <= 0)
                            {
                                Console.WriteLine("Boss byl poražen !!!");
                                Console.WriteLine("KONEC HRY !!!!");
                                Environment.Exit(0);
                            }
                        }
                        Console.WriteLine($"Nepřítel {currentRoom.Enemy.Name} byl poražen!");
                        currentRoom.Enemy = null; // Odstranění nepřítele z místnosti
                    }
                    else
                    {
                        currentRoom.Enemy.Attack(player);

                        if (player.Hp <= 0)
                        {
                            Console.WriteLine("Hráč byl poražen. Konec hry.");
                            Environment.Exit(0);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("V této místnosti není nepřítel.");
                }
            }

            static void OpenChest()
            {
                Random rnd = new Random();
                if (rnd.Next(2) == 0)
                {
                    Random rndWeapon = new Random();
                    int randomWeapon = rndWeapon.Next(1, 5);
                    switch (randomWeapon)
                    {
                        case 1:
                            player.BaseDmg += (int)Weapons.TutanchamonDagger;
                            break;
                        case 2:
                            player.BaseDmg += (int)Weapons.RobinHoodBow;
                            break;
                        case 3:
                            player.BaseDmg += (int)Weapons.AchillesSpear;
                            break;
                        case 4:
                            player.BaseDmg += (int)Weapons.BillyTheKidPistol;
                            break;
                        case 5:
                            player.BaseDmg += (int)Weapons.ThorHammer;
                            break;

                    }
                    Console.WriteLine($"Našli jste zbraň! Zvyšujete si damage na {player.BaseDmg}");
                }
                else
                {
                    // :D
                    Console.WriteLine("Našli jste trolla v truhle !");
                    Enemy surpriseTroll = Enemy.Factory.CreateChestTroll();
                    player.Attack(surpriseTroll);
                    if (surpriseTroll.Hp <= 0)
                    {
                        Console.WriteLine("Troll byl poražen");
                    }
                }
            }
        }
    }
}