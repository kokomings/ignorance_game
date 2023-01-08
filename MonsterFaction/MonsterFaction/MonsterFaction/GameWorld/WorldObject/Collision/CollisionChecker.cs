using MonsterFaction.GameWorld.WorldObject.Shape;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using System;

namespace MonsterFaction.GameWorld.WorldObject.Collision
{
    public static class CollisionChecker
    {
        public static Boolean IsCollide(ShapeOnWorld target1, ShapeOnWorld target2)
        {
            return isCollide(target1.Shape, target1.Center, target2.Shape, target2.Center);
        }

        private static Boolean isCollide(IShape shape1, Center center1, IShape shape2, Center center2)
        {
            if (shape1 is CircleShape && shape2 is CircleShape)
            {
                return isCollide((CircleShape)shape1, center1, (CircleShape)shape2, center2);
            }
            else if (shape1 is CircleShape && shape2 is SquareShape)
            {
                return isCollide((CircleShape)shape1, center1, (SquareShape)shape2, center2);
            }
            else if (shape1 is SquareShape && shape2 is CircleShape)
            {
                return isCollide((CircleShape)shape2, center2, (SquareShape)shape1, center1);
            }
            else if (shape1 is SquareShape && shape2 is SquareShape)
            {
                return isCollide((SquareShape)shape1, center1, (SquareShape)shape2, center2);
            }
            throw new NotImplementedException("Not implemeted collision situation.");
        }

        private static Boolean isCollide(CircleShape circleShape1, Center center1, CircleShape circleShape2, Center center2)
        {
            double radiusSum = circleShape1.Radius + circleShape2.Radius;
            double widthGap = center1.X - center2.X;
            double heightGap = center1.Y - center2.Y;

            return widthGap * widthGap + heightGap * heightGap < radiusSum * radiusSum;
        }

        private static Boolean isCollide(SquareShape squareShape1, Center center1, SquareShape squareShape2, Center center2)
        {
            double widthSum = squareShape1.Width + squareShape2.Width;
            double heightSum = squareShape1.Height + squareShape2.Height;

            double centerWidthGap = Math.Abs(center1.X - center2.X);
            double centerHeightGap = Math.Abs(center1.Y - center2.Y);

            return widthSum / 2 >= centerWidthGap && heightSum / 2 >= centerHeightGap;
        }
        private static Boolean isCollide(CircleShape circleShape, Center circleCenter, SquareShape squareShape, Center squareCenter)
        {
            var wideExtendedSquare = new SquareShape(squareShape.Width + circleShape.Radius * 2, squareShape.Height);
            var verticalExtendedSquare = new SquareShape(squareShape.Width, squareShape.Height + circleShape.Radius * 2);
            var topLeft = squareCenter + new Center(- squareShape.Width / 2, squareShape.Height / 2);
            var topRight = squareCenter + new Center(squareShape.Width / 2, squareShape.Height / 2);
            var bottomLeft = squareCenter + new Center(- squareShape.Width / 2, - squareShape.Height / 2);
            var bottomRight = squareCenter + new Center(squareShape.Width / 2, - squareShape.Height / 2);
            
            var testCenter = squareCenter + new Center(- circleShape.Radius, circleShape.Height);

            return isCollide(wideExtendedSquare, squareCenter, circleCenter) ||
                isCollide(verticalExtendedSquare, squareCenter, circleCenter) ||
                isCollide(circleShape, circleCenter, topLeft) ||
                isCollide(circleShape, circleCenter, topRight) ||
                isCollide(circleShape, circleCenter, bottomLeft) ||
                isCollide(circleShape, circleCenter, bottomRight);
        }

        private static Boolean isCollide(CircleShape circleShape, Center circleCenter, Center dot)
        {
            double radius = circleShape.Radius;
            double widthGap = circleCenter.X - dot.X;
            double heightGap = circleCenter.Y - dot.Y;

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
