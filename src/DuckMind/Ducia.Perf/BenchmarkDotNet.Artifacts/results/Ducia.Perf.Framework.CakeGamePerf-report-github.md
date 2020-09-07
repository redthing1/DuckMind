``` ini

BenchmarkDotNet=v0.12.1, OS=manjaro 
AMD Ryzen 7 2700X, 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.100-preview.8.20417.9
  [Host]     : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT


```
|      Method |      N |         Mean |      Error |     StdDev |
|------------ |------- |-------------:|-----------:|-----------:|
| **runCakeGame** |    **100** |     **45.91 μs** |   **0.329 μs** |   **0.292 μs** |
| **runCakeGame** |   **1000** |    **451.02 μs** |   **1.043 μs** |   **0.871 μs** |
| **runCakeGame** |  **10000** |  **4,520.45 μs** |  **31.293 μs** |  **29.271 μs** |
| **runCakeGame** | **100000** | **46,073.05 μs** | **150.961 μs** | **126.060 μs** |
