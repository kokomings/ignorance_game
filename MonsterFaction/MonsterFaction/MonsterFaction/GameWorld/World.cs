using MonsterFaction.Characters.Monster;
using MonsterFaction.GameWorld.WorldObject;
using MonsterFaction.GameWorld.WorldObject.DomainObject;
using MonsterFaction.GameWorld.WorldObject.Shape;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using MonsterFaction.SystemEvents;
using System.Collections.Generic;
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
        private readonly ObjectCollisionManager objectCollisionManager = new();

        public World()
        {
            var monster1 = wildMonsterObjectManager.Create(MonsterName.GOBLIN, 1);
            var monster2 = wildMonsterObjectManager.Create(MonsterName.GOBLIN, 1);
            drawables.Add(monster1);
            drawables.Add(monster2);

            managers.Add(objectCollisionManager);
            managers.Add(humanObjectManager);
            managers.Add(wildMonsterObjectManager);
        }

        public SimpleObject MakePlayer()
        {
            HumanObject humanObject = new HumanObject(
                new Characters.Human(),
                new CircleShape(new Size(30, 30), new Center(200, 200))
            );
            drawables.Add(humanObject);
            humanObjectManager.Add(humanObject);
            EventBroker.PublishEvent(new CreateEvent(humanObject.ID, humanObject.Shape));
            return humanObject;
        }

        public IEnumerable<IDrawable> GetDrawables()
        {
            return drawables;
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
