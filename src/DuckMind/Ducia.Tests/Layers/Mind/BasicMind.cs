namespace Ducia.Tests.Layers.Mind {
    public class BasicMind : Mind<BasicMind.State> {
        public class State : MindState { }

        public BasicMind() : base(new State()) { }
    }
}