using BenchmarkDotNet.Attributes;


namespace PredicatePointerBenchmark;


[MemoryDiagnoser]
public class Benchmarks
{
    private Evaluation _eval;

    [GlobalSetup]
    public void Setup() => _eval = new Evaluation("Test");


    [Benchmark(Baseline = true)]
    public void RunSimply() => RunSimply(in _eval);

    [Benchmark]
    public void RunViaPointer() => RunViaPointer(in _eval);

    [Benchmark]
    public void RunViaDelegate() => RunViaDelegate(in _eval);


    private static void RunSimply(in Evaluation evaluation)
    {
        evaluation.NameIsNotNull();
        evaluation.NameIsNotEmpty();
        evaluation.NameIsNotWhiteSpace();
    }

    private static void RunViaDelegate(in Evaluation evaluation)
    {
        EvaluationRunner.RunViaDelegate(in evaluation, EvaluationRule.NameIsNotNull);
        EvaluationRunner.RunViaDelegate(in evaluation, EvaluationRule.NameIsNotEmpty);
        EvaluationRunner.RunViaDelegate(in evaluation, EvaluationRule.NameIsNotWhiteSpace);
    }

    private static void RunViaPointer(in Evaluation evaluation)
    {
        EvaluationRunner.RunViaPointer(in evaluation, EvaluationRule.NameIsNotNull);
        EvaluationRunner.RunViaPointer(in evaluation, EvaluationRule.NameIsNotEmpty);
        EvaluationRunner.RunViaPointer(in evaluation, EvaluationRule.NameIsNotWhiteSpace);
    }
}