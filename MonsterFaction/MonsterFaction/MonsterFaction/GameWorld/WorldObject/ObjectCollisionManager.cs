using MonsterFaction.GameWorld.WorldObject.Shape;
using MonsterFaction.SystemEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterFaction.GameWorld.WorldObject
{
    // 미구현
    public class ObjectCollisionManager: IUpdatable
    {
        private readonly EventSubscriber<CreateEvent> createEvents = new(EventType.OBJECT_CREATE);
        private readonly EventSubscriber<MoveEvent> moveEvents = new(EventType.OBJECT_MOVE);
        private readonly EventSubscriber<DeleteEvent> deleteEvents = new(EventType.OBJECT_DELETE);

        public List<int> GetCollidingObjectIds(IShape targetRange)
        {
            return new List<int>();
        }

        public void FlushAllObject()
        {

        }

        public void Update()
        {
            createEvents.FetchAll();
            moveEvents.FetchAll();
            deleteEvents.FetchAll();
        }
    }
}
