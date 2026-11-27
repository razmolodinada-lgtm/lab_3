public static class Parse
{
    /// <summary>
    /// проверка на корректность ввода переменной типа byte
    /// </summary>
    /// <returns>возрощает переменную типа byte, при корректности ввода пользовательского значения в консоль </returns>
    public static byte ReadByte() 
    {
        while (true)
        {
            if (!byte.TryParse(Console.ReadLine(), out byte peremen_2))
            {
                Console.WriteLine("Ошибка ввода, попробуйте ещё раз ");
            }
            else
            {
                return peremen_2;
            }
        }
    }
    /// <summary>
    /// проверка на корректность ввода переменной типа double
    /// </summary>
    /// <returns>возрощает переменную типа double, при корректности ввода пользовательского значения в консоль </returns>
    public static double ReadDouble()
    { 
        while (true)
        {
            if (!double.TryParse(Console.ReadLine(), out double peremen))
            {
                Console.WriteLine("Ошибка ввода, попробуйте ещё раз ");
            }
            else
            {
                return peremen;
            }
        }
    }
    /// <summary>
    /// проверка на корректность ввода переменной типа char
    /// </summary>
    /// <returns>возрощает переменную типа char, при корректности ввода пользовательского значения в консоль </returns>
    public static char ReadChar()// проверка на корректность ввода символа 
    {
        while (true)
        {
            if (!char.TryParse(Console.ReadLine(), out char peremen_3))
            {
                Console.WriteLine("Ошибка ввода, попробуйте ещё раз ");
            }
            else
            {
                return peremen_3;
            }
        }
    }

    /// <summary>
    /// проверка на корректность ввода переменной типа int
    /// </summary>
    /// <returns>возрощает переменную типа int, при корректности ввода пользовательского значения в консоль </returns>
    public static int Readint()// проверка на корректность ввода 
    {
        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out int peremen))
            {
                Console.WriteLine("Ошибка ввода, попробуйте ещё раз ");
            }
            else
            {
                return peremen;
            }
        }
    }
    /// <summary>
    /// способ установки определённой длины массива 
    /// </summary>
    /// <returns>возрощает заданную пользовательскую длину для массива в диапозоне от 0-9 </returns>
    public static int getLenthArray() 
    {

        while (true)
        {
            Console.WriteLine("Введите предполагаемую длинну массива :");
            int size = Readint();
            if (size < 0 || size >= 10)
            {
                Console.WriteLine(" Ошибка: число должно быть положительным \n Вы запрашиватете слишком большое колличество элементов  ");
            }
            return size;

        }
    }

    /// <summary>
    /// интерактивный диалог с пользователем предлагая ему сделать выбор : продолжить работу или выйти из программы
    /// </summary>
    /// <returns>возрощает значения типа bool , при успехе-true , при неудаче -false  </returns>
    public static bool dilemma()
    {

        while (true)
        {
            Console.WriteLine("Выберите действие \n 'д' - == | Выход из программы| == \n 'н' - == | Остаться в программе | ==");
            char ch = ReadChar();
            if (ch == 'д')
            {
                return false;

            }
            else if (ch == 'н')
            {
                return true;

            }
            else
            {
                Console.WriteLine("Ошибка ввода ,попробуйте ещё раз ");
            }
        }

    }
    

}
