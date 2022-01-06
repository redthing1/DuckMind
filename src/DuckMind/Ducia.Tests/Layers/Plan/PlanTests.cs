using Activ.GOAP;
using Xunit;

namespace Ducia.Tests.Layers.Plan; 

public class PlanTests {
    [Fact]
    public void smartActionPlannerValid() {
        var a1 = new FlowerPicker {
            bucket = 2,
            flowersPicked = 4
        };
        var a2 = new FlowerPicker {
            bucket = 2,
            flowersPicked = 4
        };

        // equality
        Assert.True(a1.Equals(a2));
        Assert.True(a2.Equals(a1));

        // cloning
        var a3 = new FlowerPicker();
        a1.Clone(a3);
        Assert.True(a1.Equals(a3));

        // hash code
        Assert.True(a1.GetHashCode() == a2.GetHashCode());
        Assert.True(a1.GetHashCode() == a3.GetHashCode());
    }

    [Fact]
    public void canPlanFlowerPicking() {
        var model = new FlowerPicker();
        var solver = new Solver<FlowerPicker>();
        var plan = solver.Next(model, new Goal<FlowerPicker>(x => x.flowersPicked >= 40));
        Assert.NotNull(plan);
        var path = plan.Path();
        Assert.NotEmpty(path);
    }

    [Fact]
    public void canPlanFlowerPickingLarge() {
        var model = new FlowerPicker();
        var solver = new Solver<FlowerPicker>();
        solver.maxIter = solver.maxNodes = 10000; // unlock
        var plan = solver.Next(model, new Goal<FlowerPicker>(x => x.flowersPicked >= 1000));
        Assert.NotNull(plan);
        var path = plan.Path();
        Assert.NotEmpty(path);
    }

    [Fact]
    public void canPlanRoomCleaningBasic() {
        var model = new BasicRoomCleaner();
        var solver = new Solver<BasicRoomCleaner>();
        var plan = solver.Next(model, new Goal<BasicRoomCleaner>(x => x.workDone >= 20));
        Assert.NotNull(plan);
    }

    [Fact]
    public void canPlanRoomCleaningSmart() {
        var model = new SmartRoomCleaner();
        var solver = new Solver<SmartRoomCleaner>();
        var plan = solver.Next(model, new Goal<SmartRoomCleaner>(x => x.workDone >= 20));
        Assert.NotNull(plan);
    }
}