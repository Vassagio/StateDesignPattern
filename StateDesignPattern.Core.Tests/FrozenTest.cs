using System;
using Xunit;

namespace StateDesignPattern.Core.Tests {
    public class FrozenTest {
        [Fact]
        public void Initialize() {
            var state = BuildFrozen();

            Assert.NotNull(state);
            Assert.IsAssignableFrom<IState>(state);
        }

        [Fact]
        public void Freeze_ReturnsCurrentState()
        {
            var state = BuildFrozen();

            var newState = state.Freeze();

            Assert.Equal(state, newState);
            Assert.IsType<Frozen>(newState);
        }

        [Fact]
        public void Deposit_ReturnsActiveState()
        {
            var state = BuildFrozen();

            var newState = state.Deposit(() => new MockAction().Run());

            Assert.IsType<Active>(newState);
        }

        [Fact]
        public void Deposit_UnfreezeInvokedWhenAccountIsFrozen()
        {
            var action = new MockAction();
            var state = BuildFrozen(() => action.Run());
            
            state.Deposit(() => new MockAction().Run());

            action.VerifyRunCalled();
        }

        [Fact]
        public void Deposit_AddToBalanceInvokedWhenAccountIsFrozen()
        {            
            var addToBalance = new MockAction();
            var state = BuildFrozen();

            state.Deposit(() => addToBalance.Run());

            addToBalance.VerifyRunCalled();
        }

        [Fact]
        public void Withdraw_ReturnsActiveState()
        {
            var state = BuildFrozen();

            var newState = state.Withdraw(() => new MockAction().Run());

            Assert.IsType<Active>(newState);
        }

        [Fact]
        public void Withdraw_UnfreezeInvokedWhenAccountIsFrozen()
        {
            var action = new MockAction();
            var state = BuildFrozen(() => action.Run());

            state.Withdraw(() => new MockAction().Run());

            action.VerifyRunCalled();
        }

        [Fact]
        public void Withdraw_RemoveFromBalanceInvokedWhenAccountIsFrozen()
        {
            var removeFromBalance = new MockAction();
            var state = BuildFrozen();

            state.Withdraw(() => removeFromBalance.Run());

            removeFromBalance.VerifyRunCalled();
        }

        [Fact]
        public void Close_ReturnsClosedState()
        {
            var state = BuildFrozen();

            var newState = state.Close();

            Assert.IsType<Closed>(newState);
        }

        private static Frozen BuildFrozen(Action action = null) {
            action = action ?? (() => new MockAction().Run());
            return new Frozen(action);
        }
    }
}