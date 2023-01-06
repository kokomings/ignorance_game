using System.Collections.Generic;

namespace MonsterFaction.GameWorld.WorldObject.DomainObject
{
    public class HumanObjectManager: IUpdatable
    {
        private readonly Dictionary<int, HumanObject> objects = new();

        public void Add(HumanObject obj)
        {
            objects.Add(obj.ID, obj);
        }

        public void Remove(int objectId) 
        {
            objects.Remove(objectId);
        }

        public void Update()
        {
            foreach (var (key, humanObject) in objects) 
            {

                humanObject.Movement.Move();
            }
        }
    }
}
