public static class Information
{
    /// <summary>
    /// вывод информации об авторе
    /// </summary>
    public static void getinformat()// информаиця об авторе 
    {
        Console.WriteLine("Об авторе : 6105 Размолодина Дарья Артемовна ");
    }
    public static void WelcomeToTheGame()// информаиця об авторе 
    {
        Console.WriteLine("Добро пожаловать в игру, где король прячется за ладьёй, а студент — за конспектом! ");
        
    }
    public const string GameTitle = "<< Рокировка в сторону зачёт >>";

    /// <summary>
    /// Метод для приветсвия игрока и входа в игру 
    /// </summary>
    public static void PrintWelcome()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Clear();

        const int count = 50;

        Console.WriteLine(new string('=', count));
        Console.WriteLine($"   ♟  {GameTitle}  ♟");
        Console.WriteLine(new string('=', count));
        Console.WriteLine();
        Console.WriteLine("Добро пожаловать в игру, где король прячется за ладьёй,");
        Console.WriteLine("а студент — за конспектом!");
        Console.WriteLine();
        Console.WriteLine("Здесь всё как в жизни:");
        Console.WriteLine("  — пешки идут вперёд,");
        Console.WriteLine("  — ферзь решает всё,");
        Console.WriteLine("  — а рокировка — единственный законный способ отойти от проблем и двинуться в сторону зачёта.");
        Console.WriteLine();
        Console.WriteLine("Правила простые:");
        Console.WriteLine("  1) Ходите по очереди.");
        Console.WriteLine("  2) Не подставляйте короля.");
        Console.WriteLine("  3) Не пытайтесь сдать преподавателю ферзя как курсовую.");
        Console.WriteLine("  4) Помните: мат — это не приговор, а всего лишь шахматная оценка.");
        Console.WriteLine();
        Console.WriteLine("Желаем удачи! Пусть ваш мат будет шахматным,");
        Console.WriteLine("а зачёт — автоматическим.");
        Console.WriteLine();
    }

    /// <summary>
    /// метод для вывода  общего меню
    /// </summary>
    public static void Menu()
    {
        Console.WriteLine(" === |Меню| === \n |1 - <Угадайка> \n |2 - <Информация об авторе>  \n |3 - <Сортировка массива>  \n |4 - <Рокировка в сторону зачёт> \n |5 - <Выход>");
        Console.Write("Выберите соответсвующий пункт меню: ");
    }


    /// <summary>
    /// Главное меню. Возвращает управление в цикл после каждой партии,
    /// пока пользователь не выберет «Сдаться, но не зачёту» → «Выход».
    /// </summary>
    public static void PersonChoice()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"   ♟  {GameTitle}  ♟");
            Console.WriteLine();
            Console.WriteLine("Выберите соответствующий пункт меню:");
            Console.WriteLine("♟ 1) Начать партию");
            Console.WriteLine("♟ 2) Правила");
            Console.WriteLine("♟ 3) Сдаться, но не зачёту");
            Console.Write("Ваш выбор: ");

            ConsoleKeyInfo key = Console.ReadKey(true);
            Console.WriteLine(key.KeyChar);

            switch (key.KeyChar)
            {
                case '1':
                    Console.Clear();
                    CastlingToTheSideOfTheCheck.castlingToTheSideOfTheCheck();
                    break;

                case '2':
                    ShowRules();
                    break;

                case '3':
                    if (ConfirmExit())
                        return;   // выход из программы
                    // иначе — остаёмся в меню
                    break;

                default:
                    Console.WriteLine("Ошибка ввода, нажмите любую клавишу...");
                    Console.ReadKey(true);
                    break;
            }
        }
    }
    /// <summary>
    /// Показ правил и возврат в меню по нажатию клавиши
    /// </summary>
    private static void ShowRules()
    {
        Console.Clear();
        Console.WriteLine("=== Правила ===");
        Console.WriteLine("1) Ходите по очереди.\n 2) Не подставляйте короля.\n 3) Не пытайтесь сдать преподавателю ферзя как курсовую.\n 4) Помните: мат — это не приговор, а всего лишь шахматная оценка.");
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню...");
        Console.ReadKey(true);
    }

    /// <summary>
    /// Подтверждение выхода из программы.
    /// Поддерживает и русскую ('д'/'н'), и латинскую ('l'/'y') раскладку
    /// </summary>
    /// <returns>Возвращает true — выходим, false — остаёмся в меню.</returns>
    /// </summary>
    public static bool ConfirmExit()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("'д' — Выход из программы");
            Console.WriteLine("'н' — Остаться в программе (вернуться в меню)");
            Console.Write("Ваш выбор: ");

            ConsoleKeyInfo key = Console.ReadKey(true);
            char ch = char.ToLower(key.KeyChar);
            Console.WriteLine(ch);

            if (ch == 'д' || ch == 'l') return true; 
            if (ch == 'н' || ch == 'y') return false;
            Console.WriteLine("Ошибка ввода, попробуйте ещё раз. Нажмите клавишу...");
            Console.ReadKey(true);
        }
    }
}
