using BenchmarkDotNet.Attributes;


namespace EnumCasting;


[MemoryDiagnoser]
public class Benchmarks
{
    private int _iterations;
    private Color _color;


    [GlobalSetup]
    public void Setup()
    {
        _iterations = 30000;
        _color = Color.Olive;
    }


    [Benchmark]
    public int ToIntCast()
    {
        var total = 0;
        for (int i = 0; i < _iterations; ++i) total += (int)_color;

        return total;
    }

    [Benchmark]
    public int ToIntCastGeneric()
    {
        var total = 0;
        for (int i = 0; i < _iterations; ++i) total += ToIntCastGeneric(_color);

        return total;
    }

    [Benchmark]
    public Color ToEnumCast()
    {
        var color = Color.White;
        for (int i = 0; i < _iterations; ++i) color = (Color)(i % 2);

        return color;
    }

    [Benchmark]
    public Color ToEnumCastGeneric()
    {
        var color = Color.White;
        for (int i = 0; i < _iterations; ++i) color = ToEnumCastGeneric<Color>(i % 2);
        

        return color;
    }

    private static int ToIntCastGeneric<TEnum>(TEnum e) where TEnum : struct, Enum => (int)(object)e;
    private static TEnum ToEnumCastGeneric<TEnum>(int number) where TEnum : struct, Enum => (TEnum)(object)number;
}