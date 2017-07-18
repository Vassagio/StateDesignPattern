using System;
using StateDesignPattern.Core;

namespace StateDesignPattern.UI.BankingOptions {
    public class VerifiedOption : BankOptionInvokeTemplate {
        private readonly Account _account;

        public VerifiedOption(Account account)
        {
            _account = account;
        }

        public override string Display => "(V)erified";
        public override string Key => "V";
        protected override void Response() => Console.WriteLine("Account has been verified.");

        protected override void Invoke() => _account.HolderVerified();
    }
}