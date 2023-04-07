using GeneralizeThisAndThat.Algebra;
using GeneralizeThisAndThat.ConvexHull;

Func<int, int> squareFunc = i => i * i;
Func<int, int> doubleIntFunc = i => i * 2;
Endomorphism<int> doubleInt = doubleIntFunc;
Console.WriteLine((doubleInt * doubleInt + squareFunc).At(3));

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

var embeddings = new List<Embedding>
{
    new("cat", new(0.2, 0.8)),
    new("dog", new(0.4, 0.6)),
    new("bird", new(0.8, 0.2)),
    new("fish", new(0.9, 0.1)),
    new("rabbit", new(0.7, 0.3)),
    new("lion", new(0.1, 0.9)),
    new("tiger", new(0.3, 0.7)),
    new("elephant", new(0.05, 0.95)),
    new("zebra", new(0.1, 0.8)),
    new("monkey", new(0.5, 0.5))
};

var convexHull = IConvexHullFinder.Instance.GetConvexHull(
    embeddings.Select(x => x.Vector).ToList()
)!;
var carrot = new Embedding("carrot", new(1.1, 1.24));
var pig = new Embedding("pig", new(0.12, 0.83));
Console.WriteLine($"{carrot.Word} - {convexHull.Contains(carrot.Vector)}");
Console.WriteLine($"{pig.Word} - {convexHull.Contains(pig.Vector)}");

public record Embedding(
    string Word,
    Point2D<double> Vector
);