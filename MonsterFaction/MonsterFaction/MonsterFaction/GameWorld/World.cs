using MonsterFaction.GameWorld.WorldObject;
using MonsterFaction.GameWorld.WorldObject.Shape;
using System.Collections.Generic;
using System.Numerics;

namespace MonsterFaction.GameWorld
{
    public class World : IDrawableWorld
    {
        private readonly Vector3 WorldSize = new(1000, 200, 1000);

        // 게임 오브젝트 그리기 테스트용
        private readonly List<Player> testObjects = new();

        public World()
        {
            testObjects.Add(
                    new Player(
                        new SphereShape(new Vector3(40, 100, 20), new Vector3(20, 50, 10)),
                        Vector3.Zero,
                        Vector2.Zero
                    ));

            testObjects.Add(
                new Player(
                    new BoxShape(new Vector3(30, 30, 30), new Vector3(15f, 15f, 15f)),
                    new Vector3(150, 80, -60),
                    Vector2.Zero
                ));
        }

        public Player MakePlayer()
        {
            var player = new Player(
                        new SphereShape(new Vector3(30, 30, 30), new Vector3(15, 15, 15)),
                        new Vector3(800, 0, -400),
                        Vector2.Zero
                    );
            testObjects.Add(player);
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
        }
    }
}
