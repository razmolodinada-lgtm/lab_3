class Pawn : Figure
{
    /// <summary>
    /// Инициализирует новый экземпляр фигуры "Пешка".
    /// </summary>
    /// <param name="points">Начальные координаты фигуры на доске.</param>
    /// <param name="color">Цвет фигуры (белый или черный).</param>
    public Pawn(Points points, Color color) : base(points, color)
    {
        charecter = color == Color.White ? '♙' : '♟';
    }
    /// <summary>
    /// Проверяет, может ли пешка атаковать указанную клетку.
    /// </summary>
    /// <param name="target">Координаты целевой клетки.</param>
    /// <param name="board">Текущее состояние шахматной доски.</param>
    /// <returns>true, если пешка может атаковать указанную клетку; иначе false.</returns>
    public override bool CanAttack(Points target, Board board)
    {
        return target.y == points.y - 1 && Math.Abs(target.x - points.x) == 1;
    }
    /// <summary>
    /// Выполняет ход пешкой на указанную клетку.
    /// </summary>
    /// <param name="point">Координаты клетки, куда необходимо сделать ход.</param>
    /// <param name="board">Текущее состояние шахматной доски.</param>
    /// <returns>true, если ход возможен и успешно выполнен - иначе false.</returns>
    public override bool Move(Points point, Board board)
    {
        if (point.x < 0 || point.x > 7 || point.y < 0 || point.y > 7) return false;

        int startX = this.points.x;
        int startY = this.points.y;
        int endX = point.x;
        int endY = point.y;


        if (startY <= endY || Math.Abs(startX - endX) > 1) return false;

        Figure figure = board.getFigureByPoinys(point);


        if (startX == endX)
        {
            if (figure != null) return false;

            int dy = startY - endY;


            if (dy == 1)
            {
                return MoveAndTransformation(endX, endY, board);
            }


            if (dy == 2 && startY == 6)
            {
                if (board.getFigureByPoinys(new Points(endX, endY + 1)) != null) return false;
                return MoveAndTransformation(endX, endY, board);
            }

            return false;
        }
        else
        {

            if (startY - endY != 1) return false;
            if (figure == null) return false;
            if (figure.getColor() == color) return false;
            if (figure is King) return false;

            board.removeFigure(figure);
            return MoveAndTransformation(endX, endY, board);
        }
    }
    /// <summary>
    /// Перемещает фигуру на указанные координаты. Если фигура достигает последней горизонтали (endY == 0), 
    /// выполняется превращение фигуры с возможностью выбора нового типа фигуры.
    /// </summary>
    /// <param name="endX">Конечная координата по оси X.</param>
    /// <param name="endY">Конечная координата по оси Y.</param>
    /// <param name="board">Текущее состояние шахматной доски.</param>
    /// <returns>true, если ход и возможное превращение выполнены успешно.False,если ход не возможен</returns>
    private bool MoveAndTransformation(int endX, int endY, Board board)
    {

        if (endY == 0)
        {
            char choice = board.autoPromotion() ?? AskPromotionChoice();
            board.transformation(this, new Points(endX, endY), choice);
            return true;
        }

        setPoints(new Points(endX, endY));
        return true;
    }
    /// <summary>
    /// Метод ,который запрашивает у пользователя выбор фигуры для превращения пешки после достижения ею последней горизонтали.
    /// </summary>
    /// <returns>Символ, обозначающий выбранную фигуру для превращения (Q, R, B или N).</returns>
    private char AskPromotionChoice()
    {
        Console.Write("Превращение (Q - ферзь, R - ладья, B - слон, N - конь): ");
        while (true)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && input.Length == 1)
            {
                char c = char.ToUpper(input[0]);
                if (c == 'Q' || c == 'R' || c == 'B' || c == 'N')
                    return c;
            }
            Console.Write("Введите Q, R, B или N: ");
        }
    }
}