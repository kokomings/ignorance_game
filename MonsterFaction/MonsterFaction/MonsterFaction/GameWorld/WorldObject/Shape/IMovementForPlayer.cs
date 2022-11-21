using System.Numerics;

namespace MonsterFaction.GameWorld.WorldObject.Shape
{
    public interface IMovementForPlayer
    {
        public Vector3 Direction { set; }
        public Vector3 Velocity { set; }
    }
}
