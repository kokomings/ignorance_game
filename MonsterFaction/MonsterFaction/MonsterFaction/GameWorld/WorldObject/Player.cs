using MonsterFaction.GameWorld.WorldObject.Shape;
using System.Numerics;

namespace MonsterFaction.GameWorld.WorldObject
{
    public class Player : IUpdatable, IDrawable
    {
        private readonly IShape shape;
        private readonly Movement movement;

        public IShape Shape => shape;
        public IMovement Movement => movement;
        public IMovementForPlayer PlayerMovement => movement;

        public Player(IShape shape, Vector3 position, Vector2 direction)
        {
            this.shape = shape;
            this.movement = new Movement(position, direction);
        }

        public void Update()
        {
            Movement.Move();
        }
    }
}
