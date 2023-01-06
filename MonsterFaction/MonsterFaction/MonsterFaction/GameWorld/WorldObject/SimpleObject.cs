using MonsterFaction.Characters;
using MonsterFaction.GameWorld.WorldObject.Shape;
using System.Numerics;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using MonsterFaction.GameWorld.WorldObject.IDGenerator;

namespace MonsterFaction.GameWorld.WorldObject
{
    public class SimpleObject : IDrawable
    {
        private readonly Movement movement;

        public readonly int ID = IdGenerator.NextObjectId();

        public IShape Shape { get; }
        public IMovement Movement => movement;
        public IMovementForPlayer PlayerMovement => movement;

        public SimpleObject(IShape shape, Center center)
        {
            Shape = shape;
            movement = new Movement(center, new Direction(0, 0));
        }
    }
}
