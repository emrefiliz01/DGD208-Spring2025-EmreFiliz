using System;

namespace DGD208_Spring2025_EmreFiliz
{
    public class MenuManager
    {
        public MenuManager()
        {

        }

        static Pet selectedPet = null;

        static void Main(string[] args)
        {
            ShowMenu();
        }

        static void ShowMenu()
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
                        ShowStats();
                        break;
                    case "3":
                        UseItem();
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

            Console.WriteLine("Enter your choice: ");
            string choiceInput = Console.ReadLine();
            int choice;

            if (int.TryParse(choiceInput, out choice) && choice >= 1 && choice <= petOptions.Count)
            {
                selectedPet = new Pet(petOptions[choice - 1]);
                Console.WriteLine($"You adopted a {selectedPet.Name}");
            }
            else
            {
                Console.WriteLine("Invalid Choice");
            }

            Console.WriteLine("Press Enter to return to the Main Menu");
            Console.ReadLine();
        }

        static void ShowStats()
        {
            if (selectedPet == null)
            {
                Console.WriteLine("You haven't adopted a pet yet");
            }
            else
            {
                selectedPet.ShowStats();
            }

            Console.WriteLine("Press Enter to return to the Main Menu");
            Console.ReadLine();
        }

        static void UseItem()
        {
            Console.WriteLine("Don't have Items yet");
            Console.WriteLine("Press Enter to return to the Main Menu");
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
