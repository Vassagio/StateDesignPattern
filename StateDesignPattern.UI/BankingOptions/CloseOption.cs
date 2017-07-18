using System;
using StateDesignPattern.Core;

namespace StateDesignPattern.UI.BankingOptions {
    public class CloseOption : BankOptionInvokeTemplate {
        private readonly Account _account;

        public CloseOption(Account account)
        {
            _account = account;
        }

        public override string Display => "(C)lose";
        public override string Key => "C";
        protected override void Invoke() =>_account.Close();        

        protected override void Response() => Console.WriteLine("The account is closed.");        
    }
}