using BenchmarkDotNet.Attributes;

namespace StructWithIFacePatternMatching;


[MemoryDiagnoser]
public class Benchmarks
{
    private ShortName _shortName;
    private LongName _longName;


    [GlobalSetup]
    public void Setup()
    {
        _shortName = new("Gregg", "Allman");
        _longName = new("Gregg", "LeNoir", "Allman");
    }


    [Benchmark]
    public bool PatternMatchingCheck() 
    => PatternMatchingCheckGeneric(_shortName)
       && PatternMatchingCheckGeneric(_longName);


    private static bool PatternMatchingCheckGeneric<T>(T subject) 
        where T : struct 
        => subject is ILongName || subject is IShortName;   
}