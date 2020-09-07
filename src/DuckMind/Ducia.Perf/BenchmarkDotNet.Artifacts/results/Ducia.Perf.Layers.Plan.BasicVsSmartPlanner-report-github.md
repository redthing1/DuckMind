``` ini

BenchmarkDotNet=v0.12.1, OS=manjaro 
AMD Ryzen 7 2700X, 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.100-preview.8.20417.9
  [Host]     : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT


```
|            Method |     N |         Mean |      Error |     StdDev |
|------------------ |------ |-------------:|-----------:|-----------:|
| **solveBasicCleaner** |   **100** |     **27.35 μs** |   **0.191 μs** |   **0.169 μs** |
| solveSmartCleaner |   100 |    288.07 μs |   1.036 μs |   0.919 μs |
| **solveBasicCleaner** |  **1000** |    **287.20 μs** |   **2.273 μs** |   **2.126 μs** |
| solveSmartCleaner |  1000 |  2,968.09 μs |  22.222 μs |  18.557 μs |
| **solveBasicCleaner** | **10000** |  **5,546.40 μs** |  **95.693 μs** |  **84.830 μs** |
| solveSmartCleaner | 10000 | 37,373.96 μs | 714.347 μs | 850.379 μs |
