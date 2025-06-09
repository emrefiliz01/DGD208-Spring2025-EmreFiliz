using System;
using System.Threading.Tasks;

namespace DGD208_Spring2025_EmreFiliz
{
    public class MenuManager
    {
        public MenuManager()
        {

        }

        static Pet selectedPet = null;
        static PetManager petManager = new PetManager();

        public static async Task ShowMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("=== Main Menu ===");
                Console.WriteLine("1. Adopt A Pet");
                Console.WriteLine("2. Show Pet Stats");
                Console.WriteLine("3. Use Item");
                Console.WriteLine("4. Credits");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                string input = Console.ReadLine();
                
                switch (input)
                {
                    case "1":
                        AdoptPet();
                        break;
                    case "2":
                        await ShowStats();                    
                        break;
                    case "3":
                        await UseItem();
                        break;
                    case "4":
                        ShowCredits();
                        break;
                    case "5":
                        isRunning= false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void AdoptPet()
        {
            Console.Clear();
            List<string> petOptions = Pet.GetAvailablePets();

            Console.WriteLine("Choose a pet to adopt: ");
            for (int i = 0; i < petOptions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {petOptions[i]}");
            }

            Console.Write("Enter your choice: ");
            string choiceInput = Console.ReadLine();
            int choice;

            if (int.TryParse(choiceInput, out choice) && choice >= 1 && choice <= petOptions.Count)
            {
                string petTypeName = petOptions[choice - 1];

                if (Enum.TryParse<PetType>(petTypeName, out PetType petType))
                {
                    Console.Write("Give your pet a name: ");
                    string petName = Console.ReadLine();

                    Pet newPet = new Pet(petName, petType);
                    petManager.AdoptPet(newPet);

                    selectedPet= newPet;

                    Console.WriteLine($"You adopted a {petType} named {petName}");
                }
                else
                {
                    Console.WriteLine("Invalid pet type.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

            Console.WriteLine("Press Enter to return to the Main Menu");
            Console.ReadLine();
        }

        static async Task ShowStats()
        {
            if (petManager.Pets.Count == 0)
            {
                Console.WriteLine("You haven't adopted any pets yet.");
                Console.WriteLine("Press Enter to return to the Main Menu.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Select a pet to view stats:");
            for (int i = 0; i < petManager.Pets.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {petManager.Pets[i].Name} ({petManager.Pets[i].Type})");
            }

            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();
            int choice;

            if (!int.TryParse(input, out choice) || choice < 1 || choice > petManager.Pets.Count)
            {
                Console.WriteLine("Invalid selection.");
            }
            else
            {
                Pet selected = petManager.Pets[choice - 1];
                selectedPet = selected;
                selected.ShowStats();
            }

            Console.WriteLine("Press Enter to return to the Main Menu.");
            Console.ReadLine();
        }

        static async Task UseItem()
        {
            if (selectedPet == null)
            {
                Console.WriteLine("You haven't adopted a pet yet.");
                Console.WriteLine("Press Enter to return the Main Menu.");
                Console.ReadLine();
                return;

            }

            Console.WriteLine("Select a pet to use an item on:");
            for (int i = 0; i < petManager.Pets.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {petManager.Pets[i].Name} ({petManager.Pets[i].Type})");
            }

            Console.Write("Enter your choice: ");
            string petInput = Console.ReadLine();
            int petChoice;

            if (!int.TryParse(petInput, out petChoice) || petChoice < 1 || petChoice > petManager.Pets.Count)
            {
                Console.WriteLine("Invalid pet selection.");
                Console.WriteLine("Press Enter to return to the Main Menu.");
                Console.ReadLine();
                return;
            }

            Pet selected = petManager.Pets[petChoice - 1];
            selectedPet = selected;

            if (!selected.IsAlive)
            {
                Console.WriteLine($"{selected.Name} is no longer alive :( ");
                Console.WriteLine("Press Enter to return to the Main Menu.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Select an item to use on {selected.Name}:");
            for (int i = 0; i < petManager.Items.Count; i++)
            {
                var item = petManager.Items[i];
                Console.WriteLine($"{i + 1}. {item.Name} (+{item.StatIncreaseAmount})");
            }

            Console.Write("Enter your choice: ");
            string itemInput = Console.ReadLine();
            int itemChoice;

            if (!int.TryParse(itemInput, out itemChoice) || itemChoice < 1 || itemChoice > petManager.Items.Count)
            {
                Console.WriteLine("Invalid item selection.");
                Console.WriteLine("Press Enter to return to the Main Menu.");
                Console.ReadLine();
                return;
            }

            Item selectedItem = petManager.Items[itemChoice - 1];

            await petManager.UseItemOnPetAsync(selected, selectedItem);

            Console.WriteLine("Press Enter to return to the Main Menu.");
            Console.ReadLine();
        }

        static void ShowCredits()
        {
            Console.WriteLine("Written by Emre Filiz - 205040094");
            Console.WriteLine("Press Enter to return to the Main Menu");
            Console.ReadLine();
        }
    }
}
