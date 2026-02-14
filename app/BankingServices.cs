using System;

namespace ATMApp.Services
{
    public static class BankingServices
    {
        private static double lastTransactionAmount = 0.0;

        // Option 1: Pass-by-value
        public static double GetBalance(double balance)
        {
            return balance;
        }

        // Option 2: ref (Deposit)
        public static bool Deposit(ref double balance, double amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            balance += amount;
            lastTransactionAmount = amount;
            return true;
        }

        // Option 3: ref + out (Withdraw)
        public static void Withdraw(
            ref double balance,
            double amount,
            out bool isSuccessful)
        {
            if (amount <= 0 || amount > balance)
            {
                isSuccessful = false;
                return;
            }

            balance -= amount;
            lastTransactionAmount = amount;
            isSuccessful = true;
        }

        // Mini Statement
        public static double GetLastTransaction()
        {
            return lastTransactionAmount;
        }
    }
}
