using Ducia;

namespace MindDemos {
    public class AntMind : Mind<AntMind.State> {
        public class State : MindState { }

        public AntMind(State state) : base(state) { }
    }
}