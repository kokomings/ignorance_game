using MonsterFaction.GameWorld.WorldObject;
using MonsterFaction.GameWorld.WorldObject.Collision;
using MonsterFaction.SystemEvents;
using System;

namespace MonsterFaction.Characters.Battle
{
    public class BattleManager : IUpdatable
    {
        private readonly static EventSubscriber<AttackEvent> attackEvents = new(EventType.ATTACK);
        public void Update()
        {
            foreach (AttackEvent attackEvent in attackEvents.FetchAll()) 
            {
                attackTarget(attackEvent);
            }
        }

        private void attackTarget(AttackEvent attackEvent)
        {
            var objectIdsInRange = ObjectCollisionManager.GetCollidingObjectIds(new ShapeOnWorld(attackEvent.Shape, attackEvent.Center));
            Logger.Log.Information(objectIdsInRange.ToString());
        }
    }
}
