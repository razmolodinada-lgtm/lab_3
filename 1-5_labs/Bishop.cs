
class Bishop : SlidingFigure
{   
    /// <summary>
    /// конструктор для создания фигуры "слон"
    /// </summary>
    /// <param name="points">координата</param>
    /// <param name="color">цвет фигуры</param>
    public Bishop(Points points, Color color) : base(points, color)
    {
        charecter = color == Color.White ? '♗' : '♝';
    }

    /// <summary>
    /// метод для реализации и проверки  хода фигуры "слон"
    /// </summary>
    /// <param name="point">координаты </param>
    /// <returns>true (если фигура может ходить) или false (если фигура не может ходить)</returns>
    protected override bool isValidDirection(Points point)
    {
        int offsetx = Math.Abs(point.x - points.x);
        int offsety = Math.Abs(point.y - points.y);
        return offsetx == offsety && offsetx > 0;
    }
}