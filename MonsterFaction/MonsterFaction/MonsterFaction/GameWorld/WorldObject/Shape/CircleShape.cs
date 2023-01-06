using MonsterFaction.GameWorld.WorldObject.VectorUnit;

namespace MonsterFaction.GameWorld.WorldObject.Shape
{
    public struct CircleShape : IShape
    {
        public double Radius { get; }
        public double Width { get => Radius; }
        public double Height { get => Radius; }

        public CircleShape(double radius) { Radius = radius; }
    }
}
