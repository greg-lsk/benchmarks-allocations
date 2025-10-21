```

BenchmarkDotNet v0.15.4, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Core2 Quad CPU Q9300 2.50GHz, 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.306
  [Host]     : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v1
  DefaultJob : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v1


```
| Method               | Mean     | Error     | StdDev    | Ratio | Allocated | Alloc Ratio |
|--------------------- |---------:|----------:|----------:|------:|----------:|------------:|
| FromInterfaceCheck   | 2.159 μs | 0.0021 μs | 0.0018 μs |  1.00 |         - |          NA |
| PatternMatchingCheck | 2.151 μs | 0.0004 μs | 0.0003 μs |  1.00 |         - |          NA |
