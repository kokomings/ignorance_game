using MonsterFaction.Characters;
using MonsterFaction.GameWorld.WorldObject.Shape;
using System.Numerics;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;

namespace MonsterFaction.GameWorld.WorldObject
{
    public class SimpleObject : IUpdatable, IDrawable
    {
        private readonly IShape shape;
        private readonly Movement movement;

        public IShape Shape => shape;
        public IMovement Movement => movement;
        public IMovementForPlayer PlayerMovement => movement;

        public SimpleObject(IShape shape, Center center, Direction direction)
        {
            this.shape = shape;
            this.movement = new Movement(center, direction);
        }

        public void Update()
        {
            Movement.Move();
        }
    }
}
