using MonsterFaction.GameWorld.WorldObject.VectorUnit;

namespace MonsterFaction.GameWorld.WorldObject.Shape
{
    public struct CircleShape : IShape
    {
        public double Radius { get; }
        public double Width { get => Radius * 2; }
        public double Height { get => Radius * 2; }

        public CircleShape(double radius) { Radius = radius; }
    }
}
