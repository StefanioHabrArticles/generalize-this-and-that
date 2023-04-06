namespace GeneralizeThisAndThat.Algebra;

public interface IRing<T>
    where T : IRing<T>
{
    static abstract T operator +(T x, T y);
    
    static abstract T Zero { get; }
    
    static abstract T operator -(T x);

    static abstract T operator *(T x, T y);
    
    static abstract T One { get; }
}