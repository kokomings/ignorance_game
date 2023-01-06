using MonsterFaction.GameWorld.WorldObject.Shape;
using System.Numerics;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;

namespace MonsterFaction.GameWorld.WorldObject
{
    public sealed class Movement : IMovement, IMovementForPlayer
    {
        public Center Center { get; set; }
        public Direction Direction { get; set; }
        public Velocity Velocity { get; set; }
        public Movement(Center center, Direction direction)
        {
            Center = center;
            Direction = direction;
            Velocity = new Velocity(0, 0);
        }

        public void Move()
        {
            Center = Center + new Center(Velocity.X, Velocity.Y);
        }

        public Center NextPosition()
        {
            return Center + new Center(Velocity.X, Velocity.Y);
        }
    }
}
