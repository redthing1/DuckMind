using System;
using Xunit;

namespace Ducia.Tests.Layers.Mind {
    public class MindTests {
        private BasicMind mind;

        public MindTests() {
            mind = new BasicMind();
        }

        [Fact]
        public void canConstructMind() {
            Assert.NotNull(mind.state);
        }
    }
}