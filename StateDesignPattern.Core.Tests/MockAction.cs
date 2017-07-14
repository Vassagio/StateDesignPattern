using Xunit;

namespace StateDesignPattern.Core.Tests {
    public class MockAction {
        private bool _hasRun;
        private int _timesExecuted;

        public void Run() {
            _hasRun = true;
            _timesExecuted += 1;
        }

        public void VerifyRunCalled(int times = 1) {
            Assert.True(_hasRun);
            Assert.Equal(times, _timesExecuted);
        }

        public void VerifyRunNotCalled()
        {
            Assert.False(_hasRun);
            Assert.Equal(0, _timesExecuted);
        }
    }
}