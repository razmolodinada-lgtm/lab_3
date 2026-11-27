using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Reflection.Metadata;
using System.Diagnostics;
public enum Color { White, Black }

public class Program()
{   
    /// <summary>
    /// точка входа в программу 
    /// </summary>
    public static void Main()
    {
        bool check = true;

        while (check)
        {
            Information.Menu();
            switch (Parse.ReadByte())
            {   
                case 1: Console.Clear(); Fortune.fortune(); break;
                case 2: Console.Clear(); Information.getinformat(); break;
                case 3: { Console.Clear(); 
                        workWithArray wwa1 = new workWithArray();
                        Console.WriteLine(wwa1.getLenArray());
                        wwa1.RunSortingByUserChoice();
                        workWithArray wwa2 = new workWithArray(8);
                        Console.WriteLine(wwa2.getLenArray());
                        wwa2.RunSortingByUserChoice();

                        break; }
                case 4: Console.Clear();
                    Information.PrintWelcome();
                    CastlingToTheSideOfTheCheck.castlingToTheSideOfTheCheck(); 
                    break;
                case 5: Console.Clear(); check = Parse.dilemma();  break;
                default: Console.Clear(); Console.WriteLine("Номер введённого пункта отсутвует, попробуйте ещё раз "); Console.Clear(); break;

            }
        }
    }
}