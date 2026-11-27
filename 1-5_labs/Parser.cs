static class Parser
{   
    /// <summary>
    /// Разбирает строку с координатами хода (например, "E2 E4") и преобразует её в пару точек.
    /// </summary>
    /// <param name="stroka">Строка с координатами, вводимая пользователем.</param>
    /// <returns>Объект , если ввод корректен и соответствует всем условиям; иначе null.</returns>
    public static PairofPoints parse(string stroka)
    {
        if (string.IsNullOrWhiteSpace(stroka))
        {
            return null;
        }
        string[] s = stroka.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (s.Length != 2)
        {
            return null;
        }
        if (s[0].Length != 2 || s[1].Length != 2)
        {
            return null;
        }
        int x1 = char.ToUpper(s[0][0]) - 65;
        int y1 = s[0][1] - 49;
        int x2 = char.ToUpper(s[1][0]) - 65;
        int y2 = s[1][1] - 49;
        if (x1 >= 0 && x1 < 8 && y1 >= 0 && y1 < 8 && x2 >= 0 && x2 < 8 && y2 >= 0 && y2 < 8)
        {
            return new PairofPoints(new Points(x1, y1), new Points(x2, y2));
        }
        return null;
    }
}

