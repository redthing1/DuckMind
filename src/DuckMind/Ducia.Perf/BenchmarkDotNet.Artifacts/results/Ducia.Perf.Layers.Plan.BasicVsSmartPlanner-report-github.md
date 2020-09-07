``` ini

BenchmarkDotNet=v0.12.1, OS=manjaro 
AMD Ryzen 7 2700X, 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.100-preview.8.20417.9
  [Host]     : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT


```
|            Method |     N |         Mean |      Error |    StdDev |
|------------------ |------ |-------------:|-----------:|----------:|
| **solveBasicCleaner** |   **100** |     **27.28 μs** |   **0.271 μs** |  **0.241 μs** |
| solveSmartCleaner |   100 |    280.18 μs |   1.040 μs |  0.973 μs |
| **solveBasicCleaner** |  **1000** |    **283.07 μs** |   **2.504 μs** |  **2.220 μs** |
| solveSmartCleaner |  1000 |  2,879.19 μs |   4.619 μs |  4.320 μs |
| **solveBasicCleaner** | **10000** |  **5,582.31 μs** |  **76.297 μs** | **71.368 μs** |
| solveSmartCleaner | 10000 | 36,450.59 μs | 116.019 μs | 96.881 μs |
