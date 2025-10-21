using BenchmarkDotNet.Attributes;

namespace StructWithIFacePatternMatching;


[MemoryDiagnoser]
public class Benchmarks
{
    private int _iterations;
    private ShortName _shortName;


    [GlobalSetup]
    public void Setup()
    {
        _iterations = 5000;
        _shortName = new("Gregg", "Allman");
    }


    [Benchmark(Baseline = true)]
    public bool FromInterfaceCheck()
    {
        var returnValue = true;
        for (int i = 0; i < _iterations; ++i) returnValue = IsShortNameFromInterface(_shortName);
        return returnValue;
    }

    [Benchmark]
    public bool PatternMatchingCheck()    
    {
        var returnValue = true;
        for (int i = 0; i < _iterations; ++i) returnValue = IsShortNameFromPatternMatching(_shortName);
        return returnValue;
    }

    private static bool IsShortNameFromPatternMatching<T>(T subject) where T : struct => subject is IShortName;
    private static bool IsShortNameFromInterface<T>(T subject) where T : struct, IMayHasMiddleName => subject.HasMiddleName();   
}