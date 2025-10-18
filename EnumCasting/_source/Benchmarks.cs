using BenchmarkDotNet.Attributes;


namespace EnumCasting;


[MemoryDiagnoser]
public class Benchmarks
{
    [Benchmark]
    public void ToIntCast() => IntCast();

    [Benchmark]
    public void ToColorCast() => EnumCast();


    private static int IntCast() => (int)Color.Blue;
    private static Color EnumCast() => (Color)0;
}