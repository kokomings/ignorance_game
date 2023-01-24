using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MonsterFaction.GameWorld.WorldObject.Shape
{
    public struct Area
    {
        public IShape Shape { get; }
        public Center Center { get; }
        public Area(IShape shape, Center center) { Shape = shape; Center = center; }

        public bool isCircle { get => Shape is CircleShape; }
        public bool isSquare { get => Shape is SquareShape;  }

        public CircleArea toCircle()
        {
            return new CircleArea((CircleShape)Shape, Center);
        }
        public SquareArea toSquare()
        {
            return new SquareArea((SquareShape)Shape, Center);
        }
    }

    public struct CircleArea
    {
        public CircleShape Circle { get; }
        public Center Center { get; }
        public double Radius => Circle.Radius;
        public double X => Center.X;
        public double Y => Center.Y;
        public CircleArea(CircleShape circle, Center center) { Circle = circle; Center = center; }
    }
    public struct SquareArea
    {
        public SquareShape Square { get; }
        public Center Center { get; }
        public double Width => Square.Width;
        public double Height => Square.Height;
        public double X => Center.X;
        public double Y => Center.Y;
        public SquareArea(SquareShape square, Center center) { Square = square; Center = center; }
    }
}
