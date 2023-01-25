using MonsterFaction.GameWorld.WorldObject;
using MonsterFaction.GameWorld.WorldObject.Collision;
using MonsterFaction.GameWorld.WorldObject.Shape;
using MonsterFaction.SystemEvents;
using MonsterFaction.Util;
using System;
using System.Collections;
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
            }
        }

        private void attackTarget(AttackEvent attackEvent)
        {
            var objectIdsInRange = ObjectCollisionManager.GetCollidingObjectIds(attackEvent.Area);
            foreach (var i in objectIdsInRange) { Logger.Log.Information(i.ToString()); }
        }
    }
}
