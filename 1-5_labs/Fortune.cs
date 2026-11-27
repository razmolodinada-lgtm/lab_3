
public class Fortune
{   
    /// <summary>
    /// Игра, с помощью которой можно угадать значение функции 
    /// </summary>
    public static void fortune()
    {
        bool cnt = true;
        while (cnt)
        {
            Console.WriteLine("Введите значение a:");
            double a = Parse.ReadDouble();
            Console.WriteLine("Введите значение b:");
            double b = Parse.ReadDouble();
            double answerF = Function.function(a, b);
            byte count = 0;
            while (count < 3)
            {
                Console.Write("Угадайте значение функции, введите свой ответ: ");

                if (Parse.ReadDouble() == Math.Round(answerF, 2))
                {
                    Console.Write("Поздравляю, вы угадали!");
                    count = 4;

                }
                else
                {
                    Console.WriteLine("О нет, попробуйте ещё раз ввести число: ");
                    count++;
                    if (count == 3)
                    {
                        Console.Write($"У вас закончились попытки! Правильный ответ: {Function.function(a, b)}");
                        Console.WriteLine("Конец игры ");
                        cnt = false;
                    }
                }

            }
        }
    }
}
