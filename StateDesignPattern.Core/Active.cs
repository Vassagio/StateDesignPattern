using System;

namespace StateDesignPattern.Core {
    public class Active : IState {

        private readonly Action _onUnfreeze;
        public Active(Action onUnfreeze)
        {
            _onUnfreeze = onUnfreeze;
        }
        public IState Deposit(Action addToBalance) {
            addToBalance();
            return this;
        }

        public IState Withdraw(Action removeFromBalance) {
            removeFromBalance();
            return this;
        }

        public IState Freeze() => new Frozen(_onUnfreeze);
        public IState Close() => new Closed();
    }
}