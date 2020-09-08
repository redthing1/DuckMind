using Ducia.Calc;
using Xunit;

namespace Ducia.Tests.Cogs {
    public class PersonalityTests {
        [Fact]
        public void canMapValues() {
            var vi = 0f;
            var v01 = PerMath.map01(vi);
            Assert.Equal(0.5f, v01, 4);
            var v11 = PerMath.map11(v01);
            Assert.Equal(vi, v11, 4);
        }
    }
}