using System;
using StateDesignPattern.Core;
using StateDesignPattern.UI.BankingOptions;

namespace StateDesignPattern.UI {
    internal class Program {
        private static void Main(string[] args)
        {
            new Application().Run();
            Console.ReadKey();
        }        
    }
}