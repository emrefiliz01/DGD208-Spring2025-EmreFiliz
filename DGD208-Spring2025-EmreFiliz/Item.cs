using System;

namespace DGD208_Spring2025_EmreFiliz
{
    public class Item
    {
        public string Name { get; private set; }
        public ItemType Type { get; private set;}
        public int StatIncreaseAmount { get; private set; }
        public int UseDurationSeconds { get; private set; }

        public Item(string name, ItemType type, int statIncreaseAmount, int useDurationSeconds)
        {
            Name = name;
            Type = type;
            StatIncreaseAmount = statIncreaseAmount;
            UseDurationSeconds = useDurationSeconds;
        }

        public async Task UseItemAsync(Pet pet)
        {
            Console.WriteLine($"Using {Name} on {pet.Name}");
            await Task.Delay(UseDurationSeconds * 1000);

            switch (Type)
            {
                case ItemType.Food:
                    pet.IncreaseHunger(StatIncreaseAmount);
                    break;

                case ItemType.Toy:
                    pet.IncreaseFun(StatIncreaseAmount);
                    break;

                case ItemType.Bed:
                    pet.IncreaseSleep(StatIncreaseAmount);
                    break;
            }

            Console.WriteLine($"{Name} used on {pet.Name}");
        }
    }
}
