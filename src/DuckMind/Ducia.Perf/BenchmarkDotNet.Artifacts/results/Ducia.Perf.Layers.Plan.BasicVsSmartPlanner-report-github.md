``` ini

BenchmarkDotNet=v0.12.1, OS=manjaro 
AMD Ryzen 7 2700X, 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.100-preview.8.20417.9
  [Host]     : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT


```
|            Method |     N |         Mean |      Error |     StdDev |     Gen 0 |    Gen 1 |    Gen 2 |  Allocated |
|------------------ |------ |-------------:|-----------:|-----------:|----------:|---------:|---------:|-----------:|
| **solveBasicCleaner** |   **100** |     **26.96 μs** |   **0.458 μs** |   **0.428 μs** |    **4.0894** |   **0.5798** |        **-** |   **33.59 KB** |
| solveSmartCleaner |   100 |    275.12 μs |   0.869 μs |   0.812 μs |    9.7656 |   1.4648 |        - |   82.17 KB |
| **solveBasicCleaner** |  **1000** |    **269.13 μs** |   **0.711 μs** |   **0.665 μs** |   **40.0391** |  **14.1602** |        **-** |  **329.87 KB** |
| solveSmartCleaner |  1000 |  2,888.82 μs |  55.649 μs |  52.055 μs |   97.6563 |  46.8750 |        - |  814.37 KB |
| **solveBasicCleaner** | **10000** |  **5,647.57 μs** |  **47.597 μs** |  **44.522 μs** |  **375.0000** | **234.3750** | **117.1875** | **3236.14 KB** |
| solveSmartCleaner | 10000 | 37,538.99 μs | 194.089 μs | 162.073 μs | 1000.0000 | 357.1429 | 142.8571 | 8080.19 KB |
