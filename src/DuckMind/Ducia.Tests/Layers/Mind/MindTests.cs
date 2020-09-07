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

        /// <summary>
        /// ensure that systems can be updated
        /// </summary>
        [Fact]
        public void canUpdateSystems() {
            mind.tick(0.1f);
            var rhythmSystem = (BasicMind.RhythmSystem) mind.sensorySystems.Single(x => x is BasicMind.RhythmSystem);
            Assert.True(rhythmSystem.beats > 0);
            var rngSystem =
                (BasicMind.RandomSeedSystem) mind.cognitiveSystems.Single(x => x is BasicMind.RandomSeedSystem);
            Assert.True(rngSystem.state >= 0);
        }

        /// <summary>
        /// ensure that systems don't update faster than their interval
        /// </summary>
        [Fact]
        public void systemUpdateThrottled() {
            mind.tick(0.1f);
            var rhythmSystem = (BasicMind.RhythmSystem) mind.sensorySystems.Single(x => x is BasicMind.RhythmSystem);
            Assert.True(rhythmSystem.beats == 1);
            mind.tick(0.5f);
            Assert.True(rhythmSystem.beats == 2);
        }

        public void Dispose() {
            mind.destroy();
        }
    }
}