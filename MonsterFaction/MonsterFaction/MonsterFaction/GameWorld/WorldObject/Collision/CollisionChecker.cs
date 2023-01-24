using MonsterFaction.GameWorld.WorldObject.Shape;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using System;

namespace MonsterFaction.GameWorld.WorldObject.Collision
{
    public static class CollisionChecker
    {
        public static Boolean IsCollide(Area area1, Area area2)
        {
            if (area1.isCircle && area2.isCircle)
            {
                return isCollide(area1.toCircle(), area2.toCircle());
            }
            else if (area1.isCircle && area2.isSquare)
            {
                return isCollide(area1.toCircle(), area2.toSquare());
            }
            else if (area1.isSquare && area2.isCircle)
            {
                return isCollide(area2.toCircle(), area1.toSquare());
            }
            else if (area1.isSquare && area2.isSquare)
            {
                return isCollide(area1.toSquare(), area2.toSquare());
            }
            throw new NotImplementedException("Not implemeted collision situation.");
        }

        private static Boolean isCollide(CircleArea circleArea1, CircleArea circleArea2)
        {
            double radiusSum = circleArea1.Radius + circleArea2.Radius;
            double widthGap = circleArea1.X - circleArea2.X;
            double heightGap = circleArea1.Y - circleArea2.Y;

            return widthGap * widthGap + heightGap * heightGap < radiusSum * radiusSum;
        }

        private static Boolean isCollide(SquareArea squareArea1, SquareArea squareArea2)
        {
            double widthSum = squareArea1.Width + squareArea2.Width;
            double heightSum = squareArea1.Height + squareArea2.Height;

            double centerWidthGap = Math.Abs(squareArea1.X - squareArea2.X);
            double centerHeightGap = Math.Abs(squareArea1.Y - squareArea2.Y);

            return widthSum / 2 >= centerWidthGap && heightSum / 2 >= centerHeightGap;
        }
        private static Boolean isCollide(CircleArea circleArea, SquareArea squareArea)
        {
            var wideExtendedSquare = new SquareShape(squareArea.Width + circleArea.Radius * 2, squareArea.Height);
            var verticalExtendedSquare = new SquareShape(squareArea.Width, squareArea.Height + circleArea.Radius * 2);
            var topLeft = squareArea.Center + new Center(-squareArea.Width / 2, squareArea.Height / 2);
            var topRight = squareArea.Center + new Center(squareArea.Width / 2, squareArea.Height / 2);
            var bottomLeft = squareArea.Center + new Center(-squareArea.Width / 2, -squareArea.Height / 2);
            var bottomRight = squareArea.Center + new Center(squareArea.Width / 2, -squareArea.Height / 2);

            return isCollide(wideExtendedSquare, squareArea.Center, circleArea.Center) ||
                isCollide(verticalExtendedSquare, squareArea.Center, circleArea.Center) ||
                isCollide(circleArea, topLeft) ||
                isCollide(circleArea, topRight) ||
                isCollide(circleArea, bottomLeft) ||
                isCollide(circleArea, bottomRight);
        }

        private static Boolean isCollide(CircleArea circleArea, Center dot)
        {
            double radius = circleArea.Radius;
            double widthGap = circleArea.X - dot.X;
            double heightGap = circleArea.Y - dot.Y;

            return widthGap * widthGap + heightGap * heightGap <= radius * radius;
        }

        private static Boolean isCollide(SquareShape squareShape, Center shapeCenter, Center dot)
        {
            double widthGap = Math.Abs(shapeCenter.X - dot.X);
            double heightGap = Math.Abs(shapeCenter.Y - dot.Y);

            return squareShape.Width / 2 >= widthGap && squareShape.Height / 2 >= heightGap;
        }
    }
}
