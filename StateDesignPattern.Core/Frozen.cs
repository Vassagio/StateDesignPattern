using System;

namespace StateDesignPattern.Core {
    public class Frozen : IState {
        private readonly Action _onUnfreeze;

        public Frozen(Action onUnfreeze) {
            _onUnfreeze = onUnfreeze;
        }

        public IState Deposit(Action addToBalance) {
            _onUnfreeze();
            addToBalance();
            return new Active(_onUnfreeze);
        }

        public IState Withdraw(Action removeFromBalance) {
            _onUnfreeze();
            removeFromBalance();
            return new Active(_onUnfreeze);
        }

        public IState Freeze() {
            return this;
        }

        public IState Close() {
            return new Closed();
        }
    }
}