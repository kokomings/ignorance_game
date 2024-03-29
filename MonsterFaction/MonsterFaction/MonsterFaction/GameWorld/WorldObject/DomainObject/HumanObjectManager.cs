﻿using MonsterFaction.GameWorld.WorldObject.Collision;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using MonsterFaction.GameWorld.WorldObject.Shape;
using MonsterFaction.SystemEvents;
using System.Collections.Generic;

namespace MonsterFaction.GameWorld.WorldObject.DomainObject
{
    public class HumanObjectManager
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
            if (ObjectCollisionSimulator.MoveObjectIfCan(humanObject.ID, nextCenter))
            {
                humanObject.Center = nextCenter;
                humanObject.Direction = direction;
            }
        }

        public void Attack()
        {
            EventBroker.PublishEvent(new AttackEvent(humanObject.AttackArea(), true));
        }

        public IEnumerable<IDrawable> GetDrawables()
        {
            var list = new List<HumanObject>();
            list.Add(humanObject);
            return list;
        }
    }
}
