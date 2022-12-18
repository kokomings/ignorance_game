using System.Numerics;

namespace MonsterFaction.GameWorld.WorldObject
{
    public interface IMovement
    {
        public Vector3 Position { get; }
        public Vector2 Direction { get; }
        public void Move(float speed = 1.0f);
    }
}
