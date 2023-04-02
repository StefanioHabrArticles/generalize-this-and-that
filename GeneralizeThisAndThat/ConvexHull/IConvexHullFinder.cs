using GeneralizeThisAndThat.ConvexHull.GrahamScan.TurnCalculator;

namespace GeneralizeThisAndThat.ConvexHull;

public interface IConvexHullFinder
{
    IEnumerable<Point2D>? GetConvexHull(IList<Point2D>? points);

    public static IConvexHullFinder Instance =>
        new GrahamScan.GrahamScan(
            ITurnCalculator.Instance
        );
}