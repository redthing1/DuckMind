namespace Ducia.Cogs {
    public abstract class Traits<TPersonality> where TPersonality : Personality {
        public abstract void calculate(TPersonality ply);
    }
}