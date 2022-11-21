using System.Numerics;

namespace MonsterFaction.GameWorld.WorldObject.Shape
{
    public interface IShape
    {
        public Vector3 Size { get; }
        public Vector3 Center { get; }
    }
}
