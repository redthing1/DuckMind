``` ini

BenchmarkDotNet=v0.12.1, OS=manjaro 
AMD Ryzen 7 2700X, 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.100-preview.8.20417.9
  [Host]     : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT


```
|            Method |     N |         Mean |      Error |     StdDev |
|------------------ |------ |-------------:|-----------:|-----------:|
| **solveBasicCleaner** |   **100** |     **28.95 μs** |   **0.451 μs** |   **0.422 μs** |
| solveSmartCleaner |   100 |    289.39 μs |   1.065 μs |   0.944 μs |
| **solveBasicCleaner** |  **1000** |    **282.01 μs** |   **2.004 μs** |   **1.674 μs** |
| solveSmartCleaner |  1000 |  2,880.26 μs |   8.586 μs |   7.611 μs |
| **solveBasicCleaner** | **10000** |  **5,502.88 μs** |  **37.884 μs** |  **33.583 μs** |
| solveSmartCleaner | 10000 | 37,736.99 μs | 255.356 μs | 213.234 μs |
