using MonsterFaction.GameWorld.WorldObject.Shape;
using System.Numerics;

namespace MonsterFaction.GameWorld.WorldObject
{
    public interface IDrawable
    {
        public IShape Shape { get; }
        public Vector3 Position { get; }
        public Vector3 Direction { get; }
    }
}
