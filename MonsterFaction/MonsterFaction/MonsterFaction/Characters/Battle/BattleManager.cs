using MonsterFaction.GameWorld.WorldObject;
using MonsterFaction.GameWorld.WorldObject.Collision;
using MonsterFaction.GameWorld.WorldObject.Shape;
using MonsterFaction.SystemEvents;
using MonsterFaction.Util;
using System.Collections.Generic;

namespace MonsterFaction.Characters.Battle
{
    public class BattleManager : IUpdatable
    {
        private readonly EventSubscriber<AttackEvent> attackEvents = new(EventType.ATTACK);

        private TimeLimitedCollection<IDrawable> projectiles = new(); // 나중에 다른 곳으로 옮기자.
        public void Update()
        {
            foreach (AttackEvent attackEvent in attackEvents.FetchAll()) 
            {
                attackTarget(attackEvent);
                createProjectiles(attackEvent.Area);
            }
            projectiles.Tick();
        }

        public IEnumerable<IDrawable> GetDrawables()
        {
            return projectiles;
        }

        private void attackTarget(AttackEvent attackEvent)
        {
            var objectIdsInRange = ObjectCollisionSimulator.GetCollidingObjectIds(attackEvent.Area);
            foreach (var i in objectIdsInRange) { Logger.Log.Information(i.ToString()); }
        }

        //TODO: 여기선 만들어 주고 있지만 나중엔 외부에서 받아야 함.
        private void createProjectiles(Area attackArea)
        {
            var projectile = new SimpleObject(attackArea.Shape, attackArea.Center);
            projectiles.Add(projectile, 10);
        }
    }
}
