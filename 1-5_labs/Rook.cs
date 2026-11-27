class Rook : SlidingFigure
{
    /// <summary>
    /// Инициализирует новый экземпляр фигуры "Ладья".
    /// </summary>
    /// <param name="points">Начальные координаты фигуры на доске.</param>
    /// <param name="color">Цвет фигуры (белый или черный).</param>
    public Rook(Points points, Color color) : base(points, color)
    {
        charecter = color == Color.White ? '♖' : '♜';
    }
    /// <summary>
    /// Проверяет, соответствует ли направление хода правилам перемещения ладьи 
    /// (движение допускается только по горизонтали или только по вертикали).
    /// </summary>
    /// <param name="point">Целевые координаты клетки, куда планируется ход.</param>
    /// <returns>true, если направление хода допустимо для ладьи; иначе false.</returns>
    protected override bool isValidDirection(Points point)
    {
        return (point.x == points.x) != (point.y == points.y);
    }
}