using MonsterFaction.GameWorld.WorldObject;
using System.Collections.Generic;

namespace MonsterFaction.GameWorld
{
    public interface IDrawableWorld
    {
        public IEnumerable<SampleObject> GetTestObjects();
    }
}
