using System;

namespace DGD208_Spring2025_EmreFiliz
{
    public class Pet
    {
        public string Name { get; private set; }
        public PetType Type { get; private set; }

        public int Hunger { get; private set; } = 50;
        public int Sleep { get; private set; } = 50;
        public int Fun { get; private set; } = 50;

        public bool IsAlive { get; private set; } = true;

        public Pet(string name, PetType type)
        {
            Name = name;
            Type= type;
        }

        public void ShowStats()
        {
            Console.WriteLine($"\nPet: {Name} ({Type})");
            Console.WriteLine($"Hunger: {Hunger}");
            Console.WriteLine($"Sleep: {Sleep}");
            Console.WriteLine($"Fun: {Fun}");
        }

        public async Task StatDecreaseAsync()
        {
            while (IsAlive)
            {
                await Task.Delay(2000);

                Hunger = Math.Max(Hunger - 1, 0);
                Sleep = Math.Max(Sleep - 1, 0);
                Fun = Math.Max(Fun - 1, 0);

                if (Hunger == 0 || Sleep == 0 || Fun == 0)
                {
                    IsAlive = false;
                    Console.WriteLine($"\n{Name} the {Type}) is dead :(");
                }
            }
        }

        public static List<string> GetAvailablePets()
        {
            return Enum.GetNames(typeof(PetType)).ToList();
        }

    }
}
