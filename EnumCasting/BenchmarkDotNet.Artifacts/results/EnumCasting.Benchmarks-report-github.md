```

BenchmarkDotNet v0.15.4, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Core2 Quad CPU Q9300 2.50GHz, 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.306
  [Host]     : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v1
  DefaultJob : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v1


```
| Method            | Mean     | Error    | StdDev   | Allocated |
|------------------ |---------:|---------:|---------:|----------:|
| ToIntCast         | 12.90 μs | 0.001 μs | 0.001 μs |         - |
| ToIntCastGeneric  | 12.90 μs | 0.001 μs | 0.001 μs |         - |
| ToEnumCast        | 46.58 μs | 0.008 μs | 0.007 μs |         - |
| ToEnumCastGeneric | 46.59 μs | 0.010 μs | 0.010 μs |         - |
