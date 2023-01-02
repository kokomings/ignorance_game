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
            drawables.Add(
                    new SimpleObject(
                        new CircleShape(new Size(40, 40), new Center(20, 10)),
                        new Center(0, 0)
                    ));

            drawables.Add(
                new SimpleObject(
                    new SquareShape (new Size(30, 30), new Center(15f, 15f)),               
                    new Center(150, 80)
                ));
            managers.Add(objectCollisionManager);
            managers.Add(humanObjectManager);
            managers.Add(wildMonsterObjectManager);
        }

        public SimpleObject MakePlayer()
        {
            // Center 를 분리 할 수 없을까?
            var playerCenter = new Center(200, 200);
            HumanObject humanObject = new HumanObject(
                new Characters.Human(),
                new CircleShape(new Size(30, 30), playerCenter),
                playerCenter
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
