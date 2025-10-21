using System.Linq.Expressions;
using System.Reflection;

namespace GenericCtorProviderViaExpressionAPI;


public readonly record struct PairOf<T, Y>(T First, Y Second);


public readonly struct GenericCtorProvider<T, Y>
{
    public static Func<T, Y, PairOf<T, Y>> StaticConstructor { get; }
    public Func<T, Y, PairOf<T, Y>> NonStaticConstructor => GetCtor();

    static GenericCtorProvider()
    {
        Type genericType = typeof(PairOf<T, Y>);

        ConstructorInfo ctor = genericType.GetConstructor([typeof(T), typeof(Y)])
            ?? throw new InvalidOperationException("Constructor not found.");

        var param01 = Expression.Parameter(typeof(T), "value1");
        var param02 = Expression.Parameter(typeof(Y), "value2");

        var newExpression = Expression.New(ctor, param01, param02);

        StaticConstructor = Expression.Lambda<Func<T, Y, PairOf<T, Y>>>(newExpression, param01, param02).Compile();
    }

    private static Func<T, Y, PairOf<T, Y>> GetCtor()
    {
         Type genericType = typeof(PairOf<T, Y>);

        ConstructorInfo ctor = genericType.GetConstructor([typeof(T), typeof(Y)])
            ?? throw new InvalidOperationException("Constructor not found.");

        var param01 = Expression.Parameter(typeof(T), "value1");
        var param02 = Expression.Parameter(typeof(Y), "value2");

        var newExpression = Expression.New(ctor, param01, param02);

        return Expression.Lambda<Func<T, Y, PairOf<T, Y>>>(newExpression, param01, param02).Compile();       
    } 
}