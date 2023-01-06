using MonsterFaction.GameWorld.WorldObject.Collision;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;
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
                // 테스트를 위해 충돌되면 못 가게 하고 있음.
                var blockingObjects = ObjectCollisionManager.GetCollidingObjectIds(
                    new ShapeOnWorld(humanObject.Shape, humanObject.Movement.NextPosition())
                    );
                if (blockingObjects.Count >= 2 || blockingObjects.Count == 1 && !blockingObjects.Contains(humanObject.ID))
                    continue;
                humanObject.Movement.Move();
            }
        }
    }
}
