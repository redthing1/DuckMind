using System;
using Activ.GOAP;
using Xunit;

namespace Ducia.Tests.Layers.Plan {
    public class PlanTests {
        [Fact]
        public void canPlanFlowerPicking() {
            var model = new FlowerPicker();
            var solver = new Solver<FlowerPicker>();
            var plan = solver.Next(model, new Goal<FlowerPicker>(x => x.flowersPicked >= 10));
            Assert.NotNull(plan);
        }

        [Fact]
        public void canPlanRoomCleaning() {
            throw new NotImplementedException();
        }
    }
}