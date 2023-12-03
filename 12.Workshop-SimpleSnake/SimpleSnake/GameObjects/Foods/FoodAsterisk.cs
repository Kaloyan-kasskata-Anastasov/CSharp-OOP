namespace SimpleSnake.GameObjects.Foods
{
internal class FoodAsterisk : Food
{
    private const char Symbol = '*';
    private const int Points = 1;

    public FoodAsterisk() 
        : base(Symbol, Points)
    {
    }
}
}
