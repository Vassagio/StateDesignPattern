using System;
using Xunit;

namespace StateDesignPattern.Core.Tests {
    public class NotVerifiedTest {
        [Fact]
        public void Initialize() {
            var state = BuildNotVerified();

            Assert.NotNull(state);
            Assert.IsAssignableFrom<IState>(state);
        }

        [Fact]
        public void Freeze_ReturnsCurrentState() {
            var state = BuildNotVerified();

            var newState = state.Freeze();

            Assert.Equal(state, newState);
            Assert.IsType<NotVerified>(newState);
        }

        [Fact]
        public void Deposit_ReturnsCurrentState()
        {
            var state = BuildNotVerified();

            var newState = state.Deposit(() => new MockAction().Run());

            Assert.Equal(state, newState);
            Assert.IsType<NotVerified>(newState);
        }

        [Fact]
        public void Deposit_AddFromBalanceNotInvoked()
        {
            var state = BuildNotVerified();
            var addToBalance = new MockAction();

            state.Deposit(() => addToBalance.Run());

            addToBalance.VerifyRunCalled();
        }

        [Fact]
        public void Withdraw_ReturnsCurrentState()
        {
            var state = BuildNotVerified();

            var newState = state.Withdraw(() => new MockAction().Run());

            Assert.Equal(state, newState);
            Assert.IsType<NotVerified>(newState);
        }

        [Fact]
        public void Withdraw_RemoveFromBalanceNotInvoked()
        {
            var state = BuildNotVerified();
            var removeFromBalance = new MockAction();

            state.Withdraw(() => removeFromBalance.Run());
            
            removeFromBalance.VerifyRunNotCalled();
        }

        [Fact]
        public void Closed_ReturnsClosedState() {
            var state = BuildNotVerified();

            var newState = state.Close();

            Assert.IsType<Closed>(newState);
        }

        [Fact]
        public void HolderVerified_ReturnsActiveState()
        {
            var state = BuildNotVerified();

            var newState = state.HolderVerified();

            Assert.IsType<Active>(newState);
        }

        private static NotVerified BuildNotVerified(Action action = null) {
            action = action ?? (() => new MockAction().Run());
            return new NotVerified(action);
        }
    }
}