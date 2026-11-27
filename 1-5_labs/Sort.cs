
public class Sort
{   
    /// <summary>
    /// метод, в котором сортируется массив , вводимый пользователем, c помощью  устойчивого вида сортировки "Shaker"
    /// </summary>
    /// <param name="arr2">массив вводимы пользователем</param>
    /// <returns>отсортированный массив ,элементы которого размещаются в возрастающем порядке </returns>
    public static int[] meshalka(int[] arr2)
    {

        if (arr2 == null || arr2.Length == 0)
        {
            return arr2;
        }
        int left = 0;
        int right = arr2.Length - 1;
        bool isSwapped = true;

        while (left < right && isSwapped)
        {
            isSwapped = false;
            for (int i = left; i < arr2.Length - 1; i++)
            {
                if (arr2[i] > arr2[i + 1])
                {
                    int indicator = arr2[i];
                    arr2[i] = arr2[i + 1];
                    arr2[i + 1] = indicator;
                    isSwapped = true;
                }
            }
            right--;
            for (int i = right; i >= 1; i--)
            {
                if (arr2[i - 1] > arr2[i])
                {
                    int indicator = arr2[i];
                    arr2[i] = arr2[i - 1];
                    arr2[i - 1] = indicator;
                    isSwapped = true;

                }
            }
            left++;
        }
        return arr2;
    }
    /// <summary>
    /// метод, в котором сортируется массив , вводимый пользователем, c помощью  устойчивого вида сортировки "Gnome sort"
    /// </summary>
    /// <param name="arr2">массив вводимы пользователем</param>
    /// <returns>отсортированный массив ,элементы которого размещаются в возрастающем порядке </returns>

    public static int[] dwarfSorting(int[] arr1)
    {
        if (arr1 == null || arr1.Length == 0)
        {
            return arr1;
        }
        int indicator = 1;
        while (indicator < arr1.Length)
        {
            if (indicator == 0 || arr1[indicator] >= arr1[indicator - 1])
            {
                indicator++;
            }
            else
            {
                int dopIndicator = arr1[indicator];
                arr1[indicator] = arr1[indicator - 1];
                arr1[indicator - 1] = dopIndicator;
                indicator--;
            }
        }
        return arr1;
    }
}
