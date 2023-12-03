namespace SimpleSnake.GameObjects.Foods
{
internal abstract class Food : GameObject
    {
    protected Food(char drawSymbol, int foodPoints)
        : base(drawSymbol)
    {
        FoodPoints = foodPoints;
    }

    public int FoodPoints { get; private set; }

    public bool CollidesWith(Point point)
    {
        return point.X == X && point.Y == Y;
    }
}
}
