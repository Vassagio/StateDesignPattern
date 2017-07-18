namespace StateDesignPattern.UI.BankingOptions {
    public interface IBankOption {
        void Execute();
        string Display { get;  }
        string Key { get;  }
    }
}