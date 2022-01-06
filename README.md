
# DuckMind

a research project: generalizing Sor’s AI engine, providing a multi-layered game-playing agent

## overview

DuckMind is a collection of projects that are based on Sor's AI engine, and provides its game-playing AI functionality as a reusable library.

It implements the multi-phase AI system described in my [Duck Intelligence](https://blog.rie.icu/post/duck_intelligence_presentation/) presentation<sup>[PDF](https://github.com/xdrie/Sor/releases/download/0.6.6.05-dev/Sor.Duck.Intelligence.pdf)</sup>.

Generally, this system is based around the idea of hierarchically combining multiple advanced game-playing AI algorithms into a decision making and action pipeline.

## features

the **Ducia** library provides the core AI algorithms and classes. when using them in external projects, they are typically subclassed for application specific functionality, though many good defaults are provided.

+ **Framework** - Core AI algorithms, including pathfinding, goal-oriented action planning, and utility-based reasoners
+ **Calc** - Mathematical utility classes for AI-related computations
+ **Cogs** - The [**Personality Engine**](https://blog.rie.icu/post/duck_intelligence_presentation/#headline-15) classes
+ **Layers** - abstract framework for combining multiple **Systems** in a [sense-think-act](https://blog.rie.icu/post/duck_intelligence_presentation/#headline-10) architecture

## concepts

read the [documentation](doc/index.md) for detailed information on Ducia's key concepts.

### simple example: ants

see the Ants (WIP) example

### robust example: ducks

the [Sor](https://github.com/xdrie/Sor/) game makes extensive use of this AI engine, which powers the multi-agent real-time simulation of a bird ecosystem.

in particular, see the [AI sources](https://github.com/xdrie/Sor/tree/main/src/Sor/Sor/AI).

## build

use the `Ducia.sln` for the version including the XNez library, or `Ducia.Standalone.sln` for a standalone version.
