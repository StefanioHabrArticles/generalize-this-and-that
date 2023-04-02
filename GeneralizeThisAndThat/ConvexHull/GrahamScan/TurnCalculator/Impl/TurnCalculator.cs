namespace GeneralizeThisAndThat.ConvexHull.GrahamScan.TurnCalculator.Impl;

public class TurnCalculator : ITurnCalculator
{
    public Turn GetTurn(Point2D p1, Point2D p2, Point2D p3)
    {
        var crossProduct =
            (p2.X - p1.X) * (p3.Y - p1.Y) -
            (p2.Y - p1.Y) * (p3.X - p1.X);
        return crossProduct switch
        {
            < 0 => Turn.ClockWise,
            > 0 => Turn.CounterClockWise,
            _ => Turn.Collinear
        };
    }
}