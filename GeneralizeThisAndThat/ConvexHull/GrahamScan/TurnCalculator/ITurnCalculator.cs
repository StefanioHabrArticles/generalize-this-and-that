namespace GeneralizeThisAndThat.ConvexHull.GrahamScan.TurnCalculator;

public interface ITurnCalculator
{
    Turn GetTurn<TRing>(Point2D<TRing> p1, Point2D<TRing> p2, Point2D<TRing> p3)
        where TRing :
        IComparable<TRing>,
        IAdditionOperators<TRing, TRing, TRing>,
        IAdditiveIdentity<TRing, TRing>,
        IUnaryNegationOperators<TRing, TRing>,
        IMultiplyOperators<TRing, TRing, TRing>,
        IMultiplicativeIdentity<TRing, TRing>;

    public static ITurnCalculator Instance =>
        new Impl.TurnCalculator();
}