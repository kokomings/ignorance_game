using MonsterFaction.GameWorld.WorldObject.Shape;
using System.Numerics;

namespace MonsterFaction.GameWorld.WorldObject
{
    public class SampleObject : IDrawable
    {
        private readonly IShape shape;
        private Vector3 position;
        private Vector3 direction;

        public IShape Shape => shape;
        public Vector3 Position => position;
        public Vector3 Direction => direction;

        public SampleObject(IShape shape, Vector3 position, Vector3 direction)
        {
            this.shape = shape;
            this.position = position;
            this.direction = direction;
        }
    }
}
