using MonsterFaction.GameWorld.WorldObject.Shape;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using MonsterFaction.SystemEvents;
using System;
using System.Collections.Generic;

namespace MonsterFaction.GameWorld.WorldObject.Collision
{
    // 단순 격자 형태로 구현됨. 이후에 QuadTree 등 알고리즘 개선하자.
    public static class ObjectCollisionManager
    {
        private readonly static EventSubscriber<CreateEvent> createEvents = new(EventType.OBJECT_CREATE);
        private readonly static EventSubscriber<MoveEvent> moveEvents = new(EventType.OBJECT_MOVE);
        private readonly static EventSubscriber<DeleteEvent> deleteEvents = new(EventType.OBJECT_DELETE);

        private static HashSet<int>[,] positionToObjectIds = new HashSet<int>[1000, 1000];
        private static Dictionary<int, List<Tuple<int, int>>> objectIdToPositions = new();
        private static Dictionary<int, ShapeOnWorld> objectIdToShapeOnWorld = new();

        static ObjectCollisionManager() { initialize(); }

        public static HashSet<int> GetCollidingObjectIds(ShapeOnWorld target)
        {
            HashSet<int> result = new();
            foreach (var position in getPositions(target))
            {
                foreach (var objectId in positionToObjectIds[position.Item1, position.Item2])
                {
                    if (CollisionChecker.IsCollide(target, objectIdToShapeOnWorld[objectId]))
                    {
                        result.Add(objectId);
                    }
                }
            }

            return result;
        }

        public static void FlushAllObject()
        {
            throw new NotImplementedException();
        }

        public static void Update()
        {
            foreach (var createEvent in createEvents.FetchAll())
            {
                setObjectPosition(createEvent.ObjectId, createEvent.Shape, createEvent.Center);
                objectIdToShapeOnWorld[createEvent.ObjectId] = new ShapeOnWorld(createEvent.Shape, createEvent.Center);
            }
            foreach (var moveEvent in moveEvents.FetchAll())
            {
                moveObjectPosition(moveEvent.ObjectId);
            }
            foreach (var deleteEvent in deleteEvents.FetchAll())
            {
                deleteObject(deleteEvent.ObjectId);
            }
        }

        private static void setObjectPosition(int objectId, IShape shape, Center center)
        {
            objectIdToPositions[objectId] = new();

            List<Tuple<int, int>> positions = getPositions(shape, center);
            foreach (var position in positions)
            {
                positionToObjectIds[position.Item1, position.Item2].Add(objectId);
                objectIdToPositions[objectId].Add(position);
            }
        }
        private static List<Tuple<int, int>> getPositions(ShapeOnWorld shapeOnWorld)
        {
            return getPositions(shapeOnWorld.Shape, shapeOnWorld.Center);
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

        private static void moveObjectPosition(int objectId)
        {
            foreach (var position in objectIdToPositions[objectId])
            {
                positionToObjectIds[position.Item1, position.Item2].Remove(objectId);
            }
            objectIdToPositions[objectId].Clear();
        }

        private static void deleteObject(int objectId)
        {
            foreach (var position in objectIdToPositions[objectId])
            {
                positionToObjectIds[position.Item1, position.Item2].Remove(objectId);
            }
            objectIdToPositions[objectId].Clear();
            objectIdToShapeOnWorld.Remove(objectId);
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
