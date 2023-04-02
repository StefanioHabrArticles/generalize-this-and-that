namespace GeneralizeThisAndThat.ConvexHull.GrahamScan;

public class PolarOrderComparer : IComparer<Point2D>
{
    private readonly Point2D _pivot;

    public PolarOrderComparer(Point2D pivot) =>
        _pivot = pivot;

    public int Compare(Point2D? x, Point2D? y)
    {
        ArgumentNullException.ThrowIfNull(x);
        ArgumentNullException.ThrowIfNull(y);

        var p1 = x - _pivot;
        var p2 = y - _pivot;

        var cross = p1 ^ p2;
        return cross == 0
            ? (p1 * p1).CompareTo(p2 * p2)
            : 0.CompareTo(cross);
    }
}