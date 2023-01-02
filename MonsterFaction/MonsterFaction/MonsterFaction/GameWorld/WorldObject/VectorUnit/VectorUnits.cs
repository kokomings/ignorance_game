using MonsterFaction.Characters;
using System.Numerics;

namespace MonsterFaction.GameWorld.WorldObject.VectorUnit
{
    public class Center
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Center(double x, double y) { X = x; Y = y; }
        public static Center operator +(Center left, Center right) => new Center(left.X + right.X, left.Y + right.Y);
    }

    public class Direction
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Direction(double x, double y) { X = x; Y = y; }
        public static Direction operator +(Direction left, Direction right) => new Direction(left.X + right.X, left.Y + right.Y);

    }

    public class Velocity
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Velocity(double x, double y) { X = x; Y = y; }
    }

    public class Size
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Size(double width, double height) { Width = width; Height = height; }
    }
}
