using MonsterFaction.Characters;
using MonsterFaction.GameWorld.WorldObject.Shape;
using System.Numerics;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using MonsterFaction.GameWorld.WorldObject.IDGenerator;

namespace MonsterFaction.GameWorld.WorldObject
{
    public class SimpleObject : IDrawable
    {
        private readonly IShape shape;
        private readonly Movement movement;

        public readonly int ID = IdGenerator.NextObjectId();

        public IShape Shape => shape;
        public IMovement Movement => movement;
        public IMovementForPlayer PlayerMovement => movement;

        public SimpleObject(IShape shape)
        {
            this.shape = shape;
            this.movement = new Movement(shape.Center, new Direction(0, 0));
        }
    }
}
