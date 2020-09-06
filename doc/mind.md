
# mind

the **Mind** is the encapsulating representation of the AI consciousness of an agent.
it represents a unit that implements the sense-think-act architecture.

the sense-think-act paradigm can be summarized as follows:
+ sense: receive input from the environment and convert it to a useful representation
+ think: based on environment state, make plans and decisions to respond to the environment
+ act: given a set of plans, carry them out in a coordinated manner

## state

every agent will have a single mind, and this mind has an associated **MindState**, which serves as the working memory and cache.

## systems

the mind is itself composed of various systems, which are reusable units of functionality that can be instanced across multiple minds.

systems are divided into _sensory_ and _cognitive_ systems:
+ **sensory** systems run during the _sense_  phase, and serve to gather information about the environment and store it in working memory for quick access
+ **cognitive** systems run during the _think_ phase, and run the planning algorithms to make decisions and plans based on available information

### example systems: Sor

+ the [Vision](https://github.com/xdrie/Sor/blob/main/src/Sor/Sor/AI/Systems/VisionSystem.cs) system is a basic _sensory_ system that detects nearby birds and stores the results in working memory.
+ the [Think](https://github.com/xdrie/Sor/blob/main/src/Sor/Sor/AI/Systems/ThinkSystem.cs) system is a `PlannerSystem`, which is a type of _cognitive_ system that uses a utility reasoner to make decisions.

## pipelines

the mind has two main pipelines: the _autonomous_ pipeline and the _conscious_ pipeline.

### autonomous pipeline

generally, the autonomous pipeline runs on the main thread, because it is designed to run quickly and not require complex computation. in addition, it frequently needs to access game state, so by running on the game thread, up-to-date game state information is readily available.

### conscious pipeline

generally, the conscious pipeline is offloaded to the thread pool, and runs asynchronously independently of the autonomous pipeline. the conscious pipeline includes the _think_ phase, which includes complex AI algorithms that can require a significant amount of time to execute. thread-pooling the AI makes efficient use of modern multi-core CPUs to maximize information throughput when simulating many agents.

thread-pooling is enabled by default, but can be disabled by setting `Mind.useThreadPool` to `false`. when thread-pooling is disabled, the conscious pipeline will be run between the _sense_ and _act_ phases on the autonomous pipeline's thread, usually the main thread.

since working memory is cached in the MindState, this pipeline can generally work completely independently of the autonomous pipeline. when results are ready, it can use message queues in the MindState to pass information to the _act_ phase.

## signals

signals represent events in a way roughly analagous to nervous system impulses. signals are sent to a mind by the external environment, passing an important message about the environmental interaction.

within the conscious pipeline, during the _think_ phase, systems based on `PlannerSystem` are able to process signals.

in the context of a game, certain events such as being hit by an object within the game physics engine should call `Mind.signal` to add a signal to the signal queue in working memory.
