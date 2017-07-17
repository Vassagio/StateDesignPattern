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

        private static Active BuildActive()
        {
            return new Active();
        }
    }
}
