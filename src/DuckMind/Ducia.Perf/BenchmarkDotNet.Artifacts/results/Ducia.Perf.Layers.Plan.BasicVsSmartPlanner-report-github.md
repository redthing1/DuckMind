``` ini

BenchmarkDotNet=v0.12.1, OS=manjaro 
AMD Ryzen 7 2700X, 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.100-preview.8.20417.9
  [Host] : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT


```
|            Method |     N | Mean | Error |
|------------------ |------ |-----:|------:|
| **solveBasicCleaner** |  **1000** |   **NA** |    **NA** |
| solveSmartCleaner |  1000 |   NA |    NA |
| **solveBasicCleaner** | **10000** |   **NA** |    **NA** |
| solveSmartCleaner | 10000 |   NA |    NA |

Benchmarks with issues:
  BasicVsSmartPlanner.solveBasicCleaner: DefaultJob [N=1000]
  BasicVsSmartPlanner.solveSmartCleaner: DefaultJob [N=1000]
  BasicVsSmartPlanner.solveBasicCleaner: DefaultJob [N=10000]
  BasicVsSmartPlanner.solveSmartCleaner: DefaultJob [N=10000]
