using System;
using System.Linq;
using Xunit;

namespace Ducia.Tests.Layers.Mind {
    public class MindTests : IDisposable {
        private BasicMind mind;

        public MindTests() {
            mind = new BasicMind();
            mind.initialize();
        }

        [Fact]
        public void canConstructMind() {
            Assert.NotNull(mind.state);
        }

        [Fact]
        public void canAddSystems() {
            Assert.NotEmpty(mind.sensorySystems);
            Assert.NotEmpty(mind.cognitiveSystems);
        }

        [Fact]
        public void canUpdateSystems() {
            mind.tick(0.1f);
            var rhythmSystem = (BasicMind.RhythmSystem) mind.sensorySystems.Single(x => x is BasicMind.RhythmSystem);
            Assert.True(rhythmSystem.beats > 0);
            var rngSystem = (BasicMind.RandomSeedSystem) mind.cognitiveSystems.Single(x => x is BasicMind.RandomSeedSystem);
            Assert.True(rngSystem.state >= 0);
        }

        public void Dispose() {
            mind.destroy();
        }
    }
}