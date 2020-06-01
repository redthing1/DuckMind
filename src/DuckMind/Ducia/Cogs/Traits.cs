namespace Ducia.Cogs {
    public abstract class Traits<TPersonality> where TPersonality : Personality {
        public abstract float[] vec { get; }

        public abstract void calculate(TPersonality ply);
    }
}