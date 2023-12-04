namespace SimpleSnake.GameObjects.Food
{
internal class FoodHash : Food
{
    private const char Symbol = '#';
    private const int HashPoints = 3;

    public FoodHash()
        : base(Symbol, HashPoints)
    {
    }
}
}
