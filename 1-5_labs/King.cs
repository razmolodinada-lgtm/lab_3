class King : Figure
{
    /// <summary>
    /// Инициализирует новый экземпляр фигуры "Король".
    /// </summary>
    /// <param name="points">Начальные координаты фигуры на доске.</param>
    /// <param name="color">Цвет фигуры (белый или черный).</param>
    public King(Points points, Color color) : base(points, color)
    {
        charecter = color == Color.White ? '♔' : '♚';
    }

    /// <summary>
    /// Проверяет, может ли король атаковать указанную клетку.
    /// </summary>
    /// <param name="target">Координаты целевой клетки.</param>
    /// <param name="board">Текущее состояние шахматной доски.</param>
    /// <returns>true, если король может атаковать указанную клетку; иначе false.</returns>
    public override bool CanAttack(Points target, Board board)
    {
        int dx = Math.Abs(target.x - points.x);
        int dy = Math.Abs(target.y - points.y);
        return dx <= 1 && dy <= 1 && (dx != 0 || dy != 0);
    }

    /// <summary>
    /// Выполняет ход королем на указанную клетку.
    /// </summary>
    /// <param name="point">Координаты клетки, куда необходимо сделать ход.</param>
    /// <param name="board">Текущее состояние шахматной доски.</param>
    /// <returns>true, если ход возможен и успешно выполнен - иначе false.</returns>
    public override bool Move(Points point, Board board)
    {
        if (point.x < 0 || point.x > 7 || point.y < 0 || point.y > 7) return false;

        int offsetx = Math.Abs(point.x - points.x);
        int offsety = Math.Abs(point.y - points.y);
        if (offsetx > 1 || offsety > 1 || (offsetx == 0 && offsety == 0)) return false;

        Figure figure = board.getFigureByPoinys(point);
        if (figure != null)
        {
            if (figure.getColor() == color) return false;
            if (figure is King) return false;
            board.removeFigure(figure);
        }
        setPoints(new Points(point.x, point.y));
        return true;
    }
}