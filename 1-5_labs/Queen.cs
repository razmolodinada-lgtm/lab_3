class Queen : SlidingFigure
{
    /// <summary>
    /// Инициализирует новый экземпляр фигуры "Королева(Ферзь)".
    /// </summary>
    /// <param name="points">Начальные координаты фигуры на доске.</param>
    /// <param name="color">Цвет фигуры (белый или черный).</param>
    public Queen(Points points, Color color) : base(points, color)
    {
        charecter = color == Color.White ? '♕' : '♛';
    }
    /// <summary>
    /// Проверяет, соответствует ли направление хода правилам перемещения ферзя (по горизонтали, вертикали или диагонали).
    /// </summary>
    /// <param name="point">Целевые координаты клетки, куда планируется ход.</param>
    /// <returns>true, если направление хода допустимо для ферзя - иначе false.</returns>
    protected override bool isValidDirection(Points point)
    {
        int offsetx = Math.Abs(point.x - points.x);
        int offsety = Math.Abs(point.y - points.y);
        return offsetx == 0 || offsety == 0 || offsetx == offsety;
    }
}