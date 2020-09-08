using Ducia.Calc;
using Xunit;

namespace Ducia.Tests.Cogs {
    public class PersonalityTests {
        private WriterSoul soul;

        public PersonalityTests() {
            soul = new WriterSoul();
        }
        
        [Fact]
        public void canMapValues() {
            var vi = 0f;
            var v01 = PerMath.map01(vi);
            Assert.Equal(0.5f, v01, 4);
            var v11 = PerMath.map11(v01);
            Assert.Equal(vi, v11, 4);
        }

        [Fact]
        public void canCreateSoul() {
            Assert.NotNull(soul.ply);
            Assert.NotNull(soul.emotions);
            Assert.NotNull(soul.traits);
        }

        [Fact]
        public void canComputeTraits() {
            // create a fixed personality
            soul.ply = new WriterSoul.Personality(e: 0.2f, c: 0.8f);
            soul.recalculate();
            Assert.Equal(-0.06, soul.traits.productivity, 4);
        }
    }
}