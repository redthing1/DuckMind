``` ini

BenchmarkDotNet=v0.12.1, OS=manjaro 
AMD Ryzen 7 2700X, 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.100-preview.8.20417.9
  [Host]     : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT


```

|            Method |     N |         Mean |      Error |     StdDev |     Gen 0 |    Gen 1 |    Gen 2 |  Allocated |
|------------------ |------ |-------------:|-----------:|-----------:|----------:|---------:|---------:|-----------:|
| **solveBasicCleaner** |   **100** |     **27.08 μs** |   **0.110 μs** |   **0.097 μs** |    **4.0894** |   **
0.5798** |        **-** |   **33.59 KB** |
| solveSmartCleaner |   100 |    281.96 μs |   0.618 μs |   0.578 μs |    9.7656 |   1.4648 |        - |   82.16 KB |
| **solveBasicCleaner** |  **1000** |    **271.59 μs** |   **1.413 μs** |   **1.180 μs** |   **40.0391** |  **
14.1602** |        **-** |  **329.87 KB** |
| solveSmartCleaner |  1000 |  2,879.93 μs |  34.576 μs |  26.994 μs |   97.6563 |  46.8750 |        - |  814.38 KB |
| **solveBasicCleaner** | **10000** |  **5,321.01 μs** |  **71.411 μs** |  **66.798 μs** |  **375.0000** | **
234.3750** | **117.1875** | **3236.21 KB** |
| solveSmartCleaner | 10000 | 37,188.48 μs | 271.140 μs | 240.359 μs | 1000.0000 | 357.1429 |  71.4286 | 8080.15 KB |
