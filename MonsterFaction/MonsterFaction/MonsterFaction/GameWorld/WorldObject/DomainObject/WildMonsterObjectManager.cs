﻿using MonsterFaction.Characters.Monster;
using MonsterFaction.GameWorld.WorldObject.Collision;
using MonsterFaction.GameWorld.WorldObject.Shape;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using MonsterFaction.SystemEvents;
using System;
using System.Collections.Generic;

namespace MonsterFaction.GameWorld.WorldObject.DomainObject
{
    public class WildMonsterObjectManager : IUpdatable
    {
        private readonly Dictionary<int, WildMonsterObject> objects = new();
        private readonly WildMonsterFactory factory = new();
        private Random random = new Random();

        public WildMonsterObject Create(MonsterName name, int level)
        {
            var monster = new WildMonsterObject(
                factory.CreateMonster(name, level),
                generateRandomShape(),
                new Center(random.Next(50, 150), random.Next(50, 150))
                );
            ObjectCollisionSimulator.CreateObject(monster.ID, new Area(monster.Shape, monster.Center));
            EventBroker.PublishEvent(new CreateEvent(monster.ID, new Area(monster.Shape, monster.Center)));
            Add(monster);
            return monster;
        }
        private void Add(WildMonsterObject obj)
        {
            objects.Add(obj.ID, obj);
        }

        public void Remove(int objectId)
        {
            objects.Remove(objectId);
        }

        public void Update()
        {
        }

        public IEnumerable<IDrawable> GetDrawables()
        {
            return objects.Values;
        }

        private IShape generateRandomShape()
        {
            //if (random.Next(1,3) %2 == 0)
            //{
            //    return new SquareShape(random.Next(20, 60), random.Next(20, 60));
            //}
            //else
            //{
            //    return new SquareShape(random.Next(20, 60), random.Next(20, 60));
            //}
            return new SquareShape(20, 20);
        }
    }
}
