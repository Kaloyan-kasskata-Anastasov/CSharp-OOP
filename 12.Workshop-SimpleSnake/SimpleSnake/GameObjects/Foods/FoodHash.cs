namespace SimpleSnake.GameObjects.Foods;

internal class FoodHash : Food
{
    private const char Symbol = '#';
    private const int Points = 3;

    public FoodHash()
        : base(Symbol, Points)
    {
    }
}
