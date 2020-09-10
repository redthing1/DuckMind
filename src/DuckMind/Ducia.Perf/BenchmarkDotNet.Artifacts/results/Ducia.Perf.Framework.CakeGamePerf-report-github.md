``` ini

BenchmarkDotNet=v0.12.1, OS=manjaro 
AMD Ryzen 7 2700X, 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.100-preview.8.20417.9
  [Host]     : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT


```
|      Method |      N |         Mean |      Error |    StdDev | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------- |-------------:|-----------:|----------:|------:|------:|------:|----------:|
| **runCakeGame** |    **100** |     **41.34 μs** |   **0.300 μs** |  **0.281 μs** |     **-** |     **-** |     **-** |         **-** |
| **runCakeGame** |   **1000** |    **407.44 μs** |   **0.586 μs** |  **0.520 μs** |     **-** |     **-** |     **-** |       **5 B** |
| **runCakeGame** |  **10000** |  **4,049.00 μs** |  **10.662 μs** |  **9.973 μs** |     **-** |     **-** |     **-** |      **66 B** |
| **runCakeGame** | **100000** | **40,794.39 μs** | **109.279 μs** | **96.873 μs** |     **-** |     **-** |     **-** |         **-** |
