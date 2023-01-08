using MonsterFaction.GameWorld.WorldObject;
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
        private readonly List<SimpleObject> testObjects = new();

        private readonly List<IUpdatable> managers = new List<IUpdatable>();

        public World()
        {
            testObjects.Add(
                    new SimpleObject(
                        new CircleShape(new Size(40, 40), new Center(20, 10)),
                        new Center(0, 0),
                        new Direction(0, 0)
                    ));

            testObjects.Add(
                new SimpleObject(
                    new SquareShape (new Size(30, 30), new Center(15f, 15f)),               
                    new Center(150, 80),
                    new Direction(0, 0)
                ));
            managers.Add(new ObjectCollisionManager());
        }

        public SimpleObject MakePlayer()
        {
            // Center 를 분리 할 수 없을까?
            var playerCenter = new Center(200, 200);
            var player = new SimpleObject(
                        new CircleShape (new Size(30, 30), playerCenter),
                        playerCenter,
                        new Direction(0, 0)
                    );
            testObjects.Add(player);
            EventBroker.PublishEvent(new CreateEvent(1, player.Shape));
            return player;
        }

        public IEnumerable<IDrawable> GetDrawables()
        {
            return testObjects;
        }

        public void Update()
        {
            foreach (var testObject in testObjects)
            {
                testObject.Update();
            }
            foreach (var manager in managers)
            {
                manager.Update();
            }
        }
    }
}
