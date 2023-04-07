namespace GeneralizeThisAndThat.Algebra;

public class Endomorphism<TGroup> : IRing<Endomorphism<TGroup>>
    where TGroup :
    IAdditionOperators<TGroup, TGroup, TGroup>,
    IAdditiveIdentity<TGroup, TGroup>,
    IUnaryNegationOperators<TGroup, TGroup>
{
    private readonly Func<TGroup, TGroup> _func;

    private Endomorphism(Func<TGroup, TGroup> func) =>
        _func = func;

    public TGroup At(TGroup x) =>
        _func(x);

    public static implicit operator Endomorphism<TGroup>(Func<TGroup, TGroup> func) =>
        new(func);

    public static Endomorphism<TGroup> operator +(Endomorphism<TGroup> left, Endomorphism<TGroup> right) =>
        (Func<TGroup, TGroup>)(x => left.At(x) + right.At(x));

    public static Endomorphism<TGroup> AdditiveIdentity =>
        (Func<TGroup, TGroup>)(_ => TGroup.AdditiveIdentity);

    public static Endomorphism<TGroup> operator -(Endomorphism<TGroup> value) =>
        (Func<TGroup, TGroup>)(x => -value.At(x));

    public static Endomorphism<TGroup> operator *(Endomorphism<TGroup> left, Endomorphism<TGroup> right) =>
        (Func<TGroup, TGroup>)(x => left.At(right.At(x)));

    public static Endomorphism<TGroup> MultiplicativeIdentity =>
        (Func<TGroup, TGroup>)(x => x);
}