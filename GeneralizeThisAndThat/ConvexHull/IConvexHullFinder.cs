using GeneralizeThisAndThat.ConvexHull.GrahamScan.TurnCalculator;

namespace GeneralizeThisAndThat.ConvexHull;

public interface IConvexHullFinder
{
    ConvexHull<TRing>? GetConvexHull<TRing>(IList<Point2D<TRing>>? points)
        where TRing :
        IComparable<TRing>,
        IAdditionOperators<TRing, TRing, TRing>,
        IAdditiveIdentity<TRing, TRing>,
        IUnaryNegationOperators<TRing, TRing>,
        IMultiplyOperators<TRing, TRing, TRing>,
        IMultiplicativeIdentity<TRing, TRing>;

    public static IConvexHullFinder Instance =>
        new GrahamScan.GrahamScan(
            ITurnCalculator.Instance
        );
}