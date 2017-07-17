using Xunit;

namespace StateDesignPattern.Core.Tests {
    public class ClosedTest {
        [Fact]
        public void Initialize() {
            var state = BuildClosed();

            Assert.NotNull(state);
            Assert.IsAssignableFrom<IState>(state);
        }

        [Fact]
        public void Freeze_ReturnsCurrentState() {
            var state = BuildClosed();

            var newState = state.Freeze();

            Assert.Equal(state, newState);
            Assert.IsType<Closed>(newState);
        }

        [Fact]
        public void Deposit_ReturnsCurrentState() {
            var state = BuildClosed();

            var newState = state.Deposit(() => new MockAction().Run());

            Assert.Equal(state, newState);
            Assert.IsType<Closed>(newState);
        }

        [Fact]
        public void Withdraw_ReturnsCurrentState() {
            var state = BuildClosed();

            var newState = state.Withdraw(() => new MockAction().Run());

            Assert.Equal(state, newState);
            Assert.IsType<Closed>(newState);
        }

        [Fact]
        public void Closed_ReturnsCurrentState() {
            var state = BuildClosed();

            var newState = state.Close();

            Assert.Equal(state, newState);
            Assert.IsType<Closed>(newState);
        }

        [Fact]
        public void NotVerified_ReturnsCurrentState()
        {
            var state = BuildClosed();

            var newState = state.HolderVerified();

            Assert.Equal(state, newState);
            Assert.IsType<Closed>(newState);
        }

        private static Closed BuildClosed() {
            return new Closed();
        }
    }
}