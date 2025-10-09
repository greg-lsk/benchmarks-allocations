```

BenchmarkDotNet v0.15.4, Windows 10 (10.0.19045.6332/22H2/2022Update)
Intel Core2 Quad CPU Q9300 2.50GHz, 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.300
  [Host]     : .NET 9.0.5 (9.0.5, 9.0.525.21509), X64 RyuJIT x86-64-v1
  DefaultJob : .NET 9.0.5 (9.0.5, 9.0.525.21509), X64 RyuJIT x86-64-v1


```
| Method         | Mean       | Error     | StdDev    | Ratio  | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------- |-----------:|----------:|----------:|-------:|--------:|-------:|----------:|------------:|
| RunSimply      |   4.720 ns | 0.0046 ns | 0.0041 ns |   1.00 |    0.00 |      - |         - |          NA |
| RunViaPointer  |  24.462 ns | 0.0192 ns | 0.0161 ns |   5.18 |    0.01 |      - |         - |          NA |
| RunViaDelegate | 730.398 ns | 8.6942 ns | 8.1326 ns | 154.76 |    1.67 | 0.1678 |     264 B |          NA |
