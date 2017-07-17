using System;

namespace StateDesignPattern.Core {
    public class Account {
        public decimal Balance { get; private set; }        
        private IState State { get; set; }

        public Account(decimal startingBalance, Action onUnfreeze) {
            Balance = startingBalance;
            State = new NotVerified(onUnfreeze);
        }

        public void Deposit(decimal amount) {
            State = State.Deposit(() => Balance += amount);            
        }

        public void Withdraw(decimal amount) {
            State = State.Withdraw(() => Balance -= amount);
        }

        public void HolderVerified() {
            State = State.HolderVerified();
        }

        public void Close() {
            State = State.Close();
        }

        public void Freeze() {
            State = State.Freeze();
        }        
    }
}