using System;
using StateDesignPattern.Core;
using StateDesignPattern.UI.BankingOptions;

namespace StateDesignPattern.UI {
    public class Application {
        public void Run() {
            var startingBalance = GetStartingBalance();
            var account = Account.Create(startingBalance, OnUnfreeze);
            var options = BankOptionRules.Create(account);
            DisplayOptions(options);
        }

        private static void DisplayOptions(BankOptions options) {
            IBankOption selectedOption = new UnknownOption();
            do {
                Console.WriteLine("Which option:  ");
                Console.WriteLine(options.Display());
                selectedOption = options.Find(Console.ReadLine());
                selectedOption.Execute();
            } while (!(selectedOption is ExitOption));
        }

        private static decimal GetStartingBalance() {
            decimal startingBalance;
            Console.Write("What is your starting balance: ");
            if (decimal.TryParse(Console.ReadLine(), out startingBalance))
                return startingBalance;
            return 0;
        }

        private void OnUnfreeze() {
            Console.WriteLine("Account is unfrozen.");
        }
    }
}