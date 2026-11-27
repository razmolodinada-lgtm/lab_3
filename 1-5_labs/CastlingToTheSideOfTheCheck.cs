using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Runtime.Versioning;
public static class CastlingToTheSideOfTheCheck
{
    /// <summary>
    /// метод для вызова игры  
    /// </summary>
    public static void castlingToTheSideOfTheCheck() 
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Clear();
        Console.WriteLine("Партия началась...");

        Board board = new Board();

        for (int i = 0; i< 8; i++)
        {
            board.addFigure(new Pawn(new Points(i, 6), Color.Black));
        }
        board.addFigure(new Knight(new Points(1, 7), Color.Black));
        board.addFigure(new Knight(new Points(6, 7), Color.Black));
        board.addFigure(new Bishop(new Points(2, 7), Color.Black));
        board.addFigure(new Queen(new Points(3, 7), Color.Black));
        board.addFigure(new King(new Points(4, 7), Color.Black));
        board.addFigure(new Bishop(new Points(5, 7), Color.Black));
        board.addFigure(new Rook(new Points(0, 7), Color.Black));
        board.addFigure(new Rook(new Points(7, 7), Color.Black));
        board.rotate();

        for (int i = 0; i < 8; i++)
        {
            board.addFigure(new Pawn(new Points(i, 6), Color.White));
        }

        board.addFigure(new Knight(new Points(1, 7), Color.White));
        board.addFigure(new Knight(new Points(6, 7), Color.White));
        board.addFigure(new Bishop(new Points(2, 7), Color.White));
        board.addFigure(new Queen(new Points(3, 7), Color.White));
        board.addFigure(new King(new Points(4, 7), Color.White));
        board.addFigure(new Bishop(new Points(5, 7), Color.White));
        board.addFigure(new Rook(new Points(0, 7), Color.White));
        board.addFigure(new Rook(new Points(7, 7), Color.White));

        Color currentColor = Color.White;

        while (true)
        {
            board.printBoard();

            if (board.IsKingInCheck(currentColor, currentColor))
                Console.WriteLine("Шах!");

            PairofPoints move = board.ReadMove(currentColor);   
            if (move == null)
            {
                Console.WriteLine("Сдаёмся, но не зачёту... Возврат в меню.");
                break;
            }

            currentColor = (currentColor == Color.White) ? Color.Black : Color.White;
            board.rotate();

            if (board.IsCheckmate(currentColor, currentColor))
            {
                board.printBoard();
                Console.WriteLine($"Мат! Победили {(currentColor == Color.White ? "чёрные" : "белые")}.");
                break;
            }

            if (board.IsStalemate(currentColor, currentColor))
            {
                board.printBoard();
                Console.WriteLine("Пат! Ничья.");
                break;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Партия окончена. Нажмите любую клавишу для возврата в меню...");
        Console.ReadKey(true);
        Console.Clear();
    }

}
    

