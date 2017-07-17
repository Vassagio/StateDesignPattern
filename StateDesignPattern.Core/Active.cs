using System;

namespace StateDesignPattern.Core {
    public class Active : IState {
        public IState Deposit(Action addToBalance) {
            throw new NotImplementedException();
        }

        public IState Withdraw(Action removeFromBalance) {
            throw new NotImplementedException();
        }

        public IState Freeze() {
            throw new NotImplementedException();
        }
    }
}