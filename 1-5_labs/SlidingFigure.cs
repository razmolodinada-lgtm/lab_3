abstract class SlidingFigure : Figure
{
    protected SlidingFigure(Points points, Color color) : base(points, color) { }

    /// <summary>
    /// Проверяет, свободны ли клетки для хода фигуры.
    /// </summary>
    /// <param name="start">Начальные координаты пути.</param>
    /// <param name="end">Конечные координаты пути.</param>
    /// <param name="board">Текущее состояние шахматной доски.</param>
    /// <returns>true, если путь свободен; иначе false.</returns>
    protected bool IsThePathFree(Points start, Points end, Board board)
    {
        int dx = Math.Sign(end.x - start.x);
        int dy = Math.Sign(end.y - start.y);
        int x = start.x + dx;
        int y = start.y + dy;

        while (x != end.x || y != end.y)
        {
            if (board.getFigureByPoinys(new Points(x, y)) != null)
                return false;
            x += dx;
            y += dy;
        }
        return true;
    }

    /// <summary>
    /// Проверяет, может ли фигура атаковать указанную клетку.
    /// Учитывает направление движения и наличие препятствий на пути.
    /// </summary>
    /// <param name="target">Координаты целевой клетки для проверки атаки.</param>
    /// <param name="board">Текущее состояние шахматной доски.</param>
    /// <returns>true, если фигура может атаковать указанную клетку; иначе false.</returns>
    public override bool CanAttack(Points target, Board board)
    {
        if (target.x == points.x && target.y == points.y) return false;
        if (!isValidDirection(target)) return false;
        return IsThePathFree(points, target, board);
    }

    /// <summary>
    /// Выполняет ход фигуры на указанную клетку.
    /// Проверяет границы доски, допустимое направление, свободен ли путь,
    /// а также возможность взятия фигуры противника.
    /// </summary>
    /// <param name="point">Координаты клетки, куда планируется ход.</param>
    /// <param name="board">Текущее состояние шахматной доски.</param>
    /// <returns>true, если ход корректен и успешно выполнен - иначе false.</returns>
    public override bool Move(Points point, Board board)
    {
        if (point.x < 0 || point.x > 7 || point.y < 0 || point.y > 7) return false;
        if (this.points.x == point.x && this.points.y == point.y) return false;
        if (!isValidDirection(point)) return false;
        if (!IsThePathFree(points, point, board)) return false;

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
    protected abstract bool isValidDirection(Points to);
}