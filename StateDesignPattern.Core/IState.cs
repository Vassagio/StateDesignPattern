using System;

namespace StateDesignPattern.Core {
    public interface IState {
        IState Deposit(Action addToBalance);
        IState Withdraw(Action removeFromBalance);
        IState Freeze();
        IState Close();
        IState HolderVerified();
    }
}