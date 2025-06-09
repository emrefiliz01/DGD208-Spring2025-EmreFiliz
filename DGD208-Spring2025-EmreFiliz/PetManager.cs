using System;

namespace DGD208_Spring2025_EmreFiliz
{
    public class PetManager
    {
        public List<Pet> Pets { get; private set; } = new List<Pet>();
        public List<Item> Items { get; private set; } = new List<Item>();

        public PetManager()
        {
            Items.Add(new Item("Food", ItemType.Food, 10, 2));
            Items.Add(new Item("Toy", ItemType.Toy, 15, 3));
            Items.Add(new Item("Bed", ItemType.Bed, 20, 4));
        }

        public void AdoptPet(Pet pet)
        {
            Pets.Add(pet);
            Task.Run(() => pet.StatDecreaseAsync());
        }

        public async Task UseItemOnPetAsync(Pet pet, Item item)
        {
            if (!pet.IsAlive)
            {
                Console.WriteLine($"Cannot use {item.Name} on {pet.Name} because It's no longer alive.");
                Console.WriteLine("Press Enter to return to the Main Menu.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Using {item.Name} on {pet.Name}. Please wait {item.UseDurationSeconds} seconds.");
            await item.UseItemAsync(pet);
            Console.WriteLine($"{pet.Name}'s stats have been increased");
        }

    }
}
