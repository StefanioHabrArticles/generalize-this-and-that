namespace GeneralizeThisAndThat.ConvexHull;

public record Point2D(double X, double Y)
{
    public static Point2D operator -(Point2D p1, Point2D p2) =>
        new(p1.X - p2.X, p1.Y - p2.Y);

    public static double operator *(Point2D p1, Point2D p2) =>
        p1.X * p2.X + p1.Y * p1.Y;

    public static double operator ^(Point2D p1, Point2D p2) =>
        p1.X * p2.Y - p1.Y * p2.X;
}