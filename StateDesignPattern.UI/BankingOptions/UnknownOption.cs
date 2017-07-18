using System;

namespace StateDesignPattern.UI.BankingOptions {
    public class UnknownOption : BankOptionInvokeTemplate {
        public override string Display => "";
        public override string Key => "";
        protected override void Invoke() { }
        protected override void Response() => Console.WriteLine("Unknown option");
    }
}