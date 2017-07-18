using System;
using StateDesignPattern.Core;

namespace StateDesignPattern.UI.BankingOptions {
    public class DepositOption : BankOptionWithQuestionTemplate {
        private readonly Account _account;

        public DepositOption(Account account) {
            _account = account;
        }

        public override string Display => "(D)eposit";
        public override string Key => "D";

        protected override decimal Question()
        {
            Console.WriteLine("How much do you want to deposit?  ");
            decimal deposit;
            decimal.TryParse(Console.ReadLine(), out deposit);
            return deposit;
        }

        protected override void Response() => Console.WriteLine(_account);        
        protected override void Invoke(decimal deposit) => _account.Deposit(deposit);
    }
}