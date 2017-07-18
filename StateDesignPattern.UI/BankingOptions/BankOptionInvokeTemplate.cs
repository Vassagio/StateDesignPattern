using System;

namespace StateDesignPattern.UI.BankingOptions {
    public abstract class BankOptionInvokeTemplate : IBankOption {
        public void Execute() {
            Clear();
            Invoke();
            Response();
        }

        public abstract string Display { get; }
        public abstract string Key { get; }
        private static void Clear() => Console.Clear();        
        protected abstract void Invoke();
        protected abstract void Response();
    }
}