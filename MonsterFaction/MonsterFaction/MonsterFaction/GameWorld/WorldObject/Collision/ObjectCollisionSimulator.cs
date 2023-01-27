using MonsterFaction.GameWorld.WorldObject.DomainObject;
using MonsterFaction.GameWorld.WorldObject.Shape;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using MonsterFaction.SystemEvents;
using System;
using System.Collections.Generic;

namespace MonsterFaction.GameWorld.WorldObject.Collision
{
    // 단순 격자 형태로 구현됨. 이후에 QuadTree 등 알고리즘 개선하자.
    public static class ObjectCollisionSimulator
    {
        private static HashSet<int>[,] positionToObjectIds = new HashSet<int>[1000, 1000];
        private static Dictionary<int, List<Tuple<int, int>>> objectIdToPositions = new();
        private static Dictionary<int, Area> objectIdToArea = new();

        static ObjectCollisionSimulator() { initialize(); }

        public static HashSet<int> GetCollidingObjectIds(Area target)
        {
            HashSet<int> targetObjectIds = new();
            HashSet<int> result = new();
            foreach (var position in getPositions(target))
            {
                foreach (var objectId in positionToObjectIds[position.Item1, position.Item2])
                {
                    targetObjectIds.Add(objectId);
                }
            }

            foreach (var objectId in targetObjectIds)
            {
                if (CollisionChecker.IsCollide(target, objectIdToArea[objectId]))
                {
                    result.Add(objectId);
                }
            }

            //// test
            //foreach (var sw in objectIdToShapeOnWorld)
            //{
            //    if (CollisionChecker.IsCollide(target, sw.Value))
            //    {
            //        result.Add(sw.Key);
            //    }
            //}

            return result;
        }

        public static void FlushAllObject()
        {
            throw new NotImplementedException();
        }

        public static void CreateObject(int objectId, Area area)
        {
            setObjectPosition(objectId, area);
            objectIdToArea[objectId] = area;
        }

        public static void DeleteObject(int objectId)
        {
            foreach (var position in objectIdToPositions[objectId])
            {
                positionToObjectIds[position.Item1, position.Item2].Remove(objectId);
            }
            objectIdToPositions[objectId].Clear();
            objectIdToArea.Remove(objectId);
        }

        public static void MoveObject(int objectId, Center newCenter)
        {
            var shape = objectIdToArea[objectId].Shape;
            DeleteObject(objectId);
            CreateObject(objectId, new Area(shape, newCenter));
        }

        public static bool MoveObjectIfCan(int objectId, Center newCenter)
        {
            var desiredArea = new Area(objectIdToArea[objectId].Shape, newCenter);
            var overlappingObjects = GetCollidingObjectIds(desiredArea);
            if (overlappingObjects.Count == 0 || overlappingObjects.Count == 1 && overlappingObjects.Contains(objectId))
            {
                MoveObject(objectId, newCenter);
                return true;
            }
            return false;
        }

        private static void setObjectPosition(int objectId, Area area)
        {
            objectIdToPositions[objectId] = new();

            List<Tuple<int, int>> positions = getPositions(area);
            foreach (var position in positions)
            {
                positionToObjectIds[position.Item1, position.Item2].Add(objectId);
                objectIdToPositions[objectId].Add(position);
            }
        }
        private static List<Tuple<int, int>> getPositions(Area area)
        {
            return getPositions(area.Shape, area.Center);
        }

        private static List<Tuple<int, int>> getPositions(IShape shape, Center center)
        {
            // 원도 사각형으로 계산 했음.
            double width = shape.Width;
            double height = shape.Height;

            int left = normalize(center.X - width / 2);
            int right = normalize(center.X + width / 2);
            int top = normalize(center.Y + height / 2);
            int bottom = normalize(center.Y - height / 2);

            var result = new List<Tuple<int, int>>();

            for (int i = left; i <= right; i++)
            {
                for (int j = bottom; j <= top; j++) 
                { 
                    result.Add(new Tuple<int, int>(i, j));
                }
            }

            return result;
        }

        private static int normalize(double x)
        {
            if (x < 0)
                return 0;
            if (x > 999)
                return 999;
            return (int)x;
        }

        private static void initialize()
        {
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    positionToObjectIds[i, j] = new();
                }
            }
        }
    }
}
