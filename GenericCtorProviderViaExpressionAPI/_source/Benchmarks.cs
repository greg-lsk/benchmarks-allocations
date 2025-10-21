using BenchmarkDotNet.Attributes;

namespace GenericCtorProviderViaExpressionAPI;


[MemoryDiagnoser]
public class Benchmarks
{
    private int _number;
    private string _word;


    [GlobalSetup]
    public void Setup()
    {
        _number = 1;
        _word = "one";
    }

    [Benchmark(Baseline = true)]
    public PairOf<int, string> SimpleCtorCall() 
    => new(_number, _word);

    [Benchmark]
    public PairOf<int, string> StaticCtorViaExpression() 
    => GenericCtorProvider<int, string>.StaticConstructor(_number, _word);

    [Benchmark]
    public PairOf<int, string> NonStaticCtorViaExpression() 
    => new GenericCtorProvider<int, string>().NonStaticConstructor(_number, _word);
}