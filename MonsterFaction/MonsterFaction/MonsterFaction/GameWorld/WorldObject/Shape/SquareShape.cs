using MonsterFaction.GameWorld.WorldObject.VectorUnit;

namespace MonsterFaction.GameWorld.WorldObject.Shape
{
    public struct SquareShape : IShape
    {
        public double Width { get; }
        public double Height { get; }

        public SquareShape(double width, double height) { Width = width; Height = height; }
    }
}
