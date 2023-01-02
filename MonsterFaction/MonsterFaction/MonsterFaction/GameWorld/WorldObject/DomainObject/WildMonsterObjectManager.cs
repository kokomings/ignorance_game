using MonsterFaction.Characters.Monster;
using MonsterFaction.GameWorld.WorldObject.Shape;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using MonsterFaction.SystemEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                generateRandomShape()
                );
            Console.WriteLine(monster.ID);
            // FIXME: 왜 이벤트 로그 출력 안되지?
            EventBroker.PublishEvent(new CreateEvent(monster.ID, monster.Shape));
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

        private IShape generateRandomShape()
        {
            var Size = new Size(random.Next(20, 60), random.Next(20, 60));
            var Center = new Center(random.Next(0, 300), random.Next(0, 300));
            if (random.Next(1,3) %2 == 0)
            {
                return new CircleShape(Size, Center);
            }
            else
            {
                return new SquareShape(Size, Center);
            }
        }
    }
}
