using System;

namespace StateDesignPattern.Core {
    public class Closed : IState {
        public IState Deposit(Action addToBalance) => this;

        public IState Withdraw(Action removeFromBalance) => this;

        public IState Freeze() => this;

        public IState Close() => this;

        public IState HolderVerified() => this;
    }
}