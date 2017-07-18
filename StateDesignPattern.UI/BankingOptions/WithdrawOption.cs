using System;
using StateDesignPattern.Core;

namespace StateDesignPattern.UI.BankingOptions {
    public class WithdrawOption : BankOptionWithQuestionTemplate {
        private readonly Account _account;

        public WithdrawOption(Account account) {
            _account = account;
        }

        public override string Display => "(W)ithdraw";
        public override string Key => "W";
        protected override decimal Question()
        {
            Console.WriteLine("How much do you want to withdraw?  ");
            decimal withdraw;
            decimal.TryParse(Console.ReadLine(), out withdraw);
            return withdraw;
        }
            
        protected override void Response() => Console.WriteLine(_account);

        protected override void Invoke(decimal withdraw) => _account.Withdraw(withdraw);
    }
}