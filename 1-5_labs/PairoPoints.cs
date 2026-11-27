class PairofPoints
{
    public Points pointOne;
    public Points pointTwo;

    /// <summary>
    /// Инициализирует новый экземпляр класса 
    /// </summary>
    /// <param name="pointOne">Первая координата (начальная точка).</param>
    /// <param name="pointTwo">Вторая координата (конечная точка).</param>
    public PairofPoints(Points pointOne, Points pointTwo)
    {
        this.pointOne = pointOne;
        this.pointTwo = pointTwo;
    }
    
}