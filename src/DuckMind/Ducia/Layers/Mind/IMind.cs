namespace Ducia; 

public interface IMind {
    /// <summary>
    ///     the number of ticks
    /// </summary>
    int ticks { get; }

    /// <summary>
    ///     the elapsed time within this mind
    /// </summary>
    float elapsed { get; }

    /// <summary>
    ///     allocate resources and start
    /// </summary>
    void initialize();

    /// <summary>
    ///     deallocate resources and halt
    /// </summary>
    void destroy();

    /// <summary>
    ///     step all the systems (main thread)
    /// </summary>
    /// <param name="dt"></param>
    void tick(float dt);

    /// <summary>
    ///     propagate a signal
    /// </summary>
    /// <param name="signal"></param>
    void signal(MindSignal signal);
}