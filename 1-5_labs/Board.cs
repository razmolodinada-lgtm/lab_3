using System;
using System.Collections.Generic;
using System.Drawing;

/// <summary>
/// Класс, представляющий сохраненное состояние одной фигуры на доске.
/// </summary>
public class FigureState
{
    public Type Type { get; set; }
    public Color Color { get; set; }
    public Points Point { get; set; }

    /// <summary>
    /// Конструктор для создания состояния фигуры.
    /// </summary>
    /// <param name="type">Тип фигуры (Pawn, Rook, Bishop, Knight, Queen, King).</param>
    /// <param name="color">Цвет фигуры (White или Black).</param>
    /// <param name="point">Координата фигуры на доске.</param>
    public FigureState(Type type, Color color, Points point)
    {
        Type = type;
        Color = color;
        Point = point;
    }
}


class Board
{
    private List<Figure> figuers = new List<Figure>();

    /// <summary>
    /// Автоматический выбор фигуры для превращения пешки.
    /// </summary>
    /// <returns>Символ выбранной фигуры или null, если автовыбор отключен.</returns>
    public char? autoPromotion()
    {
        return null;
    }
    /// <summary>
    /// Читает ход с консоли, пока не получит корректный.
    /// Возвращает null, если игрок решил выйти в меню ('q' или пустой ввод).
    /// </summary>
    public PairofPoints ReadMove(Color currentColor)
    {
        while (true)
        {
            Console.Write("Введите ход (например e2-e4) или 'q' для выхода в меню: ");
            string input = Console.ReadLine();

            // Выход в меню — в любой момент, в т.ч. при ошибке ввода
            if (string.IsNullOrWhiteSpace(input) ||
                input.Trim().Equals("q", StringComparison.OrdinalIgnoreCase))
                return null;

            PairofPoints move = Parser.parse(input);
            if (move != null && this.step(move, currentColor))   // ← this.step, т.к. мы внутри Board
                return move;

            Console.WriteLine("Ошибка ввода, попробуйте ещё раз!");
        }
    }
    /// <summary>
    /// Добавляет фигуру на доску.
    /// </summary>
    /// <param name="figure">Экземпляр добавляемой фигуры.</param>
    public void addFigure(Figure figure)
    {
        figuers.Add(figure);
    }

    /// <summary>
    /// Выводит текущее состояние шахматной доски в консоль.
    /// </summary>
    public void printBoard()
    {
        Console.Write("  ");
        char start = 'A';
        for (int i = 0; i < 8; i++)
        {
            Console.Write((char)(start + i) + " ");
        }
        Console.WriteLine();
        int cnt = 1;
        for (int y = 0; y < 8; y++)
        {
            Console.Write(cnt);
            for (int x = 0; x < 8; x++)
            {
                Figure figure = getFigureByPoinys(new Points(x, y));
                if (figure != null)
                {
                    Console.Write(figure.getCharacter() + " ");
                }
                else
                {
                    Console.Write(". ");
                }
            }

            Console.Write(cnt);
            cnt++;
            Console.WriteLine();
        }
        Console.Write("  ");
        start = 'A';
        for (int i = 0; i < 8; i++)
        {
            Console.Write((char)(start + i) + " ");
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Находит фигуру по заданным координатам.
    /// </summary>
    /// <param name="point">Координаты клетки для поиска</param>
    /// <returns>Экземпляр фигуры, если он есть на клетке, иначе null</returns>
    public Figure getFigureByPoinys(Points point)
    {
        foreach (Figure figure in figuers)
        {
            if (figure.getPoints().x == point.x && figure.getPoints().y == point.y)
            {
                return figure;
            }
        }
        return null;
    }

    /// <summary>
    /// Переворачивает доску (меняет координаты всех фигур по вертикали).
    /// </summary>
    public void rotate()
    {
        foreach (Figure figure in figuers)
        {
            Points points = figure.getPoints();
            points.y = 8 - points.y - 1;
            figure.setPoints(points);
        }
    }

    /// <summary>
    /// Удаляет указанную фигуру с доски.
    /// </summary>
    /// <param name="figure">Экземпляр удаляемой фигуры.</param>
    public void removeFigure(Figure figure)
    {
        figuers.Remove(figure);
    }

    /// <summary>
    /// Выполняет ход фигуры, проверяя его легальность и возможность поедания.
    /// </summary>
    /// <param name="pairofPoints">Пара координат: откуда и куда ходит фигура.</param>
    /// <param name="curentColor">Цвет игрока, который делает ход.</param>
    /// <returns>true, если ход успешно выполнен; false, если ход невозможен или оставляет короля под шахом.</returns>
    public bool step(PairofPoints pairofPoints, Color curentColor)
    {
        Figure figure = getFigureByPoinys(pairofPoints.pointOne);
        if (figure == null) return false;
        if (figure.getColor() != curentColor) return false;

        Figure target = getFigureByPoinys(pairofPoints.pointTwo);
        if (target is King) return false;

        var snapshot = Snapshot();

        if (!figure.Move(pairofPoints.pointTwo, this))
        {
            return false;
        }

        if (IsKingInCheck(curentColor, curentColor))
        {
            Restore(snapshot);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Превращает пешку в выбранную фигуру (ферзь, ладья, слон, конь).
    /// </summary>
    /// <param name="pawn">Пешка, достигшая последней горизонтали.</param>
    /// <param name="point">Координата, где происходит превращение.</param>
    /// <param name="choice">Символ, обозначающий выбранную фигуру (R, B, N, Q).</param>
    public void transformation(Pawn pawn, Points point, char choice)
    {
        Color color = pawn.getColor();
        removeFigure(pawn);
        Figure newFigure;
        switch (char.ToUpper(choice))
        {
            case 'R': newFigure = new Rook(point, color); break;
            case 'B': newFigure = new Bishop(point, color); break;
            case 'N': newFigure = new Knight(point, color); break;
            default: newFigure = new Queen(point, color); break;
        }
        addFigure(newFigure);
    }

    /// <summary>
    /// Проверяет, находится ли указанная клетка под атакой фигур определенного цвета.
    /// </summary>
    /// <param name="target">Координаты проверяемой клетки.</param>
    /// <param name="byColor">Цвет атакующих фигур.</param>
    /// <param name="bottomColor">Цвет игрока, находящегося внизу доски (для определения направления пешек).</param>
    /// <returns>true, если клетка под атакой; иначе false.</returns>
    public bool IsSquareAttacked(Points target, Color byColor, Color bottomColor)
    {
        int pawnDy = (byColor == bottomColor) ? -1 : 1;

        foreach (Figure figure in figuers)
        {
            if (figure.getColor() != byColor) continue;

            if (figure is Pawn)
            {
                Points p = figure.getPoints();
                if (target.y == p.y + pawnDy && Math.Abs(target.x - p.x) == 1)
                    return true;
            }
            else
            {
                if (figure.CanAttack(target, this))
                    return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Проверяет, находится ли король указанного цвета под шахом.
    /// </summary>
    /// <param name="kingColor">Цвет проверяемого короля.</param>
    /// <param name="bottomColor">Цвет игрока, находящегося внизу доски.</param>
    /// <returns>true, если король под шахом; иначе false.</returns>
    public bool IsKingInCheck(Color kingColor, Color bottomColor)
    {
        Points kingPoint = null;
        foreach (Figure f in figuers)
        {
            if (f is King && f.getColor() == kingColor)
            {
                kingPoint = f.getPoints();
                break;
            }
        }
        if (kingPoint == null) return false;

        Color enemy = (kingColor == Color.White) ? Color.Black : Color.White;
        return IsSquareAttacked(kingPoint, enemy, bottomColor);
    }

    /// <summary>
    /// Создает снимок текущего состояния доски для возможного отката (undo).
    /// </summary>
    /// <returns>Список состояний всех фигур на доске.</returns>
    public List<FigureState> Snapshot()
    {
        var list = new List<FigureState>();
        foreach (var f in figuers)
        {
            Points pt = new Points(f.getPoints().x, f.getPoints().y);
            list.Add(new FigureState(f.GetType(), f.getColor(), pt));
        }
        return list;
    }

    /// <summary>
    /// Восстанавливает состояние доски из ранее сохраненного снимка.
    /// </summary>
    /// <param name="snap">Снимок состояния доски (список фигур с их координатами).</param>
    public void Restore(List<FigureState> snap)
    {
        figuers.Clear();
        foreach (var s in snap)
        {
            Figure f = CreateFigure(s.Type, s.Point, s.Color);
            if (f != null)
            {
                figuers.Add(f);
            }
        }
    }

    /// <summary>
    /// Создает экземпляр фигуры на основе типа, координаты и цвета.
    /// </summary>
    /// <param name="type">Тип фигуры.</param>
    /// <param name="pt">Координата фигуры.</param>
    /// <param name="color">Цвет фигуры.</param>
    /// <returns>Экземпляр фигуры или null, если тип неизвестен.</returns>
    private Figure CreateFigure(Type type, Points pt, Color color)
    {
        if (type == typeof(Pawn)) return new Pawn(pt, color);
        if (type == typeof(Rook)) return new Rook(pt, color);
        if (type == typeof(Bishop)) return new Bishop(pt, color);
        if (type == typeof(Knight)) return new Knight(pt, color);
        if (type == typeof(Queen)) return new Queen(pt, color);
        if (type == typeof(King)) return new King(pt, color);
        return null;
    }

    /// <summary>
    /// Проверяет, есть ли у указанного игрока хотя бы один легальный ход.
    /// </summary>
    /// <param name="color">Цвет проверяемого игрока.</param>
    /// <param name="bottomColor">Цвет игрока, находящегося внизу доски.</param>
    /// <returns>true, если есть хотя бы один легальный ход; иначе false.</returns>
    public bool HasAnyLegalMove(Color color, Color bottomColor)
    {
        var snapshot = Snapshot();
        char? savedPromotion = autoPromotion();
        savedPromotion = 'Q';
        try
        {
            int count = figuers.Count;
            for (int i = 0; i < count; i++)
            {
                Restore(snapshot);
                Figure figure = figuers[i];
                if (figure.getColor() != color) continue;

                for (int x = 0; x < 8; x++)
                    for (int y = 0; y < 8; y++)
                    {
                        Restore(snapshot);
                        figure = figuers[i];

                        var target = new Points(x, y);
                        var targetFigure = getFigureByPoinys(target);
                        if (targetFigure is King) continue;

                        if (figure.Move(target, this))
                        {
                            if (!IsKingInCheck(color, bottomColor))
                            {
                                Restore(snapshot);
                                return true;
                            }
                        }
                    }
            }
            return false;
        }
        finally
        {
            savedPromotion = autoPromotion();
            Restore(snapshot);
        }
    }

    /// <summary>
    /// Проверяет, поставлен ли мат указанному цвету.
    /// </summary>
    /// <param name="color">Цвет проверяемого игрока.</param>
    /// <param name="bottomColor">Цвет игрока, находящегося внизу доски.</param>
    /// <returns>true, если это мат; иначе false.</returns>
    public bool IsCheckmate(Color color, Color bottomColor)
    {
        return IsKingInCheck(color, bottomColor) && !HasAnyLegalMove(color, bottomColor);
    }

    /// <summary>
    /// Проверяет, попал ли указанный цвет в пат (нет ходов, но нет и шаха).
    /// </summary>
    /// <param name="color">Цвет проверяемого игрока.</param>
    /// <param name="bottomColor">Цвет игрока, находящегося внизу доски.</param>
    /// <returns>true, если это пат; иначе false.</returns>
    public bool IsStalemate(Color color, Color bottomColor)
    {
        return !IsKingInCheck(color, bottomColor) && !HasAnyLegalMove(color, bottomColor);
    }
}