using System.Numerics;

namespace MonsterFaction.GameWorld.WorldObject.Shape
{
    public sealed class BoxShape : IShape
    {
        private readonly Vector3 size;
        public Vector3 Size => size;
        private readonly Vector3 center;
        public Vector3 Center => center;

        public BoxShape(Vector3 size, Vector3 center)
        {
            this.size = size;
            this.center = center;
        }
    }
}
