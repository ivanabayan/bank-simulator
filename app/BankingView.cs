namespace ATMApp.View
{
    using ATMApp.Services;
    
    public static class BankingView
    {
        public static void Run()
        {
            double balance = 1000.00;
            bool isRunning = true;

            Console.WriteLine("Ivan Abayan");
            Console.WriteLine("=== Simple ATM System ===");
            Console.WriteLine("Initial Balance: ₱1000.00");

            while (isRunning)
            {
                Console.WriteLine("\nATM Menu");
                Console.WriteLine("1: Check Balance");
                Console.WriteLine("2: Deposit Money");
                Console.WriteLine("3: Withdraw Money");
                Console.WriteLine("4: Print Mini Statement");
                Console.WriteLine("5: Exit");
                Console.Write("Select an option: ");

                int.TryParse(Console.ReadLine(), out int choice);

                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Current Balance: ₱{BankingServices.GetBalance(balance):F2}");
                        break;

                    case 2:
                        Console.Write("Enter amount to deposit: ");
                        double.TryParse(Console.ReadLine(), out double depositAmount);

                        if (!BankingServices.Deposit(ref balance, depositAmount))
                        {
                            Console.WriteLine("Invalid deposit amount.");
                            break;
                        }

                        Console.WriteLine("Deposit successful.");
                        Console.WriteLine($"Updated Balance: ₱{balance:F2}");
                        break;

                    case 3:
                        Console.Write("Enter amount to withdraw: ");
                        double.TryParse(Console.ReadLine(), out double withdrawAmount);

                        BankingServices.Withdraw(ref balance, withdrawAmount, out bool success);

                        if (!success)
                        {
                            Console.WriteLine("Withdrawal failed. Check amount or balance.");
                        }
                        else
                        {
                            Console.WriteLine("Withdrawal successful.");
                            Console.WriteLine($"Updated Balance: ₱{balance:F2}");
                        }
                        break;

                    case 4:
                        Console.WriteLine("\n--- Mini Statement ---");
                        Console.WriteLine($"Current Balance: ₱{balance:F2}");
                        Console.WriteLine($"Last Transaction Amount: ₱{BankingServices.GetLastTransaction():F2}");
                        break;

                    case 5:
                        Console.WriteLine("Thank you for using the ATM. Goodbye!");
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
