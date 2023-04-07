using GeneralizeThisAndThat.ConvexHull;

IConvexHullFinder.Instance.GetConvexHull(new List<Point2D<int>>
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