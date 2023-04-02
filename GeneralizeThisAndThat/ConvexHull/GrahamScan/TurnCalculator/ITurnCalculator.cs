namespace GeneralizeThisAndThat.ConvexHull.GrahamScan.TurnCalculator;

public interface ITurnCalculator
{
    Turn GetTurn(Point2D p1, Point2D p2, Point2D p3);
}