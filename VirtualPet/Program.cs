using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet
{
    class Program
    {
        static void Main(string[] args)
        {

            int optionInput;
            int units;

            Pet Lebron = new Pet(50, 50, 50, 50, false);
            Console.WriteLine("Welcome to virtual pet, your goal is to keep the pet alive\nGet each level to 100 and you beat the game");
            Console.WriteLine("Press Enter to continue: ");
            Console.ReadLine();
            Console.WriteLine("Meet your new pet:  Lebron the goat");

            do
            {
                Lebron.CheckPetStatus();
                Console.WriteLine("\nWhat would you like to do?");

                Console.WriteLine("Enter 1 to Feed Lebron");
                Console.WriteLine("Enter 2 to Give Lebron Water");
                Console.WriteLine("Enter 3 to Play Lebron 1 on 1 airbud style");
                Console.WriteLine("Enter 4 to Walk Lebron (watch out for ticks)");
                Console.WriteLine("Enter 5 to Make Lebron go to sleep");
                Console.WriteLine("Enter 6 to exit\n");

                optionInput = int.Parse(Console.ReadLine());
                Console.WriteLine("");

                switch (optionInput)
                {
                    case 1:
                        Console.WriteLine("How many units of food do you want to feed Lebron? ");
                        units = int.Parse(Console.ReadLine());
                        Lebron.Feed(units);
                        break;

                    case 2:
                        Console.WriteLine("How many units of water do you want to give Lebron?");
                        units = int.Parse(Console.ReadLine());
                        Lebron.giveWater(units);
                        break;

                    case 3:
                        Lebron.Play();
                        break;

                    case 4:
                        Console.WriteLine(Lebron.Walk());
                        bool isTick = true;
                        isTick = Chance(isTick);
                        Lebron.Tick(isTick);

                        break;

                    case 5:
                        Console.WriteLine(Lebron.Yawn());
                        break;

                    case 6:

                        break;

                }

                if (Lebron.HungerLevel == 100 && Lebron.ThirstLevel == 100 && Lebron.Happiness == 100 && Lebron.Energy == 100)
                {
                    Lebron.CheckPetStatus();
                    Console.WriteLine("\nCongratulations you beat the game!!! Lebron the GOAT is \nready to face the warriors now!\n");
                    break;
                }

            } while (optionInput != 6);

            
        }

        static bool Chance(bool test)
        {
            Random chance = new Random();       //Method to randomize true and false for tick method in class. 
            int sick = chance.Next(0, 10);

            if (sick < 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}