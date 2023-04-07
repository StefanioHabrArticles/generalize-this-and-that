using GeneralizeThisAndThat.ConvexHull.GrahamScan.TurnCalculator;

namespace GeneralizeThisAndThat.ConvexHull.GrahamScan;

public class GrahamScan : IConvexHullFinder
{
    private readonly ITurnCalculator _calculator;

    public GrahamScan(ITurnCalculator calculator) =>
        _calculator = calculator;

    public IEnumerable<Point2D<TRing>>? GetConvexHull<TRing>(IList<Point2D<TRing>>? points)
        where TRing :
        IComparable<TRing>,
        IAdditionOperators<TRing, TRing, TRing>,
        IAdditiveIdentity<TRing, TRing>,
        IUnaryNegationOperators<TRing, TRing>,
        IMultiplyOperators<TRing, TRing, TRing>,
        IMultiplicativeIdentity<TRing, TRing>
    {
        if (points is null or { Count: < 3 })
            return null;

        var p0 = points.OrderBy(p => p.Y).ThenBy(p => p.Y).First();
        points = points.OrderBy(p => p, new PolarOrderComparer<TRing>(p0)).ToList();

        var hull = new Stack<Point2D<TRing>>();
        hull.Push(points[0]);
        hull.Push(points[1]);
        hull.Push(points[2]);

        for (var i = 3; i < points.Count; i++)
        {
            while (_calculator.GetTurn(hull.NextToTop(), hull.Peek(), points[i]) != Turn.CounterClockWise)
                hull.Pop();

            hull.Push(points[i]);
        }

        return hull;
    }
}