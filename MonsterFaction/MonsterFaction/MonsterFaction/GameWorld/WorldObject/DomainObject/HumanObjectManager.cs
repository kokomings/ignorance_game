using MonsterFaction.GameWorld.WorldObject.Collision;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using MonsterFaction.GameWorld.WorldObject.Shape;
using MonsterFaction.SystemEvents;

namespace MonsterFaction.GameWorld.WorldObject.DomainObject
{
    public class HumanObjectManager: IUpdatable // updatable 필요 없을 듯.
    {
        private HumanObject humanObject;

        public void Assign(HumanObject human)
        {
            this.humanObject = human;
        }
        public void Move(Direction direction, double speed)
        {
            if (direction.X == 0 && direction.Y == 0)
                return;

            // 테스트를 위해 충돌되면 못 가게 하고 있음.
            Center nextCenter = humanObject.Center + new Center(direction.X * speed, direction.Y * speed);
            var blockingObjects = ObjectCollisionManager.GetCollidingObjectIds(
                new Area(humanObject.Shape, nextCenter)
                );
            if (blockingObjects.Count >= 2 || blockingObjects.Count == 1 && !blockingObjects.Contains(humanObject.ID))
                return;
            humanObject.Center = nextCenter;
            EventBroker.PublishEvent(new MoveEvent(humanObject.ID, humanObject.Center));
        }

        public void Attack()
        {
            
        }

        public void Update()
        {

        }
    }
}
