namespace StateDesignPattern.UI.BankingOptions {
    public class ExitOption : IBankOption {
        public void Execute() {}

        public string Display => "(E)xit";
        public string Key => "E";
    }
}