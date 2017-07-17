using System;

namespace StateDesignPattern.Core {
    public class NotVerified : IState {
        private readonly Action _onUnfreeze;

        public NotVerified(Action onUnfreeze) {
            _onUnfreeze = onUnfreeze;
        }
        public IState Deposit(Action addToBalance) {
            addToBalance();
            return this;
        }

        public IState Withdraw(Action removeFromBalance) => this;

        public IState Freeze() => this;

        public IState Close() => new Closed();

        public IState HolderVerified() => new Active(_onUnfreeze);
    }
}