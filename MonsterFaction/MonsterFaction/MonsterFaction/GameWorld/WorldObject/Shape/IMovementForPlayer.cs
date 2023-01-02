using System.Numerics;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;

namespace MonsterFaction.GameWorld.WorldObject.Shape
{
    public interface IMovementForPlayer
    {
        public Direction Direction { get; set; }
        public Velocity Velocity { set; }
    }
}
