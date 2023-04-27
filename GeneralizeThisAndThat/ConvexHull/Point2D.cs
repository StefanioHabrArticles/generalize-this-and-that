namespace GeneralizeThisAndThat.ConvexHull;

public record Point2D<TRing>(TRing X, TRing Y)
    where TRing :
    IComparable<TRing>,
    IAdditionOperators<TRing, TRing, TRing>,
    IAdditiveIdentity<TRing, TRing>,
    IUnaryNegationOperators<TRing, TRing>,
    IMultiplyOperators<TRing, TRing, TRing>,
    IMultiplicativeIdentity<TRing, TRing>
{
    public static Point2D<TRing> operator -(Point2D<TRing> p1, Point2D<TRing> p2) =>
        new(p1.X + -p2.X, p1.Y + -p2.Y);

    public static TRing operator *(Point2D<TRing> p1, Point2D<TRing> p2) =>
        p1.X * p2.X + p1.Y * p2.Y;

    public static TRing operator ^(Point2D<TRing> p1, Point2D<TRing> p2) =>
        p1.X * p2.Y + -(p1.Y * p2.X);
}
