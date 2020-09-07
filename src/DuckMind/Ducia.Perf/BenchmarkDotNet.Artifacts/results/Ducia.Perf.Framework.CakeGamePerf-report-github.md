``` ini

BenchmarkDotNet=v0.12.1, OS=manjaro 
AMD Ryzen 7 2700X, 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.100-preview.8.20417.9
  [Host]     : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT


```
|      Method |      N |         Mean |      Error |     StdDev |
|------------ |------- |-------------:|-----------:|-----------:|
| **runCakeGame** |    **100** |     **72.94 μs** |   **0.273 μs** |   **0.242 μs** |
| **runCakeGame** |   **1000** |    **702.55 μs** |   **1.901 μs** |   **1.484 μs** |
| **runCakeGame** |  **10000** |  **7,222.10 μs** |  **42.358 μs** |  **39.622 μs** |
| **runCakeGame** | **100000** | **71,878.08 μs** | **324.172 μs** | **287.370 μs** |
