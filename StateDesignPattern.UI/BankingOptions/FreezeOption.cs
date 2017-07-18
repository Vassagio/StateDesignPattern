using System;
using StateDesignPattern.Core;

namespace StateDesignPattern.UI.BankingOptions {
    public class FreezeOption : BankOptionInvokeTemplate {
        private readonly Account _account;

        public FreezeOption(Account account)
        {
            _account = account;
        }

        public override string Display => "(F)reeze";
        public override string Key => "F";

        protected override void Response() => Console.WriteLine("The account is frozen.");

        protected override void Invoke() => _account.Freeze();
    }
}