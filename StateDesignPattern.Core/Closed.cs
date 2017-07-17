using System;

namespace StateDesignPattern.Core {
    public class Closed : IState {
        public IState Deposit(Action addToBalance) {
            return this;
        }

        public IState Withdraw(Action removeFromBalance) {
            return this;
        }

        public IState Freeze() {
            return this;
        }

        public IState Close() {
            return this;
        }
    }
}