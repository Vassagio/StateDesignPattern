﻿using System;

namespace StateDesignPattern.Core {
    public class Account {
        public decimal Balance { get; private set; }
        internal bool IsVerified { get; private set; }
        internal bool IsClosed { get; private set; }
        internal bool IsFrozen { get; private set; }
        private Action OnUnfreeze { get; }
        private Action ManageUnfreezing { get; set; }

        public Account(decimal startingBalance, Action onUnfreeze) {
            Balance = startingBalance;
            OnUnfreeze = onUnfreeze;
            ManageUnfreezing = StayUnfrozen;
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
            ManageUnfreezing = Unfreeze;
        }

        private void Unfreeze() {
            IsFrozen = false;
            OnUnfreeze();
            ManageUnfreezing = StayUnfrozen;
        }

        private void StayUnfrozen() { }
    }
}