namespace PredicatePointerBenchmark;


public unsafe readonly struct PredicatePointer<T>(delegate*<in T, bool> predicate) where T : struct
{
    private readonly delegate*<in T, bool> _predicate = predicate;

    public bool Invoke(in T item) => _predicate(in item);
}