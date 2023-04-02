namespace GeneralizeThisAndThat.ConvexHull;

public interface IConvexHullFinder
{
    IEnumerable<Point2D>? GetConvexHull(IList<Point2D>? points);
}