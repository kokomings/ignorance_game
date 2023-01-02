using MonsterFaction.GameWorld.WorldObject.VectorUnit;

namespace MonsterFaction.GameWorld.WorldObject.Shape
{
    public struct CircleShape : IShape
    {
        public Size Size { get; private set; }
        public Center Center { get; private set; }

        public CircleShape(Size size, Center center) { Size = size; Center = center; }
    }
}
