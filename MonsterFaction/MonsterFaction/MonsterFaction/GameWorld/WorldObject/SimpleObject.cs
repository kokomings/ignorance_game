using MonsterFaction.Characters;
using MonsterFaction.GameWorld.WorldObject.Shape;
using System.Numerics;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using MonsterFaction.GameWorld.WorldObject.IDGenerator;

namespace MonsterFaction.GameWorld.WorldObject
{
    public class SimpleObject : IDrawable
    {
        public readonly int ID = IdGenerator.NextObjectId();

        public IShape Shape { get; }

        public Center Center { get; set; }

        public SimpleObject(IShape shape, Center center)
        {
            Shape = shape;
            Center = center;
        }
    }
}
