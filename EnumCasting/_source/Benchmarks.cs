using BenchmarkDotNet.Attributes;


namespace EnumCasting;


[MemoryDiagnoser]
public class Benchmarks
{
    [Benchmark]
    public int ToIntCast() => (int)Color.Blue;

    [Benchmark]
    public Color ToColorCast() => (Color)0;


    private static int IntCast() => (int)Color.Blue;
    private static Color EnumCast() => (Color)0;
}