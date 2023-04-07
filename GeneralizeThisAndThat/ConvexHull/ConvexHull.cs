using System.Collections;
using GeneralizeThisAndThat.ConvexHull.GrahamScan.TurnCalculator;

namespace GeneralizeThisAndThat.ConvexHull;

public class ConvexHull<TRing> : IEnumerable<Point2D<TRing>>
    where TRing :
    IComparable<TRing>,
    IAdditionOperators<TRing, TRing, TRing>,
    IAdditiveIdentity<TRing, TRing>,
    IUnaryNegationOperators<TRing, TRing>,
    IMultiplyOperators<TRing, TRing, TRing>,
    IMultiplicativeIdentity<TRing, TRing>
{
    private readonly List<Point2D<TRing>> _hull;
    private readonly ITurnCalculator _calculator;

    public ConvexHull(IEnumerable<Point2D<TRing>> hull, ITurnCalculator calculator)
    {
        _hull = hull.ToList();
        _calculator = calculator;
    }

    public bool Contains(Point2D<TRing> point) =>
        Enumerable.Range(0, _hull.Count)
            .DistinctBy(i => _calculator.GetTurn(point, _hull[i], _hull[(i + 1) % _hull.Count]))
            .Count() == 1;

    public IEnumerator<Point2D<TRing>> GetEnumerator() =>
        _hull.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        GetEnumerator();
}