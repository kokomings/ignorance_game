﻿using MonsterFaction.Characters.Battle;
using MonsterFaction.Characters.Monster;
using MonsterFaction.GameWorld.WorldObject;
using MonsterFaction.GameWorld.WorldObject.Collision;
using MonsterFaction.GameWorld.WorldObject.DomainObject;
using MonsterFaction.GameWorld.WorldObject.Shape;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using MonsterFaction.SystemEvents;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MonsterFaction.GameWorld
{
    public class World : IDrawableWorld
    {
        private readonly Vector3 WorldSize = new(1000, 200, 1000);

        // 게임 오브젝트 그리기 테스트용
        private readonly List<IDrawable> drawables = new();

        private readonly List<IUpdatable> managers = new List<IUpdatable>();
        private readonly HumanObjectManager humanObjectManager = new();
        private readonly WildMonsterObjectManager wildMonsterObjectManager = new();
        private readonly BattleManager battleManager = new();
        public readonly InputListener inputListener;

        public World()
        {
            wildMonsterObjectManager.Create(MonsterName.GOBLIN, 1);

            managers.Add(wildMonsterObjectManager);
            inputListener = new InputListener(humanObjectManager);
            managers.Add(inputListener);
            managers.Add(battleManager);
        }

        public SimpleObject MakePlayer()
        {
            HumanObject humanObject = new HumanObject(
                new Characters.Human(),
                new CircleShape(30),
                new Center(200, 200)
            );
            humanObjectManager.Assign(humanObject);
            ObjectCollisionSimulator.CreateObject(humanObject.ID, new Area(humanObject.Shape, humanObject.Center));
            EventBroker.PublishEvent(new CreateEvent(humanObject.ID, new Area(humanObject.Shape, humanObject.Center)));
            return humanObject;
        }

        public IEnumerable<IDrawable> GetDrawables()
        {
            return drawables
                .Concat(humanObjectManager.GetDrawables())
                .Concat(battleManager.GetDrawables())
                .Concat(wildMonsterObjectManager.GetDrawables());
        }

        public void Update()
        {
            foreach (var manager in managers)
            {
                manager.Update();
            }
        }
    }
}
