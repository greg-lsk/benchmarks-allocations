using BenchmarkDotNet.Attributes;


namespace EnumCasting;


[MemoryDiagnoser]
public class Benchmarks
{
    [Benchmark]
    public int ToIntCast() => (int)Color.Blue;

    [Benchmark]
    public Color ToColorCast() => (Color)0;
}