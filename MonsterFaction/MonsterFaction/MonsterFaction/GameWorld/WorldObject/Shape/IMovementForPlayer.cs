using System.Numerics;

namespace MonsterFaction.GameWorld.WorldObject.Shape
{
    public interface IMovementForPlayer
    {
        public Vector2 Direction { get; set; }
        public Vector3 Velocity { set; }
    }
}
