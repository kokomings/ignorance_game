using MonsterFaction.GameWorld.WorldObject;
using MonsterFaction.GameWorld.WorldObject.Collision;
using MonsterFaction.GameWorld.WorldObject.Shape;
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
            var objectIdsInRange = ObjectCollisionManager.GetCollidingObjectIds(attackEvent.Area);
            Logger.Log.Information(objectIdsInRange.ToString());
        }
    }
}
