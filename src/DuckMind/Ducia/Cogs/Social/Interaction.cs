namespace Ducia.Cogs.Social {
    public abstract class Interaction<TContext, TSentient, TPersonality, TTraits, TEmotions>
        where TPersonality : Personality, new()
        where TTraits : Traits<TPersonality>, new()
        where TEmotions : Emotions, new()
        where TSentient : Sentient<TPersonality, TTraits, TEmotions> {
        public abstract void run(params TContext[] participants);
    }
}