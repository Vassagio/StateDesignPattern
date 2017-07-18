using System;

namespace StateDesignPattern.UI.BankingOptions {
    public abstract class BankOptionWithQuestionTemplate: IBankOption {
        public void Execute()
        {
            var result = Question();
            Clear();
            Invoke(result);
            Response();
        }

        public abstract string Display { get; }
        public abstract string Key { get; }
        protected abstract decimal Question();
        private static void Clear() => Console.Clear();        
        protected abstract void Invoke(decimal result);
        protected abstract void Response();
    }
}