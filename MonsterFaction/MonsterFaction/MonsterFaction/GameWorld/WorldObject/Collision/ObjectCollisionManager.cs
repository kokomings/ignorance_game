using MonsterFaction.GameWorld.WorldObject.Shape;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using MonsterFaction.SystemEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterFaction.GameWorld.WorldObject.Collision
{
    // 단순 격자 형태로 구현됨. 이후에 QuadTree 등 알고리즘 개선하자.
    public class ObjectCollisionManager : IUpdatable
    {
        private readonly EventSubscriber<CreateEvent> createEvents = new(EventType.OBJECT_CREATE);
        private readonly EventSubscriber<MoveEvent> moveEvents = new(EventType.OBJECT_MOVE);
        private readonly EventSubscriber<DeleteEvent> deleteEvents = new(EventType.OBJECT_DELETE);

        private HashSet<int>[,] positionToObjectIds = new HashSet<int>[1000, 1000];
        private Dictionary<int, List<Tuple<int, int>>> objectIdToPositions = new();
        private Dictionary<int, ShapeOnWorld> objectIdToShapeOnWorld = new();

        // Tuple int int 대신 좌표로
        public HashSet<int> GetCollidingObjectIds(ShapeOnWorld target)
        {
            HashSet<int> result = new();
            foreach (var position in getPositions(target))
            {
                foreach (var objectId in positionToObjectIds[position.Item1, position.Item2])
                {
                    if (CollisionChecker.Judge(target, objectIdToShapeOnWorld[objectId]))
                    {
                        result.Add(objectId);
                    }
                }
            }

            return result;
        }

        public void FlushAllObject()
        {
            throw new NotImplementedException();
        }

        public void Update()
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

        private void setObjectPosition(int objectId, IShape shape, Center center)
        {
            objectIdToPositions[objectId] = new();

            List<Tuple<int, int>> positions = getPositions(shape, center);
            foreach (var position in positions)
            {
                positionToObjectIds[position.Item1, position.Item2].Add(objectId);
                objectIdToPositions[objectId].Add(position);
            }
        }
        private List<Tuple<int, int>> getPositions(ShapeOnWorld shapeOnWorld)
        {
            return getPositions(shapeOnWorld.Shape, shapeOnWorld.Center);
        }

        private List<Tuple<int, int>> getPositions(IShape shape, Center center)
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
                for (int j = top; j <= bottom; j++) 
                { 
                    result.Add(new Tuple<int, int>(i, j));
                }
            }

            return result;
        }

        private int normalize(double x)
        {
            if (x < 0)
                return 0;
            if (x > 999)
                return 999;
            return (int)x;
        }

        private void moveObjectPosition(int objectId)
        {
            foreach (var position in objectIdToPositions[objectId])
            {
                positionToObjectIds[position.Item1, position.Item2].Remove(objectId);
            }
            objectIdToPositions[objectId].Clear();
        }

        private void deleteObject(int objectId)
        {
            foreach (var position in objectIdToPositions[objectId])
            {
                positionToObjectIds[position.Item1, position.Item2].Remove(objectId);
            }
            objectIdToPositions[objectId].Clear();
            objectIdToShapeOnWorld.Remove(objectId);
        }
    }
}
