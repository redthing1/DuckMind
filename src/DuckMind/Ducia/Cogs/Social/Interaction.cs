namespace Ducia.Cogs.Social {
    public abstract class Interaction<TContext> {
        public abstract void run(params TContext[] participants);
    }
}