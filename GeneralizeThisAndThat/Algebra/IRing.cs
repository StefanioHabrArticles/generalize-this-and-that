namespace GeneralizeThisAndThat.Algebra;

public interface IRing<T> :
    IGroup<T>,
    IMultiplyOperators<T, T, T>,
    IMultiplicativeIdentity<T, T>
    where T :
    IAdditionOperators<T, T, T>,
    IAdditiveIdentity<T, T>,
    IUnaryNegationOperators<T, T>,
    IMultiplyOperators<T, T, T>,
    IMultiplicativeIdentity<T, T>
{
}