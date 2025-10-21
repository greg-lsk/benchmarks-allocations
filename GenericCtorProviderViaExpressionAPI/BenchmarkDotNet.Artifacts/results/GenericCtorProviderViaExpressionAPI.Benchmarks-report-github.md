```

BenchmarkDotNet v0.15.4, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Core2 Quad CPU Q9300 2.50GHz, 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.306
  [Host]     : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v1
  DefaultJob : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v1


```
| Method                     | Mean           | Error       | StdDev      | Ratio     | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|--------------------------- |---------------:|------------:|------------:|----------:|--------:|-------:|-------:|----------:|------------:|
| SimpleCtorCall             |       2.523 ns |   0.0014 ns |   0.0011 ns |      1.00 |    0.00 |      - |      - |         - |          NA |
| StaticCtorViaExpression    |       9.443 ns |   0.0011 ns |   0.0009 ns |      3.74 |    0.00 |      - |      - |         - |          NA |
| NonStaticCtorViaExpression | 153,431.995 ns | 590.5989 ns | 552.4466 ns | 60,819.70 |  213.75 | 3.1738 | 2.9297 |    5073 B |          NA |
