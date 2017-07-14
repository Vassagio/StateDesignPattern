using System;

namespace StateDesignPattern.Core {
    public class Account {
        public decimal Balance { get; private set; }
        internal bool IsVerified { get; private set; }
        internal bool IsClosed { get; private set; }
        internal bool IsFrozen { get; private set; }

        private Action OnUnfreeze { get; }

        public Account(decimal startingBalance, Action onUnfreeze) {
            Balance = startingBalance;
            OnUnfreeze = onUnfreeze;
        }

        public void Deposit(decimal amount) {
            if (IsClosed)
                return;
            ManageUnfreezing();

            Balance += amount;
        }

        public void Withdraw(decimal amount) {
            if (IsClosed)
                return;
            if (!IsVerified)
                return;
            ManageUnfreezing();

            Balance -= amount;
        }

        private void ManageUnfreezing() {
            if (IsFrozen) {
                IsFrozen = false;
                OnUnfreeze();
            }
        }

        public void HolderVerified() {
            IsVerified = true;
        }

        public void Close() {
            IsClosed = true;
        }

        public void Freeze() {
            if (IsClosed)
                return;
            if (!IsVerified)
                return;
            IsFrozen = true;
        }
    }
}