using MonsterFaction.GameWorld.WorldObject.VectorUnit;

namespace MonsterFaction.GameWorld.WorldObject.Shape
{
    public struct SquareShape : IShape
    {
        public Size Size { get; private set; }
        public Center Center { get; private set; }

        public SquareShape(Size size, Center center) { Size = size; Center = center; }
    }
}
