namespace SimpleSnake.GameObjects.Foods;

internal class FoodDollar : Food
{
    private const char Symbol = '$';
    private const int Points = 2;

    public FoodDollar()
        : base(Symbol, Points)
    {
    }
}
