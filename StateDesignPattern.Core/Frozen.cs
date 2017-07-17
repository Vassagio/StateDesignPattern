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
            return new Active();
        }

        public IState Withdraw(Action removeFromBalance) {
            _onUnfreeze();
            removeFromBalance();
            return new Active();
        }

        public IState Freeze() => this;
    }
}