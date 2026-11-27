using System;
using System.Diagnostics;

public class workWithArray
{
    private int lenArray;

    public int getLenArray()
    {
        return lenArray;
    }

    /// <summary>
    /// Единственный конструктор — только сохраняет длину массива.
    /// </summary>
    public workWithArray(int len)
    {
        lenArray = len;
    }

    public workWithArray()
    {
        lenArray = 10;
    }

    /// <summary>
    /// Спрашивает у пользователя длину массива и вид сортировки,
    /// затем вызывает соответствующий метод.
    /// </summary>

    public void RunSortingByUserChoice()
    {
        int len = lenArray;

        

        Console.WriteLine("Выберите сортировку:");
        Console.WriteLine("1 — Гномья");
        Console.WriteLine("2 — Перемешиванием");

        while (true)
        {
            byte choice = Parse.ReadByte();

            switch (choice)
            {
                case 1:
                    SortGnomeAndPrint(len);
                    return;

                case 2:
                    SortShakerAndPrint(len);
                    return;

                default:
                    Console.WriteLine("Некорректный выбор. Введите 1 или 2:");
                    break;
            }
        }
    }

    /// <summary>
    /// Гномья сортировка массива заданной длины.
    /// </summary>
    public void SortGnomeAndPrint(int len)
    {
        int[] original = creatingArray(len);
        int[] sorted = Sort.dwarfSorting(arrayCopy(original));

        Console.WriteLine("=== Сортировка: Гномья ===");
        Console.WriteLine("Исходный массив:");
        outputArray(original);
        Console.WriteLine();
        Console.WriteLine("Отсортированный массив:");
        outputArray(sorted);
        Console.WriteLine();
    }

    /// <summary>
    /// Сортировка перемешиванием массива заданной длины.
    /// </summary>
    public void SortShakerAndPrint(int len)
    {
        int[] original = creatingArray(len);
        int[] sorted = Sort.meshalka(arrayCopy(original));

        Console.WriteLine("=== Сортировка: Перемешиванием ===");
        Console.WriteLine("Исходный массив:");
        outputArray(original);
        Console.WriteLine();
        Console.WriteLine("Отсортированный массив:");
        outputArray(sorted);
        Console.WriteLine();
    }

    /// <summary>
    /// Получение клона (копии) массива.
    /// </summary>
    public int[] arrayCopy(int[] firstArry)
    {
        if (firstArry == null)
        {
            return null;
        }

        int[] arryCopy = new int[firstArry.Length];
        Array.Copy(firstArry, arryCopy, firstArry.Length);
        return arryCopy;
    }

    /// <summary>
    /// Проверка на длину массива (не больше 10) и вывод массива.
    /// </summary>
    public void outputArray(int[] arr)
    {
        if (arr == null)
        {
            Console.WriteLine("Ошибка! Массив равен null.");
            return;
        }

        if (arr.Length > 10)
        {
            Console.WriteLine("Ошибка! Вывод массива невозможен, слишком большое количество элементов");
            return;
        }

        Console.WriteLine("Ваш массив состоит из следующих элементов:");
        Console.Write("[");

        for (int i = 0; i < arr.Length; i++)
        {
            if (i < arr.Length - 1)
            {
                Console.Write(arr[i] + ", ");
            }
            else
            {
                Console.Write(arr[i] + "]");
            }
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Сравнение двух сортировок между собой (Shaker и Gnome Sort).
    /// </summary>
    public  void sortArray()
    {
        int sizeArray = Parse.getLenthArray();

        int[] myChoice = creatingArray(sizeArray);

        Console.WriteLine("=== < Злой Гном > === ");
        Console.WriteLine();

        Stopwatch time1 = new Stopwatch();
        time1.Start();
        int[] dwarf = Sort.dwarfSorting(arrayCopy(myChoice));
        time1.Stop();

        Console.WriteLine("=== |Массив до сортировки|===");
        outputArray(myChoice);
        Console.WriteLine();

        Console.WriteLine("=== |Массив после сортировки|===");
        outputArray(dwarf);
        Console.WriteLine();

        Console.WriteLine($"Время выполнения: {time1.Elapsed.TotalMilliseconds}");

        Console.WriteLine("=== < Бетономешалка > === ");
        Console.WriteLine();

        Stopwatch time2 = new Stopwatch();
        time2.Start();
        int[] mixingSpoon = Sort.meshalka(arrayCopy(myChoice));
        time2.Stop();

        Console.WriteLine("=== |Массив до сортировки|===");
        outputArray(myChoice);
        Console.WriteLine();

        Console.WriteLine("=== |Массив после сортировки|===");
        outputArray(mixingSpoon);
        Console.WriteLine();

        Console.WriteLine($"Время выполнения: {time2.Elapsed.TotalMilliseconds}");

        if (time1.Elapsed < time2.Elapsed)
        {
            Console.WriteLine("Сортировка вида < Злой Гном > выгодней");
        }
        else if (time1.Elapsed > time2.Elapsed)
        {
            Console.WriteLine("Сортировка вида < Бетономешалка > выгодней");
        }
        else
        {
            Console.WriteLine("Попробуйте выбрать другую длину исходного массива");
        }
    }

    /// <summary>
    /// Заполнение массива заданной длины случайными числами.
    /// </summary>
    public int[] creatingArray(int s)
    {
        int length = s;
        int[] array = new int[length];
        Random rnd = new Random();

        for (int i = 0; i < length; i++)
        {
            array[i] = rnd.Next(-10, 10);
        }

        return array;
    }
}