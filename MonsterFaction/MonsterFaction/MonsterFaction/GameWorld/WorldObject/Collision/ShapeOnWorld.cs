using MonsterFaction.GameWorld.WorldObject.Shape;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterFaction.GameWorld.WorldObject.Collision
{
    public struct ShapeOnWorld
    {
        public IShape Shape { get; }
        public Center Center { get; }
        public ShapeOnWorld(IShape shape, Center center) { Shape = shape; Center = center; }
    }
}
