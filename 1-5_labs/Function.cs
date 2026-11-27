

public class Function
{
    /// <summary>
    /// метод для задавания функции 
    /// </summary>
    /// <param name="a">первый параметр функции ,задаваемый пользователем</param>
    /// <param name="b">второй параметр функции ,задаваемый пользователем</param>
    /// <returns>значение функции</returns>
    public static double function(double a, double b)
    {
        double grad;
        const double PI = Math.PI;
        grad = b * PI / 180;
        double f = Math.Pow(Math.Sin(3 * PI / 4 + a / 3), 2) + Math.Sqrt(grad);
        return f;
    }


}
