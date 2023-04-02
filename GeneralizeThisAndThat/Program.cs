using GeneralizeThisAndThat.ConvexHull;
using GeneralizeThisAndThat.ConvexHull.GrahamScan;
using GeneralizeThisAndThat.ConvexHull.GrahamScan.TurnCalculator;
using GeneralizeThisAndThat.ConvexHull.GrahamScan.TurnCalculator.Impl;

ITurnCalculator calc = new TurnCalculator();
IConvexHullFinder finder = new GrahamScan(calc);

finder.GetConvexHull(new List<Point2D>
    {
        new(0, 3),
        new(1, 1),
        new(2, 2),
        new(4, 4),
        new(0, 0),
        new(1, 2),
        new(3, 1),
        new(3, 3)
    }
)?.ToList().ForEach(Console.WriteLine);