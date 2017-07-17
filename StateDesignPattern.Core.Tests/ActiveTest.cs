using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StateDesignPattern.Core.Tests {
    public class ActiveTest {
        [Fact]
        public void Initialize()
        {
            var state = BuildActive();

            Assert.NotNull(state);
            Assert.IsAssignableFrom<IState>(state);
        }

        [Fact]
        public void Freeze_ReturnsFrozenState() {
            var state = BuildActive();

            var newState = state.Freeze();

            Assert.IsType<Frozen>(newState);
        }

        [Fact]
        public void Deposit_ReturnsCurrentState()
        {
            var state = BuildActive();

            var newState = state.Deposit(() => new MockAction().Run());

            Assert.Equal(state, newState);
            Assert.IsType<Active>(newState);
        }

        [Fact]
        public void Deposit_AddToBalanceInvokedWhenAccountIsFrozen()
        {
            var addToBalance = new MockAction();
            var state = BuildActive();

            state.Deposit(() => addToBalance.Run());

            addToBalance.VerifyRunCalled();
        }

        [Fact]
        public void Withdraw_ReturnsCurrentState()
        {
            var state = BuildActive();

            var newState = state.Withdraw(() => new MockAction().Run());

            Assert.Equal(state, newState);
            Assert.IsType<Active>(newState);
        }

        [Fact]
        public void Withdraw_RemoveFromBalanceInvokedWhenAccountIsFrozen()
        {
            var removeFromBalance = new MockAction();
            var state = BuildActive();

            state.Withdraw(() => removeFromBalance.Run());

            removeFromBalance.VerifyRunCalled();
        }


        [Fact]
        public void Close_ReturnsClosedState()
        {
            var state = BuildActive();

            var newState = state.Close();

            Assert.IsType<Closed>(newState);
        }

        private static Active BuildActive(Action action = null)
        {
            action = action ?? (() => new MockAction().Run());
            return new Active(action);
        }
    }
}
