class Knight : Figure
{
    /// <summary>
    /// Инициализирует новый экземпляр фигуры "Конь".
    /// </summary>
    /// <param name="points">Начальные координаты фигуры на доске.</param>
    /// <param name="color">Цвет фигуры (белый или черный).</param>
    public Knight(Points points, Color color) : base(points, color)
    {
        charecter = color == Color.White ? '♘' : '♞';
    }

    /// <summary>
    /// Проверяет, может ли конь атаковать указанную клетку.
    /// </summary>
    /// <param name="target">Координаты целевой клетки.</param>
    /// <param name="board">Текущее состояние шахматной доски.</param>
    /// <returns>true, если конь может атаковать указанную клетку; иначе false.</returns>
    public override bool CanAttack(Points target, Board board)
    {
        int dx = Math.Abs(target.x - points.x);
        int dy = Math.Abs(target.y - points.y);
        return (dx == 1 && dy == 2) || (dx == 2 && dy == 1);
    }

    /// <summary>
    /// Выполняет ход конем на указанную клетку.
    /// </summary>
    /// <param name="point">Координаты клетки, куда необходимо сделать ход.</param>
    /// <param name="board">Текущее состояние шахматной доски.</param>
    /// <returns>true, если ход возможен и успешно выполнен; иначе false.</returns>
    public override bool Move(Points point, Board board)
    {
        if (point.x < 0 || point.x > 7 || point.y < 0 || point.y > 7) return false;

        int offsetx = Math.Abs(points.x - point.x);
        int offsety = Math.Abs(points.y - point.y);
        if (!((offsetx == 1 && offsety == 2) || (offsetx == 2 && offsety == 1))) return false;

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