using GeneralizeThisAndThat.ConvexHull.GrahamScan.TurnCalculator;

namespace GeneralizeThisAndThat.ConvexHull.GrahamScan;

public class GrahamScan : IConvexHullFinder
{
    private readonly ITurnCalculator _calculator;

    public GrahamScan(ITurnCalculator calculator) =>
        _calculator = calculator;

    public IEnumerable<Point2D>? GetConvexHull(IList<Point2D>? points)
    {
        if (points is null or { Count: < 3 })
            return null;

        var p0 = points.OrderBy(p => p.Y).ThenBy(p => p.Y).First();
        points = points.OrderBy(p => p, new PolarOrderComparer(p0)).ToList();

        var hull = new Stack<Point2D>();
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