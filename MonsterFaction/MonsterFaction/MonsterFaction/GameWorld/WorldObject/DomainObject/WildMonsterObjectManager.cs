using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterFaction.GameWorld.WorldObject.DomainObject
{
    public class WildMonsterObjectManager : IUpdatable
    {
        private readonly Dictionary<int, WildMonsterObject> objects = new();

        public void Add(WildMonsterObject obj)
        {
            objects.Add(obj.ID, obj);
        }

        public void Remove(int objectId)
        {
            objects.Remove(objectId);
        }

        public void Update()
        {
        }
    }
}
