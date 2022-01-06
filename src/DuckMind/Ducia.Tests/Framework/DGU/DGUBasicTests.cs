using Ducia.Framework.DGU;
using Xunit;

namespace Ducia.Tests.Framework.DGU; 

public class DGUBasicTests {
    public DGUBasicTests() {
    }

    [Fact]
    public void canInitAgent() {
        var agent = new DGUAgent();
    }
    
    [Fact]
    public void canRunEmptySTA() {
        var agent = new DGUAgent();
        
        agent.sense();
        agent.think();
        agent.act();
    }
}