abstract class Figure
{
    protected Points points;
    protected char charecter;
    protected Color color;

    /// <summary>
    /// Перемещает фигуру в указанную позицию.
    /// </summary>
    /// <param name="points">Целевая позиция, в которую должна быть перемещена фигура.</param>
    /// <param name="board">Текущее состояние игровой доски.</param>
    /// <returns>"true" если ход был успешно выполнен; иначе "false"/> </returns>
    abstract public bool Move(Points points, Board board);

    /// <summary>
    /// Проверяет, может ли фигура атаковать указанную позицию.
    /// </summary>
    /// <param name="target">Позиция, которую необходимо проверить на возможность атаки.</param>
    /// <param name="board">Текущее состояние игровой доски.</param>
    /// <returns>true если фигура может атаковать указанную позицию иначе false"</returns>
    public virtual bool CanAttack(Points target, Board board) { return false; }

    /// <summary>
    /// Инициализирует новый экземпляр фигуры.
    /// </summary>
    /// <param name="points">Начальная позиция фигуры на доске.</param>
    /// <param name="color">Цвет фигуры.</param>
    public Figure(Points points, Color color)
    {
        this.points = points;
        this.color = color;
    }

    /// <summary>
    /// Возвращает символьное обозначение фигуры.
    /// </summary>
    /// <returns>Символ, отображающий фигуру на доске.</returns>
    public char getCharacter() { return charecter; }

    /// <summary>
    /// Возвращает текущую позицию фигуры.
    /// </summary>
    /// <returns>Объект с текущими координатами фигуры.</returns>
    public Points getPoints() { return points; }

    /// <summary>
    /// Устанавливает новую позицию фигуры.
    /// </summary>
    /// <param name="points">Новая позиция фигуры на доске.</param>
    public void setPoints(Points points) { this.points = points; }

    /// <summary>
    /// Возвращает цвет фигуры.
    /// </summary>
    /// <returns>Цвет фигуры.</returns>
    public Color getColor() { return color; }
}