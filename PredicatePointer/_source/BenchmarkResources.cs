namespace PredicatePointerBenchmark;


public enum EvaluationRule
{
    NameIsNotNull,
    NameIsNotEmpty,
    NameIsNotWhiteSpace
}


public readonly struct Evaluation(string name)
{
    internal string Name { get; } = name;


    public bool NameIsNotNull() => Name is not null;
    public bool NameIsNotEmpty() => Name is not "";
    public bool NameIsNotWhiteSpace() => !string.IsNullOrWhiteSpace(Name);

    internal static unsafe PredicatePointer<Evaluation> GetPointer(EvaluationRule rule) => rule switch
    {
        EvaluationRule.NameIsNotNull => new PredicatePointer<Evaluation>(&NameIsNotNull),
        EvaluationRule.NameIsNotEmpty => new PredicatePointer<Evaluation>(&NameIsNotEmpty),
        EvaluationRule.NameIsNotWhiteSpace => new PredicatePointer<Evaluation>(&NameIsNotWhiteSpace),
        _ => throw new NotSupportedException($"The rule '{rule}' is not supported.")
    };

    internal Func<bool> GetPredicate(EvaluationRule rule) => rule switch
    {
        EvaluationRule.NameIsNotNull => this.NameIsNotNull,
        EvaluationRule.NameIsNotEmpty => this.NameIsNotEmpty,
        EvaluationRule.NameIsNotWhiteSpace => this.NameIsNotWhiteSpace,
        _ => throw new NotSupportedException($"The rule '{rule}' is not supported.")
    };
    
    //Shimps
    private static bool NameIsNotNull(in Evaluation evaluation) => evaluation.NameIsNotNull();
    private static bool NameIsNotEmpty(in Evaluation evaluation) => evaluation.NameIsNotEmpty();
    private static bool NameIsNotWhiteSpace(in Evaluation evaluation) => evaluation.NameIsNotWhiteSpace();
    //Shimps 
}

public static class EvaluationRunner
{
    public static bool RunViaPointer(in Evaluation evaluation, EvaluationRule rule)
    {
        var predicatePointer = Evaluation.GetPointer(rule);
        return predicatePointer.Invoke(in evaluation);
    }

    public static bool RunViaDelegate(in Evaluation evaluation, EvaluationRule rule)
    {
        var del = evaluation.GetPredicate(rule);
        return del.Invoke();
    }    
}