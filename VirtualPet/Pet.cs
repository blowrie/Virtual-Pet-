using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet
{
    class Pet
    {
        static Random generator = new Random();
        int decrease = generator.Next(15, 30);
        int tickMayhem = generator.Next(60, 85);

        //fields(min 3)
        private int hungerLevel;
        private int thirstLevel;
        private int happiness;
        private int energy;
        private bool goPotty;

        //properties(min 3)
        public int HungerLevel
        {
            get { return this.hungerLevel; }
            set { this.hungerLevel = value; }
        }

        public int ThirstLevel
        {
            get { return this.thirstLevel; }
            set { this.thirstLevel = value; }
        }

        public int Energy
        {
            get { return this.energy; }
            set { this.energy = value; }
        }

        public int Happiness
        {
            get { return this.happiness; }
            set { this.happiness = value; }
        }

        public bool GoPotty
        {
            get { return this.goPotty; }
            set { this.goPotty = value; }
        }

        //Constructors(min 1)
        public Pet(int hungerLevel, int thirstLevel, int happiness, int energy, bool goPotty)
        {
            this.hungerLevel = hungerLevel;
            this.thirstLevel = thirstLevel;
            this.happiness = happiness;
            this.energy = energy;
            this.goPotty = goPotty;

        }

        //methods (min 3)

        /* Method to feed the pet, feeding the pet causes energy to decrease and
         thirst to decrease, Also makes the pet have to go to the bathroom */

        public void CheckPetStatus()
        {
            Console.WriteLine("\nHunger: " + hungerLevel);
            Console.WriteLine("Thirsty: " + thirstLevel);
            Console.WriteLine("Happiness: " + happiness);
            Console.WriteLine("Energy: " + energy);
        }


        public void Feed(int foodAmount)
        {
            hungerLevel += foodAmount;
            if (hungerLevel >= 100)
            {
                hungerLevel = 100;
                Console.WriteLine("MAX hunger ");
            }
            thirstLevel -= decrease;
            if (thirstLevel < 0)
            {
                thirstLevel = 0;
            }

            energy -= (decrease / 2);
            if (energy < 0)
            {
                energy = 0;
            }

            goPotty = true;

        }
        /*Method to give the pet water.Drinking the water casues the pet to immediately have
         * to go to the bathroom taking them for a walk */
        public void giveWater(int waterAmount)
        {
            thirstLevel += waterAmount;

            if (thirstLevel >= 100)
            {
                thirstLevel = 100;
                Console.WriteLine("thirst is MAX ");
            }
            if (thirstLevel > 80)
            {
                Console.WriteLine("Lebron needs to go to the Bathroom, Take him for a walk immediately.");
            }
            goPotty = true;
        }

        /*Play method casues the pets happiness to rise causing its happiness to rise
         * playing causes energy to decrease and also makes it hungry */
        public void Play()
        {

            happiness += happiness;

            if (happiness >= 100)
            {
                happiness = 100;
                Console.WriteLine("MAX Happiness ");
            }
            hungerLevel -= decrease;
            energy -= (decrease / 2);

            if (hungerLevel < 0)
            {
                hungerLevel = 0;
            }

            if (energy < 0)
            {
                energy = 0;
            }

        }
        /* play method controls the energy field and it recahes max when the dogs sleeps
         * Sleeping does not change anything for the pet so that you can beat the game */

        public string Yawn()
        {
            if (energy < 0)
            {
                energy = 0;
                return "Wow! Lebron is really tired. He needs to get his rest";
            }
            else if (energy > 0 && energy < 100)
            {
                energy = 100;
                return "Lebron is tired he needs to get some sleep to recharge his energy";
            }
            else if (energy >= 100)
            {
                energy = 100;
                return "MAX Energy";
            }
            else
            {
                return "You broke the program, Your pet is dead.";
            }
        }

        public string Walk()
        {
            if (goPotty == true)
            {
                goPotty = false;
                return "Your pet went to the bathroom";
            }
            else
            {
                return "Your pet didnt need to go to the bathroom, but the walk made them sleepy!";
            }





        }

        //Tick method
        public bool Tick(bool sick)
        {
            if (sick == true)
            {
                hungerLevel -= tickMayhem;
                thirstLevel -= (tickMayhem / 2);
                happiness -= (tickMayhem / 3);
                energy -= (tickMayhem / 4);

                if (hungerLevel < 0)
                {
                    hungerLevel = 0;
                }
                if (thirstLevel < 0)
                {
                    thirstLevel = 0;
                }
                if (happiness < 0)
                {
                    happiness = 0;
                }
                if (energy < 0)
                {
                    energy = 0;
                }

                Console.WriteLine("Uh oh, your pet got a tick!! Its levels have dramatically been skewed");
                return sick = false;

            }
            else
            {
                Console.WriteLine("False Alarm! No ticks but a great walk.");
                return sick = false;

            }
        }
    }
}
