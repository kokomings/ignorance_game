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
        private readonly List<SampleObject> testObjects = new();

        public World()
        {
            testObjects.Add(
                    new SampleObject(
                        new SphereShape(new Vector3(40, 100, 20), new Vector3(20, 50, 10)),
                        Vector3.Zero,
                        Vector3.Zero
                    ));

            testObjects.Add(
                new SampleObject(
                    new BoxShape(new Vector3(30, 30, 30), new Vector3(15f, 15f, 15f)),
                    new Vector3(150, 80, -60),
                    Vector3.Zero
                ));
        }

        public IEnumerable<SampleObject> GetTestObjects()
        {
            return testObjects;
        }
    }
}
