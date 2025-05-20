using System;

namespace DGD208_Spring2025_EmreFiliz
{
    public class Pet
    {
        public string Name { get; private set; }

        public Pet(string name)
        {
            Name = name;
        }

        public void ShowStats()
        {
            Console.WriteLine("Don't have stats right now.");
        }

        public static List<string> GetAvailablePets()
        {
            return new List<string> { "Cat", "Dog", "Bird", "Turtle" };
        }
    }
}
