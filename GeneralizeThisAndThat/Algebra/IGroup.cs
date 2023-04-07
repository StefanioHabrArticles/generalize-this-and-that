using System.Numerics;

namespace GeneralizeThisAndThat.Algebra;

public interface IGroup<T> :
    IAdditionOperators<T, T, T>,
    IAdditiveIdentity<T, T>,
    IUnaryNegationOperators<T, T>
    where T :
    IAdditionOperators<T, T, T>,
    IAdditiveIdentity<T, T>,
    IUnaryNegationOperators<T, T>
{
}