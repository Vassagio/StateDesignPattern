using System;
using Xunit;

namespace StateDesignPattern.Core.Tests {
    public class AccountTest {
        [Fact]
        public void Initialize() {
            var account = BuildAccount();

            Assert.NotNull(account);
        }

        [Fact]
        public void Initialize_SetsIsVerified_False() {
            var account = BuildAccount();

            Assert.False(account.IsVerified);
        }

        [Fact]
        public void Initialize_SetsIsClosed_False() {
            var account = BuildAccount();

            Assert.False(account.IsClosed);
        }

        [Fact]
        public void HolderVerified_SetsIsVerified_True() {
            var account = BuildAccount();

            account.HolderVerified();

            Assert.True(account.IsVerified);
        }

        [Fact]
        public void Close_SetsIsClosed_True() {
            var account = BuildAccount();

            account.Close();

            Assert.True(account.IsClosed);
        }

        [Fact]
        public void Deposit_BalanceChangesWhenAccountIsOpen() {
            const decimal STARTING_AMOUNT = 10;
            var action = new MockAction();
            var account = BuildAccount(STARTING_AMOUNT, () => action.Run());

            account.Deposit(10);

            Assert.Equal(20, account.Balance);
            action.VerifyRunNotCalled();
        }

        [Fact]
        public void Deposit_BalanceDoesNotChangeWhenAccountClosed() {
            const decimal STARTING_AMOUNT = 10;
            var account = BuildAccount(STARTING_AMOUNT);

            account.Close();
            account.Deposit(5);

            Assert.Equal(10, account.Balance);
        }

        [Fact]
        public void Deposit_BalanceChangesWhenAccountIsFrozen() {
            const decimal STARTING_AMOUNT = 10;
            var account = BuildAccount(STARTING_AMOUNT);

            account.Freeze();
            account.Deposit(10);

            Assert.Equal(20, account.Balance);
        }

        [Fact]
        public void Deposit_SetsIsFrozen_False() {
            var action = new MockAction();
            var account = BuildAccount(action: () => action.Run());

            account.HolderVerified();
            account.Freeze();
            account.Deposit(10);

            Assert.False(account.IsFrozen);
        }

        [Fact]
        public void Deposit_UnfreezeInvokedWhenAccountIsFrozen() {
            var action = new MockAction();
            var account = BuildAccount(action: () => action.Run());

            account.HolderVerified();
            account.Freeze();
            account.Deposit(10);

            action.VerifyRunCalled();
        }

        [Fact]
        public void Withdraw_BalanceChangesWhenAccountIsVerifiedAndOpen() {
            const decimal STARTING_AMOUNT = 10;
            var account = BuildAccount(STARTING_AMOUNT);

            account.HolderVerified();
            account.Withdraw(5);

            Assert.Equal(5, account.Balance);
        }

        [Fact]
        public void Withdraw_BalanceDoesNotChangeWhenAccountNotVerified() {
            const decimal STARTING_AMOUNT = 10;
            var account = BuildAccount(STARTING_AMOUNT);

            account.Withdraw(5);

            Assert.Equal(10, account.Balance);
        }

        [Fact]
        public void Withdraw_BalanceDoesNotChangeWhenAccountClosed() {
            const decimal STARTING_AMOUNT = 10;
            var account = BuildAccount(STARTING_AMOUNT);

            account.Close();
            account.HolderVerified();
            account.Withdraw(5);

            Assert.Equal(10, account.Balance);
        }

        [Fact]
        public void Withdraw_BalanceChangesWhenAccountIsFrozen() {
            const decimal STARTING_AMOUNT = 10;
            var account = BuildAccount(STARTING_AMOUNT);

            account.HolderVerified();
            account.Freeze();
            account.Withdraw(5);

            Assert.Equal(5, account.Balance);
        }

        [Fact]
        public void Withdraw_SetsIsFrozen_False() {
            var action = new MockAction();
            var account = BuildAccount(action: () => action.Run());

            account.HolderVerified();
            account.Freeze();
            account.Withdraw(5);

            Assert.False(account.IsFrozen);
        }

        [Fact]
        public void Withdraw_UnfreezeInvokedWhenAccountIsFrozen() {
            var action = new MockAction();
            var account = BuildAccount(action: () => action.Run());

            account.HolderVerified();
            account.Freeze();
            account.Withdraw(5);

            action.VerifyRunCalled();
        }

        [Fact]
        public void Freeze_AccountFrozenWhenNotClosedAndVerified() {
            var account = BuildAccount();

            account.HolderVerified();
            account.Freeze();

            Assert.True(account.IsFrozen);
        }

        [Fact]
        public void Freeze_AccountNotFrozenWhenClosed() {
            const decimal STARTING_AMOUNT = 10;
            var account = BuildAccount(STARTING_AMOUNT);

            account.Close();
            account.HolderVerified();
            account.Freeze();

            Assert.False(account.IsFrozen);
        }

        [Fact]
        public void Freeze_AccountNotFrozenWhenNotVerified() {
            const decimal STARTING_AMOUNT = 10;
            var account = BuildAccount(STARTING_AMOUNT);

            account.Freeze();

            Assert.False(account.IsFrozen);
        }

        private static Account BuildAccount(decimal? startingBalance = null, Action action = null) {
            startingBalance = startingBalance ?? 10;
            action = action ?? (() => new MockAction().Run());
            return new Account(startingBalance.Value, action);
        }
    }
}