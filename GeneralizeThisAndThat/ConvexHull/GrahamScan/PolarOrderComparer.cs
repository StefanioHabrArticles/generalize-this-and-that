namespace GeneralizeThisAndThat.ConvexHull.GrahamScan;

public class PolarOrderComparer<TRing> : IComparer<Point2D<TRing>>
    where TRing :
    IComparable<TRing>,
    IAdditionOperators<TRing, TRing, TRing>,
    IAdditiveIdentity<TRing, TRing>,
    IUnaryNegationOperators<TRing, TRing>,
    IMultiplyOperators<TRing, TRing, TRing>,
    IMultiplicativeIdentity<TRing, TRing>
{
    private readonly Point2D<TRing> _pivot;

    public PolarOrderComparer(Point2D<TRing> pivot) =>
        _pivot = pivot;

    public int Compare(Point2D<TRing>? x, Point2D<TRing>? y)
    {
        ArgumentNullException.ThrowIfNull(x);
        ArgumentNullException.ThrowIfNull(y);

        var p1 = x - _pivot;
        var p2 = y - _pivot;

        var cross = p1 ^ p2;
        return cross.Equals(TRing.AdditiveIdentity)
            ? (p1 * p1).CompareTo(p2 * p2)
            : TRing.AdditiveIdentity.CompareTo(cross);
    }
}