namespace GeneralizeThisAndThat.ConvexHull.GrahamScan.TurnCalculator.Impl;

public class TurnCalculator : ITurnCalculator
{
    public Turn GetTurn<TRing>(Point2D<TRing> p1, Point2D<TRing> p2, Point2D<TRing> p3)
        where TRing :
        IComparable<TRing>,
        IAdditionOperators<TRing, TRing, TRing>,
        IAdditiveIdentity<TRing, TRing>,
        IUnaryNegationOperators<TRing, TRing>,
        IMultiplyOperators<TRing, TRing, TRing>,
        IMultiplicativeIdentity<TRing, TRing>
    {
        var crossProduct =
            (p2.X + -p1.X) * (p3.Y + -p1.Y) +
            -((p2.Y + -p1.Y) * (p3.X + -p1.X));

        var comparison = crossProduct.CompareTo(TRing.AdditiveIdentity);

        return comparison switch
        {
            < 0 => Turn.ClockWise,
            > 0 => Turn.CounterClockWise,
            _ => Turn.Collinear
        };
    }
}